FileProcessorExample
==============

Simple example app for processing files with logging support.

Utilizes CommandLineParser for folder to process (easily modified options to support additional settings) and Serilog for logging, including most of the console output.
Since it's very simple the invoked class could certainly be inline, but it's kept separate just to show where I'd normally pull out app-specific logic (which generally
would also be in a separate library in the solution to support unit testing, re-use, etc).

## Usage
* -f (required) folder path to process
* -p If provided, pauses the application after running (useful if running within an IDE)
