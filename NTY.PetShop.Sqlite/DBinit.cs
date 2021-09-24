using System;
using System.Linq;
using NTY.PetShop.Core.Models;
using NTY.PetShop.Sqlite.Entities;

namespace NTY.PetShop.Sqlite
{
    public class SeedDB
    {
        public static void DBseed(PetAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    
                    // Insurance
                    var insuranceA = ctx.Insurances.Add(new InsuranceEntity()
                    {
                        Name = "Silver",
                        Price = 5
                    }).Entity;
                    
                    var insuranceB = ctx.Insurances.Add(new InsuranceEntity()
                    {
                        Name = "Gold",
                        Price = 99
                    }).Entity;
                    
                    var insuranceC = ctx.Insurances.Add(new InsuranceEntity()
                    {
                        Name = "Diamond",
                        Price = 5000
                    }).Entity;
                    
                    // Add Pet Types
                    var dogType = ctx.PetTypes.Add(new PetTypeEntity()
                    {
                        Name = "Dog"
                    }).Entity;
            
                    ctx.PetTypes.Add(new PetTypeEntity()
                    {
                        Name = "Cat"
                    });

                    var fish = ctx.PetTypes.Add(new PetTypeEntity()
                    {
                        Name = "Fish"
                    }).Entity;
                    
                    ctx.PetTypes.Add(new PetTypeEntity()
                    {
                        Name = "Dinosaur"
                    });
                    // Add Owners

                    var ownerOne = ctx.Owners.Add(new OwnerEntity()
                    {
                        Age = 32,
                        Name = "Hansi",
                        Insurance = insuranceA
                    }).Entity;
                    
                    
                    var ownerTwo = ctx.Owners.Add(new OwnerEntity()
                    {
                        Age = 40,
                        Name = "Schwansi",
                        Insurance = insuranceB
                    }).Entity;
                    
                    ctx.Owners.Add(new OwnerEntity()
                    {
                        Age = 25,
                        Name = "Günther",
                        Insurance = insuranceC
                    });
                    

                    // Add Pets

                    ctx.Pets.Add(new PetEntity()
                    {
                        BirthDate = DateTime.Now.AddYears(-5),
                        Color = "Blue",
                        Name = "Schnerf",
                        Price = 250,
                        SoldDate = DateTime.Now,
                        Type = dogType,
                        Owner = ownerOne
                    });
                    
                    ctx.Pets.Add(new PetEntity()
                    {
                        BirthDate = DateTime.Now.AddYears(-2),
                        Color = "Green",
                        Name = "Barfie",
                        Price = 99.99,
                        SoldDate = DateTime.Now,
                        Type = fish,
                        Owner = ownerTwo
                    });

                    ctx.SaveChanges();
        }
    }
}