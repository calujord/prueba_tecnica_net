using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNet.Infraestructure.Idempotency;

public class ClientRequest
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Request { get; set; }
    public DateTime Time { get; set; }
}