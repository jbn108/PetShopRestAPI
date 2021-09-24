using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NTY.PetShop.Core.Models;
using NTY.PetShop.Domain.IRepositories;
using NTY.PetShop.Sqlite.Entities;

namespace NTY.PetShop.Sqlite.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetAppContext _ctx;

        public PetRepository(PetAppContext ctx)
        {
            _ctx = ctx;
        }
        public Pet Add(Pet pet)
        {
            var entity = new PetEntity
            {
                BirthDate = pet.BirthDate,
                Color = pet.Color,
                Name = pet.Name,
                Price = pet.Price,
                SoldDate = pet.SoldDate,
                OwnerId = pet.Owner?.Id,
                PetTypeId = pet.Type.Id
            };

            var petEntity = _ctx.Pets.Add(entity).Entity;
            
            _ctx.SaveChanges();
            return ReadById(petEntity.Id);
        }

        public Pet ReadById(int id)
        {
            var entity = _ctx.Pets
                .Include(c => c.Owner)
                .Include(c => c.Type)
                .Include(c => c.Owner.Insurance)
                .FirstOrDefault(c => c.Id == id);
            return new Pet()
            {
                Id = entity.Id,
                BirthDate = entity.BirthDate,
                Color = entity.Color,
                Name = entity.Name,
                Owner = new Owner()
                {
                    Id = entity.OwnerId.Value,
                    Age = entity.Owner.Age,
                    Insurance = new Insurance()
                    {
                        Id = entity.Owner.InsuranceId,
                        Name = entity.Owner.Insurance.Name,
                        Price = entity.Owner.Insurance.Price
                    }
                },
                Price = entity.Price,
                SoldDate = entity.SoldDate,
                Type = new PetType()
                {
                    Id = entity.PetTypeId,
                    Name = entity.Type.Name
                }
            };
        }

        public Pet UpdatePet(Pet pet)
        {
            var petDb = _ctx.Update(pet).Entity;
            _ctx.SaveChanges();
            return new Pet()
            {
                Id = petDb.Id,
                Name = petDb.Name
            };
        }

        public Pet Delete(int id)
        {
            var pet = _ctx.Remove(new Pet()
            {
                Id = id
            }).Entity;
            _ctx.SaveChanges();
            return pet;
        }

        public IEnumerable<Pet> GetAll()
        {
            var pets = _ctx.Pets
                .Include(p => p.Owner)
                .ThenInclude(o => o.Insurance)
                .Include(p => p.Type)
                .Select(entity => new Pet
                {
                    Id = entity.Id,
                    BirthDate = entity.BirthDate,
                    Color = entity.Color,
                    Name = entity.Name,
                    Owner = new Owner()
                    {
                        Id = entity.OwnerId.Value,
                        Age = entity.Owner.Age,
                        Insurance = new Insurance()
                        {
                            Id = entity.Owner.InsuranceId,
                            Name = entity.Owner.Insurance.Name,
                            Price = entity.Owner.Insurance.Price
                        }
                    },
                    Price = entity.Price,
                    SoldDate = entity.SoldDate,
                    Type = new PetType()
                    {
                        Id = entity.PetTypeId,
                        Name = entity.Type.Name
                    }
                });

            return pets;
        }
    }
}