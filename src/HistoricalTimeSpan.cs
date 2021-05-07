using System.Globalization;
using System.Text;

namespace Cyotek
{
  public readonly struct HistoricalTimeSpan
  {
    #region Public Fields

    public static readonly HistoricalTimeSpan Zero = new HistoricalTimeSpan(0);

    #endregion Public Fields

    #region Private Fields

    private const int _daysPerYear = 365;

    private const int _hoursPerDay = 24;

    private const int _minutesPerHour = 60;

    private const int _secondsPerDay = _secondsPerHour * _hoursPerDay;

    private const int _secondsPerHour = _minutesPerHour * _secondsPerMinute;

    private const int _secondsPerMinute = 60;

    private const int _secondsPerYear = _secondsPerDay * _daysPerYear;

    private readonly long _ticks;

    #endregion Private Fields

    #region Public Constructors

    public HistoricalTimeSpan(long ticks)
    {
      _ticks = ticks;
    }

    public HistoricalTimeSpan(int hours, int minutes, int seconds)
      : this(0, hours, minutes, seconds)
    {
    }

    public HistoricalTimeSpan(long days, int hours, int minutes, int seconds)
    {
      _ticks = (days * _secondsPerDay) + (hours * _secondsPerHour) + (minutes * _secondsPerMinute) + seconds;
    }

    #endregion Public Constructors

    #region Public Properties

    public int Days => (int)(_ticks / _secondsPerDay);

    public int Hours => (int)(_ticks / _secondsPerHour % _hoursPerDay);

    public int Minutes => (int)(_ticks / _secondsPerMinute % _minutesPerHour);

    public int Seconds => (int)(_ticks % _secondsPerMinute);

    public long Ticks => _ticks;

    public int Years => (int)(_ticks / _secondsPerYear);

    #endregion Public Properties

    #region Public Methods

    public static HistoricalTimeSpan FromDays(long days)
    {
      return new HistoricalTimeSpan(days * _secondsPerDay);
    }

    public override string ToString()
    {
      StringBuilder sb;

      sb = StringBuilderCache.Acquire();

      if (this.Days != 0)
      {
        sb.Append(this.Days.ToString(CultureInfo.InvariantCulture));
        sb.Append('.');
      }

      sb.Append(this.Hours.ToString("00", CultureInfo.InvariantCulture));
      sb.Append(':');
      sb.Append(this.Minutes.ToString("00", CultureInfo.InvariantCulture));
      sb.Append(':');
      sb.Append(this.Seconds.ToString("00", CultureInfo.InvariantCulture));

      return sb.ToStringAndRelease();
    }

    #endregion Public Methods
  }
}