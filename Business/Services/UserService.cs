using Business.IServices;
using Core.DTOs;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HomeCardAppUserDto> GetHomeCardUserByIdAsync(Guid userId)
        {
            var userDto = await _unitOfWork.Users.SelectAsync(
                u => u.Id == userId,
                u => new HomeCardAppUserDto
                {
                    Id = u.Id,
                    FullName = u.FullName,
                });
            return userDto;
        }
    }
}
