using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    //問題15.1
    internal class LineToHalfNumberService : ITextFileService {
        private static Dictionary<char,char> _dictionary =
        new Dictionary<char,char>(){
            {'０','0'},{'１','1'},{'２','2'},{'３','3'},{'４','4'},
            {'５','5'},{'６','6'},{'７','7'},{'８','8'},{'９','9'},
            };

        public void Initialize(string fname) {
        }

        public void Execute(string line) {
        //    Console.WriteLine(line.Normalize(NormalizationForm.FormKD));

        
        }

        public void Terminate() {
            Console.WriteLine("変換終了");
        }
    }
}

        //// 全角数字を半角数字に変換するメソッド
        //private string ConvertToHalfNumbers(string text) {          
        //            char ConvertChar(char c) {
        //                if (c >= '０' && c <= '９') {
        //                    return (char)(c - 0xFEE0);
        //                }
        //                return c;
        //            }

        //            char[] chars = text.ToCharArray();
        //            for (int i = 0; i < chars.Length; i++) {
        //                chars[i] = ConvertChar(chars[i]);
        //            }
        //            return new string(chars);
        //        }
        //    }
        //}
