using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KC_Revolution.Data.Entities
{
    public class BlogPost
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BlogId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [Required]
        public Guid AuthorFK { get; set; }
        [ForeignKey("AuthorFK")]
        public Author Author { get; set; }
    }
}
