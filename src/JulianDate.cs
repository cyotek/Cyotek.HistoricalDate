using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Cyotek
{
  [TypeConverter(typeof(JulianDateConverter))]
  public readonly struct JulianDate
    : IEquatable<JulianDate>, IComparable<JulianDate>, IComparable
  {
    #region Public Fields

    public static readonly JulianDate Empty = new JulianDate();

    public static readonly JulianDate MaxValue = new JulianDate(int.MaxValue, 12, 31, JulianEra.Ad);

    public static readonly JulianDate MinValue = new JulianDate(int.MaxValue, 1, 1, JulianEra.Bc);

    #endregion Public Fields

    #region Private Fields

    private const int _beforePresentCutOff = 10_000;

    private const int _leapYear = 2004;

    private const int _nonLeapYear = 2005;

    private static readonly int[] _daysToMonth365 =
    {
      0,
      31,
      59,
      90,
      120,
      151,
      181,
      212,
      243,
      273,
      304,
      334,
      365
    };

    private static readonly int[] _daysToMonth366 =
    {
      0,
      31,
      60,
      91,
      121,
      152,
      182,
      213,
      244,
      274,
      305,
      335,
      366
    };

    private readonly int _day;

    private readonly JulianEra _era;

    private readonly int _month;

    private readonly int _year;

    #endregion Private Fields

    #region Public Constructors

    public JulianDate(int year)
      : this(year, 1)
    {
      _month = 0;
      _day = 0;
    }

    public JulianDate(int year, JulianEra era)
      : this(year, 1, era)
    {
      _month = 0;
    }

    public JulianDate(int year, int month)
      : this(year, month, 1)
    {
      _day = 0;
    }

    public JulianDate(int year, int month, JulianEra era)
      : this(year, month, 1, era)
    {
      _day = 0;
    }

    public JulianDate(int year, int month, int day)
      : this(year, month, day, JulianEra.Ad)
    {
    }

    public JulianDate(int year, int month, int day, JulianEra era)
    {
      if (year < 1)
      {
        throw new ArgumentException("Invalid year.", nameof(year));
      }

      if (month < 1 || month > 12)
      {
        throw new ArgumentOutOfRangeException(nameof(month), month, "Month is not valid.");
      }

      if (day < 1 || day > JulianDate.GetDaysInMonth(month, year))
      {
        throw new ArgumentOutOfRangeException(nameof(day), day, "Day is not valid.");
      }

      if (era != JulianEra.Bc && era != JulianEra.Ad)
      {
        throw new ArgumentOutOfRangeException(nameof(era), era, "Invalid era.");
      }

      _era = era;
      _year = year;
      _month = month;
      _day = day;
    }

    #endregion Public Constructors

    #region Public Properties

    public int Day => _day;

    public int DayOfYear
    {
      get
      {
        return _year > 0 && _month > 0 && _day > 0
          ? JulianDate.IsLeapYear(_year)
            ? _daysToMonth366[_month - 1] + _day
            : _daysToMonth365[_month - 1] + _day
          : 0;
      }
    }

    public JulianEra Era => _era;

    public bool HasDay => _day > 0;

    public bool HasMonth => _month > 0;

    public bool IsEmpty => _year == 0;

    public int Month => _month;

    public int Year => _year;

    #endregion Public Properties

    #region Private Properties

    private long AbsoluteYears
    {
      get
      {
        return _era == JulianEra.Ad
          ? (long)int.MaxValue + (_year - 1)
          : int.MaxValue - _year;
      }
    }

    #endregion Private Properties

    #region Public Methods

    public static int DaysInMonth(long year, int month)
    {
      int[] days;

      if (month < 1 || month > 12)
      {
        throw new ArgumentOutOfRangeException(nameof(month), month, "Invalid month.");
      }

      days = JulianDate.IsLeapYear(year)
        ? _daysToMonth366
        : _daysToMonth365;

      return days[month] - days[month - 1];
    }

    public static JulianDate FromBinary(long ticks)
    {
      JulianDate result;

      if (ticks != 0)
      {
        int absoluteYear;
        int dayOfYear;
        int year;
        JulianEra era;

        absoluteYear = (int)(ticks >> 32);
        dayOfYear = ((byte)((ticks & 0xFF000000) >> 24) << 24)
          | ((byte)((ticks & 0x00FF0000) >> 16) << 16)
          | ((byte)((ticks & 0x0000FF00) >> 8) << 8)
          | (byte)(ticks & 0x000000FF);

        if (absoluteYear > 0)
        {
          year = absoluteYear;
          era = JulianEra.Ad;
        }
        else
        {
          year = -absoluteYear;
          era = JulianEra.Bc;
        }

        if (dayOfYear != 0)
        {
          JulianDate.MonthFromDayOfYear(year, dayOfYear, out int month, out int day);

          result = new JulianDate(year, month, day, era);
        }
        else
        {
          result = new JulianDate(year, era);
        }
      }
      else
      {
        result = JulianDate.Empty;
      }

      return result;
    }

    /// <summary>
    /// Determines if the specified year is a leap year.
    /// </summary>
    /// <returns></returns>
    /// <param name="year">Year to test.</param>
    public static bool IsLeapYear(long year)
    {
      // not divisible by 4? not a leap year
      // divisible by 4 and not divisible by 100? always a leap year
      // divisible by 4 and 100? Only a leap year if also divisible by 400
      return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
    }

    public static HistoricalTimeSpan operator -(JulianDate d1, JulianDate d2)
    {
      long year;
      int month;
      int day;
      long totalDays;

      year = d1.AbsoluteYears - d2.AbsoluteYears;

      if (d1._month > 0 || d2._month > 0)
      {
        if (d1._month > 0 && d2._month > 0)
        {
          month = d1._month - d2._month;
          if (month < 0)
          {
            month = 12 + month;
            year--;
          }
        }
        else
        {
          month = Math.Max(d1._month, d2._month);
        }

        if (d1._day > 0 || d2._day > 0)
        {
          if (d1._day > 0 && d2._day > 0)
          {
            day = d1._day - d2._day;

            if (day < 0)
            {
              int days;

              days = JulianDate.DaysInMonth(year, month);

              day = days + day;
              month--;

              if (month < 1)
              {
                month = 12;
                year--;
              }
            }
          }
          else
          {
            day = Math.Max(d1._day, d2._day);
          }
        }
        else
        {
          day = 0;
        }
      }
      else
      {
        month = 0;
        day = 0;
      }

      totalDays = year * 365;

      if (month != 0)
      {
        int yearDays;

        yearDays = _daysToMonth365[month - 1];

        if (totalDays >= 0)
        {
          totalDays += yearDays;
        }
        else
        {
          totalDays -= yearDays;
        }
      }

      if (totalDays > 0)
      {
        totalDays += day;
      }
      else if (totalDays < 0)
      {
        totalDays -= day;
      }

      return HistoricalTimeSpan.FromDays(totalDays);
    }

    public static bool operator !=(JulianDate a, JulianDate b) => !a.Equals(b);

    public static bool operator <(JulianDate a, JulianDate b) => a.CompareTo(b) < 0;

    public static bool operator <=(JulianDate a, JulianDate b) => a.CompareTo(b) <= 0;

    public static bool operator ==(JulianDate a, JulianDate b) => a.Equals(b);

    public static bool operator >(JulianDate a, JulianDate b) => a.CompareTo(b) > 0;

    public static bool operator >=(JulianDate a, JulianDate b) => a.CompareTo(b) >= 0;

    public static JulianDate Parse(string s)
    {
      if (string.IsNullOrEmpty(s))
      {
        throw new ArgumentNullException(nameof(s));
      }

      if (!JulianDate.TryParse(s, out JulianDate result))
      {
        throw new FormatException("Invalid date format.");
      }

      return result;
    }

    public static bool TryParse(string s, out JulianDate result)
    {
      result = !string.IsNullOrEmpty(s)
        ? JulianDateParser.Parse(s)
        : JulianDate.Empty;

      return !result.IsEmpty;
    }

    public int CompareTo(JulianDate other)
    {
      int result;

      result = _era.CompareTo(other._era);

      if (result == 0)
      {
        long x;
        long y;

        x = this.AbsoluteYears;
        y = other.AbsoluteYears;

        result = x.CompareTo(y);

        if (result == 0)
        {
          result = _month.CompareTo(other._month);

          if (result == 0)
          {
            result = _day.CompareTo(other._day);
          }
        }
      }

      return result;
    }

    public int CompareTo(object obj)
    {
      int result;

      switch (obj)
      {
        case null:
          result = 1;
          break;

        case JulianDate other:
          result = this.CompareTo(other);
          break;

        default:
          throw new ArgumentException("Argument must be a JulianDate.", nameof(obj));
      }

      return result;
    }

    public override bool Equals(object obj)
    {
      return obj is JulianDate other && this.Equals(other);
    }

    public bool Equals(JulianDate other)
    {
      return other._era == _era
        && other._year == _year
        && other._month == _month
        && other._day == _day
        ;
    }

    public override int GetHashCode()
    {
      unchecked
      {
        int hash = 17;
        hash = (hash * 23) + _era.GetHashCode();
        hash = (hash * 23) + _year;
        hash = (hash * 23) + _month;
        hash = (hash * 23) + _day;
        return hash;
      }
    }

    public long ToBinary()
    {
      long year;

      year = _era == JulianEra.Ad
        ? _year
        : -_year;

      return (year << 32) | (uint)this.DayOfYear;
    }

    public override string ToString()
    {
      if (_year > 0)
      {
        StringBuilder sb;

        sb = StringBuilderCache.Acquire(13);

        sb.Append(_year.ToString(CultureInfo.InvariantCulture));

        if (_month > 0)
        {
          sb.Append('-');
          sb.Append(_month.ToString("00", CultureInfo.InvariantCulture));

          if (_day > 0)
          {
            sb.Append('-');
            sb.Append(_day.ToString("00", CultureInfo.InvariantCulture));
          }
        }

        sb.Append(' ');

        if (_era == JulianEra.Bc)
        {
          sb.Append(_year >= _beforePresentCutOff
            ? "BP"
            : "BC");
        }
        else
        {
          sb.Append("AD");
        }

        return sb.ToStringAndRelease();
      }
      else
      {
        return string.Empty;
      }
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Gets the days in a particular month, accounting for leap years and eras.
    /// </summary>
    /// <returns>The days in month.</returns>
    /// <param name="month">Month.</param>
    /// <param name="year">Year.</param>
    private static int GetDaysInMonth(int month, int year)
    {
      return DateTime.DaysInMonth(
          JulianDate.IsLeapYear(year) ? _leapYear : _nonLeapYear,
          month
      );
    }

    private static void MonthFromDayOfYear(int year, int dayOfYear, out int month, out int day)
    {
      if (dayOfYear > 0)
      {
        int[] days;

        days = JulianDate.IsLeapYear(year)
            ? _daysToMonth366
            : _daysToMonth365;

        month = 1;
        day = 1;

        for (int i = days.Length - 1; i > 0; i--)
        {
          if (dayOfYear > days[i])
          {
            month = i + 1;
            day = dayOfYear - days[i];
            break;
          }
        }
      }
      else
      {
        month = 0;
        day = 0;
      }
    }

    #endregion Private Methods
  }
}