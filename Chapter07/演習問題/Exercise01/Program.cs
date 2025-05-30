﻿
using System.Linq;
using System.Net.WebSockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            int[] numbers = [5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35];

            Console.WriteLine("7.1.1");
            Exercise1(numbers);

            Console.WriteLine("7.1.2");
            Exercise2(numbers);

            Console.WriteLine("7.1.3");
            Exercise3(numbers);

            Console.WriteLine("7.1.4");
            Exercise4(numbers);

            Console.WriteLine("7.1.5");
            Exercise5(numbers);
        }

        private static void Exercise1(int[] numbers) {
            Console.WriteLine(numbers.Max());
        }

        private static void Exercise2(int[] numbers) {

            foreach (var n in numbers.TakeLast(2)) {
                Console.WriteLine(n);
            }
        }

        private static void Exercise3(int[] numbers) {

            var strs = numbers.Select(numbers => numbers.ToString("000"));


            foreach (var number in strs) {
                Console.WriteLine(numbers);



            }
        }

        private static void Exercise4(int[] numbers) {

            foreach(var n in numbers.Order().Take(3)) {
                Console.WriteLine(numbers);
            }
        }

        private static void Exercise5(int[] numbers) {
            var count = numbers.Distinct().Count(numbers => numbers >= 10);
            Console.WriteLine(count);
        }
    }
}
