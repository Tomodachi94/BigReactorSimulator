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
        public BigReactorViewModel Reactor { get; set; }

        public TileSelectorViewModel Selector { get; set; }

        public NewReactorViewModel NewReactor { get; set; }

        public Command ShowNewWindowCommand { get; }

        public MainViewModel()
        {
            ShowNewWindowCommand = new Command(WindowManager.ShowNewReactor);
        }

        public void CreateReactor()
        {
            Reactor.ClearColumn();
            Reactor.ClearRows();
            Reactor.ClearTiles();

            for (int x = 0; x < NewReactor.Width; x++)
            {
                for (int z = 0; z < NewReactor.Length; z++)
                {
                    Reactor.AddTile(TileType.BlockConductorDiamond, x, z);
                }
            }
        }
    }
}
