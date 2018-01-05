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

        public DbSet<ServiceViewModel> Services { get; set; }
        public DbSet<ServiceImageViewModel> ServiceImages { get; set; }
        public DbSet<RatingViewModel> Ratings { get; set; }
        public DbSet<WatchlistViewModel> Watchlists { get; set; }

    }
}