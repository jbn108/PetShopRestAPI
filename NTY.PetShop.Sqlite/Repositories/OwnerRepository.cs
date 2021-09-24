using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NTY.PetShop.Core.Models;
using NTY.PetShop.Domain.IRepositories;
using NTY.PetShop.Sqlite.Entities;

namespace NTY.PetShop.Sqlite.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetAppContext _ctx;

        public OwnerRepository(PetAppContext ctx)
        {
            _ctx = ctx;
        }
        public Owner Create(Owner owner)
        {
            var ow = _ctx.Owners.Add(new OwnerEntity()
            {
                Name = owner.Name,
                Age = owner.Age,
                InsuranceId = owner.Insurance == null ? 0 : owner.Insurance.Id
            }).Entity;
            
            _ctx.SaveChanges();
            owner.Id = ow.Id;
            return owner;
        }

        public Owner Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _ctx.Owners
                .Include(o => o.Insurance)
                .Select(o => new Owner()
            {
                Id = o.Id,
                Age = o.Age,
                Name = o.Name,
                Insurance = new Insurance()
                {
                    Id = o.Insurance.Id,
                    Name = o.Insurance.Name,
                    Price = o.Insurance.Price
                }
            }).ToList();
        }

        public Owner ReadById(int id)
        {
            var ownerEntity = _ctx.Owners.FirstOrDefault(o => o.Id == id);
            return new Owner()
            {
                Id = ownerEntity.Id,
                Age = ownerEntity.Age,
                Insurance = new Insurance()
                {
                    Id = ownerEntity.Insurance.Id,
                    Name = ownerEntity.Insurance.Name,
                    Price = ownerEntity.Insurance.Price
                }
            };
        }

        public Owner Update(Owner owner)
        {
            throw new System.NotImplementedException();
        }
    }
}