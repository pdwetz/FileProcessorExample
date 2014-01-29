/*
    FileProcessorExample - Simple example app for processing files with logging support

    Copyright (c) 2014 Peter Wetzel
 
    The MIT License (MIT)

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/
using System;
using log4net;
using System.IO;

namespace FileProcessorExample
{
    class FileProcessor
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(FileProcessor));

        public void StartConsole()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("FileProcessor   Copyright (C) 2014 Peter Wetzel");
                Console.WriteLine("This program comes with ABSOLUTELY NO WARRANTY; for details see license.txt.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                ProcessFiles(Environment.CurrentDirectory);
            }
            catch (Exception ex)
            {
                _log.Error(null, ex);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}: Done. Press any key to continue.", DateTime.Now.ToString("HH:mm:ss.fff"));
            Console.ReadLine();
        }

        private void ProcessFiles(string sFolderPath)
        {
            Log("Processing folder {0}", sFolderPath);
            if (!Directory.Exists(sFolderPath))
            {
                Log("Skipping; folder does not exist: {0}", sFolderPath);
                return;
            }

            var filepaths = Directory.EnumerateFiles(sFolderPath, "*.*", System.IO.SearchOption.TopDirectoryOnly);
            foreach (var file in filepaths)
            {
                Log("Processing file {0}", file);
            }
        }

        public void Log(string format, params object[] arg)
        {
            _log.Info(string.Format(format, arg));
        }
    }
}
