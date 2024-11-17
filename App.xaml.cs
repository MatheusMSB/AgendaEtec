using Microsoft.Maui.Controls; // Importante para usar classes do MAUI
using System;

namespace AgendaEtec
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Defina a página principal
            MainPage = new NavigationPage(new CadastroPage());
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(new NavigationPage(new CadastroPage()));
        }
    }
}