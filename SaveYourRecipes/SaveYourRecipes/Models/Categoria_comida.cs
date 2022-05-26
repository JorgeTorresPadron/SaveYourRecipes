using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SaveYourRecipes.Models
{
    [Table("Categoria_comida")]
    public class Categoria_comida
    {
        [AutoIncrement, PrimaryKey, Column("categoria_comida_id")]
        public int categoria_comida_id { get; set; }

        public string categoria_comida_nombre { get; set; }

        [OneToMany]
        public List<Receta> Receta { get; set; }
    }
}
