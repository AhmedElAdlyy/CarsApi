using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.ViewModels
{
    public class ChooseCarViewModel
    {
        public bool IsSuccess { get; set; }
        public int ModelClassId { get; set; }
        public int CarDetailsId { get; set; }
        public string ClassName { get; set; }
        public string ImgName { get; set; }
        public string CarName { get; set; }
    }
}
