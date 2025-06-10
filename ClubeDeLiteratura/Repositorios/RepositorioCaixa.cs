using ClubeDeLiteratura.Entidades;

namespace ClubeDeLiteratura.Repositorios;


public class RepositorioCaixa : RepositorioBase<Caixa>
{
    protected override int ObterId(Caixa caixa) => caixa.Id;

    public override void Inserir(Caixa caixa)
    {
        caixa.Id = contadorId;
        base.Inserir(caixa);
    }

    public bool EtiquetaJaExiste(string etiqueta)
    {
        return listaRegistros.Exists(c => c.Etiqueta == etiqueta);
    }
}
