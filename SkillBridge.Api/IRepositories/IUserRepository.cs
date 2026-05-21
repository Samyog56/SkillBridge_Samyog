using SkillBridge.Api.Entities;

public interface IUserRepository
{
    public Task<string> CreateUserAsync(CreateUserRequestDto user);
}