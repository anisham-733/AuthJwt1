using AuthJwt1.Models;

namespace AuthJwt1.Repository
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(TodoItem todoItem);
    }
}
