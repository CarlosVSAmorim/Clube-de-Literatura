namespace ClubeDeLiteratura.Telas;

using System;
public class TelaBase
{
    protected String nomeEntidade;

    public TelaBase(string nomeEntidade)
    {
        this.nomeEntidade = nomeEntidade;
    }

    public virtual void MostrarCabecalho(String titulo)
    {
        Console.Clear();
        Console.WriteLine($"==={titulo} === \n");
    }

    public virtual void MostrarOpcoes()
    {
        Console.WriteLine($"[1] Inserir {nomeEntidade}");
        Console.WriteLine($"[2] Editar {nomeEntidade}");
        Console.WriteLine($"[3] Excluir {nomeEntidade}");
        Console.WriteLine($"[4] Visualizar {nomeEntidade}");
        Console.WriteLine($"[0] Voltar");
        Console.Write("Escolha uma opção: ");
    }
}