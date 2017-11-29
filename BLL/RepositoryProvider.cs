using System;
using System.Collections.Generic;
using BLL.UserRepository;
using Entity.UserModels;

namespace BLL
{
    public class RepositoryProvider
    {
        private readonly IDictionary<Type, Type> _repositories = new Dictionary<Type, Type>();

        public RepositoryProvider()
        {
            _repositories.Add(typeof(Tutor), typeof(TutorRepository));
            _repositories.Add(typeof(Student), typeof(StudentRepository));
            _repositories.Add(typeof(Admin), typeof(AdminRepository));
        }

        public IUserRepository<TEntity> Create<TEntity>() where TEntity : class
        {
            Type type = _repositories[typeof(TEntity)];
            return Activator.CreateInstance(type) as IUserRepository<TEntity>;
        }

    }
}
