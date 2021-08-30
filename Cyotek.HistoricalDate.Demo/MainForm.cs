using System;
using System.Windows.Forms;

namespace Cyotek.Demo.Windows.Forms
{
  internal partial class MainForm : BaseForm
  {
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
    }

    #endregion Protected Methods

    #region Private Methods

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutDialog.ShowAboutDialog();
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

    private void LoadDateFields(JulianDate date)
    {
      this.SetBoolFlag(isEmptyTextBox, date.IsEmpty);
      this.SetBoolFlag(hasMonthTextBox, date.HasMonth);
      this.SetBoolFlag(hasDayTextBox, date.HasDay);

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

    private void SetBoolFlag(TextBox control, bool flag)
    {
      control.Text = flag
        ? "Yes"
        : "No";
    }

    private void TryBuildDate()
    {
      try
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
      }
      catch (Exception ex)
      {
        statusToolStripStatusLabel.Text = ex.Message;
      }
    }

    private void TryParseBinary()
    {
      try
      {
        JulianDate date;

        date = !string.IsNullOrEmpty(fromBinaryTextBox.Text) && long.TryParse(fromBinaryTextBox.Text, out long value)
          ? JulianDate.FromBinary(value)
          : JulianDate.Empty;

        statusToolStripStatusLabel.Text = !date.IsEmpty
          ? string.Empty
          : "Invalid date entered";

        this.LoadDateFields(date);
      }
      catch (Exception ex)
      {
        statusToolStripStatusLabel.Text = ex.Message;
      }
    }

    private void TryParseDate()
    {
      try
      {
        JulianDate date;

        date = !string.IsNullOrEmpty(parseTextBox.Text)
          ? JulianDate.Parse(parseTextBox.Text)
          : JulianDate.Empty;

        statusToolStripStatusLabel.Text = !date.IsEmpty
          ? string.Empty
          : "Invalid date entered";

        this.LoadDateFields(date);
      }
      catch (Exception ex)
      {
        statusToolStripStatusLabel.Text = ex.Message;
      }
    }

    #endregion Private Methods
  }
}