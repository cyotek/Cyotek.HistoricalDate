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
      object result;

      if (value is string s && !string.IsNullOrEmpty(s))
      {
        result = JulianDate.Parse(s);
      }
      else
      {
        result = null;
      }

      return result ?? base.ConvertFrom(context, culture, value);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      object result;

      if (value is JulianDate date && destinationType == typeof(string))
      {
        result = date.ToString();
      }
      else
      {
        result = base.ConvertTo(context, culture, value, destinationType);
      }

      return result;
    }

    #endregion Public Methods
  }
}