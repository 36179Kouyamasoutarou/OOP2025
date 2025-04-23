using System.Data;

using System.Runtime.CompilerServices;

namespace Exercise02 {


    class Program {
        static void Main(string[] args) {


         PrintInchToMeterList(1, 10);


        }

        static void PrintInchToMeterList(int start, int end) {

            for (int feet = start; feet <= end; feet++) {

                double meter = IntchConverter.ToMeter(feet);

                Console.WriteLine($"{feet}inch = {meter:0.0000}m");

            }

        }

        

    }
}