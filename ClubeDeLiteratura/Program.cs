using System;
using ClubeDeLiteratura.Entidades;
using ClubeDeLiteratura.Repositorios;
using ClubeDeLiteratura.Telas;

class Program
{
    static void Main(string[] args)
    {
        // Repositórios
        var repositorioAmigo = new RepositorioAmigo();
        var repositorioCaixa = new RepositorioCaixa();
        var repositorioRevista = new RepositorioRevista();
        var repositorioEmprestimo = new RepositorioEmprestimo();

        // Telas
        var telaAmigo = new TelaAmigo(repositorioAmigo);
        var telaCaixa = new TelaCaixa(repositorioCaixa);
        var telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
        var telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Clube da Leitura ====");
            Console.WriteLine("1 - Gerenciar Amigos");
            Console.WriteLine("2 - Gerenciar Caixas");
            Console.WriteLine("3 - Gerenciar Revistas");
            Console.WriteLine("4 - Gerenciar Empréstimos");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": MenuAmigos(telaAmigo); break;
                case "2": MenuCaixas(telaCaixa); break;
                case "3": MenuRevistas(telaRevista); break;
                case "4": MenuEmprestimos(telaEmprestimo); break;
                case "0": return;
                default:
                    Console.WriteLine("Opção inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void MenuAmigos(TelaAmigo tela)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Menu de Amigos ====");
            Console.WriteLine("1 - Inserir");
            Console.WriteLine("2 - Editar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Visualizar Todos");
            Console.WriteLine("5 - Visualizar Empréstimos");
            Console.WriteLine("0 - Voltar");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": tela.Inserir(); break;
                case "2": tela.Editar(); break;
                case "3": tela.Excluir(); break;
                case "4": tela.VisualizarTodos(); break;
                case "5": tela.VisualizarEmprestimo(); break;
                case "0": return;
                default: Console.WriteLine("Opção inválida."); break;
            }

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    static void MenuCaixas(TelaCaixa tela)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Menu de Caixas ====");
            Console.WriteLine("1 - Inserir");
            Console.WriteLine("2 - Editar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Visualizar Todos");
            Console.WriteLine("0 - Voltar");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": tela.Inserir(); break;
                case "2": tela.Editar(); break;
                case "3": tela.Excluir(); break;
                case "4": tela.VisualizarTodos(); break;
                case "0": return;
                default: Console.WriteLine("Opção inválida."); break;
            }

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    static void MenuRevistas(TelaRevista tela)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Menu de Revistas ====");
            Console.WriteLine("1 - Inserir");
            Console.WriteLine("2 - Editar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Visualizar Todos");
            Console.WriteLine("0 - Voltar");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": tela.Inserir(); break;
                case "2": tela.Editar(); break;
                case "3": tela.Excluir(); break;
                case "4": tela.VisualizarTodos(); break;
                case "0": return;
                default: Console.WriteLine("Opção inválida."); break;
            }

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    static void MenuEmprestimos(TelaEmprestimo tela)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Menu de Empréstimos ====");
            Console.WriteLine("1 - Registrar Empréstimo");
            Console.WriteLine("2 - Registrar Devolução");
            Console.WriteLine("3 - Visualizar Todos");
            Console.WriteLine("0 - Voltar");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": tela.Inserir(); break;
                case "2": tela.RegistrarDevolucao(); break;
                case "3": tela.VisualizarTodos(); break;
                case "0": return;
                default: Console.WriteLine("Opção inválida."); break;
            }

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
