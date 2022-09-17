namespace WicodeApi.Models;

public class Inscription
{
    [Key]
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    [DefaultValue(0)]
    public int Etat { get; set; } = 0;

    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime DateInscription { get; set; } = DateTime.Now;


}
