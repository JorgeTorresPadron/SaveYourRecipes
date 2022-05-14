using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveYourRecipes.Models
{
    [Table("Cantidad")]
    public class Cantidad
    {
        [AutoIncrement, PrimaryKey, NotNull]
        public int cantidad_id { get; set; }
        public int receta_id { get; set; }

        public int ingredientes_id { get; set; }

        public int medidas_id { get; set; }

        public double cantidad_ingredientes { get; set; }

    }
}
