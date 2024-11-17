using Microsoft.Maui.Controls;
using AgendaEtec.Models; 

namespace AgendaEtec.Views
{
    public partial class ResumoPage : ContentPage
    {
        public ResumoPage(Evento evento)
        {
            InitializeComponent();
            BindingContext = evento; // Define o BindingContext para a instância do Evento
        }
    }
}