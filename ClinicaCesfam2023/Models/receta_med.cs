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
    
    public partial class receta_med
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public receta_med()
        {
            this.med_receta = new HashSet<med_receta>();
        }
    
        public int id_receta { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fecha_emi { get; set; }
        public string paciente_rut_pac { get; set; }
        public string usuario_rut_user { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<med_receta> med_receta { get; set; }
        public virtual paciente paciente { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
