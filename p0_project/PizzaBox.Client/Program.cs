﻿using System;
using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
{
  internal class Program
  {
    private static readonly PizzeriaSingleton _ps = PizzeriaSingleton.Instance;

    private static void Main(string[] args)
    {
      GetAllPizzas();
    }

    private static void GetAllPizzas()
    {
      foreach (var p in _ps.Get())
      {
        Console.WriteLine(p);
      }
    }
  }
}
