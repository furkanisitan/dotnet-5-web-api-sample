using Shop.Entities.Concrete;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Shop.Business.Abstract
{
    public interface IUserService
    {
        User FindByUserNameWithRoles([NotNull] string username);
    }
}