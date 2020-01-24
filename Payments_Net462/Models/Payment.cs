using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payments_Net462.Models
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        //
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d.M}")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PayDate { get; set; }

        [Required]
        [RegularExpression("^-?[0-9]{1,}", ErrorMessage = "Numbers only!")]
        public int Amount { get; set; }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int CatogoryId { get; set; }

        public Category Category { get; set; }
    }
}