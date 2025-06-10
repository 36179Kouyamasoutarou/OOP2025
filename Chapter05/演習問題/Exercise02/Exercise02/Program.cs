using Exercise01;


namespace Exercise02 {
        internal class Program {
            static void Main(string[] args) {
                // 5.2.1
                var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2024, 12),
            };

                Console.WriteLine("5.2.2");
                Exercise2(ymCollection);

                Console.WriteLine("5.2.4");
                Exercise4(ymCollection);


                Console.WriteLine("5.2.5");
                Exercise5(ymCollection);
            }
            //5.2.2
            private static void Exercise2(YearMonth[] ymCollection) {
                foreach (var ym in ymCollection) {
                    Console.WriteLine(ym);

                }
            }

            //5.2.3
            private static YearMonth? FindFirst21C(YearMonth[] ymCollection) {
                foreach (var ym in ymCollection) {
                    if (ym.Is21Century)
                        return ym;
                }


                return null;
            }

            //5.2.4
            private static void Exercise4(YearMonth[] ymCollection) {
                var ym = FindFirst21C(ymCollection);
                if (ym is null) {
                    Console.WriteLine("21世紀のデータはありません"); 
                } else {
                    Console.WriteLine(ym);
                }
            }

            //5.2.5
            private static void Exercise5(YearMonth[] ymCollection) {
                var newYmCollection = new YearMonth[ymCollection.Length];

                
                }
            }
        }
        
    }
}
