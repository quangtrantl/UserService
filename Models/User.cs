using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class User
{

    // Thuộc tính Id (thêm vào nếu bạn cần sử dụng)
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    public string Email { get; set; }

    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }
}

}
