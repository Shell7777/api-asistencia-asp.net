//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Personal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personal()
        {
            this.Invitation = new HashSet<Invitation>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<int> edad { get; set; }
        public string username { get; set; }
        [JsonIgnore]
        public string password { get; set; }
        public string genero { get; set; }
        public Nullable<int> idcategory { get; set; }
        public Nullable<bool> hidden { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Invitation> Invitation { get; set; }
    }
}
