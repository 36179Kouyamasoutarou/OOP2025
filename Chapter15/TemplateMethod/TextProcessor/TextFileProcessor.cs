using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessorDI {
    public class TextFileProcessor {
        private ITextFileService _service;

        //    
        public TextFileProcessor(ITextFileService service) {
            _service = service; 
        }

        public void Run(string fileName) {
            _service.Intialize(fileName);

            var lines = File.ReadLines(fileName);
            foreach (var line in lines) {
                _service.Execute(line);
            }
            _service.Terminate();
        }
    }
}
