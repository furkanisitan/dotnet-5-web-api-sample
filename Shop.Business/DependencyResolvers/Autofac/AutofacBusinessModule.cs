using Autofac;
using Core.Utilities.Authentication.TokenBased;
using Core.Utilities.Authentication.TokenBased.JWT;
using Microsoft.AspNetCore.Identity;
using Shop.Business.Abstract;
using Shop.Business.Concrete.Managers;
using Shop.DataAccess.Abstract;
using Shop.DataAccess.Concrete.EntityFramework;
using Shop.Entities.Concrete;

namespace Shop.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Services
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            #endregion

            #region Repositories
            builder.RegisterType<EfUserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<EfRoleRepository>().As<IRoleRepository>().SingleInstance();
            builder.RegisterType<EfUserRoleRepository>().As<IUserRoleRepository>().SingleInstance();
            builder.RegisterType<EfProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<EfCategoryRepository>().As<ICategoryRepository>().SingleInstance();
            #endregion

            builder.RegisterType<PasswordHasher<User>>().As<IPasswordHasher<User>>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<TokenHelper>().SingleInstance();
        }
    }
}
