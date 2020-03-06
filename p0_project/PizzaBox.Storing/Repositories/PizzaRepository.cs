using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaRepository
  {
    private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public List<Pizza> Get()
    {
      return _db.Pizza.Include(p => p.Crust).Include(p => p.Size).Include(p => p.PizzaToppings).ToList();
    }

    public Pizza Get(long id)
    {
      return _db.Pizza.SingleOrDefault(p => p.PizzaId == id);
    }

    public bool Post(Pizza pizza)
    {
      _db.Pizza.Add(pizza);
      return _db.SaveChanges() == 1;
    }

    public bool Put(Pizza pizza)
    {
      Pizza p = Get(pizza.PizzaId);

      p = pizza;
      return _db.SaveChanges() == 1;
    }
  }
}
