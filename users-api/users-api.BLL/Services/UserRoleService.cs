﻿using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using users_api.BLL.Validation;

namespace users_api.BLL.Services
{
    public class UserRoleService : IService<UserRole>
    {
        private IRepositoryManager _repository;
        private IMapper _mapper;
        private UserRoleValidator _validator;
        public UserRoleService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = new UserRoleValidator();
        }

        public UserRoleDTO? Create(UserRoleDTO item)
        {
            UserRole userRole = _mapper.Map<UserRole>(item);
            var result = _validator.Validate(userRole);
            if (!result.IsValid)
                return null;

            _repository.UserRole.CreateUserRole(userRole);
            return item;
        }

        public UserRoleDTO? Delete(int id)
        {
            UserRole? userRole = _repository.UserRole.GetUserRole(id, false);
            if (userRole == null)
                return null;

            _repository.UserRole.DeleteUserRole(userRole);
            return _mapper.Map<UserRoleDTO>(userRole);
        }

        public UserRoleDTO? Get(int id, bool isTracking = false)
        {
            UserRole? userRole = _repository.UserRole.GetUserRole(id, isTracking);
            return _mapper.Map<UserRoleDTO>(userRole);
        }

        public IQueryable<UserRoleDTO> GetAll(bool isTracking = false)
        {
            var users = _repository.UserRole.GetAllUserRoles(isTracking);
            return _mapper.Map<IQueryable<UserRoleDTO>>(users);
        }

        public UserDTO? Update(UserDTO item)
        {
            UserRole userRole = _mapper.Map<UserRole>(item);
            var result = _validator.Validate(userRole);
            if (!result.IsValid)
                return null;

            _repository.UserRole.UpdateUserRole(userRole);
            return item;
        }
    }
}