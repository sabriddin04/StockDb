using Dapper;
using Domain.Models;
using Infrastucture.DataContext;
namespace Infrastucture.Services;

public class StockService
{
   private readonly DapperContext context;

   public StockService()
   {
      context = new DapperContext();
   }

   public void AddStock(Stocks stock)
   {
      var sql = "insert into Stocks(name,address)values(@name,@address)";

      context.connection().Execute(sql, stock);
   }

   public string MovingProducts(MovingProduct product)
   {
      var sql1 = @"  select * from ProductStock where Id_product=@Product and Id_Stock=@FromStock  ";
      var fromStock = context.connection().QueryFirstOrDefault<Sila>(sql1, new { Product = product.Product, FromStock = product.FromStock });
      if (fromStock.Quantity == null) return "product not found";
      if (fromStock.Quantity < product.Quantity)
      {
         return "NE KHVATAET PRODUCTA";
      }
      fromStock.Quantity -= product.Quantity;
      var sql2 = @"Update  ProductStock 
                      set Quantity= @quantity 
                         where Id_ProductStock = @id ";
      context.connection().Execute(sql2, new { Quantity = fromStock.Quantity, Id = fromStock.Id_ProductStock });

      var sql3 = @"  select * from ProductStock where Id_product=@Product and Id_Stock=@ToStock  ";
      var toStock = context.connection().QueryFirstOrDefault<Sila>(sql3, new { Product = product.Product, ToStock = product.ToStock });

      toStock.Quantity += product.Quantity;

      var sql4 = "Update ProductStock set Quantity= @quantity where Id_ProductStock = @id ";

      context.connection().Execute(sql4, new { Quantity = toStock.Quantity, Id = toStock.Id_ProductStock });

         var moving = new Moving()  
        {
            From_Stock = fromStock.Id_Stock,
            To_Stock = toStock.Id_Stock,
            Quantity = product.Quantity,
            Id_Product = product.Product,
            Date_Moving = DateTime.Now,
        };

        var sql5 = @"insert into moving (Id_product, From_Stock, To_Stock, Quantity, Date_Moving) values 
                    (@id_Product, @from_Stock, @to_Stock, @quantity, @Date_Moving )";
        context.connection().Execute(sql5, moving);


      return "sucessfuly";

   }



}
