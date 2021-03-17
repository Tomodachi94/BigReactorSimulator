using System.Windows.Controls;
using System.Windows.Input;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Tiles
{
    /// <summary>
    /// Interaction logic for ChangableTileControl.xaml
    /// </summary>
    public partial class TileControl : UserControl, BaseView<TileViewModel>
    {
        public TileViewModel Model
        {
            get => base.DataContext as TileViewModel;
            set => base.DataContext = value;
        }

        private bool HasClicked;

        public TileControl()
        {
            InitializeComponent();
            HasClicked = false;
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Model.CanDragChangeTile)
            {
                if (HasClicked)
                    return;

                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    HasClicked = true;
                    Model.OnClick();
                }
            }
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Model.CanDragChangeTile)
            {
                HasClicked = false;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Model.CanDragChangeTile)
            {
                if (HasClicked)
                    return;

                HasClicked = true;
                Model.OnClick();
            }
            else
            {
                HasClicked = true;
                Model.OnClick();
            }
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Model.CanDragChangeTile)
            {
                HasClicked = false;
            }
        }
    }
}
