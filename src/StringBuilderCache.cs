using System;
using System.Text;

namespace Cyotek
{
  internal static class StringBuilderCache
  {
    #region Private Fields

    private const int _defaultCapacity = 16;

    private const int _maxBuilderSize = 360;

    [ThreadStatic]
    private static StringBuilder _cachedInstance;

    #endregion Private Fields

    #region Public Methods

    public static StringBuilder Acquire()
    {
      return StringBuilderCache.Acquire(_defaultCapacity);
    }

    public static StringBuilder Acquire(int capacity)
    {
      StringBuilder result;

      result = null;

      if (capacity <= _maxBuilderSize)
      {
        StringBuilder cachedInstance;

        cachedInstance = _cachedInstance;

        if (cachedInstance != null && capacity <= cachedInstance.Capacity)
        {
          _cachedInstance = null;
          cachedInstance.Length = 0;
          result = cachedInstance;
        }
      }

      return result ?? new StringBuilder(capacity);
    }

    public static string GetStringAndRelease(StringBuilder sb)
    {
      string result;

      result = sb.ToString();
      StringBuilderCache.Release(sb);

      return result;
    }

    public static void Release(StringBuilder sb)
    {
      if (sb.Capacity <= _maxBuilderSize)
      {
        _cachedInstance = sb;
      }
    }

    public static string ToStringAndRelease(this StringBuilder sb)
    {
      return StringBuilderCache.GetStringAndRelease(sb);
    }

    #endregion Public Methods
  }
}