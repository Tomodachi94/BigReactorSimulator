using System;
using System.Collections.Generic;
using System.Windows;
using BigReactorSimulator.Tiles;
using BigReactorSimulator.Views.Tiles;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Reactor
{
    public class BigReactorViewModel : BaseViewModel
    {
        private Action ClearRowsCallback;
        private Action ClearColumnsCallback;

        private Action<TileViewModel, int, int> AddTileCallback;
        private Action<TileViewModel, int, int> RemoveTileCallback;
        private Action ClearTilesCallback;

        public int Rows;
        public int Column;

        public Dictionary<int, TileViewModel> Tiles;

        public BigReactorViewModel(
            Action clearRows, 
            Action clearColumns,
            Action<TileViewModel, int, int> addTile,
            Action<TileViewModel, int, int> removeTile,
            Action clearTiles)
        {
            this.ClearRowsCallback = clearRows;
            this.ClearColumnsCallback = clearColumns;
            this.AddTileCallback = addTile;
            this.RemoveTileCallback = removeTile;
            this.ClearTilesCallback = clearTiles;

            Tiles = new Dictionary<int, TileViewModel>(128);
        }

        public void SetTile(TileType type, int x, int y)
        {
            if (Tiles.TryGetValue(TilePosition.Hash(x, y), out TileViewModel tile))
            {
                tile.CurrentType = type;
            }
            else
            {
                tile = new ChangableTileViewModel();
                AddTile(TilePosition.Hash(x, y), tile);
                tile.CurrentType = type;
                AddTileCallback(tile, x, y);
            }
        }

        public void SetUneditableTile(TileType type, int x, int y)
        {
            int hash = TilePosition.Hash(x, y);
            if (Tiles.TryGetValue(hash, out TileViewModel tile))
            {
                // this case should never be reached because its extremely slow
                // there should never be an existing tile at the given X and Y coords
                // instead you should add uneditable tiles in a clever way such that the
                // tile will always be uneditable unfortunately.... i think
                Tiles.Remove(hash);
                tile = new UnchangableTileViewModel();
                AddTile(hash, tile);
                tile.CurrentType = type;
                RemoveTileCallback(tile, x, y);
                AddTileCallback(tile, x, y);
            }
            else
            {
                tile = new UnchangableTileViewModel();
                AddTile(hash, tile);
                tile.CurrentType = type;
                AddTileCallback(tile, x, y);
            }
        }

        private void AddTile(int hashXY, TileViewModel tile)
        {
            Tiles.Add(hashXY, tile);
        }

        public void ClearRows()
        {
            ClearRowsCallback();
        }

        public void ClearColumn()
        {
            ClearColumnsCallback();
        }

        public void ClearTiles()
        {
            ClearTilesCallback();
        }
    }
}
