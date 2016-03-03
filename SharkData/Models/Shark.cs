using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharkData.Models
{
    public class Shark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Binomial { get; set; }
        public int MaxLength { get; set; }
    }
}