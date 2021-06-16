using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.ViewModels
{
    public class SearchViewModel
    {
        public decimal price { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Img { get; set; }
        public int modelclassId { get; set; }
    }
}
