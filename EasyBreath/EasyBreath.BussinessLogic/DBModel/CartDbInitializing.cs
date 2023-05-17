using EasyBreath.BussinessLogic.DBModel;
using System.Data.Entity;

public class CartsDbInitializer : CreateDatabaseIfNotExists<CartsContext>
{
     protected override void Seed(CartsContext context)
     {
          // Add any initial data or configurations here

          base.Seed(context);
     }
}