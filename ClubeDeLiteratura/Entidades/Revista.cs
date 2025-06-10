namespace ClubeDeLiteratura.Entidades;

// Entidades/Revista.cs
using System;

public class Revista
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int NumeroEdicao { get; set; }
    public int Ano { get; set; }
    public string Status { get; set; } = "Disponível";
    public Caixa Caixa { get; set; }

    public string Validar()
    {
        if (string.IsNullOrWhiteSpace(Titulo) || Titulo.Length < 2 || Titulo.Length > 100)
            return "Título inválido (mínimo 2 e máximo 100 caracteres).";

        if (NumeroEdicao <= 0)
            return "Número da edição deve ser positivo.";

        if (Ano < 1900 || Ano > DateTime.Now.Year)
            return "Ano de publicação inválido.";

        if (Caixa == null)
            return "Caixa é obrigatória.";

        return "VALIDO";
    }

    public void Emprestar()
    {
        Status = "Emprestada";
    }

    public void Devolver()
    {
        Status = "Disponível";
    }

    public void Reservar()
    {
        Status = "Reservada";
    }
}
