using System;
using System.Globalization;

namespace Cyotek
{
  internal static class JulianDateParser
  {
    #region Private Fields

    private static readonly char[] _dateSeparators = { '-', '/', '\\', ' ' };

    #endregion Private Fields

    #region Public Methods

    public static JulianDate Parse(string s)
    {
      JulianDate result;
      string[] parts;

      parts = s.Split(_dateSeparators, StringSplitOptions.RemoveEmptyEntries);

      switch (parts.Length)
      {
        case 3:
          result = JulianDateParser.ParseThreeValueDate(parts);
          break;

        case 2:
          result = JulianDateParser.ParseTwoValueDate(parts);
          break;

        case 4:
          result = JulianDateParser.ParseFourValueDate(parts);
          break;

        default:
          result = JulianDate.Empty;
          break;
      }

      return result;
    }

    #endregion Public Methods

    #region Private Methods

    private static JulianDate ParseFourValueDate(string[] parts)
    {
      JulianDate result;

      if (JulianDateParser.TryGetInt(parts[0], out int year)
          && JulianDateParser.TryGetInt(parts[1], out int month)
          && JulianDateParser.TryGetInt(parts[2], out int day)
          && JulianDateParser.TryGetEra(parts[3], out JulianEra era))
      {
        result = new JulianDate(year, month, day, era);
      }
      else if (JulianDateParser.TryGetInt(parts[0], out day)
          && JulianDateParser.TryGetMonth(parts[1], out month)
          && JulianDateParser.TryGetInt(parts[2], out year)
          && JulianDateParser.TryGetEra(parts[3], out era))
      {
        result = new JulianDate(year, month, day, era);
      }
      else
      {
        result = JulianDate.Empty;
      }

      return result;
    }

    private static JulianDate ParseThreeValueDate(string[] parts)
    {
      JulianDate result;

      if (JulianDateParser.TryGetInt(parts[0], out int year)
          && JulianDateParser.TryGetInt(parts[1], out int month)
          && JulianDateParser.TryGetInt(parts[2], out int day))
      {
        result = new JulianDate(year, month, day);
      }
      else if (JulianDateParser.TryGetMonth(parts[0], out month)
          && JulianDateParser.TryGetInt(parts[1], out year)
          && JulianDateParser.TryGetEra(parts[2], out JulianEra era))
      {
        result = new JulianDate(year, month, era);
      }
      else if (JulianDateParser.TryGetInt(parts[0], out day)
          && JulianDateParser.TryGetMonth(parts[1], out month)
          && JulianDateParser.TryGetInt(parts[2], out year))
      {
        result = new JulianDate(year, month, day);
      }
      else
      {
        result = JulianDate.Empty;
      }

      return result;
    }

    private static JulianDate ParseTwoValueDate(string[] parts)
    {
      JulianDate result;

      if (JulianDateParser.TryGetInt(parts[0], out int year)
          && JulianDateParser.TryGetEra(parts[1], out JulianEra era))
      {
        result = new JulianDate(year, era);
      }
      else if (JulianDateParser.TryGetMonth(parts[0], out int month)
          && JulianDateParser.TryGetInt(parts[1], out year))
      {
        result = new JulianDate(year, month);
      }
      else
      {
        result = JulianDate.Empty;
      }

      return result;
    }

    private static bool TryGetEra(string s, out JulianEra era)
    {
      bool result;

      //return Enum.TryParse(s, true, out era);
      if (string.Equals(s, "BC", StringComparison.InvariantCultureIgnoreCase)
      || string.Equals(s, "BP", StringComparison.InvariantCultureIgnoreCase))
      {
        era = JulianEra.Bc;
        result = true;
      }
      else if (string.Equals(s, "AD", StringComparison.InvariantCultureIgnoreCase))
      {
        era = JulianEra.Ad;
        result = true;
      }
      else
      {
        era = 0;
        result = false;
      }

      return result;
    }

    private static bool TryGetInt(string s, out int result)
    {
      return int.TryParse(s, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out result);
    }

    private static bool TryGetMonth(string s, DateTimeFormatInfo format, out int month)
    {
      if (!JulianDateParser.TryGetMonth(s, format.MonthNames, out month)
          && !JulianDateParser.TryGetMonth(s, format.AbbreviatedMonthNames, out month))
      {
        month = 0;
      }

      return month != 0;
    }

    private static bool TryGetMonth(string s, string[] names, out int month)
    {
      month = 0;

      for (int i = 0; i < names.Length; i++)
      {
        if (string.Equals(s, names[i], StringComparison.InvariantCultureIgnoreCase))
        {
          month = i + 1;
          break;
        }
      }

      return month != 0;
    }

    private static bool TryGetMonth(string s, out int month)
    {
      if (!JulianDateParser.TryGetInt(s, out month))
      {
        DateTimeFormatInfo format;

        format = DateTimeFormatInfo.InvariantInfo;

        if (!JulianDateParser.TryGetMonth(s, format, out month))
        {
          JulianDateParser.TryGetMonth(s, DateTimeFormatInfo.CurrentInfo, out month);
        }
      }

      return month != 0;
    }

    #endregion Private Methods
  }
}