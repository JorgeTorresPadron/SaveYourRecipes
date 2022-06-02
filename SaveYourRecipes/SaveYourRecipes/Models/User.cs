using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveYourRecipes.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int user_id { get; set; }

        [MaxLength(20), Unique]
        public string user_nombre_usuario { get; set; }

        [MaxLength(16)]
        public string user_password { get; set; }

        [MaxLength(25)]
        public string user_nombre_real { get; set; }

        [MaxLength(50)]
        public string user_apellido_real { get; set; }

        [MaxLength(2)]
        public int user_edad { get; set; }

        public DateTime user_fecha_creacion { get; set; }

    }
}
