using System;
using System.IO;

class Program {
    static void Main() {
        Console.Write("元のファイル名を入力してください: ");
        string basePath = Console.ReadLine();

        Console.Write("追加するファイル名を入力してください: ");
        string appendPath = Console.ReadLine();

        if (!File.Exists(basePath) || !File.Exists(appendPath)) {
            Console.WriteLine("いずれかのファイルが見つかりません。");
            return;
        }

        var appendLines = File.ReadAllLines(appendPath);
        File.AppendAllLines(basePath, appendLines);

        Console.WriteLine("ファイルの末尾に内容を追加しました。");
    }
}
