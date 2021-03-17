using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BigReactorSimulator.Tiles;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Selector
{
    public class TileSelectorViewModel : BaseViewModel
    {
        private static Thickness THICKNESS_CRYOTHEUM = new Thickness(0, 0, 0, 0);
        private static Thickness THICKNESS_ENDER = new Thickness(65, 0, 0, 0);
        private static Thickness THICKNESS_DIAMOND = new Thickness(130, 0, 0, 0);
        private static Thickness THICKNESS_GRAPHITE = new Thickness(195, 0, 0, 0);
        private static Thickness THICKNESS_REDSTONE = new Thickness(0, 65, 0, 0);
        private static Thickness THICKNESS_CONTROLROD = new Thickness(65, 65, 0, 0);
        private static Thickness THICKNESS_GOLD = new Thickness(130, 65, 0, 0);
        private static Thickness THICKNESS_AIR = new Thickness(195, 65, 0, 0);

        private TileType _selectedType;
        public TileType SelectedType
        {
            get => _selectedType;
            set => RaisePropertyChanged(ref _selectedType, value, UpdateSelector);
        }

        private Thickness _selectorMargin;
        public Thickness SelectorMargin
        {
            get => _selectorMargin;
            set => RaisePropertyChanged(ref _selectorMargin, value);
        }

        private Action<Thickness> SetSelectorThickness;

        public TileSelectorViewModel(Action<Thickness> setSelectorThickness)
        {
            this.SetSelectorThickness = setSelectorThickness;
        }

        public void UpdateSelector(TileType newType)
        {
            switch (newType)
            {
                case TileType.BlockReactorControlRod:
                    SetSelectorThickness(THICKNESS_CONTROLROD);
                    break;
                case TileType.BlockConductorDiamond:
                    SetSelectorThickness(THICKNESS_DIAMOND);
                    break;
                case TileType.BlockConductorGold:
                    SetSelectorThickness(THICKNESS_GOLD);
                    break;
                case TileType.BlockConductorGraphite:
                    SetSelectorThickness(THICKNESS_GRAPHITE);
                    break;
                case TileType.BlockConductorAir:
                    SetSelectorThickness(THICKNESS_AIR);
                    break;
                case TileType.LiquidCryotheum:
                    SetSelectorThickness(THICKNESS_CRYOTHEUM);
                    break;
                case TileType.LiquidEnder:
                    SetSelectorThickness(THICKNESS_ENDER);
                    break;
                case TileType.LiquidRedstone:
                    SetSelectorThickness(THICKNESS_REDSTONE);
                    break;
            }
        }
    }
}
