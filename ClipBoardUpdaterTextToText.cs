using QwertyTranslator.Translator;

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QwertyTranslator
{
    public class ClipBoardUpdaterTextToText
    {
        private readonly QwertyTranslatorMediator _translator;

        public ClipBoardUpdaterTextToText(QwertyTranslatorMediator translator) => _translator = translator;

        public void Update()
        {
            var clipboardText = GetClipboardText();

            clipboardText = _translator.Translate(clipboardText, GetLanguange());

            Clipboard.SetText(clipboardText);
        }

        private static string GetClipboardText()
        {
            var clipboardText = string.Empty;

            var clipboardData = Clipboard.GetDataObject();
            if (clipboardData != null && clipboardData.GetDataPresent(DataFormats.UnicodeText))
            {
                clipboardText = clipboardData.GetData(DataFormats.UnicodeText)?.ToString();
            }

            return clipboardText;
        }

        private static Language GetLanguange() => (Language)GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero));

        #region DllImport

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId([In] IntPtr hWnd, [Out, Optional] IntPtr lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern ushort GetKeyboardLayout([In] int idThread);

        #endregion
    }
}
