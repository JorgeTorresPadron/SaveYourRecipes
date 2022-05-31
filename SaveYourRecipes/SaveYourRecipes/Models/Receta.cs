﻿using System;
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

        [ForeignKey(typeof(User))]
        public int receta_user_id { get; set; }

        public string receta_nombre { get; set; }

        public string receta_descripcion { get; set; }

        public string receta_pasos_receta { get; set; }

        public string receta_ingredientes { get; set; }

        public int tiempo_preparacion { get; set; }

        public int tiempo_cocina { get; set; }

        public string pais_id { get; set; }

        public string categoria_comida_id { get; set; }
    }
}
