using ClubeDeLiteratura.Entidades;
using ClubeDeLiteratura.Repositorios;
using System;
using System.Collections.Generic;

namespace ClubeDeLiteratura.Telas
{
    public class TelaCaixa : TelaBase
    {
        private RepositorioCaixa repositorio;

        public TelaCaixa(RepositorioCaixa repositorio) : base("Caixa")
        {
            this.repositorio = repositorio;
        }

        public void Inserir()
        {
            MostrarCabecalho("Cadastro de Caixa");

            Caixa caixa = ObterCaixa();

            string resultado = caixa.Validar();
            if (resultado != "VALIDO")
            {
                Console.WriteLine(resultado);
                return;
            }

            if (repositorio.EtiquetaJaExiste(caixa.Etiqueta))
            {
                Console.WriteLine("Etiqueta já cadastrada.");
                return;
            }

            repositorio.Inserir(caixa);
            Console.WriteLine("Caixa cadastrada com sucesso!");
        }

        private Caixa ObterCaixa()
        {
            Console.Write("Etiqueta: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Cor (Hex ou nome): ");
            string cor = Console.ReadLine();

            Console.Write("Dias de Empréstimo (padrão 7): ");
            int dias = int.TryParse(Console.ReadLine(), out int result) ? result : 7;

            return new Caixa
            {
                Etiqueta = etiqueta,
                Cor = cor,
                DiasEmprestimo = dias
            };
        }

        public void VisualizarTodos()
        {
            MostrarCabecalho("Visualizando Caixas");

            List<Caixa> caixas = repositorio.SelecionarTodos();

            foreach (Caixa c in caixas)
                Console.WriteLine($"{c.Id} - Etiqueta: {c.Etiqueta}, Cor: {c.Cor}, Dias: {c.DiasEmprestimo}");
        }

        public void Editar()
        {
            MostrarCabecalho("Editando Caixa");

            VisualizarTodos();

            Console.Write("Digite o ID da caixa que deseja editar: ");
            int id = int.Parse(Console.ReadLine());

            Caixa caixaExistente = repositorio.SelecionarPorID(id);
            if (caixaExistente == null)
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Caixa novaCaixa = ObterCaixa();

            string resultado = novaCaixa.Validar();
            if (resultado != "VALIDO")
            {
                Console.WriteLine(resultado);
                return;
            }

            if (repositorio.EtiquetaJaExiste(novaCaixa.Etiqueta) && novaCaixa.Etiqueta != caixaExistente.Etiqueta)
            {
                Console.WriteLine("Já existe uma caixa com essa etiqueta.");
                return;
            }

            repositorio.Editar(id, novaCaixa);

            Console.WriteLine("Caixa editada com sucesso!");
        }


        public void Excluir()
        {
            MostrarCabecalho("Excluindo Caixa");

            VisualizarTodos();

            Console.Write("Digite o ID da caixa que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Caixa caixa = repositorio.SelecionarPorID(id);
            if (caixa == null)
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            bool conseguiuExcluir = repositorio.Excluir(id);

            if (conseguiuExcluir)
                Console.WriteLine("Caixa excluída com sucesso!");
            else
                Console.WriteLine("Erro ao excluir caixa.");
        }
    }
}
