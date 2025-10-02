using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace HelloWorld {

    class ViewModel : BindableBase {

        public ViewModel() {

            ChangeMessageCommand = new DelegateCommand<string>(

                (par) => GreetingMessage = par,

                (par) => GreetingMessage != par)

                .ObservesProperty(() => GreetingMessage);

        }

        private string _greetingMessage = "Hello World!";

        public string GreetingMessage {

            get => _greetingMessage;

            set => SetProperty(ref _greetingMessage, value);

        }

        //private bool _canChangedMessage = true;

        //public bool CanChangedMessage {

        //    get => _canChangedMessage;

        //    private set => SetProperty(ref _canChangedMessage, value);

        //}

        public string NewMessage1 { get; } = "ばいばいワールド";

        public string NewMessage2 { get; } = "こんにちワールド";

        public DelegateCommand<string> ChangeMessageCommand { get; }

    }

}

