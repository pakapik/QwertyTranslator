using QwertyTranslator.Translator;
using WindowsKeyLogger;

using System;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text;

namespace QwertyTranslator
{
    public class Program
    {
        private static KeyLogger _qwertyTranslator;

        [STAThread]
        public static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
           
            Start();
        }

        private static void Start()
        {
            var translator = new QwertyTranslatorMediator(new RusToEngQwertyTranslator(),
                                                          new EngToRusQwertyTranslator());

            var updater = new ClipBoardUpdaterTextToText(translator);

            _qwertyTranslator = new KeyLogger(Keys.LControlKey, Keys.N, updater.Update);

            Application.ApplicationExit += Application_ApplicationExit;

            _qwertyTranslator.Start();
            Application.Run();
            _qwertyTranslator.Stop();
        }

        private static void Application_ApplicationExit(object sender, EventArgs e) => _qwertyTranslator?.Stop();

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e) => _qwertyTranslator?.Stop();

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (!args.Name.StartsWith("KeyLogger"))
            {
                return null;
            }

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("QwertyTranslator.KeyLogger.dll"))
            {
                var assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);

                return Assembly.Load(assemblyData);
            }
        }
    }
}
