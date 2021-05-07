using NUnit.Framework;

namespace Cyotek.HistoricalDate.Tests
{
  public class JulianDateConverterTests
  {
    #region Public Methods

    [Test]
    public void ConvertFromTest()
    {
      // arrange
      JulianDateConverter target;
      object actual;
      JulianDate expected;
      string value;

      target = new JulianDateConverter();

      value = "31 January 2021";

      expected = new JulianDate(2021, 1, 31);

      // act
      actual = target.ConvertFrom(value);

      // assert
      Assert.IsInstanceOf<JulianDate>(actual);
      Assert.AreEqual(expected, (JulianDate)actual);
    }

    [Test]
    public void ConvertToTest()
    {
      // arrange
      JulianDateConverter target;
      string actual;
      string expected;
      JulianDate value;

      target = new JulianDateConverter();

      value = new JulianDate(2021, 1, 31);

      expected = "2021-01-31 AD";

      // act
      actual = target.ConvertToString(value);

      // assert
      Assert.AreEqual(expected, actual);
    }

    #endregion Public Methods
  }
}