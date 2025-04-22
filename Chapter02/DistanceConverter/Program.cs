using System.Data;

namespace DistanceConverter {

    internal class Program {

        //コマンドライン引数で指定された範囲のフィートとメートルの対応表を出力する

        static void Main(string[] args) {

            int start = int.Parse(args[1]);

            int end = int.Parse(args[2]);

            if (args.Length >= 1 && args[0] == "-tom") {

                PrintFeetToMeter(start, end);

            } else {

                PrintMeterToFeetList(start, end);

            }

        }

        static void PrintMeterToFeetList(int start, int end) {

            for (int feet = start; feet <= end; feet++) {

                double meter = FeetToMeter(feet);

                Console.WriteLine($"{feet}ft = {meter:0.0000}m");

            }

        }

        static void PrintFeetToMeter(int start, int end) {

            for (int meter = start; meter <= end; meter++) {

                double feet = MeterToFeet(meter);

                Console.WriteLine($"{meter}m = {feet:0.0000}ft");

            }

        }

        static double FeetToMeter(int feet) {

            return feet * 0.3048;

        }

        static double MeterToFeet(int meter) {

            return meter / 0.3048;

        }

    }

}

