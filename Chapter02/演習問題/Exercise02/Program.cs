using System.Data;

using System.Runtime.CompilerServices;

namespace Exercise02 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("1:ヤードからメートル");

            Console.WriteLine("2:メートルからヤード");

            Console.Write("＞");

            int con = int.Parse(Console.ReadLine());

            

            if (con == 1) {

                PrintInchToMeterList();

            } else {

                PrintMeterToInchList(start, end);

            }

        }


        static void PrintInchToMeterList(int start, int end) {

            for (int inch = start; inch <= end; inch++) {

                double meter = IntchConverter.ToMeter(inch);

                Console.WriteLine($"{inch}inch = {meter:0.0000}m");

            }

        }

        static void PrintMeterToInchList(int start, int end) {

            for (int meter = start; meter <= end; meter++) {

                double inch = IntchConverter.ToMeter(meter);

                Console.WriteLine($"{meter}meter = {inch:0.0000}inch");

            }

        }

    }

}
