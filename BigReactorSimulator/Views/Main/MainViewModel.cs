using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using BigReactorSimulator.Tiles;
using BigReactorSimulator.Views.Reactor;
using BigReactorSimulator.Views.Selector;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Main
{
    public class MainViewModel : BaseViewModel
    {
        private BigReactorViewModel _reactor;
        public BigReactorViewModel Reactor
        {
            get => _reactor;
            set => RaisePropertyChanged(ref _reactor, value);
        }

        private TileSelectorViewModel _selector;
        public TileSelectorViewModel Selector
        {
            get => _selector;
            set => RaisePropertyChanged(ref _selector, value);
        }

        public MainViewModel()
        {

        }
    }
}
