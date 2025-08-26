using Npgsql;
using ProjetoInvestimentos.Models;

namespace ProjetoInvestimentos.Repositories;

public class InvestimentoRepository
{
    private readonly string _connectionString;

    public InvestimentoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Inserir investimento
    public void InserirInvestimento(Investimento investimento)
    {
        using var conn = new NpgsqlConnection(_connectionString);
        conn.Open();

        var sql = @"INSERT INTO public.investimentos 
                    (user_id, tipo, codigo, valor, operacao) 
                    VALUES (@UserId, @Tipo, @Codigo, @Valor, @Operacao)";

        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("UserId", investimento.UserId);
        cmd.Parameters.AddWithValue("Tipo", investimento.Tipo);
        cmd.Parameters.AddWithValue("Codigo", investimento.Codigo);
        cmd.Parameters.AddWithValue("Valor", investimento.Valor);
        cmd.Parameters.AddWithValue("Operacao", investimento.Operacao);

        cmd.ExecuteNonQuery();
    }

    // Listar todos os investimentos de um usuário
    public List<Investimento> ListarPorUsuario(string UserCpf)
    {
        var lista = new List<Investimento>();

        using var conn = new NpgsqlConnection(_connectionString);
        conn.Open();

        Console.WriteLine($"Conectado ao banco de dados: {conn.Database}");

        var sql = @"
            SELECT id, user_id, tipo, codigo, valor, operacao, criado_em, alterado_em
            FROM public.investimentos
            WHERE user_id IN (
                SELECT id 
                FROM public.user_profiles
                WHERE cpf = @Cpf
            )";

        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("Cpf", UserCpf);

        Console.WriteLine($"Parâmetro Cpf: {UserCpf}");

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new Investimento
            {
                Id = reader.GetGuid(0),
                UserId = reader.GetGuid(1),
                Tipo = reader.GetString(2),
                Codigo = reader.GetString(3),
                Valor = reader.GetDecimal(4),
                Operacao = reader.GetString(5),
                CriadoEm = reader.GetDateTime(6),
                AlteradoEm = reader.GetDateTime(7)
            });
        }

        return lista;
    }

    // Opcional: atualizar valor de um investimento
    public void AtualizarInvestimento(Investimento investimento)
    {
        using var conn = new NpgsqlConnection(_connectionString);
        conn.Open();

        var sql = @"UPDATE public.investimentos 
                    SET tipo=@Tipo, codigo=@Codigo, valor=@Valor, operacao=@Operacao, alterado_em=NOW()
                    WHERE id=@Id";

        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("Id", investimento.Id);
        cmd.Parameters.AddWithValue("Tipo", investimento.Tipo);
        cmd.Parameters.AddWithValue("Codigo", investimento.Codigo);
        cmd.Parameters.AddWithValue("Valor", investimento.Valor);
        cmd.Parameters.AddWithValue("Operacao", investimento.Operacao);

        cmd.ExecuteNonQuery();
    }

    // Opcional: deletar investimento
    public void DeletarInvestimento(Guid investimentoId)
    {
        using var conn = new NpgsqlConnection(_connectionString);
        conn.Open();

        var sql = @"DELETE FROM public.investimentos WHERE id=@Id";

        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("Id", investimentoId);

        cmd.ExecuteNonQuery();
    }
}
