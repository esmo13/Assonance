using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assonance.Models
{
    [Table(name:"songs")]
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

        public Song(long id, string name, ICollection<Album> albums)
        {
            Id = id;
            Name = name;
            Albums = albums;
        }

        public Song(string name)
        {
            Name = name;
        }

        public Song()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Song song &&
                   Id == song.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
