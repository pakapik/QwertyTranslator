# QwertyTranslator
When you press a hotkey, it translates text from the clipboard from one keyboard layout to another.
Example: qwerty -> йцукен.
Uses global keystroke monitoring. By default, the hotkey is LCtrl + N.
The text is translated from the current system language to another (the logic is implemented only for 2 languages).

The best way is to use WndProc and register the key/unregister the key with WinForms,
because this code uses SetWindowsHookEx and should call UnhookWindowsHookEx when stop,
but UnhookWindowsHookEx is called only when the application is closed correctly -
not through the task manager or shutting down the computer.

## Setup
Open QwertyTranslator/Setup/Release/setup.exe

## Using
Create a shortcut from QwertyTranslator.exe and move it to the Startup folder.

For Windows, .NET Framework 4.8