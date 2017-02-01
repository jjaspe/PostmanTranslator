using FrameworkCreatorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngularFrameworkCreator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()
            {
                webPageReader = new WebPageReader(),
                codeFileCreatorService = new CodeFileCreatorService()
                {
                    codePageReader = new CodePageReader()
                }
            });
        }
    }
}
