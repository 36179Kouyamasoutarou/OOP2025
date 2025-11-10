
using System;
using System.IO;

class Program {
    static void Main() {
        Console.Write("コピー元ディレクトリを入力してください: ");
        string sourceDir = Console.ReadLine();

        Console.Write("コピー先ディレクトリを入力してください: ");
        string destDir = Console.ReadLine();

        if (!Directory.Exists(sourceDir)) {
            Console.WriteLine("コピー元ディレクトリが存在しません。");
            return;
        }

        Directory.CreateDirectory(destDir);

        var files = Directory.GetFiles(sourceDir);

        foreach (var file in files) {
            string fileName = Path.GetFileName(file);
            string destPath = Path.Combine(destDir, Path.GetFileNameWithoutExtension(fileName) + ".bak");

            File.Copy(file, destPath, overwrite: true);
            Console.WriteLine($"{fileName} → {destPath} にコピーしました。");
        }

        Console.WriteLine("すべてのファイルをコピーしました。");
    }
}

