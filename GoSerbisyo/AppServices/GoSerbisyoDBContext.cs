using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GoSerbisyo.Models;

namespace GoSerbisyo.AppServices
{
    public class GoSerbisyoDBContext : DbContext, IGoSerbisyoDBContext
    {
        public GoSerbisyoDBContext() :
            base("DefaultConnection")
        {
        }

        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<ServiceImageModel> ServiceImages { get; set; }
        public DbSet<RatingModel> Ratings { get; set; }
        public DbSet<WatchlistViewModel> Watchlists { get; set; }
        public DbSet<ReportModel> Reports { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
    }
}