using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismObservesSample
{
    internal class MainWindowViewModel :  BindableBase{
        private string _input1 = "";
        public string Input1 {
            get => _input1;
            set;
        }

        private string _input2 = "";
        public string Input2 {
            get => _input2;
            set;
        }

        private string _result = "";
        public string Result{
            get => _result;
            set; //←処理を追加
        }

        //コンストラクタ
        public MainWindowViewModel() {
            SumCommand = new DelegateCommand(ExcuteSum);
        }
        public DelegateCommand SumCommand { get; }

        //足し算の処理
        private void ExcuteSum() {
            //足し算の処理を記述




        }
    }
}
