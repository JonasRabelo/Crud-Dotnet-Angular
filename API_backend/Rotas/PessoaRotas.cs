using API_backend.Models;

namespace API_backend.Rotas
{
    public static class PessoaRotas
    {
        public static List<Pessoa> Pessoas = new List<Pessoa>() {
            new Pessoa(Guid.NewGuid(), "Neymar"),
            new Pessoa(Guid.NewGuid(), "Cristiano"),
            new Pessoa(Guid.NewGuid(), "Messi")
        };

        public static void MapPessoaRotas(this WebApplication app)
        {
            app.MapGet("/pessoas", () => Pessoas);
            app.MapGet("/pessoas/{nome}", (String nome) => Pessoas.Find(x => x.Nome.StartsWith(nome)));

            app.MapPost("/pessoas", (Pessoa pessoa) => {
                pessoa.Id = Guid.NewGuid();
                Pessoas.Add(pessoa);
                return Results.Ok(pessoa);
            });

            app.MapPut("/pessoas/{id}", (Guid id, Pessoa pessoa) => {
                var encontrado = Pessoas.Find(x => x.Id == id);

                if (encontrado == null)
                    return Results.NotFound();

                encontrado.Nome = pessoa.Nome;

                return Results.Ok(encontrado);
               

            });
        }
    }
}
