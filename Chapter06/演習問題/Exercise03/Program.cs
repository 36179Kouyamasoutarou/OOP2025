
using System.Text;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            #region
            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);
            #endregion
        }

        private static void Exercise1(string text) {
            var spaces = text.Count(c => c == ' ');
            //var spaces = text.Count(char.IsWhiteSpace);//別解
            Console.WriteLine("空白数:{0}", spaces);
        }

        private static void Exercise2(string text) {
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3(string text) {
            var array = text.Split(' ');
            var sb = new StringBuilder(array[0]);
            foreach (var word in array.Skip(1)) {
                sb.Append(" ");
                sb.Append(word);
            }
            //末尾はピリオド（.）で終わる
            Console.WriteLine(sb + ".");
        }

        private static void Exercise4(string text) {
            var count = text.Split(' ').Length;
            Console.WriteLine("単語数:{0}", count);
        }

        private static void Exercise5(string text) {
            var words = text.Split(' ').Where(s => s.Length <= 4);

            foreach (var word in words)
                Console.WriteLine(word);
        }
        private static void Exercise6(string text) {
            var str = text.ToLower().Replace("","");
            //辞書で集計
            var alphDicCount = Enumerable.Range('a', 26)
                .ToDictionary(num => ((char)num).ToString(), num => 0);

            foreach (var alph in str) {
                alphDicCount[alph.]++;

                //配列で集計
                var array = Enumerable.Repeat(0,26).ToArray();

                foreach (var alph in str) {
                    array[alph - 'a']++;
                }

            }
        }
    }
}
