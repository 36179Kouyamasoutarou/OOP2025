using System;

namespace NumberGuessingGame {
    class Program {
        static void Main(string[] args) {
            // ゲーム開始のメッセージ
            Console.WriteLine("数字当てゲームへようこそ！");
            Console.WriteLine("1から100までの数字を当ててください。");

            // コンピュータが選ぶランダムな数字
            Random random = new Random();
            int correctNumber = random.Next(1, 101);  // 1から100の間の数字をランダムに選ぶ

            int guess = 0;
            int attempts = 0;

            // プレイヤーが当てるまで繰り返す
            while (guess != correctNumber) {
                Console.Write("予想する数字を入力してください: ");
                string input = Console.ReadLine();

                // 入力が整数かどうかチェック
                if (int.TryParse(input, out guess)) {
                    attempts++;

                    // ヒントを表示
                    if (guess < correctNumber) {
                        Console.WriteLine("もっと大きい数字です！");
                    } else if (guess > correctNumber) {
                        Console.WriteLine("もっと小さい数字です！");
                    } else {
                        // 正解した場合
                        Console.WriteLine($"おめでとうございます！正解は {correctNumber} でした！");
                        Console.WriteLine($"あなたは {attempts} 回で正解しました！");
                    }
                } else {
                    Console.WriteLine("無効な入力です。数字を入力してください。");
                }
            }

            // ゲーム終了後に再挑戦するか聞く
            Console.WriteLine("もう一度プレイしますか？ (y/n): ");
            string playAgain = Console.ReadLine();
            if (playAgain.ToLower() == "y") {
                Main(args);  // 再帰的にゲームをリスタート
            } else {
                Console.WriteLine("ゲームを終了します。ありがとうございました！");
            }
        }
    }
}
