using System;
using System.ComponentModel;
using System.Globalization;

namespace Cyotek
{
  public class JulianDateConverter : TypeConverter
  {
    #region Public Methods

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      return value is string s && !string.IsNullOrEmpty(s)
        ? JulianDate.Parse(s)
        : base.ConvertFrom(context, culture, value);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      return value is JulianDate date && destinationType == typeof(string)
        ? date.ToString()
        : base.ConvertTo(context, culture, value, destinationType);
    }

    #endregion Public Methods
  }
}