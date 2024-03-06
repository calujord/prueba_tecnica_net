using Alicunde.PruebaTecnica.Data;
using Alicunde.PruebaTecnica.Models;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Alicunde.PruebaTecnica.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fee, FeeDTO>();
            CreateMap<FeeDTO, Fee>();
            // Add other mappings as needed
        }
    }
}
