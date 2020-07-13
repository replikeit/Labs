using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab6.Core.Models
{
    [Table("Cinemas")]
    class Cinema
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }

        public Cinema(string name, string street)
        {
            Name = name;
            Street = street;
        }

        public Cinema()
        {
        }
    }
}
