using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoSerbisyo.Models
{
    [Table("Ratings")]
    public class RatingViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string LoginId { get; set; }
        public bool? IsPositive { get; set; }
        public bool? IsNegative { get; set; }
        public string Comment { get; set; }
        public bool? IsDeleted { get; set; }
    }
}