namespace PruebaTecnicaNet.API.Application.Commands;

// DDD and CQRS patterns comment: Note that it is recommended to implement immutable Commands
// In this case, its immutability is achieved by having all the setters as private
// plus only being able to update the data just once, when creating the object through its constructor.
// References on Immutable Commands:  
// http://cqrs.nu/Faq
// https://docs.spine3.org/motivation/immutability.html 
// http://blog.gauffin.org/2012/06/griffin-container-introducing-command-support/
// https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/how-to-implement-a-lightweight-class-with-auto-implemented-properties

// using PruebaTecnicaNet.API.Application.Models;
using PruebaTecnicaNet.API.Extensions;

[DataContract]
public class CreateSettlementBankCommand : IRequest<bool>
{
    [DataMember]
    public string Bic { get; private set; }

    [DataMember]
    public string Name { get; private set; }

    [DataMember]
    public string Country { get; private set; }

    public CreateSettlementBankCommand(string bic, string name, string country)
    {
        Bic = bic;
        Name = name;
        Country = country;
    }
}