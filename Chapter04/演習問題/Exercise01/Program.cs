
using System.Diagnostics;

namespace Exercise01 {
    internal class Program {

        static void Main(string[] args) {
            List<string> langs = [
                "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
                "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        private static void Exercise1(List<string> langs) {
            //for文
            for (int i = 0; i < langs.Count; i++) {
                if (langs[i].Contains('S'))
                    Console.WriteLine(langs[i]);
            }
            Console.WriteLine("");  //改行

            //foreach文
            foreach (var lang in langs) {
                if (lang.Contains('S'))
                    Console.WriteLine(lang);
            }
            Console.WriteLine("");  //改行

            //while文
            int index = 0;
            while (index < langs.Count) {
                if (langs[index].Contains('S'))
                    Console.WriteLine(langs[index]);
                index++;
            }
            Console.WriteLine("");  //改行


        }

        private static void Exercise2(List<string> langs) {
            var selected = langs.Where(x => x.Contains('S'));
            foreach (var lang in selected) {
                Console.WriteLine(lang);
            }
        }

        private static void Exercise3(List<string> langs) {
            Console.WriteLine(langs.Find(x => x.Length == 10) ?? "unknown");
        }
    }
}
