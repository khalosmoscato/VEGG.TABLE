namespace VEGG.TABLE.Core.Entities;

public class User : IdentityUser
{
    public required string Name { get; set; }
    public UserType UserType { get; set; } = UserType.Buyer;
}
public enum UserType
{
    Seller,
    Buyer,
    Admin
}