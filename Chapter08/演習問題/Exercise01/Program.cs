namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();


            Exercise2(text);

        }

        private static void Exercise1(string text) {
            var dict = new Dictionary<char, int>();
            foreach (var c in text.ToUpper()) {
                if ('A' <= c && c <= 'Z') {
                    if (dict.ContainsKey(c)) {
                        dict[c]++;
                    } else {
                        dict[c] = 1;
                    }
                }
            }
            foreach (var item in dict.OrderBy(c => c.Key)) {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static void Exercise2(string text) {
            var dict = new SortedDictionary<char, int>();

            foreach (var c in text.ToUpper()) {
                if ('A' <= c && c <= 'Z') {
                    if (dict.ContainsKey(c)) {
                        dict[c]++;
                    } else {
                        dict[c] = 1; //未登録：valueに１を設定
                    }
                }
            }
            //⑥すべての文字が読み終わったら出力
            foreach (var item in dict) {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}