﻿using AutoMapper;
using Contracts.Repository;
using Contracts.Service;
using Entities;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using users_api.BLL.Validation;

namespace users_api.BLL.Services
{
    public class RoleService : IRoleService
    {
        private IRepositoryManager _repository;
        private IMapper _mapper;
        private RoleValidator _validator;
        public RoleService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = new RoleValidator();
        }
        public RoleDTO? Create(RoleForCreationDTO entity)
        {
            Role role = _mapper.Map<Role>(entity);
            var result = _validator.Validate(role);
            if (!result.IsValid)
            {
                string message = "";
                result.Errors.ForEach(e => message += e.ErrorMessage);
                throw new EntityIsNotValidException(message);
            }

            _repository.Role.CreateRole(role);
            _repository.Save();
            return _mapper.Map<RoleDTO>(role);
        }

        public RoleDTO? Delete(int id)
        {
            Role? role = _repository.Role.GetRole(id, false);
            if (role == null)
                throw new NotFoundException("Role with id {id} not found");

            _repository.Role.DeleteRole(role);
            _repository.Save();
            return _mapper.Map<RoleDTO>(role);
        }

        public RoleDTO? Get(int id, bool trackChanges)
        {
            Role? user = _repository.Role.GetRole(id, trackChanges);
            return _mapper.Map<RoleDTO>(user);
        }

        public IEnumerable<RoleDTO>? GetAll(bool trackChanges)
        {
            var roles = _repository.Role.GetAllRoles(trackChanges);
            return _mapper.Map<IEnumerable<RoleDTO>?>(roles);
        }

        public RoleDTO? Update(RoleForUpdateDTO entity)
        {
            Role role = _mapper.Map<Role>(entity);
            var result = _validator.Validate(role);
            if (!result.IsValid)
            {
                string message = "";
                result.Errors.ForEach(e => message += e.ErrorMessage);
                throw new EntityIsNotValidException(message);
            }

            _repository.Role.UpdateRole(role);
            _repository.Save();
            return _mapper.Map<RoleDTO>(role);
        }
    }
}
