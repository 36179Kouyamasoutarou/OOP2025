using System;
using System.IO;

class Program {
    static void Main() {
        Console.Write("読み込むテキストファイル名を入力してください: ");
        string inputPath = Console.ReadLine();

        if (!File.Exists(inputPath)) {
            Console.WriteLine("ファイルが見つかりません。");
            return;
        }

        Console.Write("出力ファイル名を入力してください: ");
        string outputPath = Console.ReadLine();

        var lines = File.ReadAllLines(inputPath);

        using (var writer = new StreamWriter(outputPath)) {
            for (int i = 0; i < lines.Length; i++) {
                writer.WriteLine($"{i + 1}: {lines[i]}");
            }
        }

        Console.WriteLine("行番号付きファイルを出力しました。");
    }
}

 
