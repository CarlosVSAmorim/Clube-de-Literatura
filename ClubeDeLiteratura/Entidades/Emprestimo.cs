namespace ClubeDeLiteratura.Entidades;

// Entidades/Emprestimo.cs
using System;

public class Emprestimo
{
    public int Id { get; set; }
    public Amigo Amigo { get; set; }
    public Revista Revista { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucao { get; set; }
    public string Status { get; set; } = "Aberto";

    public string Validar()
    {
        if (Amigo == null)
            return "Amigo é obrigatório.";

        if (Revista == null)
            return "Revista é obrigatória.";

        if (Revista.Status != "Disponível")
            return "A revista não está disponível.";

        return "VALIDO";
    }

    public void CalcularDataDevolucao()
    {
        DataEmprestimo = DateTime.Now;
        DataDevolucao = DataEmprestimo.AddDays(Revista.Caixa.DiasEmprestimo);
    }

    public void RegistrarDevolucao()
    {
        Status = "Concluído";
        Revista.Devolver();
    }

    public bool EstaAtrasado()
    {
        return Status == "Aberto" && DateTime.Now > DataDevolucao;
    }
}
