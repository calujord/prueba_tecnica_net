using eSett.Model;

namespace eSett.API
{
    public interface I_APIeSettMg
    {
        bool Open(string uri);

        List<I_MarketParty> Get(string? code = "", string? country = "", string? name = "");

    }
}