using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SaveYourRecipes.Models
{
    [Table("Receta")]
    public class Receta
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int receta_id { get; set; }

        public int categoria_comida_id { get; set; }

        public string receta_nombre { get; set; }

        public string receta_descripcion { get; set; }

        public string tiempo_preparacion { get; set; }

        public string tiempo_cocina { get; set; }

        public int pais_id { get; set; }
    }
}
