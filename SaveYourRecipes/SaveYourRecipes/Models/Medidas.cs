using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SaveYourRecipes.Models
{
    [Table("Medidas")]
    public class Medidas
    {
        [AutoIncrement, PrimaryKey, NotNull]
        public int medidas_id { get; set; }

        public string medidas_nombre { get; set; }
    }
}
