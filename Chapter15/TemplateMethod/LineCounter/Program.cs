using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            string path =
            TextProcessor.Run<LineCounterProcessor>(args[0]);
        }
    }
}
