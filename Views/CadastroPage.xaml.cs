using Microsoft.Maui.Controls;

namespace SeuNamespace
{
    public partial class CadastroPage : ContentPage
    {
        public CadastroPage()
        {
            InitializeComponent();
            BindingContext = new CadastroViewModel();
        }
    }
}