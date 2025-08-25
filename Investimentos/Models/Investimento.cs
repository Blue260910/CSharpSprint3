namespace ProjetoInvestimentos.Models;

public class Investimento
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string Codigo { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string Operacao { get; set; } = string.Empty; // "compra" ou "venda"
    public DateTime CriadoEm { get; set; } = DateTime.Now;
    public DateTime AlteradoEm { get; set; } = DateTime.Now;
}
