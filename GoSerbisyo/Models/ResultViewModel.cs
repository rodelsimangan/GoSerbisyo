﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoSerbisyo.Models
{
    public class ResultViewModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceLocation { get; set; }
        public string[] ServiceImagesPath { get; set; }
        public bool ServiceLinkToProfile { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserNameIdentifier { get; set; }
        public string UserAddress { get; set; }
        public string UserLocation { get; set; }
        public string UserContactNumber { get; set; }

    }
}