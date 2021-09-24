using System.Collections.Generic;
using NTY.PetShop.Core.Models;

namespace NTY.PetShop.Core.IServices
{
    public interface IOwnerService
    {
        Owner Create(Owner owner);

        Owner Delete(int id);

        IEnumerable<Owner> ReadAll();

        Owner ReadById(int id);

        Owner Update(Owner owner);
    }
}