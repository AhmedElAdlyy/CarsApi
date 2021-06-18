﻿using CarsApi.Models;
using CarsApi.Services.Interface;
using CarsApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Services.Implementation
{
    public class Search : ISearch
    {
        private CarsContext _db;
        public Search(CarsContext db)
        {
            _db = db;
        }

        public List<SearchViewModel> SearchViewModel(int Brand)
        {
            List<SearchViewModel> modelPrices = new List<SearchViewModel>();
            var cardetails = _db.CarDetails.Include(a => a.ModelClass).Include(a => a.ModelClass.Model).Include(a => a.CarPhotos)
                .Where(a => a.ModelClass.Model.Brand.Id == Brand && a.ModelClass.ClassId == 1)
                .Select(x => new { x.ModelClass.Model, x.Price, x.CarPhotos, x.ModelClass.Model.Brand, x.ModelClass }).ToList();
            foreach (var M in cardetails)
            {
                SearchViewModel model_Price = new SearchViewModel
                {
                    Model = M.Model.Name,
                    price = (decimal)M.Price,
                    Brand = M.Brand.Name,
                    Img = M.CarPhotos.Select(a => a.PhotoName).FirstOrDefault(),
                    modelclassId = M.ModelClass.Id,
                    modelId=M.Model.Id
                };
                modelPrices.Add(model_Price);
            }
            return modelPrices;
        }

        public List<SearchViewModel> SearchViewModel(int Brand, int Model)
        {
            List<SearchViewModel> modelPrices = new List<SearchViewModel>();
            var cardetails = _db.CarDetails.Include(a => a.ModelClass).Include(a => a.ModelClass.Model).Include(a => a.CarPhotos)
                .Where(a => a.ModelClass.Model.Brand.Id == Brand)
                .Where(a => a.ModelClass.Model.Id == Model)
                .Select(x => new { x.ModelClass.Model, x.Price, x.CarPhotos, x.ModelClass.Model.Brand, x.ModelClass }).ToList();
            foreach (var M in cardetails)
            {
                SearchViewModel model_Price = new SearchViewModel
                {
                    Model = M.Model.Name,
                    price = (decimal)M.Price,
                    Brand = M.Brand.Name,
                    Img = M.CarPhotos.Select(a => a.PhotoName).FirstOrDefault(),
                    modelclassId = M.ModelClass.Id,
                    modelId = M.Model.Id
                };
                modelPrices.Add(model_Price);
            }
            return modelPrices;
        }

        public List<SearchViewModel> SearchViewModel(int Brand, int Model, int Body)
        {
            List<SearchViewModel> modelPrices = new List<SearchViewModel>();
            var cardetails = _db.CarDetails.Include(a => a.ModelClass).Include(a => a.ModelClass.Model).Include(a => a.CarPhotos)
                .Include(a => a.ModelClass.Model.Type)
               .Where(a => a.ModelClass.Model.Brand.Id == Brand)
               .Where(a => a.ModelClass.Model.Id == Model)
               .Where(a => a.ModelClass.Model.Type.Id == Body)
               .Select(x => new { x.ModelClass.Model, x.Price, x.CarPhotos, x.ModelClass.Model.Brand, x.ModelClass }).ToList();
            foreach (var M in cardetails)
            {
                SearchViewModel model_Price = new SearchViewModel
                {
                    Model = M.Model.Name,
                    price = (decimal)M.Price,
                    Brand = M.Brand.Name,
                    Img = M.CarPhotos.Select(a => a.PhotoName).FirstOrDefault(),
                    modelclassId = M.ModelClass.Id,
                    modelId = M.Model.Id
                };

                modelPrices.Add(model_Price);
            }
            return modelPrices;
        }

        public List<SearchViewModel> SearchByBody(int Body)
        {
            List<SearchViewModel> modelPrices = new List<SearchViewModel>();
            var cardetails = _db.CarDetails.Include(a => a.ModelClass).Include(a => a.ModelClass.Model).Include(a => a.CarPhotos)
                .Include(a => a.ModelClass.Model.Type)
               .Where(a => a.ModelClass.Model.Type.Id == Body && a.ModelClass.ClassId == 1)
               .Select(x => new { x.ModelClass.Model, x.Price, x.CarPhotos, x.ModelClass.Model.Brand, x.ModelClass }).ToList();
            foreach (var M in cardetails)
            {
                SearchViewModel model_Price = new SearchViewModel
                {
                    Model = M.Model.Name,
                    price = (decimal)M.Price,
                    Brand = M.Brand.Name,
                    Img = M.CarPhotos.Select(a => a.PhotoName).FirstOrDefault(),
                    modelclassId = M.ModelClass.Id,
                    modelId = M.Model.Id
                };
                modelPrices.Add(model_Price);
            }
            return modelPrices;
        }

        public List<SearchViewModel> SearchByPrice(int price1, int price2)
        {
            List<SearchViewModel> modelPrices = new List<SearchViewModel>();
            var cardetails = _db.CarDetails.Include(a => a.ModelClass).Include(a => a.ModelClass.Model).Include(a => a.CarPhotos)
                .Include(a => a.ModelClass.Model.Type)
               .Where(a => a.Price>=price1 && a.Price<=price2 && a.ModelClass.ClassId == 1)
               .Select(x => new { x.ModelClass.Model, x.Price, x.CarPhotos, x.ModelClass.Model.Brand, x.ModelClass }).ToList();
            foreach (var M in cardetails)
            {
                SearchViewModel model_Price = new SearchViewModel
                {
                    Model = M.Model.Name,
                    price = (decimal)M.Price,
                    Brand = M.Brand.Name,
                    Img = M.CarPhotos.Select(a => a.PhotoName).FirstOrDefault(),
                    modelclassId = M.ModelClass.Id,
                    modelId = M.Model.Id
                };

                modelPrices.Add(model_Price);
            }
            return modelPrices;
        }

        public List<SearchViewModel> SearchByYear(int year)
        {
            List<SearchViewModel> modelPrices = new List<SearchViewModel>();
            var cardetails = _db.CarDetails.Include(a => a.ModelClass).Include(a => a.ModelClass.Model).Include(a => a.CarPhotos)
                .Include(a => a.ModelClass.Model.Type)
               .Where(a => a.ModelClass.Model.Year ==year && a.ModelClass.ClassId == 1)
               .Select(x => new { x.ModelClass.Model, x.Price, x.CarPhotos, x.ModelClass.Model.Brand, x.ModelClass }).ToList();
            foreach (var M in cardetails)
            {
                SearchViewModel model_Price = new SearchViewModel
                {
                    Model = M.Model.Name,
                    price = (decimal)M.Price,
                    Brand = M.Brand.Name,
                    Img = M.CarPhotos.Select(a => a.PhotoName).FirstOrDefault(),
                    modelclassId = M.ModelClass.Id,
                    modelId = M.Model.Id
                };

                modelPrices.Add(model_Price);
            }
            return modelPrices;
        }
    }

}

