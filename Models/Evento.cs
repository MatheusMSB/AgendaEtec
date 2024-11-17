// Evento.cs
namespace AgendaEtec.Models 
{
    public class Evento
    {
        public required string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int NumeroParticipantes { get; set; }
        public required string Local { get; set; }
        public decimal CustoPorParticipante { get; set; }
        public decimal CustoTotal { get; set; }

        // Propriedade calculada para a duração em dias
        public int DuracaoEmDias => (DataTermino - DataInicio).Days;
    }
}