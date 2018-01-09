﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoSerbisyo.Models;

namespace GoSerbisyo.AppServices
{
    public class ServicesAppService : IServicesAppService
    {
        IGoSerbisyoDBContext _context;
        public ServicesAppService(IGoSerbisyoDBContext context)
        {
            _context = context;
        }
        public List<ServiceViewModel> GetServices(string UserId)
        {
            try
            {
                var query = from q in _context.Services
                            where q.IsDeleted == false || q.IsDeleted == null
                            select q;

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ServiceViewModel> GetServices(string name, string location)
        {
            try
            {
                var query = from q in _context.Services
                            where q.IsDeleted == false || q.IsDeleted == null
                            && (string.IsNullOrEmpty(name) ||  q.Name.ToLower().Contains(name.ToLower())) && (string.IsNullOrEmpty(location) ||  q.Location.ToLower().Contains(location.ToLower()))
                            select q;

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ServiceViewModel GetService(int ServiceId)
        {
            try
            {
                if (ServiceId == 0)
                    throw new NullReferenceException();

                var query = from q in _context.Services
                            where q.Id == ServiceId
                            select q;

                return query.AsNoTracking().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpsertService(ServiceViewModel input)
        {
            try
            {
                if (input.Id == 0)
                    _context.Services.Add(input);
                else
                    _context.Entry(input).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveService(int ServiceId)
        {
            try
            {
                if (ServiceId == 0)
                    throw new NullReferenceException();
                var service = GetService(ServiceId);
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