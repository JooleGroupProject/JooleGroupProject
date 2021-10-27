using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.Data;

namespace JooleGroupProject.Repo
{
    public class PropertyValueRepository : Repository<tblPropertyValue>
    {
        public PropertyValueRepository() : base()
        {
        }

        public IEnumerable<tblPropertyValue> GetPropertyValuesByProductId(int productId)
        {
            return from propertyValue in this.entities
                   where propertyValue.Product_ID == productId
                   select propertyValue;
        }

        //Unfinished
        public IEnumerable<object> GetPropertyByProductId(int productId)
        {
            return from v in this.entities
                   join p in context.tblProperties
                   on v.Property_ID equals p.Property_ID
                   where v.Product_ID == productId
                   select new
                   {
                       PropertyName = p.Property_Name,
                       PropertyValue = v.Value,
                       IsTechSpec = p.IsTechSpec,
                       IsType = p.IsType
                   };
        }
    }
}
