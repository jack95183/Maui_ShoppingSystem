using SQLite;

namespace MauiShoppingSystem.Models;
[Table("[User]")]
public class UserModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? name { get; set; }
    public string? phone { get; set; }
    public string? address { get; set; }
    public int age { get; set; }
    public string? userid { get; set; }
    public string? password { get; set; }
    public string? Checkpassword { get; set; }
}