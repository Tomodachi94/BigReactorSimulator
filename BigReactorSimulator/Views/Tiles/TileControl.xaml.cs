using System.Windows.Controls;
using System.Windows.Input;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Tiles
{
    /// <summary>
    /// Interaction logic for ChangableTileControl.xaml
    /// </summary>
    public partial class TileControl : UserControl, BaseView<ChangableTileViewModel>
    {
        public ChangableTileViewModel Model
        {
            get => base.DataContext as ChangableTileViewModel;
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
            if (HasClicked)
                return;

            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                HasClicked = true;
                Model.OnClick();
            }
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            HasClicked = false;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (HasClicked)
                return;

            HasClicked = true;
            Model.OnClick();
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HasClicked = false;
        }
    }
}
