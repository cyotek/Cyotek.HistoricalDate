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
  internal static class Program
  {
    #region Private Methods

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }

    #endregion Private Methods
  }
}