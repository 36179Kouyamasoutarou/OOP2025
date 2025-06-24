using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var today =  new DateTime(2025,7,12);//日付
            var now = DateTime.Now;             //日付と時刻

            Console.WriteLine($"Today:{today}");
            Console.WriteLine($"Now:{now}");

            //①自分の生年月日は何曜日かをプログラムを書いて調べる
            //　日付を入力
            Console.Write("西暦");
            var year = int.Parse(Console.ReadLine());
            //var Birthday = new DateTime(2006, 2, 20);
            //DayOfWeek dow = Birthday.DayOfWeek;
            //var culture = new CultureInfo("ja-JP");
            //Console.WriteLine($"{Birthday:yyyy年M月d日} は、{dow} です。");

            //  月
            Console.Write("月");
            var month = int.Parse(Console.ReadLine());
            //  日:20
            Console.Write("日");
            var day = int.Parse(Console.ReadLine());

            //  平成〇〇年〇月〇日は〇曜日です　←西暦は和暦、曜日は漢字で表示
            var birth = new DateTime(year, month, day);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = birth.ToString("ggyy年M月d日", culture);
            var shortDayOfWeek = culture.DateTimeFormat.GetShortestDayName(birth.DayOfWeek);


            Console.WriteLine(str + birth.ToString("ddd曜日",culture));

            //生まれてから〇〇〇〇日目です。
            TimeSpan diff = DateTime.Now - birth;
            Console.WriteLine(diff.TotalDays + "日");

            //②うるう年の判定プログラムを作成する

            //西暦を入力

            //→〇〇〇〇年はうるう年です。
            //→〇〇〇〇年は平年です。
        }
    }
}
