using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MockCMS.Models;
using MockCMS.ViewModels;

namespace MockCMS.Repositories
{
    public interface IItemPropertyTypeRepository : IRepository
    {
        public IItemPropertyType GetPropertyType(Guid id);

        public void AddPropertyType(CreatePropertyTypeInputModel newValues);

        public void RemovePropertyType(Guid id);

        public IList<IItemPropertyType> GetAllPropertyTypes();
    }
}