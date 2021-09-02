using System.Linq;
using AutoMapper;
using business_layer.DTO;
using domain_layer.entities;

namespace business_layer
{
    public class MappingProfile: Profile
    {
        public MappingProfile(){
            CreateMap<Suscripcion, SuscripcionDTO>();
            CreateMap<Suscriptor, SuscriptorDTO>();
            CreateMap<Ciudad,CiudadDTO>();
            CreateMap<Sexo,SexoDTO>();
        }
    }
}