using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NTY.PetShop.Core.Models;
using NTY.PetShop.Domain.IRepositories;
using NTY.PetShop.Sqlite.Entities;

namespace NTY.PetShop.Sqlite.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly PetAppContext _ctx;

        public InsuranceRepository(PetAppContext ctx)
        {
            _ctx = ctx;
        }
        
        public  Insurance Add(Insurance insurance)
        {
            var insDb = _ctx.Insurances.Add(new InsuranceEntity()
            {
                Name = insurance.Name,
                Price = insurance.Price
            }).Entity;
            _ctx.SaveChanges();

            insurance.Id = insDb.Id;
            return insurance;
        }

        public Insurance ReadById(int id)
        {
            var insurance = _ctx.Insurances.FirstOrDefault(i => i.Id == id);
            return new Insurance()
            {
                Id = insurance.Id,
                Name = insurance.Name,
                Price = insurance.Price
            };
        }

        public Insurance UpdatePet(Insurance insurance)
        {
            throw new System.NotImplementedException();
        }

        public Insurance Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Insurance> GetAll()
        {
            return _ctx.Insurances.Select(i => new Insurance()
            {
                Id = i.Id,
                Name = i.Name,
                Price = i.Price
            }).ToList();
        }
    }
}