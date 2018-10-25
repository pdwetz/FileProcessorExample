using CommandLine;

namespace FileProcessorExample
{
    public class ProgramOptions
    {
        [Option('f', "folderpath", Required = true, HelpText = "Full path of folder to process.")]
        public string FilePath { get; set; }

        [Option('p', "pause", Required = false, HelpText = "Pause on program completion.")]
        public bool PauseAtCompletion { get; set; }
    }
}