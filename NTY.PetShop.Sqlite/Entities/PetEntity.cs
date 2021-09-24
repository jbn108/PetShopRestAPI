using System;
using NTY.PetShop.Core.Models;

namespace NTY.PetShop.Sqlite.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public int PetTypeId { get; set; }
        public PetTypeEntity Type { get; set; }
        public int? OwnerId { get; set; }
        public OwnerEntity Owner { get; set; }
    }
}