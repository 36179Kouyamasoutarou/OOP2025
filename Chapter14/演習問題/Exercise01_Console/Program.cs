using System;
using System.IO;
using System.Text;

internal class Program {
    static void Main(string[] args) {
        string text = TextReaderSample.ReadText("吾輩は猫である.txt");
        Console.WriteLine(text);

        Console.WriteLine("End!");
    }

    static class TextReaderSample {
        public static string ReadText(string filePath) {
            var sb = new StringBuilder();

            // using を使って自動的にファイルを閉じる
            using (var sr = new StreamReader(filePath, Encoding.UTF8)) {
                while (!sr.EndOfStream) {
                    string? line = sr.ReadLine();  // 1行読み取り
                    sb.AppendLine(line);
                }
            }

            return sb.ToString();
        }
    }
}
