namespace NTY.PetShop.Core.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Insurance? Insurance { get; set; }
    }
}