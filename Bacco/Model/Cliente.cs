public class Cliente : BaseModel
{
    public int Id { get; set; }

    private string nome;
    public string Nome
    {
        get => nome;
        set { nome = value; OnPropertyChanged(); }
    }

    public string Cognome { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Documento { get; set; }
}
