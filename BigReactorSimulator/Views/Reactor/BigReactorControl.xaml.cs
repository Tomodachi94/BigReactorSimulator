using System.Windows.Controls;
using BigReactorSimulator.Views.Tiles;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Reactor
{
    /// <summary>
    /// Interaction logic for BigReactorControl.xaml
    /// </summary>
    public partial class BigReactorControl : UserControl, BaseView<BigReactorViewModel>
    {
        public BigReactorViewModel Model
        {
            get => this.DataContext as BigReactorViewModel;
            set => this.DataContext = value;
        }

        private Grid ReactorGrid;

        public BigReactorControl()
        {
            InitializeComponent();
            ReactorGrid = this.BlockGrid;

            Model = new BigReactorViewModel(
                InsertRow, 
                InsertColumn, 
                ClearRows, 
                ClearColumn,
                InsertTile,
                RemoveTile);
        }

        private void InsertTile(ChangableTileViewModel tile, int x, int y)
        {
            TileControl tileControl = new TileControl
            {
                Model = tile
            };
            InsertTileControl(tileControl, x, y);
        }

        private void InsertTileControl(TileControl tile, int x, int y)
        {
            ReactorGrid.Children.Add(tile);
            EnsureAddColumn(x);
            EnsureAddRow(y);
            Grid.SetColumn(tile, x);
            Grid.SetRow(tile, y);
        }

        private void RemoveTile(int x, int y)
        {
            RemoveColumn(x);
            RemoveRow(y);
        }

        private void EnsureAddRow(int targetRow)
        {
            if (ShouldAddRow(targetRow))
            {
                InsertRow();
            }
        }

        private void EnsureAddColumn(int targetColumn)
        {
            if (ShouldAddColumn(targetColumn))
            {
                InsertColumn();
            }
        }

        private bool ShouldAddRow(int targetRow)
        {
            return targetRow >= ReactorGrid.RowDefinitions.Count;
        }

        private bool ShouldAddColumn(int targetColumn)
        {
            return targetColumn >= ReactorGrid.ColumnDefinitions.Count;
        }

        private void InsertRow()
        {
            ReactorGrid.RowDefinitions.Add(new RowDefinition());
        }

        private void InsertColumn()
        {
            ReactorGrid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        private void RemoveRow(int index)
        {
            ReactorGrid.RowDefinitions.RemoveAt(index);
        }

        private void RemoveColumn(int index)
        {
            ReactorGrid.ColumnDefinitions.RemoveAt(index);
        }

        private void ClearRows()
        {
            ReactorGrid.RowDefinitions.Clear();
        }

        private void ClearColumn()
        {
            ReactorGrid.ColumnDefinitions.Clear();
        }
    }
}
