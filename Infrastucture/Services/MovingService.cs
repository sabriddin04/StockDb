namespace Infrastucture.Services;
using Dapper;
using DataContext;
using Domain.Models;
public class MovingService
{
    private readonly DapperContext context;

    public MovingService()
    {
        context = new DapperContext();
    }

   public List<Moving> MovingOfTime(DateTime date)
    {
        var sql2 = "select * from Moving where Date_Moving>@date";
        return context.connection().Query<Moving>(sql2, new { Date = date }).ToList();
    }









}
