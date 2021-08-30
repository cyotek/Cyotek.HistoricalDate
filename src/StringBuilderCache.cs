﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/runtime/blob/ab56a06ce4c09c1f923cc55a8a29b40bbf2fdc4a/src/libraries/Common/src/System/Text/StringBuilderCache.cs#L1

namespace System.Text
{
  /// <summary>Provide a cached reusable instance of stringbuilder per thread.</summary>
  internal static class StringBuilderCache
  {
    // The value 360 was chosen in discussion with performance experts as a compromise between using
    // as little memory per thread as possible and still covering a large part of short-lived
    // StringBuilder creations on the startup path of VS designers.
    internal const int MaxBuilderSize = 360;
    private const int DefaultCapacity = 16; // == StringBuilder.DefaultCapacity

    // WARNING: We allow diagnostic tools to directly inspect this member (t_cachedInstance).
    // See https://github.com/dotnet/corert/blob/master/Documentation/design-docs/diagnostics/diagnostics-tools-contract.md for more details.
    // Please do not change the type, the name, or the semantic usage of this member without understanding the implication for tools.
    // Get in touch with the diagnostics team if you have questions.
    [ThreadStatic]
    private static StringBuilder t_cachedInstance;

    /// <summary>Get a StringBuilder for the specified capacity.</summary>
    /// <remarks>If a StringBuilder of an appropriate size is cached, it will be returned and the cache emptied.</remarks>
    public static StringBuilder Acquire(int capacity = DefaultCapacity)
    {
      if (capacity <= MaxBuilderSize)
      {
        StringBuilder sb = t_cachedInstance;
        if (sb != null)
        {
          // Avoid stringbuilder block fragmentation by getting a new StringBuilder
          // when the requested size is larger than the current capacity
          if (capacity <= sb.Capacity)
          {
            t_cachedInstance = null;
            sb.Length = 0;
            return sb;
          }
        }
      }

      return new StringBuilder(capacity);
    }

    /// <summary>Place the specified builder in the cache if it is not too big.</summary>
    public static void Release(StringBuilder sb)
    {
      if (sb.Capacity <= MaxBuilderSize)
      {
        t_cachedInstance = sb;
      }
    }

    /// <summary>ToString() the stringbuilder, Release it to the cache, and return the resulting string.</summary>
    public static string GetStringAndRelease(StringBuilder sb)
    {
      string result = sb.ToString();
      Release(sb);
      return result;
    }
  }
}
