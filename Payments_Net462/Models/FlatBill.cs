using System.ComponentModel.DataAnnotations;

namespace Payments_Net462.Models
{
    public class FlatBill
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [RegularExpression("^-?[0-9]{2}", ErrorMessage = "Two Numbers only!")]
        public byte Year { get; set; }

        [Required]
        [RegularExpression("^-?[0-9]{2}", ErrorMessage = "Two Numbers only!")]
        public byte Month { get; set; }

        [Required]
        public decimal PowerPrice { get; set; }
        public int PowerCount { get; set; }

        [Required]
        public decimal WaterColdPrice { get; set; }
        public int WaterColdCount { get; set; }

        [Required]
        public decimal WaterHotPrice { get; set; }
        public int WaterHotCount { get; set; }

        [Required]
        public decimal WaterDrainPrice { get; set; }
        public int WaterDrainCount { get; set; }

        [Required]
        public decimal HeatingPrice { get; set; }

        [Required]
        public decimal CyfralPrice { get; set; }

        [Required]
        public decimal WasteRemovalPrice { get; set; }

        [Required]
        public decimal OsbbPrice { get; set; }

        [Required]
        public decimal InternetPrice { get; set; }
    }
}