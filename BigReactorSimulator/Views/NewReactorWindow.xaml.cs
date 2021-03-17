using System.Windows;
using System.Windows.Input;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views
{
    /// <summary>
    /// Interaction logic for NewReactorWindow.xaml
    /// </summary>
    public partial class NewReactorWindow : Window, BaseView<NewReactorViewModel>
    {
        public NewReactorViewModel Model
        {
            get => this.DataContext as NewReactorViewModel; 
            set => this.DataContext = value;
        }

        public NewReactorWindow()
        {
            InitializeComponent();
        }

        private void LengthKeydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Width.Focus();
                Width.SelectAll();
            }
        }

        private void WidthKeydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Height.Focus();
                Height.SelectAll();
            }
        }

        private void HeightKeydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Model.CreateReactor();
            }
        }
    }
}
