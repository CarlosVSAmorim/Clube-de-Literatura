using ClubeDeLiteratura.Entidades;
using ClubeDeLiteratura.Repositorios;

namespace ClubeDeLiteratura.Telas;

using System;
using System.Collections.Generic;

public class TelaEmprestimo : TelaBase
{
    private RepositorioEmprestimo repositorioEmprestimo;
    private RepositorioAmigo repositorioAmigo;
    private RepositorioRevista repositorioRevista;

    public TelaEmprestimo(
        RepositorioEmprestimo repoEmprestimo,
        RepositorioAmigo repoAmigo,
        RepositorioRevista repoRevista
    ) : base("Empréstimos")
    {
        repositorioEmprestimo = repoEmprestimo;
        repositorioAmigo = repoAmigo;
        repositorioRevista = repoRevista;
    }

    public void Inserir()
    {
        MostrarCabecalho("Novo Empréstimo");

        Amigo amigo = SelecionarAmigo();
        if (repositorioEmprestimo.AmigoTemEmprestimoAtivo(amigo))
        {
            Console.WriteLine("Este amigo já possui um empréstimo ativo.");
            return;
        }

        Revista revista = SelecionarRevistaDisponivel();

        Emprestimo emprestimo = new Emprestimo
        {
            Amigo = amigo,
            Revista = revista
        };

        string validacao = emprestimo.Validar();
        if (validacao != "VALIDO")
        {
            Console.WriteLine(validacao);
            return;
        }

        emprestimo.CalcularDataDevolucao();
        revista.Emprestar();
        repositorioEmprestimo.Inserir(emprestimo);

        Console.WriteLine("Empréstimo registrado com sucesso!");
    }

    public void RegistrarDevolucao()
    {
        MostrarCabecalho("Registrar Devolução");

        List<Emprestimo> abertos = repositorioEmprestimo.SelecionarAbertos();

        foreach (Emprestimo e in abertos)
            Console.WriteLine($"{e.Id} - {e.Revista.Titulo} | {e.Amigo.Nome} - Devolução até {e.DataDevolucao:dd/MM/yyyy}");

        Console.Write("Informe o ID do empréstimo para devolver: ");
        int id = int.Parse(Console.ReadLine());

        Emprestimo emprestimo = repositorioEmprestimo.SelecionarPorID(id);
        if (emprestimo == null || emprestimo.Status != "Aberto")
        {
            Console.WriteLine("Empréstimo não encontrado ou já devolvido.");
            return;
        }

        emprestimo.RegistrarDevolucao();
        Console.WriteLine("Devolução registrada com sucesso.");
    }

    public void VisualizarTodos()
    {
        MostrarCabecalho("Lista de Empréstimos");

        List<Emprestimo> todos = repositorioEmprestimo.SelecionarTodos();

        foreach (Emprestimo e in todos)
        {
            string atraso = e.EstaAtrasado() ? " (ATRASADO)" : "";
            Console.WriteLine($"{e.Id} - {e.Revista.Titulo} para {e.Amigo.Nome} | Devolução: {e.DataDevolucao:dd/MM/yyyy} | Status: {e.Status}{atraso}");
        }
    }

    private Amigo SelecionarAmigo()
    {
        Console.WriteLine("Amigos disponíveis:");
        List<Amigo> amigos = repositorioAmigo.SelecionarTodos();

        foreach (Amigo a in amigos)
            Console.WriteLine($"{a.Id} - {a.Nome}");

        Console.Write("Digite o ID do amigo: ");
        int id = int.Parse(Console.ReadLine());

        return repositorioAmigo.SelecionarPorID(id);
    }

    private Revista SelecionarRevistaDisponivel()
    {
        Console.WriteLine("Revistas disponíveis:");
        List<Revista> revistas = repositorioRevista.SelecionarDisponiveis();

        foreach (Revista r in revistas)
            Console.WriteLine($"{r.Id} - {r.Titulo}");

        Console.Write("Digite o ID da revista: ");
        int id = int.Parse(Console.ReadLine());

        return repositorioRevista.SelecionarPorID(id);
    }
}
