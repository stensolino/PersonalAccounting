﻿using PersonalAccounting.Domain.Dto;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Services.Interfaces
{
    public interface IUsersServices
    {
        Task<long> CreateUserAsync(UserDto user);
    }
}
