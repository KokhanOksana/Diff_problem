using Koshi_giu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cauchy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main ( )
        {
            Application . EnableVisualStyles ( );
            Application . SetCompatibleTextRenderingDefault ( false );
            Application . Run ( new Boundary_problem ( ) );
        }
    }
}
