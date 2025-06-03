using System;
using System.Collections.Generic;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            // 入力文字列
            var line = "Novelist=谷崎潤一郎: BestWork=春琴抄: Born=1886";

            // 文字列を辞書に変換
            var dict = ParseLine(line);

            // 辞書の内容を日本語のラベルとともに表示
            foreach (var entry in dict) {
                Console.WriteLine($"{ToJapanese(entry.Key)}: {entry.Value}");
            }
        }

        /// <summary>
        /// 引数の単語を日本語へ変換します
        /// </summary>
        /// <param name="key">"Novelist", "BestWork", "Born"</param>
        /// <returns>"作家", "代表作", "誕生年"</returns>
        static string ToJapanese(string key) {
            return key switch {
                "Novelist" => "作家",
                "BestWork" => "代表作",
                "Born" => "誕生年",
                _ => key // 未知のキーはそのまま返す
            };
        }

        /// <summary>
        /// セミコロン区切りの文字列をキーと値のペアに分解し、辞書に格納します
        /// </summary>
        /// <param name="line">"Novelist=谷崎潤一郎: BestWork=春琴抄: Born=1886"</param>
        /// <returns>Dictionary<string, string></returns>
        static Dictionary<string, string> ParseLine(string line) {
            var dict = new Dictionary<string, string>();

            // セミコロンで分割
            var pairs = line.Split(new[] { ": " }, StringSplitOptions.None);

            foreach (var pair in pairs) {
                var keyValue = pair.Split('=');
                if (keyValue.Length == 2) {
                    dict[keyValue[0].Trim()] = keyValue[1].Trim();
                }
            }

            return dict;
        }
    }
}
