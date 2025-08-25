using ProjetoInvestimentos.Models;
using ProjetoInvestimentos.Repositories;

var builder = WebApplication.CreateBuilder(args);

// --- Habilita CORS (mesmo que o HTML esteja local, evita bloqueio) ---
builder.Services.AddCors();

var app = builder.Build();

// --- Serve arquivos estáticos da pasta wwwroot ---
app.UseDefaultFiles(); // Procura automaticamente por index.html
app.UseStaticFiles();

// --- CORS liberado para testes ---
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

// --- Conexão com Supabase ---
string connectionString = "Host=db.oziwendirtmqquvqkree.supabase.co;Port=5432;Username=postgres;Password=vqUfvs3b3RgDrEpX;Database=postgres;SSL Mode=Require;Trust Server Certificate=true";
var repo = new InvestimentoRepository(connectionString);

// --- Endpoints ---

app.MapGet("/", () => Results.Redirect("/index.html"));

// Inserir investimento
app.MapPost("/investimentos", (Investimento inv) =>
{
    repo.InserirInvestimento(inv);
    return Results.Created($"/investimentos/{inv.Id}", inv);
});

// Listar investimentos por usuário
app.MapGet("/investimentos/{userId:guid}", (Guid userId) =>
{
    var lista = repo.ListarPorUsuario(userId);
    return Results.Ok(lista);
});

// Opcional: atualizar investimento
app.MapPut("/investimentos/{id:guid}", (Guid id, Investimento inv) =>
{
    inv.Id = id;
    repo.AtualizarInvestimento(inv);
    return Results.Ok(inv);
});

// Opcional: deletar investimento
app.MapDelete("/investimentos/{id:guid}", (Guid id) =>
{
    repo.DeletarInvestimento(id);
    return Results.Ok();
});

app.Run("http://localhost:5171");