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

            Clipboard.SetText(GetCorrectText(clipboardText));
        }

        /// <summary>
        /// Clipboard.SetText(clipboardText) throw ArgumentNullExecption, 
        /// if clipboardText == string.Empty
        /// </summary>
        /// <param name="text">to contains to Clipboard</param>
        /// <returns></returns>
        private string GetCorrectText(string clipboardText)
        {
            return string.IsNullOrEmpty(clipboardText)
                 ? " "
                 : clipboardText;
        }

        private string GetClipboardText()
        {
            var clipboardText = string.Empty;

            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
            {
                clipboardText = Clipboard.GetText(TextDataFormat.UnicodeText);
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
