using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views
{
    public class NewReactorViewModel : BaseViewModel
    {
        private int _length;
        public int Length
        {
            get => _length;
            set => RaisePropertyChanged(ref _length, value);
        }

        private int _width;
        public int Width
        {
            get => _width;
            set => RaisePropertyChanged(ref _width, value);
        }

        private int _height;
        public int Height
        {
            get => _height;
            set => RaisePropertyChanged(ref _height, value);
        }

        public Command CreateReactorCommand { get; }
        public Command CancelCreateCommand { get; }

        private Action CreateReactorCallback;

        public NewReactorViewModel(Action createReactorCallback)
        {
            this.CreateReactorCallback = createReactorCallback;
            CreateReactorCommand = new Command(CreateReactorCallback);

            CancelCreateCommand = new Command(WindowManager.HideNewReactor);
        }
    }
}
