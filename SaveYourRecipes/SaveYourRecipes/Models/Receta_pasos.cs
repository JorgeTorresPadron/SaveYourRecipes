using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SaveYourRecipes.Models
{
    [Table("Receta_pasos")]
    public class Receta_pasos
    {
        [PrimaryKey, AutoIncrement, Column("receta_paso_id")]
        public int receta_paso_id { get; set; }

        [ForeignKey(typeof(Receta))]
        public int receta_id { get; set; }

        public int receta_paso_numero { get; set; }

        public string receta_paso_descripcion { get; set; }
    }
}
