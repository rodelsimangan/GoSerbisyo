using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoSerbisyo.Models;

namespace GoSerbisyo.AppServices
{
    public interface IServiceImagesAppService
    {
        List<ServiceImageViewModel> GetServiceImages(int ServiceId);
        ServiceImageViewModel GetServiceImage(int ServiceImageId);
        void UpsertServiceImage(ServiceImageViewModel input);
        void RemoveServiceImage(int ServiceImageId);
    }
}
