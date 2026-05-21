using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[Controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    [HttpPost, Route("Create")]
    public async Task<string> CreateUser(CreateUserRequestDto request)
    {
        var result = await _userRepository.CreateUserAsync(request);
        return result;
    }

}