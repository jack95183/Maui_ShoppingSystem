namespace MauiShoppingSystem.Models;

// DAL層回傳Model 
public class ResultModel<T>
{
    public bool Result { get; set; }
    public T? Data { get; set; }
    public string Messages { get; set; } = string.Empty;
}
