namespace UserService.Models
{
    public class User
{

    // Thuộc tính Id (thêm vào nếu bạn cần sử dụng)
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }
}

}
