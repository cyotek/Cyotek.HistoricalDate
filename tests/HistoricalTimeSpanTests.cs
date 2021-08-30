// Cyotek.HistoricalDate Library
// https://github.com/cyotek/Cyotek.HistoricalDate

// Copyright (c) 2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Cyotek.HistoricalDate.Tests
{
  [TestFixture]
  public class HistoricalTimeSpanTests
  {
    #region Public Properties

    public static IEnumerable<TestCaseData> ToStringTestCaseSource
    {
      get
      {
        yield return new TestCaseData(new HistoricalTimeSpan(2021, 3, 41, 57), "2021.03:41:57").SetName("{m}");
        yield return new TestCaseData(HistoricalTimeSpan.Zero, "00:00:00").SetName("{m}Zero");
        yield return new TestCaseData(new HistoricalTimeSpan(1, 0, 0, 0), "1.00:00:00").SetName("{m}OneDay");
        yield return new TestCaseData(new HistoricalTimeSpan(-1, 0, 0, 0), "-1.00:00:00").SetName("{m}MinusOneDay");
        yield return new TestCaseData(new HistoricalTimeSpan(1, 0, 0), "01:00:00").SetName("{m}OneHour");
        yield return new TestCaseData(new HistoricalTimeSpan(0, 1, 0), "00:01:00").SetName("{m}OneMinute");
        yield return new TestCaseData(new HistoricalTimeSpan(0, 0, 1), "00:00:01").SetName("{m}OneSecond");
      }
    }

    #endregion Public Properties

    #region Public Methods

    [Test]
    [TestCaseSource(nameof(ToStringTestCaseSource))]
    public void ToStringTestCases(HistoricalTimeSpan target, string expected)
    {
      // arrange
      string actual;

      // act
      actual = target.ToString();

      // assert
      Trace.WriteLine(new TimeSpan(366, 0, 0, 0, 0));
      Trace.WriteLine(new TimeSpan(23, 17, 10));
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TotalDaysTest()
    {
      // arrange
      HistoricalTimeSpan target;
      double expected;
      double actual;

      target = new HistoricalTimeSpan(7, 12, 30, 15);

      expected = 7.5210069444444443;

      // act
      actual = target.TotalDays;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TotalHoursTest()
    {
      // arrange
      HistoricalTimeSpan target;
      double expected;
      double actual;

      target = new HistoricalTimeSpan(7, 12, 30, 15);

      expected = 180.50416666666666;

      // act
      actual = target.TotalHours;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TotalMinutesTest()
    {
      // arrange
      HistoricalTimeSpan target;
      double expected;
      double actual;

      target = new HistoricalTimeSpan(7, 12, 30, 15);

      expected = 10830.25;

      // act
      actual = target.TotalMinutes;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TotalSecondsTest()
    {
      // arrange
      HistoricalTimeSpan target;
      double expected;
      double actual;

      target = new HistoricalTimeSpan(7, 12, 30, 15);

      expected = 649815;

      // act
      actual = target.TotalSeconds;

      // assert
      Assert.AreEqual(expected, actual);
    }

    #endregion Public Methods
  }
}