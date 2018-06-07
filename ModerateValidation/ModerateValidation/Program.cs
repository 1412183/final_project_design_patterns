using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModerateValidation
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
            SignupForm signupForm = new SignupForm();
            signupForm.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(signupForm);
        }
    }
}
