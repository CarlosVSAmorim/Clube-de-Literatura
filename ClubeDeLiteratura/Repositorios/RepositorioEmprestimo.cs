using ClubeDeLiteratura.Entidades;

namespace ClubeDeLiteratura.Repositorios;

// Repositorios/RepositorioEmprestimo.cs
public class RepositorioEmprestimo : RepositorioBase<Emprestimo>
{
    protected override int ObterId(Emprestimo emprestimo) => emprestimo.Id;

    public override void Inserir(Emprestimo emprestimo)
    {
        emprestimo.Id = contadorId;
        base.Inserir(emprestimo);
    }

    public List<Emprestimo> SelecionarAbertos()
    {
        return listaRegistros.FindAll(e => e.Status == "Aberto");
    }

    public bool AmigoTemEmprestimoAtivo(Amigo amigo)
    {
        return listaRegistros.Exists(e => e.Amigo == amigo && e.Status == "Aberto");
    }
}
