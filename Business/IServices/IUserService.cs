﻿using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IUserService
    {
        Task<HomeCardAppUserDto> GetHomeCardUserByIdAsync(Guid userId); 
    }
}
