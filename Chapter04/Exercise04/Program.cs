
using System.Data.SqlTypes;

namespace Section04 {
    internal class Program {
        static void Main(string[] args) {

            #region null 合体演算子

            #endregion

            #region null 条件演算子

            #region 値の入れ替え
            string? inputData = Console.ReadLine();

            if (int.TryParse(inputData, out var number)) {
                Console.WriteLine(number);
            }else {
                Console.WriteLine("エラー");
            }

        //    try {
        //        int num = int.Parse(inputData);
        //        Console.WriteLine(num);
        //    }
        //    catch (FormatException e) {

        //        Console.WriteLine("フォーマットエラー");
        //    }
        //    catch (OverflowException e) {
        //        Console.WriteLine("入力値が大きすぎます");
        //    }
        //    finally {
        //        Console.WriteLine("処理完了");
        //    }
        //    Console.WriteLine("メソッド終了");
        //}

        private static object? GetMessage(string code) {
            return code;
        }

        private static object? DefaultMessage() {
            return "DefaultMessage";
        }


    }
}