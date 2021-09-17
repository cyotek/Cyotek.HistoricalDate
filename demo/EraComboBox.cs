// Cyotek.HistoricalDate Library
// https://github.com/cyotek/Cyotek.HistoricalDate

// Copyright (c) 2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System.ComponentModel;
using System.Windows.Forms;

namespace Cyotek.Demo.Windows.Forms
{
  internal sealed class EraComboBox : ComboBox
  {
    #region Public Constructors

    public EraComboBox()
    {
      base.Items.Add("BC");
      base.Items.Add("AD");

      base.DropDownStyle = ComboBoxStyle.DropDownList;
      base.FormattingEnabled = false;
    }

    

    #endregion Public Constructors

    #region Public Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new ComboBoxStyle DropDownStyle
    {
      get => base.DropDownStyle;
      set => base.DropDownStyle = value;
    }
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool FormattingEnabled
    {
      get => base.FormattingEnabled;
      set => base.FormattingEnabled = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public JulianEra Era
    {
      get => this.SelectedIndex != -1
        ? (JulianEra)(this.SelectedIndex + 1)
        : JulianEra.Ad;
      set => this.SelectedIndex = (int)value - 1;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new ObjectCollection Items => base.Items;

    #endregion Public Properties
  }
}