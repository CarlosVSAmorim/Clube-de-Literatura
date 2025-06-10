namespace ClubeDeLiteratura.Entidades;

public class Amigo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string NomeResponsavel { get; set; }
    public string Telefone { get; set; }

    public string Validar()
    {
        if (String.IsNullOrWhiteSpace(Nome) || Nome.Length < 3 || Nome.Length > 100)
        {
            return "Nome Inválido.";
        }

        if (String.IsNullOrWhiteSpace(NomeResponsavel) || NomeResponsavel.Length < 3 || NomeResponsavel.Length > 100)
        {
            return "Nome do Responsável Inválido.";
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(Telefone,@"^\(\d{2}\) \d{4,5}-\d{4}$"))
        {
            return "Telefone Inválido.";
        }
        return "Valido";
    }
}