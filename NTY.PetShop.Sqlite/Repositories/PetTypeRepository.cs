using System.Collections.Generic;
using System.Linq;
using NTY.PetShop.Core.Models;
using NTY.PetShop.Domain.IRepositories;

namespace NTY.PetShop.Sqlite.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private readonly PetAppContext _ctx;

        public PetTypeRepository(PetAppContext ctx)
        {
            _ctx = ctx;
        }

        public PetType Add(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public PetType ReadById(int id)
        {
            throw new System.NotImplementedException();
        }

        public PetType UpdatePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public PetType Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PetType> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}