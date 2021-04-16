using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyXpens.Models
{
    public class PaysSummary
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        [Required]
        [RegularExpression("^-?[0-9]{1,}", ErrorMessage = "Numbers only!")]
        public int Amount { get; set; }

        [ForeignKey("Category")]
        public int CatogoryId { get; set; }

        public Category Category { get; set; }
    }
}