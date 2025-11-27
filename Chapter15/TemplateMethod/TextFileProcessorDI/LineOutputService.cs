using System;

namespace TextFileProcessorDI {
    public class LineOutputService : ITextFileService {
        private int _lineCount = 0;

        public void Initialize(string fname) {
            Console.WriteLine($"Start reading: {fname}");
            _lineCount = 0;
        }

        public void Execute(string line) {
            // 20行未満のときだけ出力する
            if (_lineCount < 20) {
                Console.WriteLine(line);
                _lineCount++;
            }
        }

        public void Terminate() {
            Console.WriteLine("Finished processing.");
        }
    }
}
