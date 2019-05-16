namespace ConfiguracionUsuarios.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Marca")]
    public partial class Marca
    {
        [Key]
        public int IDMarca { get; set; }

        [Required]
        [StringLength(25)]
        public string NombreMarca { get; set; }
    }
}
