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

    public static readonly JulianDate Empty;

    public static readonly JulianDate MaxValue;

    public static readonly JulianDate MinValue;

    #endregion Public Fields

    #region Private Fields

    private const int _beforePresentCutOff = 10_000;

    private const int _maximumYearsBeforeSeparators = 9999;

    private const int _yearModifier = 100_000_000;

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

    static JulianDate()
    {
      JulianDate.Empty = new JulianDate();
      JulianDate.MaxValue = new JulianDate(int.MaxValue, 12, 31, JulianEra.Ad);
      JulianDate.MinValue = new JulianDate(int.MaxValue, 1, 1, JulianEra.Bc);
    }

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
        throw new ArgumentException("Year is not valid.", nameof(year));
      }

      if (month < 1 || month > 12)
      {
        throw new ArgumentOutOfRangeException(nameof(month), month, "Month is not valid.");
      }

      if (day < 1 || day > JulianDate.DaysInMonth(year, month, era))
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
          ? JulianDate.IsLeapYear(_year, _era)
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

    private long AbsoluteYear => _era == JulianEra.Ad
                                    ? (long)int.MaxValue + (_year - 1)
                                    : int.MaxValue - _year;

    private int RelativeYear => _era == JulianEra.Ad
                                  ? _year
                                  : -_year;

    #endregion Private Properties

    #region Public Methods

    public static int DaysInMonth(long year, int month, JulianEra era)
    {
      int[] days;

      if (month < 1 || month > 12)
      {
        throw new ArgumentOutOfRangeException(nameof(month), month, "Invalid month.");
      }

      days = JulianDate.IsLeapYear(year, era)
        ? _daysToMonth366
        : _daysToMonth365;

      return days[month] - days[month - 1];
    }

    public static JulianDate FromBinary(long ticks)
    {
      JulianDate result;

      if (ticks != 0)
      {
        long absoluteYear;
        int dayOfYear;
        int year;

        absoluteYear = ticks / _yearModifier;
        dayOfYear = (int)((ticks - (absoluteYear * _yearModifier)) / HistoricalTimeSpan._secondsPerDay);

        year = JulianDate.GetRelativeYear(absoluteYear, out JulianEra era);

        result = JulianDate.FromYearAndDay(year, dayOfYear, era);
      }
      else
      {
        result = JulianDate.Empty;
      }

      return result;
    }

    /// <summary> Determines if the specified year is a leap year. </summary>
    /// <param name="year"> Year to test. </param>
    /// <param name="era">  Era of the year to test. </param>
    /// <returns> True if leap year, false if not. </returns>
    public static bool IsLeapYear(long year, JulianEra era)
    {
      bool result;

      /*
       * The Julian calendar has 1 leap year every 4 years:
       *
       * Every year divisible by 4 is a leap year.
       *
       * However, the 4-year rule was not followed in the first years after the
       * introduction of the Julian calendar in 45 BC. Due to a counting error,
       * every 3rd year was a leap year in the first years of this calendar’s
       * existence. The leap years were:
       *
       * 45 BC, 42 BC, 39 BC, 36 BC, 33 BC, 30 BC, 27 BC, 24 BC, 21 BC, 18 BC,
       * 15 BC, 12 BC, 9 BC, AD 8, AD 12, and every 4th year from then on.
       *
       * Authorities disagree about whether 45 BC was a leap year or not.
       *
       * https://www.tondering.dk/claus/cal/julian.php
       */

      switch (era)
      {
        case JulianEra.Ad when year >= 8 && year % 4 == 0:
        case JulianEra.Bc when year >= 9 && year <= 45 && year % 3 == 0:
          result = true;
          break;

        default:
          result = false;
          break;
      }

      return result;
    }

    public static HistoricalTimeSpan operator -(JulianDate d1, JulianDate d2) => d1.Subtract(d2);

    public static bool operator !=(JulianDate a, JulianDate b) => !a.Equals(b);

    public static JulianDate operator +(JulianDate d, HistoricalTimeSpan t) => d.Add(t);

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

    public JulianDate Add(HistoricalTimeSpan value)
    {
      JulianDate result;

      if (value.Ticks != 0)
      {
        result = this.AddDays(Convert.ToInt32(value.TotalDays));
      }
      else
      {
        result = this;
      }

      return result;
    }

    public JulianDate AddDays(int days)
    {
      JulianDate result;

      if (days != 0)
      {
        int y;
        int d;

        y = this.RelativeYear;
        d = this.DayOfYear + days;

        if (d > 0)
        {
          int q = (int)((uint)(d - 1) / 365);
          y += q;
          d -= q * 365;
        }
        else
        {
          y += d / 365 - 1;
          d = 365 + d % 365;
        }

        JulianDate.RotateYear(ref y, out JulianEra era);

        if (JulianDate.IsLeapYear(y, era) && days < 0)
        {
          d++;
        }

        result = JulianDate.FromYearAndDay(y, d, era);
      }
      else
      {
        result = JulianDate.Empty;
      }

      return result;
    }

    public JulianDate AddMonths(int months)
    {
      JulianDate result;

      if (months != 0)
      {
        int y;
        int d;
        int m;
        int daysInMonth;

        // Derived from
        // https://github.com/dotnet/runtime/blob/01b7e73cd378145264a7cb7a09365b41ed42b240/src/libraries/System.Private.CoreLib/src/System/DateTime.cs#L444

        y = this.RelativeYear;
        d = _day;
        m = _month + months;

        if (m > 0)
        {
          int q = (int)((uint)(m - 1) / 12);
          y += q;
          m -= q * 12;
        }
        else
        {
          y += m / 12 - 1;
          m = 12 + m % 12;
        }

        JulianDate.RotateYear(ref y, out JulianEra era);

        daysInMonth = JulianDate.DaysInMonth(y, m, era);
        if (d > daysInMonth)
        {
          d = daysInMonth;
        }

        result = JulianDate.FromPartial(y, m, d, era);
      }
      else
      {
        result = this;
      }

      return result;
    }

    public JulianDate AddYears(int value)
    {
      JulianDate result;

      if (value != 0)
      {
        int y;

        if (_era == JulianEra.Bc)
        {
          value = -value;
        }

        y = JulianDate.GetRelativeYear(this.AbsoluteYear + value, out JulianEra era);

        result = JulianDate.FromYearAndDay(y, this.DayOfYear, era);
      }
      else
      {
        result = this;
      }

      return result;
    }

    public int CompareTo(JulianDate other)
    {
      int result;

      result = _era.CompareTo(other._era);

      if (result == 0)
      {
        long x;
        long y;

        x = this.AbsoluteYear;
        y = other.AbsoluteYear;

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
          throw new ArgumentException("Argument must be a " + nameof(JulianDate) + ".", nameof(obj));
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

    public HistoricalTimeSpan Subtract(JulianDate value)
    {
      long years;
      int yearDays;
      int d1RelativeYear;
      int d2RelativeYear;
      int leapDays;

      years = this.AbsoluteYear - value.AbsoluteYear;
      yearDays = this.DayOfYear - value.DayOfYear;
      d1RelativeYear = this.RelativeYear;
      d2RelativeYear = value.RelativeYear;
      leapDays = 0;

      if (d1RelativeYear >= -45 && d2RelativeYear >= -45) // TODO: Consider maximum years, don't need to enumerate 2billion numbers
      {
        for (int i = Math.Min(d1RelativeYear, d2RelativeYear); i < Math.Max(d1RelativeYear, d2RelativeYear); i++)
        {
          if (JulianDate.IsLeapYear(i, i > 0
            ? JulianEra.Ad
            : JulianEra.Bc))
          {
            leapDays++;
          }
        }

        if (d1RelativeYear < d2RelativeYear)
        {
          leapDays = -leapDays;
        }
      }

      return HistoricalTimeSpan.FromDays((years * 365) + yearDays + leapDays);
    }

    public long ToBinary()
    {
      return _year != 0
        ? (this.AbsoluteYear * _yearModifier) + (this.DayOfYear * HistoricalTimeSpan._secondsPerDay)
        : 0;
    }

    public override string ToString()
    {
      if (_year > 0)
      {
        StringBuilder sb;

        sb = StringBuilderCache.Acquire();

        if (_year < -_maximumYearsBeforeSeparators || _year > _maximumYearsBeforeSeparators)
        {
          sb.Append(_year.ToString("N0", CultureInfo.InvariantCulture));
        }
        else
        {
          sb.Append(_year.ToString(CultureInfo.InvariantCulture));
        }

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

      return string.Empty;
    }

    #endregion Public Methods

    #region Private Methods

    private static JulianDate FromPartial(int year, int month, int day, JulianEra era)
    {
      JulianDate result;

      if (day > 0)
      {
        result = new JulianDate(year, month, day, era);
      }
      else if (month > 0)
      {
        result = new JulianDate(year, month, era);
      }
      else
      {
        result = new JulianDate(year, era);
      }

      return result;
    }

    private static JulianDate FromYearAndDay(int year, int dayOfYear, JulianEra era)
    {
      JulianDate result;

      if (dayOfYear != 0)
      {
        JulianDate.MonthFromDayOfYear(year, dayOfYear, era, out int month, out int day);

        result = new JulianDate(year, month, day, era);
      }
      else
      {
        result = new JulianDate(year, era);
      }

      return result;
    }

    private static int GetRelativeYear(long absoluteYear, out JulianEra era)
    {
      int year;

      if (absoluteYear >= int.MaxValue)
      {
        year = (int)(absoluteYear - int.MaxValue) + 1;
        era = JulianEra.Ad;
      }
      else
      {
        year = -(int)(absoluteYear - int.MaxValue);
        era = JulianEra.Bc;
      }

      return year;
    }

    private static void MonthFromDayOfYear(int year, int dayOfYear, JulianEra era, out int month, out int day)
    {
      if (dayOfYear > 0)
      {
        int[] days;

        days = JulianDate.IsLeapYear(year, era)
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

    private static void RotateYear(ref int y, out JulianEra era)
    {
      if (y > 0)
      {
        era = JulianEra.Ad;
      }
      else
      {
        era = JulianEra.Bc;
        y = -y + 1;
      }
    }

    #endregion Private Methods
  }
}