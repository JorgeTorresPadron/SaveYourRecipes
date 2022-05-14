using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SaveYourRecipes.Models
{
    [Table("Pais")]
    public class Pais
    {
        [AutoIncrement, PrimaryKey, NotNull]
        public int pais_id { get; set; }

        public string pais_nombre { get; set; }
    }
}
