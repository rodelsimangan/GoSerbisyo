using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoSerbisyo.Models
{
    public class ResultModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceLocation { get; set; }
        public string[] ServiceImagesPath { get; set; }
        public bool ServiceLinkToProfile { get; set; }
        public bool ServiceSendToMessenger { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserNameIdentifier { get; set; }
        public string UserAddress { get; set; }
        public string UserLocation { get; set; }
        public string UserContactNumber { get; set; }

        public int PositiveRatings { get; set; }
        public int NegativeRatings { get; set; }

        public bool RatingGiven { get; set; }
        public string LoginId { get; set; }
    }
}