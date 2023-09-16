using System.ComponentModel.DataAnnotations.Schema;

namespace MauiShoppingSystem.Models;
[Table("[commodity]")]
//[Table("[WC_SUB]")]
public class CommodityModel
{
    public int? id { get; set; }
    public string? name { get; set; }
    public int price { get; set; }
    //public string? Wc { get; set; }
    //public string? SubWc { get; set; }
    //public string? Editor { get; set; }
}