using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveYourRecipes.Models
{
    [Table("Person")]
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int person_id { get; set; }

        [MaxLength(30)]
        public string person_nombre { get; set; }

        [MaxLength(2)]
        public string person_edad { get; set; }
    }
}
