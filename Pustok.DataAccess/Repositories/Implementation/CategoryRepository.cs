using Pustok.Core.Entities;
using Pustok.DataAccess.Contexts;
using Pustok.DataAccess.Repositories.Abstraction;
using Pustok.DataAccess.Repositories.Implementation.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Repositories.Implementation
{
    internal class CategoryRepository(AppDbContext _conteext) :  Repository<Category>(_conteext) , ICategoryRepository
    {
    }
}
