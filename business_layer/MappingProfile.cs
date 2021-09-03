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
            CreateMap<TrackingSuscripcion, IncidenciaDTO>();
            /*.ForMember(destino => destino.incidencia_id, opt => opt.MapFrom(src => src.Idtracking))
            .ForMember(destino => destino.EmpleadoAsignado, opt => opt.MapFrom(src => src.IdempleadoAsignadoNavigation))
            .ForMember(destino => destino.UsuarioCrea, opt => opt.MapFrom(src => src.IdusuarioCreaNavigation))
            .ForMember(destino => destino.Suscripcion, opt => opt.MapFrom(src => src.Suscripcion));*/
        }
    }
}