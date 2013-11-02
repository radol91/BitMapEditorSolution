using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BitMapEditor
{
    static class Program
    {
        [DllImport("BitMapEditorDLL.dll")]
        public static extern int Dodaj(int a, int b);
        [DllImport("BitMapEditorDLL.dll")]
        public static extern int Negatyw(int a, int b, int c);
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
