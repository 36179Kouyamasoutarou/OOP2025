using System;
using System.IO;

class Program {
    static void Main() {
        Console.Write("調べるディレクトリを入力してください: ");
        string dirPath = Console.ReadLine();

        if (!Directory.Exists(dirPath)) {
            Console.WriteLine("ディレクトリが存在しません。");
            return;
        }

        var files = Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);
        long threshold = 1_048_576; // 1MB

        Console.WriteLine("1MB以上のファイル一覧:");
        foreach (var file in files) {
            var info = new FileInfo(file);
            if (info.Length >= threshold) {
                Console.WriteLine($"{info.FullName} ({info.Length} bytes)");
            }
        }
    }
}

