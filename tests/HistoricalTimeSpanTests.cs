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

    #endregion Public Methods
  }
}