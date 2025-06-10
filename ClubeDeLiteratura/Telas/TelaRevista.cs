using ClubeDeLiteratura.Entidades;
using ClubeDeLiteratura.Repositorios;

namespace ClubeDeLiteratura.Telas;

// Telas/TelaRevista.cs
using System;
using System.Collections.Generic;

public class TelaRevista : TelaBase
{
    private RepositorioRevista repositorioRevista;
    private RepositorioCaixa repositorioCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa) 
        : base("Revista")
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }

    public void Inserir()
    {
        MostrarCabecalho("Cadastro de Revista");

        Revista revista = ObterRevista();

        string resultado = revista.Validar();
        if (resultado != "VALIDO")
        {
            Console.WriteLine(resultado);
            return;
        }

        if (repositorioRevista.ExisteTituloEdicao(revista.Titulo, revista.NumeroEdicao))
        {
            Console.WriteLine("Já existe uma revista com esse título e edição.");
            return;
        }

        repositorioRevista.Inserir(revista);
        Console.WriteLine("Revista cadastrada com sucesso!");
    }

    private Revista ObterRevista()
    {
        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Número da edição: ");
        int edicao = int.Parse(Console.ReadLine());

        Console.Write("Ano de publicação: ");
        int ano = int.Parse(Console.ReadLine());

        Caixa caixaSelecionada = SelecionarCaixa();

        return new Revista
        {
            Titulo = titulo,
            NumeroEdicao = edicao,
            Ano = ano,
            Caixa = caixaSelecionada
        };
    }
    public void Editar()
    {
        MostrarCabecalho("Editando Revista");

        VisualizarTodos();

        Console.Write("Digite o ID da revista que deseja editar: ");
        int id = int.Parse(Console.ReadLine());

        Revista revistaExistente = repositorioRevista.SelecionarPorID(id);
        if (revistaExistente == null)
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        Revista novaRevista = ObterRevista();

        string resultado = novaRevista.Validar();
        if (resultado != "VALIDO")
        {
            Console.WriteLine(resultado);
            return;
        }

        if (repositorioRevista.ExisteTituloEdicao(novaRevista.Titulo, novaRevista.NumeroEdicao) &&
            !(novaRevista.Titulo == revistaExistente.Titulo && novaRevista.NumeroEdicao == revistaExistente.NumeroEdicao))
        {
            Console.WriteLine("Já existe uma revista com esse título e edição.");
            return;
        }

        repositorioRevista.Editar(id, novaRevista);
        Console.WriteLine("Revista editada com sucesso!");
    }
    public void Excluir()
    {
        MostrarCabecalho("Excluindo Revista");

        VisualizarTodos();

        Console.Write("Digite o ID da revista que deseja excluir: ");
        int id = int.Parse(Console.ReadLine());

        Revista revista = repositorioRevista.SelecionarPorID(id);
        if (revista == null)
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        if (revista.Status != "Disponível")
        {
            Console.WriteLine("Não é possível excluir uma revista que está emprestada ou reservada.");
            return;
        }

        repositorioRevista.Excluir(id);
        Console.WriteLine("Revista excluída com sucesso!");
    }
    private Caixa SelecionarCaixa()
    {
        Console.WriteLine("Caixas disponíveis:");
        List<Caixa> caixas = repositorioCaixa.SelecionarTodos();

        foreach (Caixa caixa in caixas)
            Console.WriteLine($"{caixa.Id} - {caixa.Etiqueta}");

        Console.Write("Digite o ID da caixa: ");
        int id = int.Parse(Console.ReadLine());

        return repositorioCaixa.SelecionarPorID(id);
    }

    public void VisualizarTodos()
    {
        MostrarCabecalho("Visualizando Revistas");

        List<Revista> revistas = repositorioRevista.SelecionarTodos();

        foreach (Revista r in revistas)
            Console.WriteLine($"{r.Id} - \"{r.Titulo}\" Edição {r.NumeroEdicao}, Ano {r.Ano}, Status: {r.Status}, Caixa: {r.Caixa.Etiqueta}");
    }
}
