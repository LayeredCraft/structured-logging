---
name: compono
description: >-
  **WORKFLOW SKILL** - Compono test-composition guidance for .NET/C# unit
  tests. Compono is a source-generated AutoFixture alternative
  (`composer.Create<T>()`/`CreateMany<T>()`, `[Composable]`,
  registrations, profiles, `[Shared]`, plus optional
  `Compono.XunitV3`/`Compono.NSubstitute`/`Compono.Bogus` packages).
  USE FOR: writing/modifying/reviewing Compono tests, diagnosing
  `CMP0001`-`CMP0012` or `CompositionException` failures, deciding on
  `[Composable]`/`Register<T>()`/`.For<T>()`/`[Shared]`, adding Compono
  when asked, migrating AutoFixture tests (`[Frozen]`, `AutoData`), any
  Compono/`Composer`/`[Compose]` question.
  DO NOT USE FOR: ordinary xUnit/NUnit/MSTest, NSubstitute, or Bogus work
  with no Compono package referenced; generic reflection/DI questions;
  production object construction.
  SCOPES TO: only load `xunit-v3.md`/`nsubstitute.md`/`bogus.md`
  references when that package is referenced or requested.
license: MIT
metadata:
  author: LayeredCraft
  version: "0.1.0"
---

# Compono

Compono is a source-generated test-composition framework for modern
.NET — not a reflection-based fixture library. It looks similar to
AutoFixture on the surface (`Create<T>()`, `CreateMany<T>()`) but makes
different design choices throughout, and an agent relying on pretrained
AutoFixture habits will write code that doesn't compile, doesn't behave
as expected, or actively fights the framework. This skill exists to close
that gap — read the **Guardrails** section below before writing any
Compono code, then follow **Default workflow**.

## Detection

Check before assuming Compono is in play or absent — a project may use
some packages and not others.

| Signal | Where to look | Confidence | Meaning |
|---|---|---|---|
| `<PackageReference Include="Compono"` | any `.csproj` in the project | Definitive | Core Compono in use |
| `<PackageReference Include="Compono.XunitV3"` | `.csproj` | Definitive | `[Compose]`/`[Compose<TProfile>]`/`[Compose<TProfile, TConfig>]`/`[Shared]` available — load `references/xunit-v3.md` |
| `<PackageReference Include="Compono.NSubstitute"` | `.csproj` | Definitive | `UseNSubstitute()` available — load `references/nsubstitute.md` |
| `<PackageReference Include="Compono.Bogus"` | `.csproj` | Definitive | `UseBogus()`/`UseBogus<T>()` available — load `references/bogus.md` |
| `Composer.Create(`, `.Create<`, `.CreateMany<`, `CompositionBuilder` | `*.cs` | High | Core Compono API in active use |
| `[Compose]`, `[Compose<...>]`, `[Shared]` | `*.cs` | High | `Compono.XunitV3` attributes in active use |
| `ICompositionProfile` implementations | `*.cs` | Medium | Profile-based configuration convention already established — follow it rather than inventing a new one |
| `[Composable]` / `[assembly: Composable(` | `*.cs` | Medium | Discovery-gap workaround already in use somewhere in this codebase |
| No `Compono*` package reference anywhere | `.csproj` | — | Not a Compono project. Don't suggest Compono unless the user explicitly asks to adopt it. |

Don't hardcode an assumed version scheme or `--prerelease` requirement —
it changes independently of this skill. Check
`docs/getting-started/installation.md` (or the actual NuGet listing) for
the current install command instead of guessing from a remembered
version pattern.

**Adopting Compono in a project that doesn't have it yet**: only do this
when the user explicitly asks. Add the `Compono` package (plus
`Compono.XunitV3` if the project uses xUnit v3 theories, `Compono.NSubstitute`/
`Compono.Bogus` only if the user wants those). Don't retrofit existing
passing tests to use Compono unprompted — that's a scope decision for the
user to make test-by-test, not something to do as a drive-by.

