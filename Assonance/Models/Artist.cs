using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assonance.Models
{
    [Table(name:"artists")]
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
    

        public Artist(long id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }

        public Artist(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public Artist()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Artist artist &&
                   Id == artist.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
