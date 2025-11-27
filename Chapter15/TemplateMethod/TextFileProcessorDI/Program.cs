namespace TextFileProcessorDI {
    internal class Program {
        static void Main(string[] args) {
            var service = new LineToHalfNumberService();
            //var service = new LineCounterService();
            //var service = new LineOutputService();
            var processor = new TextFileProcessor(service);
            Console.Write("パスの入力");
            String path = Console.ReadLine();
            path = path.Trim().Trim('"');
            processor.Run(path) ;            
        }
    }
}
