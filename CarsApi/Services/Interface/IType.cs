﻿using CarsApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Models;
using Type = CarsApi.Models.Type;

namespace CarsApi.Services.Interface
{
    public interface IType
    {
        Type GetTypeById(int id);
        MessageResponseViewModel EditType(int id, Type type);
        List<Type> GetAllTypes();
        MessageResponseViewModel AddType(Type type);
    }
}