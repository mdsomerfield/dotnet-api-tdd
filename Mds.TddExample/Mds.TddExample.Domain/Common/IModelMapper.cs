using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mds.TddExample.Domain.Common
{
    public interface IModelMapper<TEntity, TModel>
    {
        TModel MapFrom(TEntity entity);
        TEntity MapTo(TModel model);
    }
}
