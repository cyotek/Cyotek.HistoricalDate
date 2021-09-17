// Cyotek.HistoricalDate Library
// https://github.com/cyotek/Cyotek.HistoricalDate

// Copyright (c) 2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.Windows.Forms;

namespace Cyotek.Demo.Windows.Forms
{
  internal partial class MainForm : BaseForm
  {
    #region Private Fields

    private JulianDate _current;

    #endregion Private Fields

    #region Public Constructors

    public MainForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnShown(EventArgs e)
    {
      isLeapYearEraComboBox.Era = JulianEra.Bc;
      this.LoadDefaultDates();

      base.OnShown(e);

      this.LoadDateFields((JulianDate)DateTime.UtcNow);
      this.PerformLeapYearTest();
      this.PerformAddDays();
      this.PerformAddMonths();
      this.PerformAddYears();
      this.PerformSubtract();
    }

    #endregion Protected Methods

    #region Private Methods

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutDialog.ShowAboutDialog();
    }

    private void AddDaysButton_Click(object sender, EventArgs e)
    {
      this.PerformAddDays();
    }

    private void AddMonthsButton_Click(object sender, EventArgs e)
    {
      this.PerformAddMonths();
    }

    private void AddYearsButton_Click(object sender, EventArgs e)
    {
      this.PerformAddYears();
    }

    private void CreateButton_Click(object sender, EventArgs e)
    {
      this.TryBuildDate();
    }

    private void CyotekLinkToolStripStatusLabel_Click(object sender, EventArgs e)
    {
      AboutDialog.OpenCyotekHomePage();

      cyotekLinkToolStripStatusLabel.LinkVisited = true;
    }

    private void DatesListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (datesListBox.SelectedItem is string s && JulianDate.TryParse(s, out JulianDate date))
      {
        this.LoadDateFields(date);
      }
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void FromBinaryButton_Click(object sender, EventArgs e)
    {
      this.TryParseBinary();
    }

    private void IsLeapYearButton_Click(object sender, EventArgs e)
    {
      this.PerformLeapYearTest();
    }

    private void LoadDateFields(JulianDate date)
    {
      _current = date;

      currentDateToolStripStatusLabel.Text = date.IsEmpty
        ? "Empty"
        : date.ToString();

      this.SetBoolFlag(isEmptyTextBox, date.IsEmpty);
      this.SetBoolFlag(hasMonthTextBox, date.HasMonth);
      this.SetBoolFlag(hasDayTextBox, date.HasDay);
      this.SetBoolFlag(isFullyKnownTextBox, date.IsFullyKnown);
      this.SetBoolFlag(isPartialTextBox, date.IsPartial);

      dayTextBox.Text = date.HasDay
        ? date.Day.ToString()
        : string.Empty;
      monthTextBox.Text = date.HasMonth
        ? date.Month.ToString()
        : string.Empty;
      dayOfYearTextBox.Text = date.HasDay
        ? date.DayOfYear.ToString()
        : string.Empty;
      yearTextBox.Text = date.Year.ToString();
      eraTextBox.Text = date.Era.ToString();

      formatTextBox.Text = date.ToString();
      binaryTextBox.Text = date.ToBinary().ToString();
    }

    private void LoadDefaultDates()
    {
      datesListBox.BeginUpdate();
      datesListBox.Items.Add("500,000 BP");
      datesListBox.Items.Add("130,000 BP");
      datesListBox.Items.Add("40,000 BP");
      datesListBox.Items.Add("13,000 BP");
      datesListBox.Items.Add("10,000 BP");
      datesListBox.Items.Add("5000 BC");
      datesListBox.Items.Add("3500 BC");
      datesListBox.Items.Add("3000 BC");
      datesListBox.Items.Add("2500 BC");
      datesListBox.Items.Add("2150 BC");
      datesListBox.Items.Add("1500 BC");
      datesListBox.Items.Add("1250 BC");
      datesListBox.Items.Add("750 BC");
      datesListBox.Items.Add("450 BC");
      datesListBox.Items.Add("150 BC");
      datesListBox.Items.Add("43 AD");
      datesListBox.Items.Add("43 AD");
      datesListBox.Items.Add("2021-08-29");
      datesListBox.Items.Add("2021/08/29");
      datesListBox.Items.Add("2021 08 29");
      datesListBox.Items.Add("08 2021");
      datesListBox.Items.Add("2021");
      datesListBox.Items.Add("2021 BC");
      datesListBox.Items.Add("2021 AD");
      datesListBox.Items.Add("08 2021 BC");
      datesListBox.Items.Add("08 2021 AD");
      datesListBox.Items.Add("2021 08 29 BC");
      datesListBox.Items.Add("2021 08 29 AD");
      datesListBox.EndUpdate();
    }

