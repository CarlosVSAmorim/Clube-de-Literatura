namespace ClubeDeLiteratura.Entidades;

public class Caixa
{
    public int Id { get; set; }
    public string Etiqueta { get; set; }
    public string Cor { get; set; }
    public int DiasEmprestimo { get; set; }

    public string Validar()
    {
        if (string.IsNullOrWhiteSpace(Etiqueta) || Etiqueta.Length > 50)
            return "Etiqueta inválida (máx. 50 caracteres).";

        if (string.IsNullOrWhiteSpace(Cor))
            return "Cor é obrigatória.";

        if (DiasEmprestimo <= 0)
            return "Dias de empréstimo deve ser maior que zero.";

        return "VALIDO";
    }
}
