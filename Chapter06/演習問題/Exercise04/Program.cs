namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

            var array = line.Split(';');

            var word = array[0].Split('=');
            var jpName = ToJapanese(word[0]);
                
            }



        

        /// <summary>
        /// 引数の単語を日本語へ変換します
        /// </summary>
        /// <param name="key">"Novelist","BestWork","Born"</param>
        /// <returns>"「作家」,「代表作」,「誕生年」</returns>
        static string ToJapanese(string key) {

            switch (key) {
                default:
                    break;
            }


            var retText = key switch {
                "Novelist" => "作家",
                "BestWork" => "代表作",
                "Born" => "誕生年",　
                => "引き数Keyは、正しい値ではありません。"
            };
            return retText;
        }
    }
}