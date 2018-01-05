using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoSerbisyo.Models;

namespace GoSerbisyo.AppServices
{
    public class ServiceImagesAppService : IServiceImagesAppService
    {
        IGoSerbisyoDBContext _context;
        public ServiceImagesAppService(IGoSerbisyoDBContext context)
        {
            _context = context;
        }
        public List<ServiceImageViewModel> GetServiceImages(int ServiceId)
        {
            try
            {
                var query = from q in _context.ServiceImages
                            select q;

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ServiceImageViewModel GetServiceImage(int ServiceImageId)
        {
            try
            {
                if (ServiceImageId == 0)
                    throw new NullReferenceException();

                var query = from q in _context.ServiceImages
                            where q.Id == ServiceImageId
                            select q;

                return query.AsNoTracking().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpsertServiceImage(ServiceImageViewModel input)
        {
            try
            {
                if (input.Id == 0)
                    _context.ServiceImages.Add(input);
                else
                    _context.Entry(input).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveServiceImage(int ServiceImageId)
        {
            try
            {
                if (ServiceImageId == 0)
                    throw new NullReferenceException();
                var service = GetServiceImage(ServiceImageId);
                service.IsDeleted = true;
                _context.Entry(service).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}