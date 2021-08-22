using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ENSEK.Models
{
    public class MeterReader
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
        [Range(10000, 99999)]
        public int MeterReadValue { get; set; }
    }
}
