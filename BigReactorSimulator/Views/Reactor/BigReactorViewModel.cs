using System;
using BigReactorSimulator.Tiles;
using BigReactorSimulator.Views.Tiles;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Reactor
{
    public class BigReactorViewModel : BaseViewModel
    {
        private Action InsertRowCallback;
        private Action InsertColumnCallback;

        private Action ClearRowsCallback;
        private Action ClearColumnsCallback;

        private Action<ChangableTileViewModel, int, int> InsertTileCallback;
        private Action<int, int> RemoveTileCallback;
        private Action ClearTilesCallback;

        public int Rows;
        public int Column;

        public BigReactorViewModel(
            Action insertRow, 
            Action insertColumn, 
            Action clearRows, 
            Action clearColumns,
            Action<ChangableTileViewModel, int, int> insertTile,
            Action<int, int> removeTile, 
            Action clearTiles)
        {
            this.InsertRowCallback = insertRow;
            this.InsertColumnCallback = insertColumn;
            this.ClearRowsCallback = clearRows;
            this.ClearColumnsCallback = clearColumns;
            this.InsertTileCallback = insertTile;
            this.RemoveTileCallback = removeTile;
            this.ClearTilesCallback = clearTiles;
        }

        public void AddTile(TileType type, int x, int y)
        {
            ChangableTileViewModel tile = new ChangableTileViewModel();
            tile.CurrentType = type;
            InsertTileCallback(tile, x, y);
        }

        public void RemoveTile(int x, int y)
        {
            RemoveTileCallback(x, y);
        }

        public void InsertRow()
        {
            InsertRowCallback();
        }

        public void InsertColumn()
        {
            InsertColumnCallback();
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
