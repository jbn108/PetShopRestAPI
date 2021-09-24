using System.Collections.Generic;
using NTY.PetShop.Core.Models;

namespace NTY.PetShop.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);

        Owner Delete(int id);

        IEnumerable<Owner> ReadAll();

        Owner ReadById(int id);

        Owner Update(Owner owner);
    }
}