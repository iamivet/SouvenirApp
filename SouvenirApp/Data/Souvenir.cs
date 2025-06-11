namespace SouvenirApp.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Souvenir
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required]
        public int TypeId { get; set; }
        public SouvenirType Type{ get; set; }
    }
}
