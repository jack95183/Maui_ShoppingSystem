
using SQLite;

namespace MauiShoppingSystem.Models;
[Table("[shopingcart]")]
public class ShoppingCartJoinCommodityModel
{
    public string? name { get; set; }
    public int price { get; set; }
    public int count { get; set; }
    public int commodityid { get; set; }
    public DateTime cdt {  get; set; }
    public DateTime udt { get; set; }
    public string status {  get; set; }
}