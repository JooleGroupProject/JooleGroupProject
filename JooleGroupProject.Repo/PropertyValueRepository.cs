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
    }
}