    private void ParseButton_Click(object sender, EventArgs e)
    {
      this.TryParseDate();
    }

    private void PerformAddDays()
    {
      this.WrapAction(() =>
      {
        addDaysResultTextBox.Text = int.TryParse(addDaysTextBox.Text, out int days)
          ? _current.AddDays(days).ToString()
          : string.Empty;
      });
    }

    private void PerformAddMonths()
    {
      this.WrapAction(() =>
      {
        addMonthsResultTextBox.Text = int.TryParse(addMonthsTextBox.Text, out int months)
          ? _current.AddMonths(months).ToString()
          : string.Empty;
      });
    }

    private void PerformAddYears()
    {
      this.WrapAction(() =>
      {
        addYearsResultTextBox.Text = int.TryParse(addYearsTextBox.Text, out int years)
          ? _current.AddYears(years).ToString()
          : string.Empty;
      });
    }

    private void PerformLeapYearTest()
    {
      if (!string.IsNullOrEmpty(isLeapYearYearTextBox.Text) && int.TryParse(isLeapYearYearTextBox.Text, out int year))
      {
        bool isLeapYear;

        isLeapYear = JulianDate.IsLeapYear(year, isLeapYearEraComboBox.Era);

        this.SetBoolFlag(isLeapYearResultTextBox, isLeapYear);
      }
      else
      {
        isLeapYearResultTextBox.Text = string.Empty;
      }
    }

    private void PerformSubtract()
    {
      this.WrapAction(() =>
      {
        subtractResultTextBox.Text = JulianDate.TryParse(subtractTextBox.Text, out JulianDate date)
          ? (date - _current).ToString()
          : string.Empty;
      });
    }

    private void SetBoolFlag(TextBox control, bool flag)
    {
      control.Text = flag
        ? "Yes"
        : "No";
    }

    private void SubtractButton_Click(object sender, EventArgs e)
    {
      this.PerformSubtract();
    }

    private void TryBuildDate()
    {
      this.WrapAction(() =>
      {
        JulianDate date;

        date = JulianDate.Empty;

        if (int.TryParse(newYearTextBox.Text, out int year))
        {
          JulianEra era;

          era = newEraComboBox.Era;

          if (string.IsNullOrEmpty(newMonthTextBox.Text))
          {
            date = new JulianDate(year, era);
          }
          else if (int.TryParse(newMonthTextBox.Text, out int month))
          {
            if (string.IsNullOrEmpty(newDayTextBox.Text))
            {
              date = new JulianDate(year, month, era);
            }
            else if (int.TryParse(newDayTextBox.Text, out int day))
            {
              date = new JulianDate(year, month, day, era);
            }
          }
        }

        statusToolStripStatusLabel.Text = !date.IsEmpty
          ? string.Empty
          : "Invalid date entered";

        this.LoadDateFields(date);
      });
    }

    private void TryParseBinary()
    {
      this.WrapAction(() =>
      {
        JulianDate date;

        date = !string.IsNullOrEmpty(fromBinaryTextBox.Text) && long.TryParse(fromBinaryTextBox.Text, out long value)
          ? JulianDate.FromBinary(value)
          : JulianDate.Empty;

        statusToolStripStatusLabel.Text = !date.IsEmpty
          ? string.Empty
          : "Invalid date entered";

        this.LoadDateFields(date);
      });
    }

    private void TryParseDate()
    {
      this.WrapAction(() =>
      {
        JulianDate date;

        date = !string.IsNullOrEmpty(parseTextBox.Text)
          ? JulianDate.Parse(parseTextBox.Text)
          : JulianDate.Empty;

        statusToolStripStatusLabel.Text = !date.IsEmpty
          ? string.Empty
          : "Invalid date entered";

        this.LoadDateFields(date);
      });
    }

    private void WrapAction(Action action)
    {
      try
      {
        action();
      }
      catch (Exception ex)
      {
        statusToolStripStatusLabel.Text = ex.Message;
      }
    }

    #endregion Private Methods
  }
}