using System.Collections.Generic;
using NTY.PetShop.Core.IServices;
using NTY.PetShop.Core.Models;
using NTY.PetShop.Domain.IRepositories;

namespace NTY.PetShop.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepo)
        {
            _ownerRepository = ownerRepo;
        }
        
        public Owner Create(Owner owner)
        {
            return _ownerRepository.Create(owner);
        }

        public Owner Delete(int id)
        {
            return _ownerRepository.Delete(id);
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _ownerRepository.ReadAll();
        }

        public Owner ReadById(int id)
        {
            return _ownerRepository.ReadById(id);
        }

        public Owner Update(Owner owner)
        {
            return _ownerRepository.Update(owner);
        }
    }
}