using System;
using System.Windows.Forms;


namespace BmiCalculator
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var auth = AuthorizationForm.Authorize();
            if (auth == AuthorizationResult.NotAuthorized)
                return;

            Application.Run(new BmiCalcForm(auth));
        }
    }
}
