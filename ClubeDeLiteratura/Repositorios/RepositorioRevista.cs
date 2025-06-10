using ClubeDeLiteratura.Entidades;

namespace ClubeDeLiteratura.Repositorios;

// Repositorios/RepositorioRevista.cs
public class RepositorioRevista : RepositorioBase<Revista>
{
    protected override int ObterId(Revista revista) => revista.Id;

    public override void Inserir(Revista revista)
    {
        revista.Id = contadorId;
        base.Inserir(revista);
    }

    public bool ExisteTituloEdicao(string titulo, int edicao)
    {
        return listaRegistros.Exists(r => r.Titulo == titulo && r.NumeroEdicao == edicao);
    }

    public List<Revista> SelecionarDisponiveis()
    {
        return listaRegistros.FindAll(r => r.Status == "Disponível");
    }
}
