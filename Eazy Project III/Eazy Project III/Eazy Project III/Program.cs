﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Eazy_Project_III
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormSpace.frmUserSelect());
            //_test();
            Application.Run(new MainForm());

        }
        static void _test()
        {
            JetEazy.GdxCore3.Model.CoretronicsAPI.updateParams();
        }
    }
}