using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BalanceResponsibleParty
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Esta anotación hace que el ID sea autoincremental
    public int Id { get; set; }
    public string BrpCode { get; set; }
    public string BrpName { get; set; }
    public string BusinessId { get; set; }
    public string CodingScheme { get; set; }
    public string Country { get; set; }
    public string ValidityEnd { get; set; }
    public string ValidityStart { get; set; }
}