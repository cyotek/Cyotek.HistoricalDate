
namespace Cyotek.Demo.Windows.Forms
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.Label newDayLabel;
      System.Windows.Forms.Label newMonthLabel;
      System.Windows.Forms.Label newYearLabel;
      System.Windows.Forms.Label newEraLabel;
      System.Windows.Forms.Label formatLabel;
      System.Windows.Forms.Label hasDayLabel;
      System.Windows.Forms.Label hasMonthLabel;
      System.Windows.Forms.Label isEmptyLabel;
      System.Windows.Forms.Label datesLabel;
      System.Windows.Forms.Label binaryLabel;
      System.Windows.Forms.Label dayOfYearLabel;
      System.Windows.Forms.GroupBox attributesGroupBox;
      System.Windows.Forms.Label dayLabel;
      System.Windows.Forms.Label monthLabel;
      System.Windows.Forms.Label yearLabel;
      System.Windows.Forms.Label eraLabel;
      Cyotek.Windows.Forms.Line line2;
      Cyotek.Windows.Forms.Line line1;
      System.Windows.Forms.GroupBox createGroupBox;
      System.Windows.Forms.Button fromBinaryButton;
      System.Windows.Forms.Button parseButton;
      System.Windows.Forms.Button createButton;
      System.Windows.Forms.Label fromBinaryLabel;
      Cyotek.Windows.Forms.Line line5;
      Cyotek.Windows.Forms.Line line4;
      Cyotek.Windows.Forms.Line line3;
      System.Windows.Forms.Label parseLabel;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
      System.Windows.Forms.Panel panel1;
      System.Windows.Forms.GroupBox isLeapYearGroupBox;
      System.Windows.Forms.Button isLeapYearButton;
      System.Windows.Forms.Label label3;
      System.Windows.Forms.Label label1;
      System.Windows.Forms.MenuStrip menuStrip;
      System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      System.Windows.Forms.StatusStrip statusStrip;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.dayTextBox = new System.Windows.Forms.TextBox();
      this.eraTextBox = new System.Windows.Forms.TextBox();
      this.monthTextBox = new System.Windows.Forms.TextBox();
      this.yearTextBox = new System.Windows.Forms.TextBox();
      this.binaryTextBox = new System.Windows.Forms.TextBox();
      this.isEmptyTextBox = new System.Windows.Forms.TextBox();
      this.dayOfYearTextBox = new System.Windows.Forms.TextBox();
      this.formatTextBox = new System.Windows.Forms.TextBox();
      this.hasMonthTextBox = new System.Windows.Forms.TextBox();
      this.hasDayTextBox = new System.Windows.Forms.TextBox();
      this.fromBinaryTextBox = new System.Windows.Forms.TextBox();
      this.parseTextBox = new System.Windows.Forms.TextBox();
      this.datesListBox = new System.Windows.Forms.ListBox();
      this.newDayTextBox = new System.Windows.Forms.TextBox();
      this.newEraComboBox = new Cyotek.Demo.Windows.Forms.EraComboBox();
      this.newMonthTextBox = new System.Windows.Forms.TextBox();
      this.newYearTextBox = new System.Windows.Forms.TextBox();
      this.isLeapYearResultTextBox = new System.Windows.Forms.TextBox();
      this.isLeapYearYearTextBox = new System.Windows.Forms.TextBox();
      this.isLeapYearEraComboBox = new Cyotek.Demo.Windows.Forms.EraComboBox();
      this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.cyotekLinkToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      newDayLabel = new System.Windows.Forms.Label();
      newMonthLabel = new System.Windows.Forms.Label();
      newYearLabel = new System.Windows.Forms.Label();
      newEraLabel = new System.Windows.Forms.Label();
      formatLabel = new System.Windows.Forms.Label();
      hasDayLabel = new System.Windows.Forms.Label();
      hasMonthLabel = new System.Windows.Forms.Label();
      isEmptyLabel = new System.Windows.Forms.Label();
      datesLabel = new System.Windows.Forms.Label();
      binaryLabel = new System.Windows.Forms.Label();
      dayOfYearLabel = new System.Windows.Forms.Label();
      attributesGroupBox = new System.Windows.Forms.GroupBox();
      dayLabel = new System.Windows.Forms.Label();
      monthLabel = new System.Windows.Forms.Label();
      yearLabel = new System.Windows.Forms.Label();
      eraLabel = new System.Windows.Forms.Label();
      line2 = new Cyotek.Windows.Forms.Line();
      line1 = new Cyotek.Windows.Forms.Line();
      createGroupBox = new System.Windows.Forms.GroupBox();
      fromBinaryButton = new System.Windows.Forms.Button();
      parseButton = new System.Windows.Forms.Button();
      createButton = new System.Windows.Forms.Button();
      fromBinaryLabel = new System.Windows.Forms.Label();
      line5 = new Cyotek.Windows.Forms.Line();
      line4 = new Cyotek.Windows.Forms.Line();
      line3 = new Cyotek.Windows.Forms.Line();
      parseLabel = new System.Windows.Forms.Label();
      tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      panel1 = new System.Windows.Forms.Panel();
      isLeapYearGroupBox = new System.Windows.Forms.GroupBox();
      isLeapYearButton = new System.Windows.Forms.Button();
      label3 = new System.Windows.Forms.Label();
      label1 = new System.Windows.Forms.Label();
      menuStrip = new System.Windows.Forms.MenuStrip();
      fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      statusStrip = new System.Windows.Forms.StatusStrip();
      attributesGroupBox.SuspendLayout();
      createGroupBox.SuspendLayout();
      tableLayoutPanel.SuspendLayout();
      panel1.SuspendLayout();
      isLeapYearGroupBox.SuspendLayout();
      menuStrip.SuspendLayout();
      statusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // newDayLabel
      // 
      newDayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      newDayLabel.AutoSize = true;
      newDayLabel.Location = new System.Drawing.Point(3, 417);
      newDayLabel.Name = "newDayLabel";
      newDayLabel.Size = new System.Drawing.Size(29, 13);
      newDayLabel.TabIndex = 8;
      newDayLabel.Text = "&Day:";
      // 
      // newMonthLabel
      // 
      newMonthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      newMonthLabel.AutoSize = true;
      newMonthLabel.Location = new System.Drawing.Point(3, 391);
      newMonthLabel.Name = "newMonthLabel";
      newMonthLabel.Size = new System.Drawing.Size(40, 13);
      newMonthLabel.TabIndex = 6;
      newMonthLabel.Text = "&Month:";
      // 
      // newYearLabel
      // 
      newYearLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      newYearLabel.AutoSize = true;
      newYearLabel.Location = new System.Drawing.Point(3, 365);
      newYearLabel.Name = "newYearLabel";
      newYearLabel.Size = new System.Drawing.Size(32, 13);
      newYearLabel.TabIndex = 4;
      newYearLabel.Text = "&Year:";
      // 
      // newEraLabel
      // 
      newEraLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      newEraLabel.AutoSize = true;
      newEraLabel.Location = new System.Drawing.Point(3, 338);
      newEraLabel.Name = "newEraLabel";
      newEraLabel.Size = new System.Drawing.Size(26, 13);
      newEraLabel.TabIndex = 2;
      newEraLabel.Text = "&Era:";
      // 
      // formatLabel
      // 
      formatLabel.AutoSize = true;
      formatLabel.Location = new System.Drawing.Point(3, 247);
      formatLabel.Name = "formatLabel";
      formatLabel.Size = new System.Drawing.Size(37, 13);
      formatLabel.TabIndex = 16;
      formatLabel.Text = "&String:";
      // 
      // hasDayLabel
      // 
      hasDayLabel.AutoSize = true;
      hasDayLabel.Location = new System.Drawing.Point(3, 74);
      hasDayLabel.Name = "hasDayLabel";
      hasDayLabel.Size = new System.Drawing.Size(51, 13);
      hasDayLabel.TabIndex = 4;
      hasDayLabel.Text = "Has Day:";
      // 
      // hasMonthLabel
      // 
      hasMonthLabel.AutoSize = true;
      hasMonthLabel.Location = new System.Drawing.Point(3, 48);
      hasMonthLabel.Name = "hasMonthLabel";
      hasMonthLabel.Size = new System.Drawing.Size(62, 13);
      hasMonthLabel.TabIndex = 2;
      hasMonthLabel.Text = "Has Month:";
      // 
      // isEmptyLabel
      // 
      isEmptyLabel.AutoSize = true;
      isEmptyLabel.Location = new System.Drawing.Point(3, 22);
      isEmptyLabel.Name = "isEmptyLabel";
      isEmptyLabel.Size = new System.Drawing.Size(50, 13);
      isEmptyLabel.TabIndex = 0;
      isEmptyLabel.Text = "Is Empty:";
      // 
      // datesLabel
      // 
      datesLabel.AutoSize = true;
      datesLabel.Location = new System.Drawing.Point(3, 16);
      datesLabel.Name = "datesLabel";
      datesLabel.Size = new System.Drawing.Size(95, 13);
      datesLabel.TabIndex = 0;
      datesLabel.Text = "&Pre-defined Dates:";
      // 
      // binaryLabel
      // 
      binaryLabel.AutoSize = true;
      binaryLabel.Location = new System.Drawing.Point(3, 273);
      binaryLabel.Name = "binaryLabel";
      binaryLabel.Size = new System.Drawing.Size(39, 13);
      binaryLabel.TabIndex = 18;
      binaryLabel.Text = "&Binary:";
      // 
      // dayOfYearLabel
      // 
      dayOfYearLabel.AutoSize = true;
      dayOfYearLabel.Location = new System.Drawing.Point(3, 212);
      dayOfYearLabel.Name = "dayOfYearLabel";
      dayOfYearLabel.Size = new System.Drawing.Size(66, 13);
      dayOfYearLabel.TabIndex = 14;
      dayOfYearLabel.Text = "Day &of Year:";
      // 
      // attributesGroupBox
      // 
      attributesGroupBox.Controls.Add(dayLabel);
      attributesGroupBox.Controls.Add(monthLabel);
      attributesGroupBox.Controls.Add(yearLabel);
      attributesGroupBox.Controls.Add(this.dayTextBox);
      attributesGroupBox.Controls.Add(eraLabel);
      attributesGroupBox.Controls.Add(this.eraTextBox);
      attributesGroupBox.Controls.Add(this.monthTextBox);
      attributesGroupBox.Controls.Add(this.yearTextBox);
      attributesGroupBox.Controls.Add(line2);
      attributesGroupBox.Controls.Add(line1);
      attributesGroupBox.Controls.Add(this.binaryTextBox);
      attributesGroupBox.Controls.Add(this.isEmptyTextBox);
      attributesGroupBox.Controls.Add(binaryLabel);
      attributesGroupBox.Controls.Add(dayOfYearLabel);
      attributesGroupBox.Controls.Add(this.dayOfYearTextBox);
      attributesGroupBox.Controls.Add(this.formatTextBox);
      attributesGroupBox.Controls.Add(formatLabel);
      attributesGroupBox.Controls.Add(isEmptyLabel);
      attributesGroupBox.Controls.Add(this.hasMonthTextBox);
      attributesGroupBox.Controls.Add(hasMonthLabel);
      attributesGroupBox.Controls.Add(this.hasDayTextBox);
      attributesGroupBox.Controls.Add(hasDayLabel);
      attributesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      attributesGroupBox.Location = new System.Drawing.Point(282, 3);
      attributesGroupBox.Name = "attributesGroupBox";
      attributesGroupBox.Size = new System.Drawing.Size(273, 515);
      attributesGroupBox.TabIndex = 1;
      attributesGroupBox.TabStop = false;
      attributesGroupBox.Text = "Attributes";
      // 
      // dayLabel
      // 
      dayLabel.AutoSize = true;
      dayLabel.Location = new System.Drawing.Point(3, 186);
      dayLabel.Name = "dayLabel";
      dayLabel.Size = new System.Drawing.Size(29, 13);
      dayLabel.TabIndex = 12;
      dayLabel.Text = "&Day:";
      // 
      // monthLabel
      // 
      monthLabel.AutoSize = true;
      monthLabel.Location = new System.Drawing.Point(3, 160);
      monthLabel.Name = "monthLabel";
      monthLabel.Size = new System.Drawing.Size(40, 13);
      monthLabel.TabIndex = 10;
      monthLabel.Text = "Mo&nth:";
      // 
      // yearLabel
      // 
      yearLabel.AutoSize = true;
      yearLabel.Location = new System.Drawing.Point(3, 134);
      yearLabel.Name = "yearLabel";
      yearLabel.Size = new System.Drawing.Size(32, 13);
      yearLabel.TabIndex = 8;
      yearLabel.Text = "Ye&ar:";
      // 
      // dayTextBox
      // 
      this.dayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dayTextBox.Location = new System.Drawing.Point(75, 183);
      this.dayTextBox.Name = "dayTextBox";
      this.dayTextBox.ReadOnly = true;
      this.dayTextBox.Size = new System.Drawing.Size(192, 20);
      this.dayTextBox.TabIndex = 13;
      // 
      // eraLabel
      // 
      eraLabel.AutoSize = true;
      eraLabel.Location = new System.Drawing.Point(3, 108);
      eraLabel.Name = "eraLabel";
      eraLabel.Size = new System.Drawing.Size(26, 13);
      eraLabel.TabIndex = 6;
      eraLabel.Text = "E&ra:";
      // 
      // eraTextBox
      // 
      this.eraTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.eraTextBox.Location = new System.Drawing.Point(75, 105);
      this.eraTextBox.Name = "eraTextBox";
      this.eraTextBox.ReadOnly = true;
      this.eraTextBox.Size = new System.Drawing.Size(192, 20);
      this.eraTextBox.TabIndex = 7;
      // 
      // monthTextBox
      // 
      this.monthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.monthTextBox.Location = new System.Drawing.Point(75, 157);
      this.monthTextBox.Name = "monthTextBox";
      this.monthTextBox.ReadOnly = true;
      this.monthTextBox.Size = new System.Drawing.Size(192, 20);
      this.monthTextBox.TabIndex = 11;
      // 
      // yearTextBox
      // 
      this.yearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.yearTextBox.Location = new System.Drawing.Point(75, 131);
      this.yearTextBox.Name = "yearTextBox";
      this.yearTextBox.ReadOnly = true;
      this.yearTextBox.Size = new System.Drawing.Size(192, 20);
      this.yearTextBox.TabIndex = 9;
      // 
      // line2
      // 
      line2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      line2.Location = new System.Drawing.Point(6, 236);
      line2.Name = "line2";
      line2.Size = new System.Drawing.Size(261, 2);
      line2.Text = "line2";
      // 
      // line1
      // 
      line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      line1.Location = new System.Drawing.Point(6, 97);
      line1.Name = "line1";
      line1.Size = new System.Drawing.Size(261, 2);
      line1.Text = "line1";
      // 
      // binaryTextBox
      // 
      this.binaryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.binaryTextBox.Location = new System.Drawing.Point(75, 270);
      this.binaryTextBox.Name = "binaryTextBox";
      this.binaryTextBox.ReadOnly = true;
      this.binaryTextBox.Size = new System.Drawing.Size(192, 20);
      this.binaryTextBox.TabIndex = 19;
      // 
      // isEmptyTextBox
      // 
      this.isEmptyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.isEmptyTextBox.Location = new System.Drawing.Point(75, 19);
      this.isEmptyTextBox.Name = "isEmptyTextBox";
      this.isEmptyTextBox.ReadOnly = true;
      this.isEmptyTextBox.Size = new System.Drawing.Size(192, 20);
      this.isEmptyTextBox.TabIndex = 1;
      // 
      // dayOfYearTextBox
      // 
      this.dayOfYearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dayOfYearTextBox.Location = new System.Drawing.Point(75, 209);
      this.dayOfYearTextBox.Name = "dayOfYearTextBox";
      this.dayOfYearTextBox.ReadOnly = true;
      this.dayOfYearTextBox.Size = new System.Drawing.Size(192, 20);
      this.dayOfYearTextBox.TabIndex = 15;
      // 
      // formatTextBox
      // 
      this.formatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.formatTextBox.Location = new System.Drawing.Point(75, 244);
      this.formatTextBox.Name = "formatTextBox";
      this.formatTextBox.ReadOnly = true;
      this.formatTextBox.Size = new System.Drawing.Size(192, 20);
      this.formatTextBox.TabIndex = 17;
      // 
      // hasMonthTextBox
      // 
      this.hasMonthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hasMonthTextBox.Location = new System.Drawing.Point(75, 45);
      this.hasMonthTextBox.Name = "hasMonthTextBox";
      this.hasMonthTextBox.ReadOnly = true;
      this.hasMonthTextBox.Size = new System.Drawing.Size(192, 20);
      this.hasMonthTextBox.TabIndex = 3;
      // 
      // hasDayTextBox
      // 
      this.hasDayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hasDayTextBox.Location = new System.Drawing.Point(75, 71);
      this.hasDayTextBox.Name = "hasDayTextBox";
      this.hasDayTextBox.ReadOnly = true;
      this.hasDayTextBox.Size = new System.Drawing.Size(192, 20);
      this.hasDayTextBox.TabIndex = 5;
      // 
      // createGroupBox
      // 
      createGroupBox.Controls.Add(fromBinaryButton);
      createGroupBox.Controls.Add(parseButton);
      createGroupBox.Controls.Add(createButton);
      createGroupBox.Controls.Add(this.fromBinaryTextBox);
      createGroupBox.Controls.Add(fromBinaryLabel);
      createGroupBox.Controls.Add(line5);
      createGroupBox.Controls.Add(line4);
      createGroupBox.Controls.Add(line3);
      createGroupBox.Controls.Add(parseLabel);
      createGroupBox.Controls.Add(this.parseTextBox);
      createGroupBox.Controls.Add(this.datesListBox);
      createGroupBox.Controls.Add(datesLabel);
      createGroupBox.Controls.Add(newDayLabel);
      createGroupBox.Controls.Add(newMonthLabel);
      createGroupBox.Controls.Add(newYearLabel);
      createGroupBox.Controls.Add(this.newDayTextBox);
      createGroupBox.Controls.Add(newEraLabel);
      createGroupBox.Controls.Add(this.newEraComboBox);
      createGroupBox.Controls.Add(this.newMonthTextBox);
      createGroupBox.Controls.Add(this.newYearTextBox);
      createGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      createGroupBox.Location = new System.Drawing.Point(3, 3);
      createGroupBox.Name = "createGroupBox";
      createGroupBox.Size = new System.Drawing.Size(273, 515);
      createGroupBox.TabIndex = 0;
      createGroupBox.TabStop = false;
      createGroupBox.Text = "Create";
      // 
      // fromBinaryButton
      // 
      fromBinaryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      fromBinaryButton.Location = new System.Drawing.Point(192, 486);
      fromBinaryButton.Name = "fromBinaryButton";
      fromBinaryButton.Size = new System.Drawing.Size(75, 23);
      fromBinaryButton.TabIndex = 16;
      fromBinaryButton.Text = "Parse";
      fromBinaryButton.UseVisualStyleBackColor = true;
      fromBinaryButton.Click += new System.EventHandler(this.FromBinaryButton_Click);
      // 
      // parseButton
      // 
      parseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      parseButton.Location = new System.Drawing.Point(192, 449);
      parseButton.Name = "parseButton";
      parseButton.Size = new System.Drawing.Size(75, 23);
      parseButton.TabIndex = 13;
      parseButton.Text = "Parse";
      parseButton.UseVisualStyleBackColor = true;
      parseButton.Click += new System.EventHandler(this.ParseButton_Click);
      // 
      // createButton
      // 
      createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      createButton.Location = new System.Drawing.Point(192, 412);
      createButton.Name = "createButton";
      createButton.Size = new System.Drawing.Size(75, 23);
      createButton.TabIndex = 10;
      createButton.Text = "Create";
      createButton.UseVisualStyleBackColor = true;
      createButton.Click += new System.EventHandler(this.CreateButton_Click);
      // 
      // fromBinaryTextBox
      // 
      this.fromBinaryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.fromBinaryTextBox.Location = new System.Drawing.Point(49, 488);
      this.fromBinaryTextBox.Name = "fromBinaryTextBox";
      this.fromBinaryTextBox.Size = new System.Drawing.Size(137, 20);
      this.fromBinaryTextBox.TabIndex = 15;
      this.fromBinaryTextBox.Text = "214748566720908800";
      // 
      // fromBinaryLabel
      // 
      fromBinaryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      fromBinaryLabel.AutoSize = true;
      fromBinaryLabel.Location = new System.Drawing.Point(3, 491);
      fromBinaryLabel.Name = "fromBinaryLabel";
      fromBinaryLabel.Size = new System.Drawing.Size(39, 13);
      fromBinaryLabel.TabIndex = 14;
      fromBinaryLabel.Text = "B&inary:";
      // 
      // line5
      // 
      line5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      line5.Location = new System.Drawing.Point(6, 478);
      line5.Name = "line5";
      line5.Size = new System.Drawing.Size(261, 2);
      line5.Text = "line5";
      // 
      // line4
      // 
      line4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      line4.Location = new System.Drawing.Point(6, 441);
      line4.Name = "line4";
      line4.Size = new System.Drawing.Size(261, 2);
      line4.Text = "line4";
      // 
      // line3
      // 
      line3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      line3.Location = new System.Drawing.Point(6, 327);
      line3.Name = "line3";
      line3.Size = new System.Drawing.Size(261, 2);
      line3.Text = "line3";
      // 
      // parseLabel
      // 
      parseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      parseLabel.AutoSize = true;
      parseLabel.Location = new System.Drawing.Point(3, 454);
      parseLabel.Name = "parseLabel";
      parseLabel.Size = new System.Drawing.Size(37, 13);
      parseLabel.TabIndex = 11;
      parseLabel.Text = "S&tring:";
      // 
      // parseTextBox
      // 
      this.parseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.parseTextBox.Location = new System.Drawing.Point(49, 451);
      this.parseTextBox.Name = "parseTextBox";
      this.parseTextBox.Size = new System.Drawing.Size(137, 20);
      this.parseTextBox.TabIndex = 12;
      this.parseTextBox.Text = "2021-08-30";
      // 
      // datesListBox
      // 
      this.datesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.datesListBox.FormattingEnabled = true;
      this.datesListBox.IntegralHeight = false;
      this.datesListBox.Location = new System.Drawing.Point(6, 32);
      this.datesListBox.Name = "datesListBox";
      this.datesListBox.Size = new System.Drawing.Size(261, 289);
      this.datesListBox.TabIndex = 1;
      this.datesListBox.SelectedIndexChanged += new System.EventHandler(this.DatesListBox_SelectedIndexChanged);
      // 
      // newDayTextBox
      // 
      this.newDayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.newDayTextBox.Location = new System.Drawing.Point(49, 414);
      this.newDayTextBox.Name = "newDayTextBox";
      this.newDayTextBox.Size = new System.Drawing.Size(137, 20);
      this.newDayTextBox.TabIndex = 9;
      // 
      // newEraComboBox
      // 
      this.newEraComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.newEraComboBox.Location = new System.Drawing.Point(49, 335);
      this.newEraComboBox.Name = "newEraComboBox";
      this.newEraComboBox.Size = new System.Drawing.Size(137, 21);
      this.newEraComboBox.TabIndex = 3;
      // 
      // newMonthTextBox
      // 
      this.newMonthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.newMonthTextBox.Location = new System.Drawing.Point(49, 388);
      this.newMonthTextBox.Name = "newMonthTextBox";
      this.newMonthTextBox.Size = new System.Drawing.Size(137, 20);
      this.newMonthTextBox.TabIndex = 7;
      // 
      // newYearTextBox
      // 
      this.newYearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.newYearTextBox.Location = new System.Drawing.Point(49, 362);
      this.newYearTextBox.Name = "newYearTextBox";
      this.newYearTextBox.Size = new System.Drawing.Size(137, 20);
      this.newYearTextBox.TabIndex = 5;
      // 
      // tableLayoutPanel
      // 
      tableLayoutPanel.ColumnCount = 3;
      tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      tableLayoutPanel.Controls.Add(attributesGroupBox, 1, 0);
      tableLayoutPanel.Controls.Add(createGroupBox, 0, 0);
      tableLayoutPanel.Controls.Add(panel1, 2, 0);
      tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel.Location = new System.Drawing.Point(0, 24);
      tableLayoutPanel.Name = "tableLayoutPanel";
      tableLayoutPanel.RowCount = 1;
      tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 521F));
      tableLayoutPanel.Size = new System.Drawing.Size(837, 521);
      tableLayoutPanel.TabIndex = 1;
      // 
      // panel1
      // 
      panel1.Controls.Add(isLeapYearGroupBox);
      panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      panel1.Location = new System.Drawing.Point(561, 3);
      panel1.Name = "panel1";
      panel1.Size = new System.Drawing.Size(273, 515);
      panel1.TabIndex = 2;
      // 
      // isLeapYearGroupBox
      // 
      isLeapYearGroupBox.Controls.Add(this.isLeapYearResultTextBox);
      isLeapYearGroupBox.Controls.Add(isLeapYearButton);
      isLeapYearGroupBox.Controls.Add(label3);
      isLeapYearGroupBox.Controls.Add(this.isLeapYearYearTextBox);
      isLeapYearGroupBox.Controls.Add(this.isLeapYearEraComboBox);
      isLeapYearGroupBox.Controls.Add(label1);
      isLeapYearGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
      isLeapYearGroupBox.Location = new System.Drawing.Point(0, 0);
      isLeapYearGroupBox.Name = "isLeapYearGroupBox";
      isLeapYearGroupBox.Size = new System.Drawing.Size(273, 125);
      isLeapYearGroupBox.TabIndex = 0;
      isLeapYearGroupBox.TabStop = false;
      isLeapYearGroupBox.Text = "&IsLeapYear";
      // 
      // isLeapYearResultTextBox
      // 
      this.isLeapYearResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.isLeapYearResultTextBox.Location = new System.Drawing.Point(75, 66);
      this.isLeapYearResultTextBox.Name = "isLeapYearResultTextBox";
      this.isLeapYearResultTextBox.ReadOnly = true;
      this.isLeapYearResultTextBox.Size = new System.Drawing.Size(192, 20);
      this.isLeapYearResultTextBox.TabIndex = 19;
      // 
      // isLeapYearButton
      // 
      isLeapYearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      isLeapYearButton.Location = new System.Drawing.Point(192, 92);
      isLeapYearButton.Name = "isLeapYearButton";
      isLeapYearButton.Size = new System.Drawing.Size(75, 23);
      isLeapYearButton.TabIndex = 17;
      isLeapYearButton.Text = "Test";
      isLeapYearButton.UseVisualStyleBackColor = true;
      isLeapYearButton.Click += new System.EventHandler(this.IsLeapYearButton_Click);
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(6, 43);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(32, 13);
      label3.TabIndex = 10;
      label3.Text = "&Year:";
      // 
      // isLeapYearYearTextBox
      // 
      this.isLeapYearYearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.isLeapYearYearTextBox.Location = new System.Drawing.Point(75, 40);
      this.isLeapYearYearTextBox.Name = "isLeapYearYearTextBox";
      this.isLeapYearYearTextBox.Size = new System.Drawing.Size(192, 20);
      this.isLeapYearYearTextBox.TabIndex = 11;
      this.isLeapYearYearTextBox.Text = "42";
      // 
      // isLeapYearEraComboBox
      // 
      this.isLeapYearEraComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.isLeapYearEraComboBox.Location = new System.Drawing.Point(75, 13);
      this.isLeapYearEraComboBox.Name = "isLeapYearEraComboBox";
      this.isLeapYearEraComboBox.Size = new System.Drawing.Size(192, 21);
      this.isLeapYearEraComboBox.TabIndex = 8;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(6, 16);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(26, 13);
      label1.TabIndex = 7;
      label1.Text = "E&ra:";
      // 
      // menuStrip
      // 
      menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileToolStripMenuItem,
            helpToolStripMenuItem});
      menuStrip.Location = new System.Drawing.Point(0, 0);
      menuStrip.Name = "menuStrip";
      menuStrip.Size = new System.Drawing.Size(837, 24);
      menuStrip.TabIndex = 0;
      // 
      // fileToolStripMenuItem
      // 
      fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            exitToolStripMenuItem});
      fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      fileToolStripMenuItem.Text = "&File";
      // 
      // exitToolStripMenuItem
      // 
      exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
      exitToolStripMenuItem.Text = "E&xit";
      exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem
      // 
      helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            aboutToolStripMenuItem});
      helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      helpToolStripMenuItem.Text = "&Help";
      // 
      // aboutToolStripMenuItem
      // 
      aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
      aboutToolStripMenuItem.Text = "&About";
      aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
      // 
      // statusStrip
      // 
      statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.cyotekLinkToolStripStatusLabel});
      statusStrip.Location = new System.Drawing.Point(0, 545);
      statusStrip.Name = "statusStrip";
      statusStrip.Size = new System.Drawing.Size(837, 22);
      statusStrip.TabIndex = 2;
      // 
      // statusToolStripStatusLabel
      // 
      this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
      this.statusToolStripStatusLabel.Size = new System.Drawing.Size(723, 17);
      this.statusToolStripStatusLabel.Spring = true;
      this.statusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cyotekLinkToolStripStatusLabel
      // 
      this.cyotekLinkToolStripStatusLabel.IsLink = true;
      this.cyotekLinkToolStripStatusLabel.Name = "cyotekLinkToolStripStatusLabel";
      this.cyotekLinkToolStripStatusLabel.Size = new System.Drawing.Size(99, 17);
      this.cyotekLinkToolStripStatusLabel.Text = "www.cyotek.com";
      this.cyotekLinkToolStripStatusLabel.Click += new System.EventHandler(this.CyotekLinkToolStripStatusLabel_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(837, 567);
      this.Controls.Add(tableLayoutPanel);
      this.Controls.Add(statusStrip);
      this.Controls.Add(menuStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = menuStrip;
      this.MinimizeBox = true;
      this.Name = "MainForm";
      this.ShowIcon = true;
      this.ShowInTaskbar = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Cyotek Historical Date Demonstration";
      attributesGroupBox.ResumeLayout(false);
      attributesGroupBox.PerformLayout();
      createGroupBox.ResumeLayout(false);
      createGroupBox.PerformLayout();
      tableLayoutPanel.ResumeLayout(false);
      panel1.ResumeLayout(false);
      isLeapYearGroupBox.ResumeLayout(false);
      isLeapYearGroupBox.PerformLayout();
      menuStrip.ResumeLayout(false);
      menuStrip.PerformLayout();
      statusStrip.ResumeLayout(false);
      statusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox datesListBox;
    private System.Windows.Forms.TextBox newDayTextBox;
    private System.Windows.Forms.TextBox newMonthTextBox;
    private System.Windows.Forms.TextBox newYearTextBox;
    private Cyotek.Demo.Windows.Forms.EraComboBox newEraComboBox;
    private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
    private System.Windows.Forms.TextBox formatTextBox;
    private System.Windows.Forms.TextBox hasDayTextBox;
    private System.Windows.Forms.TextBox hasMonthTextBox;
    private System.Windows.Forms.TextBox isEmptyTextBox;
    private System.Windows.Forms.TextBox binaryTextBox;
    private System.Windows.Forms.TextBox dayOfYearTextBox;
    private System.Windows.Forms.TextBox fromBinaryTextBox;
    private System.Windows.Forms.TextBox parseTextBox;
    private System.Windows.Forms.TextBox dayTextBox;
    private System.Windows.Forms.TextBox eraTextBox;
    private System.Windows.Forms.TextBox monthTextBox;
    private System.Windows.Forms.TextBox yearTextBox;
    private System.Windows.Forms.ToolStripStatusLabel cyotekLinkToolStripStatusLabel;
    private Cyotek.Demo.Windows.Forms.EraComboBox isLeapYearEraComboBox;
    private System.Windows.Forms.TextBox isLeapYearYearTextBox;
    private System.Windows.Forms.TextBox isLeapYearResultTextBox;
  }
}

