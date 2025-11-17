namespace TextProcessor {
    internal class Program {
        static void Main(string[] args) {
            var service = new LineCounterService();
            var prcessor = new TextFileProcessor(service);
            Console.Write("パスの入力:");

            prcessor.Run(Console.ReadLine());
        }
    }
}
