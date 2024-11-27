using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserService.Models;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    // Giả sử bạn có một danh sách người dùng
    private static List<User> users = new List<User>();
    private readonly HttpClient _httpClient;

    public UserController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] User user)
    {
        // Kiểm tra nếu user là null
        if (user == null)
        {
            return BadRequest();
        }

        // Thêm user vào danh sách (nếu cần tạo Id, bạn có thể tự động gán)
        user.Id = users.Count + 1;
        users.Add(user);

        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return user;
    }
    [HttpGet]

    [Route("~/GetBooks")]
    public async Task<IActionResult> GetBooks()
    {
        var response = await _httpClient.GetStringAsync("http://localhost:5001/api/Book/GetBooks");
        return Ok(response);
    }
}
