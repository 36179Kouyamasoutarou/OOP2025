using System.Text.RegularExpressions;

namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Word, Excel ,PowerPoint , Outlook,OneDrive";
            var pattern = @"\s*,\s*";

            string[] substrings = Regex.Split(text, pattern);
            foreach (var match in substrings) {
                Console.WriteLine($"'{match}'");
            }
        }
    }
}
