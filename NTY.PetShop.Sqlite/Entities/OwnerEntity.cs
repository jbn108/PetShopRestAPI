using NTY.PetShop.Core.Models;

namespace NTY.PetShop.Sqlite.Entities
{
    public class OwnerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public InsuranceEntity Insurance { get; set; }
        public int? InsuranceId { get; set; }
    }
}