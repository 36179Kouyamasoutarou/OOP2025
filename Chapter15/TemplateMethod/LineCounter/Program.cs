using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            string path = @"C:\Users\infosys\repos\OOP2025\Chapter06\Section03\Program.cs";
            TextProcessor.Run<LineCounterProcessor>(path);
        }
    }
}
