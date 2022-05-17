using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveYourRecipes.Models
{
    [Table("Cantidad")]
    public class Cantidad
    {
        [AutoIncrement, PrimaryKey, Column("cantidad_id")]
        public int cantidad_id { get; set; }

        [ForeignKey(typeof(Receta))]
        public int receta_id { get; set; }

        [ForeignKey(typeof(Ingredientes))]
        public int ingredientes_id { get; set; }

        [ForeignKey(typeof(Medidas))]
        public int medidas_id { get; set; }

        public double cantidad_ingredientes { get; set; }

    }
}
