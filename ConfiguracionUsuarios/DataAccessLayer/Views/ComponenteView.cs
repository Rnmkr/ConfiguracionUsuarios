namespace ConfiguracionUsuarios.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComponenteView")]
    public partial class ComponenteView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ArticuloComponente { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string NombreComponente { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(25)]
        public string NombreCategoria { get; set; }

        [StringLength(25)]
        public string NombreProducto { get; set; }

        [StringLength(25)]
        public string NombreModelo { get; set; }

        [StringLength(20)]
        public string VersionComponente { get; set; }

        [StringLength(10)]
        public string CodigoOrden { get; set; }
    }
}