## Default workflow

1. **Detect** — run the table above. Know which packages are actually
   installed before recommending any API from them.
2. **Inspect** the type under test and its collaborators — concrete class
   with one accessible constructor? Interface/abstract/delegate? Does it
   already have `[Composable]`? Is there an existing `ICompositionProfile`
   this codebase already uses?
3. **Decide** whether Compono is appropriate at all — see **When not to
   use Compono** below — then which mechanism fits:
   - An ordinary value, composed from scratch each time → let Compono
     generate it, no configuration needed.
   - A specific fixed value needed for an assertion → inline value
     (`[Compose(42, "widget")]`) or a member rule
     (`.For<T>().Member(x => x.Y).Use(...)`), not a post-hoc mutation
     after `Create<T>()`.
   - The *same instance* needs to be shared across the composed graph and
     the test body → `[Shared]` (in `Compono.XunitV3`) — see
     `references/registrations-profiles-and-scopes.md`. Don't reach for
     `[Shared]` just to "make things consistent" or as a perceived
     performance win; ordinary composition is already cheap.
   - Interface/abstract-class/delegate needs a real test double →
     `Compono.NSubstitute`'s `UseNSubstitute()`, not a hand-rolled stub,
     if that package is referenced.
   - A `string` member needs a realistic value (email, name, address) →
     `Compono.Bogus`'s member-name conventions or `UseBogus(...)`, if
     that package is referenced. Don't reach for Bogus everywhere — plain
     generated values are fine when realism doesn't matter to the test.
   - Cross-test/cross-project reusable setup → an `ICompositionProfile`,
     not a copy-pasted builder lambda in every test.
   - A value only known at a *specific test's call site* that must
     influence configuration logic running *inside* a profile (not a
     top-level test parameter) → `Compono.XunitV3`'s
     `[Compose<TProfile, TConfig>]`, if that package is referenced — see
     `references/xunit-v3.md`. Prefer an enum/`typeof(...)` over a bare
     string for the argument. Don't confuse this with a
     `CompositionProviderRequest.Name`-based custom provider
     (`references/registrations-profiles-and-scopes.md`), which solves a
     different (name-based, not call-site) selection problem.
4. **Check `[Composable]` necessity** — see
   `references/composition-model.md`'s Discovery section. Most types need
   nothing; only add it when the type has no local `Create<T>()`/
   `CreateMany<T>()` call site the generator can walk from (e.g. it's only
   ever reached indirectly, or it lives in a referenced assembly you can't
   annotate directly). Never add `[Composable]` speculatively across a
   type hierarchy "just in case."
5. **Act** — write the composition call, registration, or profile change.
   Prefer existing project conventions (an established profile, an
   existing member-rule pattern) over introducing a new mechanism for the
   same problem.
6. **Compile and run.** A compile-time failure is a `CMP0001`-`CMP0012`
   diagnostic from `Compono.Generators` — look it up in
   `references/diagnostics.md` before guessing a fix. A test-time failure
   is a `CompositionException` — read its tree-shaped path and `Seed:`
   line (also see `references/diagnostics.md`) to find exactly which
   nested dependency failed, rather than guessing from the root type.

## Guardrails

These are hard rules, not preferences. Compono's whole design point is
*not* being a reflection-based fixture library — violating these
undermines the reason Compono exists in this project.

- **Never introduce runtime reflection as a workaround.** No
  `Activator.CreateInstance`, no constructor/property reflection, no
  "just reflect over the type" fallback when composition fails. Compono
  has no reflection fallback today — a composition failure means the
  generator needs a supported shape, or a provider/registration needs to
  be added. Reflection is excluded from the default architecture by
  design (ADR-0001); it is not a valid escape hatch even for "just this
  one test."
