﻿using BigReactorSimulator.Tiles;
using BigReactorSimulator.Views.Reactor;
using BigReactorSimulator.Views.ReactorCosts;
using BigReactorSimulator.Views.ReactorStats;
using BigReactorSimulator.Views.Selector;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Main
{
    public class MainViewModel : BaseViewModel
    {
        public BigReactorViewModel Reactor { get; set; }

        public TileSelectorViewModel Selector { get; set; }

        public NewReactorViewModel NewReactor { get; set; }

        public ReactorStatsViewModel ReactorStats { get; }

        public ReactorEfficiencyViewModel ReactorEfficiency { get; }

        public ReactorCostsViewModel ReactorCosts { get; }

        public Command ShowNewWindowCommand { get; }

        public Command FillReactorCommand { get; }

        public int InternalWidth;
        public int InternalLength;
        public int InternalHeight;

        public MainViewModel()
        {
            // these will only ever bind to the view once hense why they're just getters
            // properties are always settable in the constructor though ;)
            ReactorStats = new ReactorStatsViewModel();
            ReactorEfficiency = new ReactorEfficiencyViewModel();
            ReactorCosts = new ReactorCostsViewModel();

            ReactorStats.Heat = 10000;
            ShowNewWindowCommand = new Command(WindowManager.ShowNewReactor);

            FillReactorCommand = new Command(FillReactorWithSelectedTile);
        }

        public void OnTileAdded(TileType type)
        {

        }

        public void CreateReactorFromView()
        {
            InternalWidth = NewReactor.Width;
            InternalLength = NewReactor.Length;
            InternalHeight = NewReactor.Height;

            int interiorX = InternalWidth;
            int interiorY = InternalLength;
            int totalX = interiorX + 2;
            int totalY = interiorY + 2;
            int totalHeight = InternalHeight + 2;

            Reactor.ClearColumn();
            Reactor.ClearRows();
            Reactor.ClearTiles();
            Reactor.Tiles.Clear();

            AddCasingTop(totalX);

            for(int y = 1; y <= interiorY; y++)
            {
                AddBordersAndTypeColumn(TileType.BlockConductorAir, totalX, y);
            }

            AddCasingBottom(totalX, totalY);

            ReactorCosts.ClearItems();
            ReactorCosts.AddCasingReactor(totalY, totalX, totalHeight, 3, 4);
        }

        public void FillReactorWithSelectedTile()
        {
            int interiorX = InternalWidth;
            int interiorY = InternalLength;

            TileType selected = TileSelector.GetSelectedTile();

            for (int y = 1; y <= interiorY; y++)
            {
                for (int x = 1; x <= interiorX; x++)
                {
                    Reactor.SetTile(selected, x, y);
                }
            }
        }

        private void AddCasingTop(int totalX)
        {
            for(int x = 0, totalXn1 = totalX - 1; x < totalX; x++)
            {
                if (x == 0 || x == totalXn1)
                {
                    Reactor.SetUneditableTile(TileType.BlockReactorCaseCorner, x, 0);
                }
                else
                {
                    Reactor.SetUneditableTile(TileType.BlockReactorCaseHorizontal, x, 0);
                }
            }
        }

        private void AddBordersAndTypeColumn(TileType type, int totalX, int currentY)
        {
            for (int x = 0, totalXn1 = totalX - 1; x < totalX; x++)
            {
                if (x == 0 || x == totalXn1)
                {
                    Reactor.SetUneditableTile(TileType.BlockReactorCaseVertical, x, currentY);
                }
                else
                {
                    Reactor.SetTile(type, x, currentY);
                }
            }
        }

        private void AddCasingBottom(int totalX, int totalY)
        {
            totalY = totalY - 1;
            for (int x = 0, totalXn1 = totalX - 1; x < totalX; x++)
            {
                if (x == 0 || x == totalXn1)
                {
                    Reactor.SetUneditableTile(TileType.BlockReactorCaseCorner, x, totalY);
                }
                else
                {
                    Reactor.SetUneditableTile(TileType.BlockReactorCaseHorizontal, x, totalY);
                }
            }
        }
    }
}
