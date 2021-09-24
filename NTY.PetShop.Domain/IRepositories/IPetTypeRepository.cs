using System.Collections.Generic;
using NTY.PetShop.Core.Models;

namespace NTY.PetShop.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        PetType Add(Pet pet);

        PetType ReadById(int id);

        PetType UpdatePet(Pet pet);

        PetType Delete(int id);

        IEnumerable<PetType> GetAll();
    }
}