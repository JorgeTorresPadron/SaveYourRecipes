using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveYourRecipes.Models
{
    [Table("Ingredientes")]
    public class Ingredientes
    {
        [AutoIncrement, PrimaryKey]
        public int ingredientes_id { get; set; }
        public string ingredientes_nombre { get; set; }
    }
}
