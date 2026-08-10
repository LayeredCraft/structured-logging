# Diagnostics

Two completely different failure classes — don't confuse them:

- **Compile-time**: `CMP0001`-`CMP0012`, emitted by `Compono.Generators`
  (a Roslyn analyzer). Fails `dotnet build`. Look up the code below.
- **Runtime**: `CompositionException`, thrown from `composer.Create<T>()`
  or a `[Compose]` theory row when the code compiled fine but the
  pipeline couldn't satisfy a request — most commonly a missing provider
  for an interface/abstract/delegate type. Read the tree path and seed
  (below), don't guess from the root type alone.

Always check *which* class you're looking at first: a red squiggle /
build failure is compile-time (this doc's table); a test that compiled
and then threw is runtime (the tree-path section).

## Compile-time: CMP0001-CMP0012

| Code | Meaning | Fix |
|---|---|---|
| CMP0001 | Ambiguous construction — the type has more than one accessible constructor | Reduce to one accessible constructor, or compose an interface/wrapper instead (interfaces are always provider-resolved, never routed through constructor selection) — no registration rescues this |
| CMP0002 | No accessible constructor at all (only `private`, or a `static` type) | Give it an accessible constructor, or compose something else |
| CMP0003 | (Historical/rare) — interfaces, abstract classes, and delegates are always classified provider-resolved today, both at root and member position, so this shouldn't surface for those. A missing provider for one is a *runtime* `CompositionException`, not this diagnostic. | Install/configure a provider: `UseNSubstitute()`, `Register<T>()`, or `.For<T>()` |
| CMP0004 | Unsupported constructor parameter kind — `ref`/`out`/`ref readonly`, ref struct, pointer, or function-pointer parameter (`in` parameters ARE supported) | Remove/change the parameter kind, or `Register<T>()` by hand |
| CMP0005 | Type argument isn't closed — an open generic type parameter reached a `Create<T>()` call | Supply a concrete closed type; open-generic registration isn't supported — there's no configuration that makes an open type composable |
| CMP0006 | Type argument shape unsupported — not a named type and not one of the supported collection roots (e.g. `int[,]`, pointer types) | Use a named type, or one of the 5 supported collection roots (array, `List<T>`, `IReadOnlyList<T>`, `HashSet<T>`, `Dictionary<TKey,TValue>`) |
| CMP0007 | Unsupported required-member kind — ref struct/pointer member type, or not assignable from generated code (no accessible init/set, or a readonly/inaccessible field) | Change the type/accessor, set it via a `Register<T>()` factory, or add a constructor annotated `[SetsRequiredMembers]` |
| CMP0008 | Assembly-level `[Composable]` used with no type argument | `[assembly: Composable(typeof(SomeType))]` — always pass the type |
| CMP0009 | Type argument is a `ref struct` (e.g. `Span<T>`) — can never be a generic type argument at all | No workaround; compose the wrapping non-ref-struct type instead |
| CMP0010 | The same type was discovered multiple times with conflicting nullability metadata across call sites | Make every request for the type use consistent nullability |
| CMP0011 | The same closed collection type was discovered with conflicting element/key nullability | Make every member/parameter of that collection type consistent |
| CMP0012 | A collection's element/key type isn't accessible (private/protected) from the generated collection-plan type | Use an accessible element/key type |

This is the complete MVP diagnostic set — CMP0001 through CMP0012, no
more, no fewer. If something references a `CMP00xx` code outside this
range, it isn't real; don't invent one.

## Runtime: `CompositionException` tree path and seed

```text
Unable to compose CreateOrderHandler.

CreateOrderHandler
└── IOrderProcessor processor
    └── OrderValidator validator
        └── IRuleProvider rules

No registration, semantic provider, test-double provider, built-in
provider, or generated plan could satisfy IRuleProvider.

Seed: 8451203967726193045
```

Read top-down — it always names the exact failing **nested** dependency
(`IRuleProvider` here), not just the root type (`CreateOrderHandler`).
Don't start debugging from the root; find the leaf the tree points at.

`CompositionDiagnostic` exposes `RootType`, `FailedType`, `Path`,
`Trace`, `Seed`, `Message` programmatically if you need to inspect it in
code rather than read the printed form. It's nullable on the exception —
some failures (e.g. `HashSet<T>`/`Dictionary` unique-value exhaustion via
`UniqueValueResolver`) have no structured diagnostic, only the exception
message with `Seed:` appended.

## Troubleshooting workflow

1. Is this a build failure or a test-run failure? Build → compile-time
   table above. Test-run → tree path below.
2. For a runtime failure: read the tree path to the exact failing type,
   not the root.
3. Read the message under the tree — it names which pipeline stages were
   tried and missed (registration, semantic provider, test-double
   provider, built-in provider, generated plan).
4. Fix by adding what's missing at the stage that should have supplied
   it — a `Register<T>()`, a `UseNSubstitute()`/`UseBogus()` if the
   package is referenced, or a `.For<T>()` rule. Don't work around the
   failure with reflection or a different fixture library (see the
   Guardrails in `SKILL.md`).
5. To reproduce locally: for a `Compono.XunitV3` row failure, the printed
   `Seed:` value plugs directly into `[Compose(Seed = ...)]` — that path
   is always `int`-range by construction. For a plain programmatic
   `composer.Create<T>()` failure, `CompositionDiagnostic.Seed` is a
   `ulong` (an unseeded composer draws a full random 64-bit value) and
   both `builder.WithSeed(int seed)` and `[Compose(Seed = ...)]` are
   `int`-typed — **if the printed seed exceeds `int.MaxValue`, there is
   currently no public API to paste it back in and get the exact same
   failure again.** Don't claim otherwise. What actually works: switch to
   an explicit `WithSeed(someChosenIntValue)` *before* re-running, so the
   next occurrence of the failure (if it reproduces at all with a
   different seed) is pinned and reproducible going forward — this finds
   *a* reproduction of the same underlying bug, not a replay of that
   exact original run. If the failure doesn't reproduce under a new seed,
   treat that as a data point about the failure's cause (e.g. it may
   depend on which specific random values were drawn) rather than
   assuming the investigation is complete. Remove any pinned seed once
   the fix is verified — don't leave it pinned as a permanent habit.
6. A `CompositionException` from Compono's own generated plans and
   built-in providers is deterministic, not flaky — don't wrap it in a
   retry, investigate. But check what's actually in the failing path
   first: a consumer-supplied `Register<T>()` factory, custom provider,
   or a configured `IServiceProvider` fallback can still do
   non-deterministic things (clock/random reads, I/O, a transient
   throw). If the failure traces through one of those, the "just
   reproduce it with the seed" assumption doesn't hold — inspect that
   code path directly instead.
