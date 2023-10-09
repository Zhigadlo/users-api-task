using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using users_api.BLL.Validation;

namespace users_api.BLL.Services
{
    public class RoleService : IService<RoleDTO>
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
        public RoleDTO? Create(RoleDTO entity)
        {
            Role role = _mapper.Map<Role>(entity);
            var result = _validator.Validate(role);
            if (!result.IsValid)
                return null;

            _repository.Role.CreateRole(role);
            return entity;
        }

        public RoleDTO? Delete(int id)
        {
            Role? role = _repository.Role.GetRole(id, false);
            if (role == null)
                return null;

            _repository.Role.DeleteRole(role);
            return _mapper.Map<RoleDTO>(role);
        }

        public RoleDTO? Get(int id, bool trackChanges)
        {
            Role? user = _repository.Role.GetRole(id, trackChanges);
            return _mapper.Map<RoleDTO>(user);
        }

        public IQueryable<RoleDTO>? GetAll(bool trackChanges)
        {
            var roles = _repository.User.GetAllUsers(trackChanges);
            return _mapper.Map<IQueryable<RoleDTO>>(roles);
        }

        public RoleDTO? Update(RoleDTO entity)
        {
            Role role = _mapper.Map<Role>(entity);
            var result = _validator.Validate(role);
            if (!result.IsValid)
                return null;

            _repository.Role.UpdateRole(role);
            return entity;
        }
    }
}
