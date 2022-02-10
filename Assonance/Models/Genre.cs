using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assonance.Models
{
    [Table(name:"genres")]
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

        public Genre(string name, ICollection<Album> albums)
        {
            Name = name;
            Albums = albums;
        }

        public Genre(long id, string name, ICollection<Album> albums)
        {
            Id = id;
            Name = name;
            Albums = albums;
        }

        public Genre()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Genre genre &&
                   Id == genre.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
