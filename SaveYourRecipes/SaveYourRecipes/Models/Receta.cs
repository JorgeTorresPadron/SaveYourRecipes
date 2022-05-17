using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SaveYourRecipes.Models
{
    [Table("Receta")]
    public class Receta
    {
        [PrimaryKey, AutoIncrement, Column("receta_id")]
        public int receta_id { get; set; }

        [ForeignKey(typeof(Categoria_comida))]
        public int categoria_comida_id { get; set; }

        public string receta_nombre { get; set; }

        public string receta_descripcion { get; set; }

        public string tiempo_preparacion { get; set; }

        public string tiempo_cocina { get; set; }

        [ForeignKey(typeof(Pais))]
        public int pais_id { get; set; }
    }
}
