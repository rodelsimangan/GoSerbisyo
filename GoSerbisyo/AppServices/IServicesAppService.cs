using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoSerbisyo.Models;

namespace GoSerbisyo.AppServices
{
    public interface IServicesAppService
    {
        List<ServiceModel> GetServices(string UserId);
        List<ServiceModel> GetServices(string name, string location);
        ServiceModel GetService(int ServiceId);
        void UpsertService(ServiceModel input);
        void RemoveService(int ServiceId);
    }
}
