using GreenMarket.Features.Commands.UserCommands.UserCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.UserQueries.UserViewModels;

namespace GreenMarket.API.Extensions.Mappers;

public static class UserMappingExtensions
{
    public static GetUserVm ToReadInfo(this User user)
    {
        return new()
        {
            Id = user.Id,
            UserBaseInfo = new()
            {
                UserName = user.UserName,
                FullName = user.FullName,
                Phone = user.Phone,
                Address = user.Address,
                Email = user.Email,
                Role = user.Role
            }
        };
    }

    public static User ToUser(this CreateUserRequest createInfo)
    {
        return new()
        {
            FullName = createInfo.UserBaseInfo.FullName,
            Phone = createInfo.UserBaseInfo.Phone,
            Address = createInfo.UserBaseInfo.Address,
            Email = createInfo.UserBaseInfo.Email,
            UserName = createInfo.UserBaseInfo.UserName,
            Role = createInfo.UserBaseInfo.Role
        };
    }

    public static User ToUpdate(this User user ,UpdateUserRequest updateInfo)
    {
        user.UserName = updateInfo.UserBaseInfo.UserName;
        user.FullName = updateInfo.UserBaseInfo.FullName;
        user.Phone = updateInfo.UserBaseInfo.Phone;
        user.Email = updateInfo.UserBaseInfo.Email;
        user.Address = updateInfo.UserBaseInfo.Address;
        user.Role = updateInfo.UserBaseInfo.Role;
        user.Version++;
        user.UpdatedAt = DateTime.UtcNow;
        return user;
    }

    public static User ToDeleted(this User user)
    {
        user.IsDeleted = true;
        user.DeletedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        user.Version++;
        return user;
    }
}