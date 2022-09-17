namespace WicodeApi.Models;

public class Payement
{
    [Key]
    public int Id { get; set; }
    public string Reference { get; set; } = String.Empty;
    public int InscriptionId { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime DatePayement { get; set; } = DateTime.Now;

    public int Etat { get; set; } = 0;

    public Payement(Payement payement) => (Reference, InscriptionId, DatePayement, Etat) = (payement.Reference, payement.InscriptionId, DateTime.Now, 0);
    public Payement()
    {

    }

}
