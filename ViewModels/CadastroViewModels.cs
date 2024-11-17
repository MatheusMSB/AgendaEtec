using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using AgendaEtec.Views; 
using AgendaEtec.Models; 

public class CadastroViewModel : INotifyPropertyChanged
{
    private string nome;
    private DateTime dataInicio;
    private DateTime dataTermino;
    private int numeroParticipantes;
    private string local;
    private decimal custoPorParticipante;

    public Evento Evento { get; set; } = new Evento();

    public string Nome
    {
        get => nome;
        set
        {
            nome = value;
            OnPropertyChanged(nameof(Nome));
        }
    }

    public DateTime DataInicio
    {
        get => dataInicio;
        set
        {
            dataInicio = value;
            OnPropertyChanged(nameof(DataInicio));
        }
    }

    public DateTime DataTermino
    {
        get => dataTermino;
        set
        {
            dataTermino = value;
            OnPropertyChanged(nameof(DataTermino));
        }
    }

    public int NumeroParticipantes
    {
        get => numeroParticipantes;
        set
        {
            numeroParticipantes = value;
            OnPropertyChanged(nameof(NumeroParticipantes));
        }
    }

    public string Local
    {
        get => local;
        set
        {
            local = value;
            OnPropertyChanged(nameof(Local));
        }
    }

    public decimal CustoPorParticipante
    {
        get => custoPorParticipante;
        set
        {
            custoPorParticipante = value;
            OnPropertyChanged(nameof(CustoPorParticipante));
        }
    }

    public ICommand CadastrarEventoCommand { get; }

    public CadastroViewModel()
    {
        CadastrarEventoCommand = new Command(async () => await CadastrarEvento());
        DataInicio = DateTime.Now; // Define a data de início padrão
        DataTermino = DateTime.Now; // Define a data de término padrão
    }

    private async Task CadastrarEvento()
    {
        // Validação dos dados
        if (DataInicio > DataTermino)
        {
            await Application.Current.MainPage.DisplayAlert("Erro", "A data de início não pode ser maior que a data de término.", "OK");
            return;
        }

        // Atualiza o objeto Evento com os dados do ViewModel
        Evento.Nome = Nome;
        Evento.DataInicio = DataInicio;
        Evento.DataTermino = DataTermino;
        Evento.NumeroParticipantes = NumeroParticipantes;
        Evento.Local = Local;
        Evento.CustoPorParticipante = CustoPorParticipante;
        Evento.CustoTotal = CustoPorParticipante * NumeroParticipantes; // Cálculo do custo total

        // Navegar para a página de resumo
        await Application.Current.MainPage.Navigation.PushAsync(new ResumoPage(Evento));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}