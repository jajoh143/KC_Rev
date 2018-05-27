using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KC_Revolution.Data.Entities
{
    public class SermonSeries
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SermomSeriesId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
