# Cyotek Historical Date Library

![A screenshot of the demonstration application][demo]

Some months ago I was trying to create a timeline of British
pre-history and needed to be able to store dates. The .NET
`DateTime` or `DateOnly` structures are completely unsuitable
for these as their ranges are far too small, nor do they allow
for partial dates.

I did spent a little time poking around to see if there was some
existing code, but there doesn't seem to be a lot of detail out
there. I found a malformed [blog post][blogres] which was
missing the bulk of the source code, and
[HistoricalDate][sourceres] class which was more fully fleshed,
but still not fully suitable. So as typical, I went my own way
and wrote my own.

## Getting the library

The easiest way of obtaining the library is via [NuGet][nuget].

> `Install-Package Cyotek.HistoricalDate`

If you don't use NuGet, pre-compiled binaries can be obtained
from the [GitHub Releases page][rel].

Of course, you can always grab [the source][source] and build it
yourself!

## About this library

The library currently offers two read-only structs, `JulianDate`
and `HistoricalTimeSpan`.

### JulianDate

The `JulianDate` structure can represent a partial date between
2147483647 BP and 2147483647 AD. By partial, I mean that a year
and the era are always required, but the month and/or day is
optional. After all, a date such as the Battle of Hastings may
be documented but the start of the Mesolithic is a little more
nebulous!

### HistoricalTimeSpan

The `HistoricalTimeSpan` is a cut down version of the more
familiar `TimeSpan` and is currently mainly used by the
`Add` and `Subtract` methods of a `JulianDate` instance.

## Using the library

### Constructing instances

There are several constructors for specifying fully qualified or
partial dates.

```csharp
JulianDate(int year); // assumes AD
JulianDate(int year, JulianEra era);
JulianDate(int year, int month);  // assumes AD
JulianDate(int year, int month, JulianEra era);
JulianDate(int year, int month, int day);  // assumes AD
JulianDate(int year, int month, int day, JulianEra era);

// fully known
var fk = new JulianDate(2021, 9, 5); // September 5th, 2021 AD

// partial
var pd = new JulianDate(13000, JulianEra.Bc); // 130,000 BC
```

You can also use an explicit operator to convert the date
portion of a `DateTime` instance into a `JulianDate`.

```csharp
var now = (JulianDate)DateTime.UtcNow;
```

### Parsing strings

You can also try and parse a string into a `JulianDate`
instance.

> Note: String parsing (and formatting) is somewhat basic (and
> potentially confusing) and will be improved in future updates
> to the library. Except with regards to month names, parsing is
> not culture-aware.

```csharp
static JulianDate Parse(string s);
static bool TryParse(string s, out JulianDate result)

// fully known
var fk = JulianDate.Parse("2021-09-17"); // September 17, 2021 AD

// partial
var pd = JulianDate.Parse("40000 BP"); // 40,000 BC
```

### Partial Dates

`JulianDate` supports partial dates, where only part of a date
is known. The year and era are always required, but month and
day are optional.

If day is specified, then the month is also available. The
`HasDay` and `HasMonth` properties allow you to query what
partial components are set, or if you just want to know if a
date is fully known or partial, the `IsFullyKnown` and
`IsPartial` properties can be used.

Accessing the `Month` or `Day` properties will return `0` if the
component has not been set.

```csharp
var pd = JulianDate.Parse("40000 BP");

pd.HasMonth; // false
pd.HasDay; // false

var pd = JulianDate.Parse("09 2021");

pd.HasMonth; // true
pd.HasDay; // false
```

## Leap Years

The static `IsLeapYear` method will return if a given year is a
leap year. This is calculated according to Scaliger.

```csharp
JulianDate.IsLeapYear(42, JulianEra.Bc); // true
JulianDate.IsLeapYear(2021, JulianEra.Ad); // false
```

## Things to improve

Currently, I'm unhappy with the string parsing as the list of
accepted formats is too vague, and I haven't yet built in
culture support.

The `Subtract` method could have serious performance issues when
used with massive AD dates.

## Requirements

.NET Framework 2.0 or later.

Pre-built binaries are available via a signed [NuGet
package][nuget] containing the following targets.

* .NET 3.5
* .NET 4.0
* .NET 4.5.2
* .NET 4.6.2
* .NET 4.7.2
* .NET 4.8
* .NET 5.0
* .NET Standard 2.0
* .NET Standard 2.1
* .NET Core 2.1
* .NET Core 3.1

Is there a target not on this list you'd like to see? Raise an
[issue][issue], or even better, a [pull request][pull].

## Acknowledgements

* Inspiration gleaned from [Representing Large AD and BC Dates
  in C#][blogres] and [cerinman/HistoricalDate][sourceres]
* The NuGet package icon is from the [Multimedia Solid 24px icon
  set][icon] by [amoghdesign][iconuser]. Licensed under
  Attribution-NonCommercial 3.0 Unported (CC BY-NC 3.0).

[source]: https://github.com/cyotek/Cyotek.HistoricalDate
[rel]: https://github.com/cyotek/Cyotek.HistoricalDate/releases
[nuget]: https://www.nuget.org/packages/Cyotek.HistoricalDate/
[issue]: https://github.com/cyotek/Cyotek.Drawing.HistoricalDate/issues
[pull]: https://github.com/cyotek/Cyotek.Drawing.HistoricalDate/pulls

[demo]: res/demo.png

[icon]: https://www.iconfinder.com/icons/5402415/history_recent_repeat_replay_refresh_reload_icon
[iconuser]: https://www.iconfinder.com/amoghdesign
[blogres]: http://flipbit.co.uk/2009/03/representing-large-ad-and-bc-dates-in-c
[sourceres]: https://github.com/cerinman/HistoricalDate/blob/master/HistoricalDate/HistoricalDate/HistoricalDate.cs
