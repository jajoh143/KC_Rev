using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KC_Revolution.Data.Entities
{
    public class Sermon
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SermonName { get; set; }
        public string SermonDescription { get; set; }
        public string SermonFileLocation { get; set; }
        public string SeriesTitle { get; set; }
        public int SeriesId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
