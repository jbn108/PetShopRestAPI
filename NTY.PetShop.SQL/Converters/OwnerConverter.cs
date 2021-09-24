using NTY.PetShop.Core.Models;
using NTY.PetShop.SQL.Entities;

namespace NTY.PetShop.SQL.Converters
{
    public class OwnerConverter
    {
        public OwnerEntity Convert(Owner owner)
        {
            return new OwnerEntity()
            {
                Id = owner.Id,
                Name = owner.Name,
                Age = owner.Age
            };
        }

        public Owner Convert(OwnerEntity ownerEntity)
        {
            return new Owner()
            {
                Id = ownerEntity.Id,
                Age = ownerEntity.Age,
                Name = ownerEntity.Name
            };
        }
    }
}