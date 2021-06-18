using System.ComponentModel.DataAnnotations;

namespace Sql_CE31_EFCore_FromCoreTemplate
{
    public class BarCode
    {
        [Key]
        [MaxLength(4)]
        public int Code { get; set; }
        [MaxLength(4)]
        public int ArticleCode { get; set; }
        [MaxLength(14)]
        public string Barcode { get; set; }
        [MaxLength(4)]
        public int? WeightBarcodeTypeCode { get; set; }
        [MaxLength(1)]
        public byte Added { get; set; }
        [MaxLength(8)]
        public float? QuantityArticle { get; set; }
        [MaxLength(8)]
        public float RetailPrice { get; set; }
        [MaxLength(8)]
        public float PBalance { get; set; }
        [MaxLength(2)]
        public short? PercentMarkdown { get; set; }
    }
}
