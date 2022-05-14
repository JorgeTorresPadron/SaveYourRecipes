using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SaveYourRecipes.Models
{
    [Table("Receta_pasos")]
    public class Receta_pasos
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int receta_paso_id { get; set; }

        public int receta_id { get; set; }

        public int receta_paso_numero { get; set; }

        public string receta_paso_descripcion { get; set; }
    }
}
