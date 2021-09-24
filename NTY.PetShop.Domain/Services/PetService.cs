using System.Collections.Generic;
using System.Linq;
using NTY.PetShop.Core.IServices;
using NTY.PetShop.Core.Models;
using NTY.PetShop.Domain.IRepositories;

namespace NTY.PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;
        private IOwnerRepository _ownerRepository;
        public PetService(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;
        }

        public Pet Create(Pet pet)
        {
            return _petRepository.Add(pet);
        }

        public Pet Delete(int id)
        {
            return _petRepository.Delete(id);
        }

        public Pet ReadById(int id)
        {
            return _petRepository.ReadById(id);
        }

        public Pet UpdatePet(Pet pet)
        {
            return _petRepository.UpdatePet(pet);
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _petRepository.GetAll();
        }

        
    }
}