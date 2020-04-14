using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorRScard.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Company { get; set; }
        public Sector Sector { get; set; }
        public string Description { get; set; }
        public string[] Keywords { get; set; }
    }
}
