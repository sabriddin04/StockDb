
using Domain.Models;
using Infrastucture.Services;
var productService = new ProductService();
var stockService = new StockService();
var movingService=new MovingService();
/*
var product1=new Products();
product1.Name="Kamaz";

 
 productService.AddProducts(product1);
 */
/*
 var stock1=new Stocks();
 stock1.Name="stock 6";
 stock1.Address="kulob";
 
 stockService.AddStock(stock1);
*/
/*

System.Console.WriteLine(productService.GetProductsStockById(2).Stock.Name);

foreach (var item in productService.GetProductsStockById(2).Products)
{
    System.Console.WriteLine(item.Name);
   System.Console.WriteLine("-------------------------------------------------");
}
*/
/*
foreach (var item in productService.GetStocksWithProducts())
{
    System.Console.WriteLine(item.Stock.Name);
    System.Console.WriteLine(item.Stock.Address);
    System.Console.WriteLine("----------------------------------");

    foreach (var item1 in item.Products)
    {
        System.Console.WriteLine(item1.Id_Product);
        System.Console.WriteLine(item1.Name);
    }
    System.Console.WriteLine("+++++++++++++++++++++++++++++++++++++");

}
*/
/*
var MovingProduct1=new MovingProduct();
MovingProduct1.Product=4;
MovingProduct1.FromStock=5;
MovingProduct1.ToStock=2;
MovingProduct1.Quantity=5;

System.Console.WriteLine(stockService.MovingProducts(MovingProduct1));
*/
 

/*

foreach (var item in movingService.MovingOfTime(new DateTime(2021-12-3)))
{
    System.Console.WriteLine(item.Id_Product);
    System.Console.WriteLine(item.Date_Moving);
    System.Console.WriteLine(item.Quantity);
    System.Console.WriteLine(item.From_Stock);
    System.Console.WriteLine(item.To_Stock);
    System.Console.WriteLine("-----------------------------------------------");
}
*/