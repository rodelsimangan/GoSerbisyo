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
        List<ServiceViewModel> GetServices(string UserId);
        List<ServiceViewModel> GetServices(string name, string location);
        ServiceViewModel GetService(int ServiceId);
        void UpsertService(ServiceViewModel input);
        void RemoveService(int ServiceId);
    }
}
