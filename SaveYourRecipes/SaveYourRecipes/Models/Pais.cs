﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SaveYourRecipes.Models
{
    [Table("Pais")]
    public class Pais
    {
        [AutoIncrement, PrimaryKey, Column("pais_id")]
        public int pais_id { get; set; }

        public string pais_nombre { get; set; }

        public string pais_nombre_usuario { get; set; }

    }
}
