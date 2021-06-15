using CarsApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Services.Interface
{
    public interface ISearch
    {
        List<SearchViewModel> SearchViewModel(int Brand);
        List<SearchViewModel> SearchViewModel(int Brand, int Model);
        List<SearchViewModel> SearchViewModel(int Brand, int Model, int Body);
        List<SearchViewModel> SearchByBody(int Body);
    }
}
