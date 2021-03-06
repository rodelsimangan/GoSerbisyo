﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoSerbisyo.Models
{
    [Table("Reports")]
    public class ReportModel
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public int ServiceId { get; set; }
        public string Comment { get; set; }
        public bool? IsDeleted { get; set; }
    }
}