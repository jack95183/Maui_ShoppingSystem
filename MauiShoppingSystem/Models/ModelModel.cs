
using System.ComponentModel.DataAnnotations.Schema;

namespace MauiShoppingSystem.Models;
[Table("[MODEL]")]
public class ModelModel
{
    public string? Model { get; set; }
    public string? Family { get; set; }
}