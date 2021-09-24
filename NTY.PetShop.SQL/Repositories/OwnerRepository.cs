using System.Collections.Generic;
using System.Linq;
using NTY.PetShop.Core.Models;
using NTY.PetShop.Domain.IRepositories;
using NTY.PetShop.SQL.Converters;
using NTY.PetShop.SQL.Entities;

namespace NTY.PetShop.SQL.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        
        private static List<OwnerEntity> _ownerTable = new List<OwnerEntity>();
        private static int _id = 1;
        private readonly OwnerConverter _ownerConverter;

        public OwnerRepository()
        {
            _ownerConverter = new OwnerConverter();
            
            Create(new Owner()
            {
                Age = 50,
                Name = "Hussmann"
            });
            
            Create(new Owner()
            {
                Age = 4,
                Name = "Mike"
            });
            
            Create(new Owner()
            {
                Age = 24,
                Name = "Jonas"
            });
        }
        
        public Owner Create(Owner owner)
        {
            var ownerEntity = _ownerConverter.Convert(owner);
            ownerEntity.Id = _id++;
            _ownerTable.Add(ownerEntity);
            return _ownerConverter.Convert(ownerEntity);
        }

        public Owner Delete(int id)
        {
            var owner = ReadById(id);
            _ownerTable.Remove(_ownerTable.FirstOrDefault(o => o.Id == id));
            return owner;
        }

        public List<Owner> ReadAll()
        {
            var owners = new List<Owner>();
            foreach (var ownerEntity in _ownerTable)
            {
                owners.Add(_ownerConverter.Convert(ownerEntity));
            }
            return owners;
        }

        public Owner ReadById(int id)
        {
            var owner = _ownerConverter.Convert(_ownerTable.FirstOrDefault(o => o.Id == id));
            if (owner != null)
            {
                return owner;
            }
            return null;
        }

        public Owner Update(Owner owner)
        {
            var oldOwner = _ownerTable.FirstOrDefault(o => o.Id == owner.Id);
            if (oldOwner != null)
            {
                oldOwner.Age = owner.Age;
                oldOwner.Id = owner.Id;
                oldOwner.Name = owner.Name;
                return _ownerConverter.Convert(oldOwner);
            }

            return null;
        }
    }
}