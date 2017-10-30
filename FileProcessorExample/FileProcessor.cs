/*
    FileProcessorExample - Simple example app for processing files with logging support

    Copyright (c) 2017 Peter Wetzel
 
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
using System.IO;
using Serilog;

namespace FileProcessorExample
{
    class FileProcessor
    {
        public FileProcessor()
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .CreateLogger();
        }

        public void StartConsole()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("FileProcessor");
                Console.WriteLine("Copyright (C) 2017 Peter Wetzel");
                Console.WriteLine("This program comes with ABSOLUTELY NO WARRANTY; for details see license.txt.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                ProcessFiles(Environment.CurrentDirectory);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now.ToString("HH: mm:ss.fff")}: Done. Press any key to continue.");
            Console.ReadLine();
        }

        private void ProcessFiles(string folderPath)
        {
            Log.Debug($"Processing folder {folderPath}");
            if (!Directory.Exists(folderPath))
            {
                Log.Warning($"Skipping; folder does not exist: {folderPath}");
                return;
            }
            var filePaths = Directory.EnumerateFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var filePath in filePaths)
            {
                Log.Debug($"Processing file {filePath}");
            }
        }
    }
}