using ClubeDeLiteratura.Entidades;
using ClubeDeLiteratura.Repositorios;

namespace ClubeDeLiteratura.Telas;

using System;
using System.Collections.Generic;

public class TelaAmigo : TelaBase
{
    private RepositorioAmigo repositorio;

    public TelaAmigo(RepositorioAmigo repositorio) : base("Amigo")
    {
        this.repositorio = repositorio;
    }

    public void Inserir()
    {
        MostrarCabecalho("Cadastro de Amigo");
        Amigo amigo = ObterAmigo();
        string resultado = amigo.Validar();
        if (resultado != "Valido")
        {
            Console.WriteLine(resultado);
            return;
        }
        repositorio.Inserir(amigo);
        Console.WriteLine("Amigo cadastrado com sucesso!");
    }

    public void Editar()
    {
        MostrarCabecalho("Editando Amigo");

        VisualizarTodos();

        Console.Write("Digite o ID do amigo que deseja editar: ");
        int id = int.Parse(Console.ReadLine());

        Amigo amigoExistente = repositorio.SelecionarPorID(id);

        if (amigoExistente == null)
        {
            Console.WriteLine("Amigo não encontrado.");
            return;
        }

        Console.Write("Novo nome: ");
        amigoExistente.Nome = Console.ReadLine();

        Console.Write("Novo nome do responsável: ");
        amigoExistente.NomeResponsavel = Console.ReadLine();

        Console.Write("Novo telefone: ");
        amigoExistente.Telefone = Console.ReadLine();

        Console.WriteLine("Amigo editado com sucesso!");
    }

    public void Excluir()
    {
        MostrarCabecalho("Excluindo Amigo");

        VisualizarTodos();

        Console.Write("Digite o ID do amigo que deseja excluir: ");
        int id = int.Parse(Console.ReadLine());

        bool conseguiuExcluir = repositorio.Excluir(id);

        if (conseguiuExcluir)
            Console.WriteLine("Amigo excluído com sucesso!");
        else
            Console.WriteLine("Amigo não encontrado.");
    }

    public void VisualizarEmprestimo()
    {
        MostrarCabecalho("Visualizando Empréstimos do Amigo");

        VisualizarTodos();

        Console.Write("Digite o ID do amigo: ");
        int id = int.Parse(Console.ReadLine());

        // Exemplo básico (substituir por lógica real caso tenha um Repositório de Empréstimos relacionado)
        Console.WriteLine("Aqui você deve listar os empréstimos do amigo (precisa integrar com RepositorioEmprestimo)");
    }

    private Amigo ObterAmigo()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Nome do Responsável: ");
        string responsavel = Console.ReadLine();

        Console.Write("Telefone (formato (XX) XXXXX-XXXX): ");
        string telefone = Console.ReadLine();

        return new Amigo
        {
            Nome = nome,
            NomeResponsavel = responsavel,
            Telefone = telefone
        };
    }

    public void VisualizarTodos()
    {
        MostrarCabecalho("Visualizando Amigos");

        List<Amigo> amigos = repositorio.SelecionarTodos();

        foreach (Amigo a in amigos)
            Console.WriteLine($"{a.Id} - {a.Nome}, {a.Telefone}");
    }
}
