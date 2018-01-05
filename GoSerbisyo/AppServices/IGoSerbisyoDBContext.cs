using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoSerbisyo.Models;

namespace GoSerbisyo.AppServices
{
    public interface IGoSerbisyoDBContext
    {
        DbSet<ServiceViewModel> Services { get; set; }
        DbSet<ServiceImageViewModel> ServiceImages { get; set; }
        DbSet<RatingViewModel> Ratings { get; set; }
        DbSet<WatchlistViewModel> Watchlists { get; set; }

        int SaveChanges();
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);
        Database Database { get; }

    }
}
