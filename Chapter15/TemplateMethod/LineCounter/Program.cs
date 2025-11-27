using System;
using System.IO;
using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("検索するファイルのパスを入力してください: ");
            string filePath = Console.ReadLine()?.Trim().Trim('"') ?? "";

            Console.WriteLine($"現在の作業ディレクトリ: {Directory.GetCurrentDirectory()}");

            while (!File.Exists(filePath)) {
                Console.WriteLine($"ファイルが見つかりません: {filePath}");
                Console.Write("もう一度ファイルパスを入力してください: ");
                filePath = Console.ReadLine()?.Trim().Trim('"') ?? "";
            }

            Console.WriteLine($"ファイルが見つかりました: {filePath}");
            TextProcessor.Run<LineCounterProcessor>(filePath);
        }
    }
}