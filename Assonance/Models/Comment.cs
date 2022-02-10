using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assonance.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column(TypeName = "text")]
        public string Content { get; set; }
        [Required]
        public User User_ { get; set; }
        [Required]
        public Album Album_ { get; set; }

        public Comment(long id, string content, User user, Album album)
        {
            Id = id;
            Content = content;
            this.User_ = user;
            this.Album_ = album;
        }

        public Comment(string content, User user, Album album)
        {
            Content = content;
            this.User_ = user;
            this.Album_ = album;
        }

        public Comment()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Comment comment &&
                   Id == comment.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
