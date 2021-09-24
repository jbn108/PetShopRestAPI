using System.Collections.Generic;
using NTY.PetShop.Core.Models;

namespace NTY.PetShop.Core.IServices
{
    public interface IInsuranceService
    {
        Insurance Create(Insurance insurance);

        Insurance Delete(int id);

        IEnumerable<Insurance> ReadAll();

        Insurance ReadById(int id);

        Insurance Update(Insurance insurance);
    }
}