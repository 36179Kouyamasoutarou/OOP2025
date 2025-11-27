using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;
using System;
using System.Linq;


namespace LineCounter {
    internal class LineCounterProcessor : TextProcessor {
        private int _count = 0;         // 単語出現回数
        private string _targetWord = ""; // 検索対象の単語

        // 初期化処理：キーボード入力で単語を指定
        protected override void Initialize(string fname) {
            Console.WriteLine($"対象ファイル: {fname}");
            Console.Write("カウントしたい単語を入力してください: ");
            _targetWord = Console.ReadLine()?.Trim() ?? "";
            _count = 0;
        }

        // 各行を処理：単語の出現を数える
        protected override void Execute(string line) {
            if (string.IsNullOrEmpty(_targetWord)) return;

            // スペースや句読点で分割して単語単位で検索
            var words = line.Split(new char[] { ' ', '　', '\t', ',', '.', '!', '?', ';', ':', '(', ')', '"', '\'' },
                                   StringSplitOptions.RemoveEmptyEntries);

            // 大文字小文字を無視して一致する単語を数える
            _count += words.Count(w => string.Equals(w, _targetWord, StringComparison.OrdinalIgnoreCase));
        }

        // 結果出力
        protected override void Terminate() {
            Console.WriteLine("単語 \"{0}\" の出現回数: {1} 回", _targetWord, _count);
        }
    }
}
