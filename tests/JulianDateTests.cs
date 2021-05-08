using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Cyotek.HistoricalDate.Tests
{
  public class JulianDateTests
  {
    #region Public Properties

    public static IEnumerable<TestCaseData> AddDaysTestData
    {
      get
      {
        yield return new TestCaseData(JulianDate.Empty, 0, JulianDate.Empty).SetName("{m}EmptyToEmpty");
        yield return new TestCaseData(new JulianDate(1, 1, 1, JulianEra.Ad), -1, new JulianDate(1, 12, 31, JulianEra.Bc)).SetName("{m}OneAdToOneBc");
        yield return new TestCaseData(new JulianDate(1, 1, 1, JulianEra.Ad), -365, new JulianDate(1, 1, 1, JulianEra.Bc)).SetName("{m}Minus365OverEra");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), 1, new JulianDate(2021, 5, 9)).SetName("{m}AddOne");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), 2, new JulianDate(2021, 5, 10)).SetName("{m}AddTwo");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), 31, new JulianDate(2021, 6, 8)).SetName("{m}AddThirtyOne");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), -1, new JulianDate(2021, 5, 7)).SetName("{m}MinusOne");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), -2, new JulianDate(2021, 5, 6)).SetName("{m}MinusTwo");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), -31, new JulianDate(2021, 4, 7)).SetName("{m}MinusThirtyOne");
      }
    }

    public static IEnumerable<TestCaseData> AddMonthsTestData
    {
      get
      {
        yield return new TestCaseData(JulianDate.Empty, 0, JulianDate.Empty).SetName("{m}EmptyToEmpty");
        yield return new TestCaseData(new JulianDate(1, 1, 1, JulianEra.Ad), -12, new JulianDate(1, 1, 1, JulianEra.Bc)).SetName("{m}OneAdToOneBc");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), 1, new JulianDate(2021, 6, 8)).SetName("{m}AddOne");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), 2, new JulianDate(2021, 7, 8)).SetName("{m}AddTwo");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), 12, new JulianDate(2022, 5, 8)).SetName("{m}AddTwelve");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), -1, new JulianDate(2021, 4, 8)).SetName("{m}MinusOne");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), -2, new JulianDate(2021, 3, 8)).SetName("{m}MinusTwo");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), -12, new JulianDate(2020, 5, 8)).SetName("{m}MinusTwelve");
        yield return new TestCaseData(new JulianDate(2021, 1, 31), 1, new JulianDate(2021, 2, 28)).SetName("{m}OverDaysInMonth");
        yield return new TestCaseData(new JulianDate(2024, 1, 31), 1, new JulianDate(2024, 2, 29)).SetName("{m}OverDaysInMonthAndLeapYear");
      }
    }

    public static IEnumerable<TestCaseData> AddYearsTestData
    {
      get
      {
        yield return new TestCaseData(JulianDate.Empty, 0, JulianDate.Empty).SetName("{m}EmptyToEmpty");
        yield return new TestCaseData(new JulianDate(1, JulianEra.Ad), -1, new JulianDate(1, JulianEra.Bc)).SetName("{m}OneAdToOneBc");
        yield return new TestCaseData(new JulianDate(2021, 8, 5), -4000, new JulianDate(1980, 8, 5, JulianEra.Bc)).SetName("{m}AdToBc");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), 1, new JulianDate(2022, 5, 8)).SetName("{m}AddOne");
        yield return new TestCaseData(new JulianDate(2022, 5, 8), -1, new JulianDate(2021, 5, 8)).SetName("{m}MinusOne");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), -1, new JulianDate(2020, 5, 7)).SetName("{m}MinusOneWithLeap");
      }
    }

    public static IEnumerable<TestCaseData> CompareToTestData
    {
      get
      {
        yield return new TestCaseData(new JulianDate(2020, 2, 1), new JulianDate(2020, 2, 1), 0).SetName("{m}Equal");
        yield return new TestCaseData(JulianDate.MinValue, JulianDate.MaxValue, -1).SetName("{m}Less");
        yield return new TestCaseData(JulianDate.MaxValue, JulianDate.MinValue, 1).SetName("{m}Greater");
      }
    }

    public static IEnumerable<TestCaseData> DayOfYearTestData
    {
      get
      {
        string suffix;

        suffix = string.Empty;

        for (int year = 2023; year <= 2024; year++)
        {
          for (int month = 1; month <= 12; month++)
          {
            for (int day = 1; day < 28; day += 7)
            {
              DateTime dateTime;

              dateTime = new DateTime(year, month, day);

              yield return new TestCaseData(new JulianDate(year, month, day), dateTime.DayOfYear).SetName("{m}" +
                day.ToString("00") + month.ToString("00") + suffix);
            }
          }

          suffix = "Leap";
        }
      }
    }

    public static IEnumerable<TestCaseData> DaysInMonthTestData
    {
      get
      {
        string suffix;

        suffix = string.Empty;

        for (int year = 2023; year <= 2024; year++)
        {
          for (int month = 1; month <= 12; month++)
          {
            int expected;

            expected = DateTime.DaysInMonth(2021, month);

            if (year == 2024 && month == 2)
            {
              expected++;
            }

            yield return new TestCaseData(year, month, JulianEra.Ad, expected).SetName("{m}" + month.ToString("00") + suffix);
          }

          suffix = "Leap";
        }
      }
    }

    public static IEnumerable<TestCaseData> GreaterThanOrEqualToTestData
    {
      get
      {
        foreach (TestCaseData data in JulianDateTests.MatchingTestData)
        {
          yield return data;
        }

        foreach (TestCaseData data in JulianDateTests.GreaterThanTestData)
        {
          yield return data;
        }
      }
    }

    public static IEnumerable<TestCaseData> GreaterThanTestData
    {
      get
      {
        yield return new TestCaseData(new JulianDate(2021, 1, 31, JulianEra.Ad),
          new JulianDate(2021, 1, 31, JulianEra.Bc)).SetName("{m}Era");
        yield return new TestCaseData(new JulianDate(2022, 1, 30), new JulianDate(2021, 1, 30)).SetName("{m}Year");
        yield return new TestCaseData(new JulianDate(2021, 3, 30), new JulianDate(2021, 1, 30)).SetName("{m}Month");
        yield return new TestCaseData(new JulianDate(2021, 1, 31), new JulianDate(2021, 1, 30)).SetName("{m}Day");
        yield return new TestCaseData(new JulianDate(800, JulianEra.Bc), new JulianDate(2500, JulianEra.Bc))
          .SetName("{m}Bc");
        yield return new TestCaseData(new JulianDate(100, JulianEra.Ad), new JulianDate(800, JulianEra.Bc)).SetName(
          "{m}EraCrossover");
        yield return new TestCaseData(JulianDate.MaxValue, JulianDate.MinValue).SetName("{m}MaxMin");
      }
    }

    public static IEnumerable<TestCaseData> HasDayTestData
    {
      get
      {
        yield return new TestCaseData(JulianDate.Empty, false).SetName("{m}Empty");
        yield return new TestCaseData(new JulianDate(2021), false).SetName("{m}Year");
        yield return new TestCaseData(new JulianDate(2021, 1), false).SetName("{m}Month");
        yield return new TestCaseData(new JulianDate(2021, 1, 30), true).SetName("{m}Day");
      }
    }

    public static IEnumerable<TestCaseData> HasMonthTestData
    {
      get
      {
        yield return new TestCaseData(JulianDate.Empty, false).SetName("{m}Empty");
        yield return new TestCaseData(new JulianDate(2021), false).SetName("{m}Year");
        yield return new TestCaseData(new JulianDate(2021, 1), true).SetName("{m}Month");
        yield return new TestCaseData(new JulianDate(2021, 1, 30), true).SetName("{m}Day");
      }
    }

    public static IEnumerable<TestCaseData> IsEmptyTestData
    {
      get
      {
        yield return new TestCaseData(JulianDate.Empty, true).SetName("{m}Empty");
        yield return new TestCaseData(new JulianDate(2021), false).SetName("{m}Year");
        yield return new TestCaseData(new JulianDate(2021, 1), false).SetName("{m}Month");
        yield return new TestCaseData(new JulianDate(2021, 1, 30), false).SetName("{m}Day");
      }
    }

    public static IEnumerable<TestCaseData> LessThanOrEqualToTestData
    {
      get
      {
        foreach (TestCaseData data in JulianDateTests.MatchingTestData)
        {
          yield return data;
        }

        foreach (TestCaseData data in JulianDateTests.LessThanTestData)
        {
          yield return data;
        }
      }
    }

    public static IEnumerable<TestCaseData> LessThanTestData
    {
      get
      {
        yield return new TestCaseData(new JulianDate(2021, 1, 31, JulianEra.Bc),
          new JulianDate(2021, 1, 31, JulianEra.Ad)).SetName("{m}Era");
        yield return new TestCaseData(new JulianDate(2021, 1, 30), new JulianDate(2022, 1, 30)).SetName("{m}Year");
        yield return new TestCaseData(new JulianDate(2021, 1, 30), new JulianDate(2021, 3, 30)).SetName("{m}Month");
        yield return new TestCaseData(new JulianDate(2021, 1, 30), new JulianDate(2021, 1, 31)).SetName("{m}Day");
        yield return new TestCaseData(new JulianDate(2500, JulianEra.Bc), new JulianDate(800, JulianEra.Bc))
          .SetName("{m}Bc");
        yield return new TestCaseData(new JulianDate(800, JulianEra.Bc), new JulianDate(100, JulianEra.Ad)).SetName(
          "{m}EraCrossover");
        yield return new TestCaseData(JulianDate.MinValue, JulianDate.MaxValue).SetName("{m}MinMax");
      }
    }

    public static IEnumerable<TestCaseData> MatchingTestData
    {
      get
      {
        yield return new TestCaseData(JulianDate.Empty, JulianDate.Empty).SetName("{m}Empty");
        yield return new TestCaseData(new JulianDate(2021, 1, 31), new JulianDate(2021, 1, 31)).SetName("{m}");
        yield return new TestCaseData(JulianDate.MinValue, JulianDate.MinValue).SetName("{m}Min");
        yield return new TestCaseData(JulianDate.MaxValue, JulianDate.MaxValue).SetName("{m}Max");
      }
    }

    public static IEnumerable<TestCaseData> MinusOperatorTestData
    {
      get
      {
        yield return new TestCaseData(JulianDate.Empty, JulianDate.Empty, HistoricalTimeSpan.Zero).SetName("{m}Empty");
        yield return new TestCaseData(JulianDate.Empty, new JulianDate(2021, 2, 4), HistoricalTimeSpan.FromDays(-737839)).SetName("{m}EmptyLeft");
        yield return new TestCaseData(new JulianDate(2021, 2, 4), JulianDate.Empty, HistoricalTimeSpan.FromDays(737839)).SetName("{m}EmptyRight");
        yield return new TestCaseData(new JulianDate(2021, 2, 4), new JulianDate(2021, 2, 4), HistoricalTimeSpan.Zero).SetName("{m}Equal");
        yield return new TestCaseData(new JulianDate(2021, 12, 8), new JulianDate(2021, 5, 8), HistoricalTimeSpan.FromDays(214)).SetName("{m}GreaterMonth");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), new JulianDate(2021, 12, 8), HistoricalTimeSpan.FromDays(-214)).SetName("{m}LesserMonth");
        yield return new TestCaseData(new JulianDate(2021, 5, 1), new JulianDate(2021, 5, 31), HistoricalTimeSpan.FromDays(-30)).SetName("{m}GreaterDay");
        yield return new TestCaseData(new JulianDate(2021, 5, 31), new JulianDate(2021, 5, 1), HistoricalTimeSpan.FromDays(30)).SetName("{m}LesserDay");
        yield return new TestCaseData(new JulianDate(2022, 2, 4), new JulianDate(2021, 2, 4), HistoricalTimeSpan.FromDays(365)).SetName("{m}GreaterYear");
        yield return new TestCaseData(new JulianDate(2021, 2, 4), new JulianDate(2022, 2, 4), HistoricalTimeSpan.FromDays(-365)).SetName("{m}LesserYear");
        yield return new TestCaseData(new JulianDate(1, JulianEra.Bc), new JulianDate(1, JulianEra.Ad), HistoricalTimeSpan.FromDays(-365)).SetName("{m}EraBcAd");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), new JulianDate(2021, 2, 4), HistoricalTimeSpan.FromDays(93)).SetName("{m}GreaterMixMonth");
        yield return new TestCaseData(new JulianDate(2021, 2, 4), new JulianDate(2021, 5, 8), HistoricalTimeSpan.FromDays(-93)).SetName("{m}LesserMixMonth");
        yield return new TestCaseData(new JulianDate(2022, 5, 8), new JulianDate(2020, 2, 4), HistoricalTimeSpan.FromDays(824)).SetName("{m}GreaterMixYearWithLeap");
        yield return new TestCaseData(new JulianDate(2020, 2, 4), new JulianDate(2022, 5, 8), HistoricalTimeSpan.FromDays(-824)).SetName("{m}LesserMixYearWithLeap");
        yield return new TestCaseData(new JulianDate(2023, 5, 8), new JulianDate(2021, 2, 4), HistoricalTimeSpan.FromDays(823)).SetName("{m}GreaterMixYear");
        yield return new TestCaseData(new JulianDate(2021, 2, 4), new JulianDate(2023, 5, 8), HistoricalTimeSpan.FromDays(-823)).SetName("{m}LesserMixYear");
      }
    }

    public static IEnumerable<TestCaseData> ParseTestData
    {
      get
      {
        yield return new TestCaseData(null, "2021 BP", new JulianDate(2021, JulianEra.Bc)).SetName("{m}BeforePresent");
        yield return new TestCaseData(null, "2021 BC", new JulianDate(2021, JulianEra.Bc)).SetName("{m}Year");
        yield return new TestCaseData(null, "2021 AD", new JulianDate(2021, JulianEra.Ad)).SetName("{m}YearEra");
        yield return new TestCaseData(null, "January 2021 BC", new JulianDate(2021, 1, JulianEra.Bc)).SetName("{m}Month");
        yield return new TestCaseData(null, "30 January 2021 BC", new JulianDate(2021, 1, 30, JulianEra.Bc)).SetName("{m}Day");
        yield return new TestCaseData(null, "30 January 2021", new JulianDate(2021, 1, 30, JulianEra.Ad)).SetName("{m}DayWithoutEra");
        yield return new TestCaseData(null, "January 2021", new JulianDate(2021, 1, JulianEra.Ad)).SetName("{m}MonthWithoutEra");
        yield return new TestCaseData(null, "2021-02-01", new JulianDate(2021, 2, 1, JulianEra.Ad)).SetName("{m}Iso");
        yield return new TestCaseData(null, "2021-02-01 BC", new JulianDate(2021, 2, 1, JulianEra.Bc)).SetName("{m}IsoWithEra");
        yield return new TestCaseData(null, "Jan 2021 BC", new JulianDate(2021, 1, JulianEra.Bc)).SetName("{m}ShortMonth");
        yield return new TestCaseData(null, "30 Jan 2021 BC", new JulianDate(2021, 1, 30, JulianEra.Bc)).SetName("{m}ShortMonthDay");
        yield return new TestCaseData(null, "30 Jan 2021", new JulianDate(2021, 1, 30, JulianEra.Ad)).SetName("{m}ShortMonthDayWithoutEra");
        yield return new TestCaseData(null, "Jan 2021", new JulianDate(2021, 1, JulianEra.Ad)).SetName("{m}ShortMonthWithoutEra");
        yield return new TestCaseData("fr-FR", "janvier 2021 BC", new JulianDate(2021, 1, JulianEra.Bc)).SetName("{m}MonthFrench");
        yield return new TestCaseData("fr-FR", "30 janvier 2021 BC", new JulianDate(2021, 1, 30, JulianEra.Bc)).SetName("{m}DayFrench");
        yield return new TestCaseData("fr-FR", "30 janvier 2021", new JulianDate(2021, 1, 30, JulianEra.Ad)).SetName("{m}DayWithoutEraFrench");
        yield return new TestCaseData("fr-FR", "janvier 2021", new JulianDate(2021, 1, JulianEra.Ad)).SetName("{m}MonthWithoutEraFrench");
        yield return new TestCaseData("fr-FR", "janv. 2021 BC", new JulianDate(2021, 1, JulianEra.Bc)).SetName("{m}ShortMonthFrench");
        yield return new TestCaseData("fr-FR", "30 janv. 2021 BC", new JulianDate(2021, 1, 30, JulianEra.Bc)).SetName("{m}ShortMonthDayFrench");
        yield return new TestCaseData("fr-FR", "30 janv. 2021", new JulianDate(2021, 1, 30, JulianEra.Ad)).SetName("{m}ShortMonthDayWithoutEraFrench");
        yield return new TestCaseData("fr-FR", "janv. 2021", new JulianDate(2021, 1, JulianEra.Ad)).SetName("{m}ShortMonthWithoutEraFrench");
      }
    }

    public static IEnumerable<TestCaseData> PlusOperatorTestData
    {
      get
      {
        yield return new TestCaseData(new JulianDate(2022, 5, 8), HistoricalTimeSpan.FromDays(-365), new JulianDate(2021, 5, 8)).SetName("{m}Minus365");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), HistoricalTimeSpan.FromDays(-365), new JulianDate(2020, 5, 8)).SetName("{m}Minus365Leap");
        yield return new TestCaseData(new JulianDate(2021, 5, 8), HistoricalTimeSpan.FromDays(365), new JulianDate(2022, 5, 8)).SetName("{m}Plus365");
        yield return new TestCaseData(new JulianDate(2023, 5, 8), HistoricalTimeSpan.FromDays(365), new JulianDate(2024, 5, 7)).SetName("{m}Plus365Leap");
      }
    }

    public static IEnumerable<TestCaseData> ToBinaryTestData
    {
      get
      {
        yield return new TestCaseData(JulianDate.Empty, 0).SetName("{m}Empty");
        yield return new TestCaseData(new JulianDate(2020, JulianEra.Bc), -8675833937920).SetName("{m}BcYearOnly");
        yield return new TestCaseData(new JulianDate(2020), 8675833937920).SetName("{m}AdYearOnly");
        yield return new TestCaseData(new JulianDate(2020, 2, 1, JulianEra.Bc), -8675833937888).SetName("{m}Bc");
        yield return new TestCaseData(new JulianDate(2020, 2, 1), 8675833937952).SetName("{m}Ad");
        yield return new TestCaseData(JulianDate.MinValue, -9223372032559808511).SetName("{m}Min");
        yield return new TestCaseData(JulianDate.MaxValue, 9223372032559808877).SetName("{m}Max");
      }
    }

    public static IEnumerable<TestCaseData> ToStringTestData
    {
      get
      {
        yield return new TestCaseData(JulianDate.Empty, string.Empty).SetName("{m}Empty");
        yield return new TestCaseData(new JulianDate(9999, JulianEra.Bc), "9999 BC").SetName("{m}BeforePresentPre");
        yield return new TestCaseData(new JulianDate(10_001, JulianEra.Bc), "10001 BP").SetName("{m}BeforePresentPost");
        yield return new TestCaseData(new JulianDate(10_000, JulianEra.Bc), "10000 BP").SetName("{m}BeforePresent");
        yield return new TestCaseData(new JulianDate(2021, JulianEra.Bc), "2021 BC").SetName("{m}Era");
        yield return new TestCaseData(new JulianDate(2021, JulianEra.Ad), "2021 AD").SetName("{m}Year");
        yield return new TestCaseData(new JulianDate(2021, 1, JulianEra.Ad), "2021-01 AD").SetName("{m}Month");
        yield return new TestCaseData(new JulianDate(2021, 1, 30, JulianEra.Ad), "2021-01-30 AD").SetName("{m}Day");
      }
    }

    public static IEnumerable<TestCaseData> TryParseTestData
    {
      get
      {
        yield return new TestCaseData(string.Empty, false, JulianDate.Empty).SetName("{m}Empty");
        yield return new TestCaseData(null, false, JulianDate.Empty).SetName("{m}Null");
        yield return new TestCaseData("2010", false, JulianDate.Empty).SetName("{m}Invalid1");
        yield return new TestCaseData("Not Valid", false, JulianDate.Empty).SetName("{m}Invalid2");
        yield return new TestCaseData("2021 BP", true, new JulianDate(2021, JulianEra.Bc)).SetName("{m}BeforePresent");
        yield return new TestCaseData("2021 BC", true, new JulianDate(2021, JulianEra.Bc)).SetName("{m}Year");
        yield return new TestCaseData("2021 AD", true, new JulianDate(2021, JulianEra.Ad)).SetName("{m}YearEra");
        yield return new TestCaseData("January 2021 BC", true, new JulianDate(2021, 1, JulianEra.Bc)).SetName("{m}Month");
        yield return new TestCaseData("30 January 2021 BC", true, new JulianDate(2021, 1, 30, JulianEra.Bc)).SetName("{m}Day");
        yield return new TestCaseData("30 January 2021", true, new JulianDate(2021, 1, 30, JulianEra.Ad)).SetName("{m}DayWithoutEra");
        yield return new TestCaseData("January 2021", true, new JulianDate(2021, 1, JulianEra.Ad)).SetName("{m}MonthWithoutEra");
      }
    }

    #endregion Public Properties

    #region Public Methods

    [Test]
    [TestCaseSource(nameof(AddDaysTestData))]
    public void AdDaysTestCases(JulianDate target, int value, JulianDate expected)
    {
      // arrange
      JulianDate actual;

      // act
      actual = target.AddDays(value);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(AddMonthsTestData))]
    public void AddMonthsTestCases(JulianDate target, int value, JulianDate expected)
    {
      // arrange
      JulianDate actual;

      // act
      actual = target.AddMonths(value);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(PlusOperatorTestData))]
    public void AddTestCases(JulianDate d, HistoricalTimeSpan t, JulianDate expected)
    {
      // arrange
      JulianDate actual;

      // act
      actual = d.Add(t);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(AddYearsTestData))]
    public void AddYearsTestCases(JulianDate target, int value, JulianDate expected)
    {
      // arrange
      JulianDate actual;

      // act
      actual = target.AddYears(value);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CompareToExceptionTest()
    {
      // act && assert
      Assert.Throws<ArgumentException>(() => JulianDate.Empty.CompareTo("not a date"));
    }

    [Test]
    public void CompareToNullTest()
    {
      // arrange
      JulianDate target;
      int expected;
      int actual;

      target = JulianDate.Empty;

      expected = 1;

      // act
      actual = target.CompareTo(null);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(CompareToTestData))]
    public void CompareToObjectTestCases(JulianDate a, JulianDate b, int expected)
    {
      // arrange
      int actual;

      // act
      actual = a.CompareTo((object)b);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(CompareToTestData))]
    public void CompareToTestCases(JulianDate a, JulianDate b, int expected)
    {
      // arrange
      int actual;

      // act
      actual = a.CompareTo(b);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CtorDayEraTest()
    {
      // arrange
      JulianDate target;
      JulianEra expectedEra;
      int expectedYear;
      int expectedMonth;
      int expectedDay;

      expectedEra = JulianEra.Bc;
      expectedYear = 2021;
      expectedMonth = 1;
      expectedDay = 30;

      // act
      target = new JulianDate(expectedYear, expectedMonth, expectedDay, expectedEra);

      // assert
      Assert.AreEqual(expectedEra, target.Era);
      Assert.AreEqual(expectedYear, target.Year);
      Assert.AreEqual(expectedMonth, target.Month);
      Assert.AreEqual(expectedDay, target.Day);
    }

    [Test]
    public void CtorDayTest()
    {
      // arrange
      JulianDate target;
      JulianEra expectedEra;
      int expectedYear;
      int expectedMonth;
      int expectedDay;

      expectedEra = JulianEra.Ad;
      expectedYear = 2021;
      expectedMonth = 1;
      expectedDay = 30;

      // act
      target = new JulianDate(expectedYear, expectedMonth, expectedDay);

      // assert
      Assert.AreEqual(expectedEra, target.Era);
      Assert.AreEqual(expectedYear, target.Year);
      Assert.AreEqual(expectedMonth, target.Month);
      Assert.AreEqual(expectedDay, target.Day);
    }

    [Test]
    public void CtorMonthEraTest()
    {
      // arrange
      JulianDate target;
      JulianEra expectedEra;
      int expectedYear;
      int expectedMonth;

      expectedEra = JulianEra.Bc;
      expectedYear = 2021;
      expectedMonth = 1;

      // act
      target = new JulianDate(expectedYear, expectedMonth, expectedEra);

      // assert
      Assert.AreEqual(expectedEra, target.Era);
      Assert.AreEqual(expectedYear, target.Year);
      Assert.AreEqual(expectedMonth, target.Month);
      Assert.Zero(target.Day);
    }

    [Test]
    public void CtorMonthTest()
    {
      // arrange
      JulianDate target;
      JulianEra expectedEra;
      int expectedYear;
      int expectedMonth;

      expectedEra = JulianEra.Ad;
      expectedYear = 2021;
      expectedMonth = 1;

      // act
      target = new JulianDate(expectedYear, expectedMonth);

      // assert
      Assert.AreEqual(expectedEra, target.Era);
      Assert.AreEqual(expectedYear, target.Year);
      Assert.AreEqual(expectedMonth, target.Month);
      Assert.Zero(target.Day);
    }

    [Test]
    public void CtorYearEraTest()
    {
      // arrange
      JulianDate target;
      JulianEra expectedEra;
      int expectedYear;

      expectedEra = JulianEra.Bc;
      expectedYear = 2021;

      // act
      target = new JulianDate(expectedYear, expectedEra);

      // assert
      Assert.AreEqual(expectedEra, target.Era);
      Assert.AreEqual(expectedYear, target.Year);
      Assert.Zero(target.Month);
      Assert.Zero(target.Day);
    }

    [Test]
    public void CtorYearTest()
    {
      // arrange
      JulianDate target;
      JulianEra expectedEra;
      int expectedYear;

      expectedEra = JulianEra.Ad;
      expectedYear = 2021;

      // act
      target = new JulianDate(expectedYear);

      // assert
      Assert.AreEqual(expectedEra, target.Era);
      Assert.AreEqual(expectedYear, target.Year);
      Assert.Zero(target.Month);
      Assert.Zero(target.Day);
    }

    [Test]
    [TestCaseSource(nameof(DayOfYearTestData))]
    public void DayOfYearTestCases(JulianDate target, int expected)
    {
      // arrange
      int actual;

      // act
      actual = target.DayOfYear;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(DaysInMonthTestData))]
    public void DaysInMonthTestCases(int year, int month, JulianEra era, int expected)
    {
      // arrange
      int actual;

      // act
      actual = JulianDate.DaysInMonth(year, month, era);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void EmptyTest()
    {
      // arrange
      JulianDate target;

      // act
      target = JulianDate.Empty;

      // assert
      Assert.IsTrue(target.IsEmpty);
      Assert.Zero(target.Day);
      Assert.Zero(target.Month);
      Assert.Zero(target.Year);
      Assert.Zero((int)target.Era);
    }

    [Test]
    [TestCaseSource(nameof(LessThanTestData))]
    public void EqualityNegativeTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target.Equals(other);

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    public void EqualityObjectInstanceTest()
    {
      // arrange
      JulianDate target;
      object other;
      bool actual;

      target = JulianDate.Empty;
      other = "not a date";

      // act
      actual = target.Equals(other);

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    [TestCaseSource(nameof(LessThanTestData))]
    public void EqualityObjectNegativeTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target.Equals((object)other);

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    [TestCaseSource(nameof(MatchingTestData))]
    public void EqualityObjectPositiveTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target.Equals((object)other);

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    [TestCaseSource(nameof(MatchingTestData))]
    public void EqualityPositiveTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target.Equals(other);

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    [TestCaseSource(nameof(MatchingTestData))]
    public void EqualsOperatorTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target == other;

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    [TestCaseSource(nameof(ToBinaryTestData))]
    public void FromBinaryTestCases(JulianDate expected, long binary)
    {
      // arrange
      JulianDate actual;

      // act
      actual = JulianDate.FromBinary(binary);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(LessThanTestData))]
    public void GreaterThanOperatorNegativeTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target > other;

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    [TestCaseSource(nameof(GreaterThanTestData))]
    public void GreaterThanOperatorPositiveTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target > other;

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    [TestCaseSource(nameof(LessThanTestData))]
    public void GreaterThanOrEqualToOperatorNegativeTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target >= other;

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    [TestCaseSource(nameof(GreaterThanOrEqualToTestData))]
    public void GreaterThanOrEqualToOperatorPositiveTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target >= other;

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    [TestCaseSource(nameof(HasDayTestData))]
    public void HasDayTestCases(JulianDate target, bool expected)
    {
      // arrange
      bool actual;

      // act
      actual = target.HasDay;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(HasMonthTestData))]
    public void HasMonthTestCases(JulianDate target, bool expected)
    {
      // arrange
      bool actual;

      // act
      actual = target.HasMonth;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(IsEmptyTestData))]
    public void IsEmptyTestCases(JulianDate target, bool expected)
    {
      // arrange
      bool actual;

      // act
      actual = target.IsEmpty;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(44, JulianEra.Bc)]
    [TestCase(41, JulianEra.Bc)]
    [TestCase(38, JulianEra.Bc)]
    [TestCase(35, JulianEra.Bc)]
    [TestCase(32, JulianEra.Bc)]
    [TestCase(29, JulianEra.Bc)]
    [TestCase(26, JulianEra.Bc)]
    [TestCase(23, JulianEra.Bc)]
    [TestCase(20, JulianEra.Bc)]
    [TestCase(17, JulianEra.Bc)]
    [TestCase(14, JulianEra.Bc)]
    [TestCase(6, JulianEra.Bc)]
    [TestCase(3, JulianEra.Bc)]
    [TestCase(7, JulianEra.Ad)]
    [TestCase(11, JulianEra.Ad)]
    [TestCase(1585, JulianEra.Ad)]
    [TestCase(1589, JulianEra.Ad)]
    [TestCase(1593, JulianEra.Ad)]
    [TestCase(1597, JulianEra.Ad)]
    [TestCase(1601, JulianEra.Ad)]
    public void IsLeapYearNegativeTestCases(int year, JulianEra era)
    {
      // arrange
      bool actual;

      // act
      actual = JulianDate.IsLeapYear(year, era);

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    [TestCase(45, JulianEra.Bc)]
    [TestCase(42, JulianEra.Bc)]
    [TestCase(39, JulianEra.Bc)]
    [TestCase(36, JulianEra.Bc)]
    [TestCase(33, JulianEra.Bc)]
    [TestCase(30, JulianEra.Bc)]
    [TestCase(27, JulianEra.Bc)]
    [TestCase(24, JulianEra.Bc)]
    [TestCase(21, JulianEra.Bc)]
    [TestCase(18, JulianEra.Bc)]
    [TestCase(15, JulianEra.Bc)]
    [TestCase(12, JulianEra.Bc)]
    [TestCase(9, JulianEra.Bc)]
    [TestCase(8, JulianEra.Ad)]
    [TestCase(12, JulianEra.Ad)]
    [TestCase(1584, JulianEra.Ad)]
    [TestCase(1588, JulianEra.Ad)]
    [TestCase(1592, JulianEra.Ad)]
    [TestCase(1596, JulianEra.Ad)]
    [TestCase(1600, JulianEra.Ad)]
    public void IsLeapYearPositiveTestCases(int year, JulianEra era)
    {
      // arrange
      bool actual;

      // act
      actual = JulianDate.IsLeapYear(year, era);

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    [TestCaseSource(nameof(GreaterThanTestData))]
    public void LessThanOperatorNegativeTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target < other;

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    [TestCaseSource(nameof(LessThanTestData))]
    public void LessThanOperatorPositiveTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target < other;

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    [TestCaseSource(nameof(GreaterThanTestData))]
    public void LessThanOrEqualOperatorNegativeTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target <= other;

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    [TestCaseSource(nameof(LessThanOrEqualToTestData))]
    public void LessThanOrEqualOperatorPositiveTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target <= other;

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    public void MaxValueTest()
    {
      // arrange
      JulianDate target;
      int expectedYear;
      int expectedMonth;
      int expectedDay;
      JulianEra expectedEra;

      expectedYear = int.MaxValue;
      expectedMonth = 12;
      expectedDay = 31;
      expectedEra = JulianEra.Ad;

      // act
      target = JulianDate.MaxValue;

      // assert
      Assert.IsFalse(target.IsEmpty);
      Assert.AreEqual(expectedYear, target.Year);
      Assert.AreEqual(expectedMonth, target.Month);
      Assert.AreEqual(expectedDay, target.Day);
      Assert.AreEqual(expectedEra, target.Era);
    }

    [Test]
    [TestCaseSource(nameof(MinusOperatorTestData))]
    public void MinusOperatorTestCases(JulianDate d1, JulianDate d2, HistoricalTimeSpan expected)
    {
      // arrange
      HistoricalTimeSpan actual;

      // act
      actual = d1 - d2;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void MinValueTest()
    {
      // arrange
      JulianDate target;
      int expectedYear;
      int expectedMonth;
      int expectedDay;
      JulianEra expectedEra;

      expectedYear = int.MaxValue;
      expectedMonth = 1;
      expectedDay = 1;
      expectedEra = JulianEra.Bc;

      // act
      target = JulianDate.MinValue;

      // assert
      Assert.IsFalse(target.IsEmpty);
      Assert.AreEqual(expectedYear, target.Year);
      Assert.AreEqual(expectedMonth, target.Month);
      Assert.AreEqual(expectedDay, target.Day);
      Assert.AreEqual(expectedEra, target.Era);
    }

    [Test]
    [TestCaseSource(nameof(LessThanTestData))]
    public void NotEqualsOperatorTestCases(JulianDate target, JulianDate other)
    {
      // arrange
      bool actual;

      // act
      actual = target != other;

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    [TestCaseSource(nameof(ParseTestData))]
    public void ParseTestCases(string culture, string value, JulianDate expected)
    {
      // arrange
      JulianDate actual;

      if (!string.IsNullOrEmpty(culture))
      {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
      }

      // act
      actual = JulianDate.Parse(value);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(PlusOperatorTestData))]
    public void PlusOperatorTestCases(JulianDate d, HistoricalTimeSpan t, JulianDate expected)
    {
      // arrange
      JulianDate actual;

      // act
      actual = d + t;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(MinusOperatorTestData))]
    public void SubtractTestCases(JulianDate d1, JulianDate d2, HistoricalTimeSpan expected)
    {
      // arrange
      HistoricalTimeSpan actual;

      // act
      actual = d1.Subtract(d2);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(ToBinaryTestData))]
    public void ToBinaryTestCases(JulianDate target, long expected)
    {
      // arrange
      long actual;

      // act
      actual = target.ToBinary();

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(ToStringTestData))]
    public void ToStringTestCases(JulianDate target, string expected)
    {
      // arrange
      string actual;

      // act
      actual = target.ToString();

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(TryParseTestData))]
    public void TryParseTestCases(string value, bool result, JulianDate expected)
    {
      // arrange
      bool actual;

      // act
      actual = JulianDate.TryParse(value, out JulianDate actualValue);

      // assert
      Assert.AreEqual(result, actual);
      Assert.AreEqual(expected, actualValue);
    }

    #endregion Public Methods
  }
}