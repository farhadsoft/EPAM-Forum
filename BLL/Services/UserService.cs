using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task AddAsync(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            var result = unitOfWork.UserRepository.FindAll();
            return mapper.Map<IEnumerable<UserModel>>(result);
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var result = await unitOfWork.UserRepository.GetByIdAsync(id);
            return mapper.Map<UserModel>(result);
        }

        public Task UpdateAsync(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}