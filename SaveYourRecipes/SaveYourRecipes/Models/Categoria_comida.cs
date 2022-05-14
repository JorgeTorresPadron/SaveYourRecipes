using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SaveYourRecipes.Models
{
    [Table("Categoria_comida")]
    public class Categoria_comida
    {
        [AutoIncrement, PrimaryKey]
        public int categoria_comida_id { get; set; }

        public string categoria_comida_nombre { get; set; }
    }
}
