using System;
using System.ComponentModel.DataAnnotations;

namespace Sql_CE31_EFCore_FromCoreTemplate
{
    public class LastSync
    {
        [Key]
        public int StoreNumber { get; set; }
        public DateTime DateOfSync { get; set; }
    }
}
