using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {

    //P362 問題15.1
    public class LineToHalfNumberService : ITextFileService {
        public void Initialize (string fname) {

        }

        public void Execute(string line) { 
            //一行の処理を考える
            string result = new string(
                line.Select(c => ('Ｏ' <= c&& c <= '9')?　(char) (c - 'Ｏ' + 'O') : c).ToArray()
                ); 
            Console.WriteLine(result);
        }

        public void Terminate() {

        }
    }
}
