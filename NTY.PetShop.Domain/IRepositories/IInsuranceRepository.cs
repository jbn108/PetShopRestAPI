using System.Collections.Generic;
using NTY.PetShop.Core.Models;

namespace NTY.PetShop.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        Insurance Add(Insurance insurance);

        Insurance ReadById(int id);

        Insurance UpdatePet(Insurance insurance);

        Insurance Delete(int id);

        IEnumerable<Insurance> GetAll();
    }
}