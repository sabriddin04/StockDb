namespace Domain.Models;

public class Moving
{

    public int Id_Moving { get; set; }

    public int Id_Product { get; set; }

    public int From_Stock { get; set; }

    public int To_Stock { get; set; }

    public int Quantity { get; set; }

    public DateTime Date_Moving { get; set; }


}
