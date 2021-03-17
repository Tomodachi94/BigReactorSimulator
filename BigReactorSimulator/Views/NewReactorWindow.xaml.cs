using System.Windows;
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
    }
}
