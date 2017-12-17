using System;
using System.Collections.Generic;
using BLL.UserRepository;
using Entity.UserModels;

namespace BLL
{
    public class ServiceProvider
    {
        private readonly IDictionary<Type, Type> _repositories = new Dictionary<Type, Type>();


        public ServiceProvider()
        {
            _repositories.Add(typeof(Tutor), typeof(TutorService));
            _repositories.Add(typeof(Student), typeof(StudentService));
            _repositories.Add(typeof(Admin), typeof(AdminService));

        }

        public IUserService<TEntity> Create<TEntity>() where TEntity : class
        {
            Type type = _repositories[typeof(TEntity)];
            return Activator.CreateInstance(type) as IUserService<TEntity>;
        }


    

    }
}
