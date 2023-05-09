var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var users = new List<User>();

app.MapGet("/users", () => users);
app.MapGet("/users/{id}", (int id) => users.FirstOrDefault(h => h.Id == id));
app.MapPost("/users", (User user) => users.Add(user));
app.MapPut("/users", (User user) =>
{
    var index = users.FindIndex(h => h.Id == user.Id);
    if (index < 0)
    {
        throw new Exception("Not found");
    }
    users[index] = user;
});
app.MapDelete("users/{id}", (int id) =>
{
    var index = users.FindIndex(h => h.Id == id);
    if (index < 0) throw new Exception("Note found");
    users.RemoveAt(index);
});
app.Run();


public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; }
}