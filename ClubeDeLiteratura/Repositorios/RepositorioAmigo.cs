using ClubeDeLiteratura.Repositorios;

namespace ClubeDeLiteratura.Entidades;

public class RepositorioAmigo : RepositorioBase<Amigo>
{
    protected override int ObterId(Amigo amigo) => amigo.Id;

    public override void Inserir(Amigo amigo)
    {
        amigo.Id = contadorId;
        base.Inserir(amigo);
    }
}
