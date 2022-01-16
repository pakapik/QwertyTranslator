using QwertyTranslator.Translator;

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QwertyTranslator
{
    public partial class MessageHandlerForm : Form
    {
        private ClipBoardUpdaterTextToText _updater;

        public MessageHandlerForm()
        {
            InitializeComponent();
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            Init();
            RegisterHotKey(Handle, 0, (int)KeyModifier.Control, Keys.N.GetHashCode());
            FormClosing += MessageHandler_FormClosing;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                _updater.Update();
            }

            base.WndProc(ref m);
        }

        private void Init()
        {
            var translator = new QwertyTranslatorMediator(new RusToEngQwertyTranslator(),
                                                          new EngToRusQwertyTranslator());

            _updater = new ClipBoardUpdaterTextToText(translator);
        }

        
        private void MessageHandler_FormClosing(object sender, FormClosingEventArgs e) => UnregisterHotKey(Handle, 0);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}
