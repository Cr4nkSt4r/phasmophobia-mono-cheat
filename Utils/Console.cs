﻿using System.IO;

namespace PhasmoMonoCheat.Utils
{
    public class ConsoleWriter
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);

        private const int ATTACH_PARENT_PROCESS = -1;

        StreamWriter _stdOutWriter;

        public ConsoleWriter()
        {
            AllocConsole();
            var stdout = System.Console.OpenStandardOutput();
            _stdOutWriter = new StreamWriter(stdout);
            _stdOutWriter.AutoFlush = true;

            AttachConsole(ATTACH_PARENT_PROCESS);
        }

        public void WriteLine(string line)
        {
            _stdOutWriter.WriteLine(line);
            System.Console.WriteLine(line);
        }
    }
}