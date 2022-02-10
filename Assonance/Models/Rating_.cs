using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assonance.Models
{
    [Table(name:"ratings")]
    public class Rating_
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {   get;   set; }
        [Required]
        public long AlbumId { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public float Rating { get; set; }

        public Rating_(long id, long albumId, long userId, float rating)
        {
            Id = id;
            AlbumId = albumId;
            UserId = userId;
            Rating = rating;
        }

        public Rating_(long albumId, long userId, float rating)
        {
            AlbumId = albumId;
            UserId = userId;
            Rating = rating;
        }

        public Rating_()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Rating_ rating &&
                   Id == rating.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
