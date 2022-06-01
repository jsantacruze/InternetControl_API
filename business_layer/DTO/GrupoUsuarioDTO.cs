using System.Collections.Generic;

namespace business_layer.DTO
{
    public class GrupoUsuarioDTO
    {
        public string Idgrupo { get; set; }
        public string Idproceso { get; set; }

        public ProcesoSistemaDTO IdprocesoNavigation { get; set; }
    }
}