//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicaCesfam2023.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class reserva_med
    {
        public int id_reserva { get; set; }
        public System.DateTime fecha_reserva { get; set; }
        public string usuario_rut_user { get; set; }
        public int med_receta_id_med_recet { get; set; }
    
        public virtual med_receta med_receta { get; set; }
        public virtual usuario usuario { get; set; }
    }
}