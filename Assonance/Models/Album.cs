using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assonance.Models
{
    [Table(name: "albums")]
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Cover { get; set; }
        [Required]
        public Artist Author { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Released { get; set; }
        [Required]
        public virtual ICollection<Genre> Genres{get;set;}
        [Required]
        public virtual ICollection<Song> Songs { get; set; }

        public Album()
        {
        }

        public Album(string name, string cover, Artist author, DateTime released, ICollection<Genre> genres, ICollection<Song> songs)
        {
            Name = name;
            Cover = cover;
            Author = author;
            Released = released;
            Genres = genres;
            Songs = songs;
        }

        public Album(long id, string name, string cover, Artist author, DateTime released, ICollection<Genre> genres, ICollection<Song> songs)
        {
            Id = id;
            Name = name;
            Cover = cover;
            Author = author;
            Released = released;
            Genres = genres;
            Songs = songs;
        }

        public override bool Equals(object obj)
        {
            return obj is Album album &&
                   Id == album.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
