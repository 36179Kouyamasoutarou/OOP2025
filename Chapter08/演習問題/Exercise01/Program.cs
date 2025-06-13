
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);

        }

        private static void Exercise1(string text) {
            var dict = new Dictionary<Char, int>();

            foreach (var c in text.ToUpper()) {
                // 'A' … 0x41
                //  :       :
                // 'Z' … 0x5a



                //④アルファベットならディクショナリに登録
                //  登録済み：valueをインクリメント
                //  未登録：valueに1を設定


            }




            //⑥すべての文字が読み終わったら、アルファベット順に並び替えて出力

        }

        private static void Exercise2(string text) {
            
        }
    }
}
