namespace Infrastucture.Services;
using Dapper;
using DataContext;
using Domain.Models;
using Npgsql;
public class ProductService
{
  private readonly DapperContext context;

  public ProductService()
  {
    context = new DapperContext();
  }

  public void AddProducts(Products product)
  {

    var sql = "insert into Products (name) values(@name)";

    context.connection().Execute(sql, product);

  }

  public ProductsStock GetProductsStockById(int id)
  {

    var sql = @"select * from Stocks where Id_Stock=@id;
                 select * from Products as p join ProductStock as ps on p.id_product=ps.id_product where ps.id_stock=@id";

    using (var multiple = context.connection().QueryMultiple(sql, new { Id = id }))
    {
      var ProductsStock1 = new ProductsStock();
      ProductsStock1.Stock = multiple.ReadFirst<Stocks>();
      ProductsStock1.Products = multiple.Read<Products>().ToList();
      return ProductsStock1;
    }

  }


  public List<ProductsStock> GetStocksWithProducts()
  {

    var sql1 = "select id_Stock from Stocks";

    var listOfId = context.connection().Query<int>(sql1);


    var sql2 = @"select * from Stocks where Id_Stock=@id;
                 select * from Products as p join ProductStock as ps on p.id_product=ps.id_product where ps.id_stock=@id";

    List<ProductsStock> listAll = new List<ProductsStock>();
    foreach (var item in listOfId)
    {
      using (var multiple = context.connection().QueryMultiple(sql2, new { Id = item }))
      {
        var ProductsStock1 = new ProductsStock();
        ProductsStock1.Stock = multiple.ReadFirst<Stocks>();
        ProductsStock1.Products = multiple.Read<Products>().ToList();
        listAll.Add(ProductsStock1);
      }
    }
    return listAll;
  }







}
