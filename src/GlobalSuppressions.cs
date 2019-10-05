// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "Type doesn't have a public constructor and thus is only instantiated internally as singleton once.", Scope = "type", Target = "~T:GdprInfo.Platforms.Ios.DeviceCountryIdentifier")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "It's up to the implementor to translate strings returned by this assembly to there users.")]
