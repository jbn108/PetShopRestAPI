using Microsoft.Extensions.DependencyInjection;
using NTY.PetShop.Core.IServices;
using NTY.PetShop.Domain.IRepositories;
using NTY.PetShop.Domain.Services;
using NTY.PetShop.SQL.Repositories;

namespace NTY.PetShop.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();
            

            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            IPetRepository petRepository = new PetRepository();
            IPetTypeRepository petTypeRepository = new PetTypeRepository();
            IPetService petService = new PetService(petRepository, ownerRepository);
            IOwnerRepository ownerRepository = new OwnerRepository();
            IOwnerService ownerService = new OwnerService(ownerRepository);
            
            var menu = new Menu(petService, petTypeRepository);
            menu.Start();
        }
    }
}