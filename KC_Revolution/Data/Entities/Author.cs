using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KC_Revolution.Data.Entities
{
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Uuid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public DateTime ModifiedDate { get; set; }

        public DateTime DeletedDate { get; set; }

        [ForeignKey("AuthorFK")]
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