- **Never silently substitute AutoFixture** (or another fixture library)
  because it's more familiar or because a Compono composition is
  failing. If Compono genuinely can't do something a test needs, say so
  explicitly and let the user decide — don't quietly reach for a
  different library.
- **Never re-register or re-customize the same type to "fix" a build
  error.** A second `Register<T>()` for the same `T` (directly, via a
  profile, or across two profiles) is a build-time conflict, not
  last-write-wins like AutoFixture customizations. If a registration
  conflicts, that's a signal to consolidate, not to add another one.
- **Never mark broad swathes of a production model `[Composable]`
  "to be safe."** It's a narrow discovery-gap opt-in, not a general
  "make this type composable" marker — see Detection above and
  `references/composition-model.md`.
- **Never treat a `CompositionException` as flaky-test noise to retry —
  but check what's actually in the failing path first.** Compono's own
  generated plans and built-in providers are deterministic and
  reproducible from the seed. A consumer-supplied `Register<T>()`
  factory, a custom provider, or a native `IServiceProvider` fallback can
  still do non-deterministic things (clock/random reads, I/O, a
  transient throw) — if the failing path runs through one of those,
  inspect it before assuming the seed alone explains or reproduces the
  failure.
- **Never hardcode "seed X produces value Y" as a permanent assertion.**
  Determinism holds for a given Compono version, not across versions.
  Only assert on values you explicitly pinned (inline values, member
  rules, `[Shared]` reference equality).
- **Never bypass a `CMP0001`-`CMP0012` compile error by working around
  the generator** (e.g. hand-writing a plan, suppressing the diagnostic,
  or switching the type to be constructed manually elsewhere just to
  dodge it). Fix the underlying shape, or compose an interface/wrapper
  instead when the diagnostic's fix column says so — see
  `references/diagnostics.md`.
- **Never assume a runtime reflection compatibility mode exists.** It's
  explicitly undecided/future work, not shipped API — don't tell a user
  they can "opt into reflection fallback."

## When not to use Compono

Compono is not always the right tool. Prefer explicit, hand-built test
data when:

- The test's whole point *is* a specific, meaningful value (e.g. testing
  a validation boundary at exactly `Age = 18`) — write it literally,
  don't compose it and then override it.
- The setup is one or two trivial values — a composed call adds
  indirection without saving anything real.
- The type has an ambiguous-constructor BCL shape (e.g. `HttpClient`,
  which has multiple accessible constructors) — these hit `CMP0001` with
  no registration-based escape hatch. Wrap in an app-owned
  interface/factory and compose that instead, or construct it directly
  by hand in that one spot.
- A collaborator's realistic *content* doesn't matter to the assertion —
  don't reach for `Compono.Bogus` just because it's installed.

## References

Load only what the Detection table says is relevant to the current task.

| File | Read when... |
|---|---|
| `references/composition-model.md` | Composing a type, deciding on `[Composable]`, understanding generated-plan discovery, or anything about determinism/seeding |
| `references/registrations-profiles-and-scopes.md` | Using `Register<T>()`, `.For<T>().Use()`/`.Member()`, `ICompositionProfile`, `[Shared]`, or debugging a recursion/registration-conflict error |
| `references/diagnostics.md` | A `CMP0001`-`CMP0012` build error, or a runtime `CompositionException` needs diagnosing |
| `references/xunit-v3.md` | `Compono.XunitV3` is referenced — `[Compose]`/`[Compose<TProfile>]`/`[Compose<TProfile, TConfig>]`/`[Shared]` theory work |
| `references/nsubstitute.md` | `Compono.NSubstitute` is referenced — `UseNSubstitute()` work |
| `references/bogus.md` | `Compono.Bogus` is referenced — `UseBogus()`/`UseBogus<T>()` work |
| `references/patterns-and-antipatterns.md` | Reviewing existing Compono usage for correctness, migrating from AutoFixture, or unsure whether an approach is idiomatic |
