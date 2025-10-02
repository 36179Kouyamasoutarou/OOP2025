using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class ViewModel : BindableBase
    {
        public ViewModel() {
            ChangeMessageCommand = new DelegateCommand(
                () => GreetingMessage = "Paipai-World");


        }
        private string _greetingMessage = "HelloMessage";
        public string GreetingMessage {
            get=>_greetingMessage;
            set => SetProperty(ref _greetingMessage, value);
       
            }

        public DelegateCommand ChangeMessageCommand { get; }

     
    }
}
