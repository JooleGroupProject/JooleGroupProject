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
            var query = "select * from tblPropertyValue join tblProperty on tblPropertyValue.Property_ID = tblProperty.Property_ID join tblProducts on tblPropertyValue.Product_ID = tblProducts.Product_ID Where tblProducts.Product_ID = " + productId;

            return this.context.tblPropertyValues.SqlQuery(query);
        }

        public IEnumerable<tblPropertyValue> GetUseTypeByProductId(int productId)
        {

            var query = "select * from tblPropertyValue join tblProperty on tblPropertyValue.Property_ID = tblProperty.Property_ID join tblProducts on tblPropertyValue.Product_ID = tblProducts.Product_ID Where tblPropertyValue.Property_ID = 2 and tblProducts.Product_ID = " + productId;

            return this.context.tblPropertyValues.SqlQuery(query);
        }

        public IEnumerable<tblPropertyValue> GetApplicationByProductId(int productId)
        {

            var query = "select * from tblPropertyValue join tblProperty on tblPropertyValue.Property_ID = tblProperty.Property_ID join tblProducts on tblPropertyValue.Product_ID = tblProducts.Product_ID Where tblPropertyValue.Property_ID = 3 and tblProducts.Product_ID = " + productId;

            return this.context.tblPropertyValues.SqlQuery(query);
        }

        public IEnumerable<tblPropertyValue> GetAccessoriesByProductId(int productId)
        {

            var query = "select * from tblPropertyValue join tblProperty on tblPropertyValue.Property_ID = tblProperty.Property_ID join tblProducts on tblPropertyValue.Product_ID = tblProducts.Product_ID Where tblPropertyValue.Property_ID = 4 and tblProducts.Product_ID = " + productId;

            return this.context.tblPropertyValues.SqlQuery(query);
        }

        public IEnumerable<tblPropertyValue> GetAirflowByProductId(int productId)
        {

            var query = "select * from tblPropertyValue join tblProperty on tblPropertyValue.Property_ID = tblProperty.Property_ID join tblProducts on tblPropertyValue.Product_ID = tblProducts.Product_ID Where tblPropertyValue.Property_ID = 1 and tblProducts.Product_ID = " + productId;

            return this.context.tblPropertyValues.SqlQuery(query);
        }

        public IEnumerable<tblPropertyValue> GetPowerByProductId(int productId)
        {

            var query = "select * from tblPropertyValue join tblProperty on tblPropertyValue.Property_ID = tblProperty.Property_ID join tblProducts on tblPropertyValue.Product_ID = tblProducts.Product_ID Where tblPropertyValue.Property_ID = 5 and tblProducts.Product_ID = " + productId;

            return this.context.tblPropertyValues.SqlQuery(query);
        }

        public IEnumerable<tblPropertyValue> GetOperatingVoltageByProductId(int productId)
        {

            var query = "select * from tblPropertyValue join tblProperty on tblPropertyValue.Property_ID = tblProperty.Property_ID join tblProducts on tblPropertyValue.Product_ID = tblProducts.Product_ID Where tblPropertyValue.Property_ID = 6 and tblProducts.Product_ID = " + productId;

            return this.context.tblPropertyValues.SqlQuery(query);
        }

        public IEnumerable<tblPropertyValue> GetFanSpeedByProductId(int productId)
        {

            var query = "select * from tblPropertyValue join tblProperty on tblPropertyValue.Property_ID = tblProperty.Property_ID join tblProducts on tblPropertyValue.Product_ID = tblProducts.Product_ID Where tblPropertyValue.Property_ID = 7 and tblProducts.Product_ID = " + productId;

            return this.context.tblPropertyValues.SqlQuery(query);
        }

        public IEnumerable<tblPropertyValue> GetNumFanSpeedByProductId(int productId)
        {

            var query = "select * from tblPropertyValue join tblProperty on tblPropertyValue.Property_ID = tblProperty.Property_ID join tblProducts on tblPropertyValue.Product_ID = tblProducts.Product_ID Where tblPropertyValue.Property_ID = 8 and tblProducts.Product_ID = " + productId;

            return this.context.tblPropertyValues.SqlQuery(query);
        }

        public IEnumerable<tblPropertyValue> GetSoundAtMaxSpeedByProductId(int productId)
        {

            var query = "select * from tblPropertyValue join tblProperty on tblPropertyValue.Property_ID = tblProperty.Property_ID join tblProducts on tblPropertyValue.Product_ID = tblProducts.Product_ID Where tblPropertyValue.Property_ID = 9 and tblProducts.Product_ID = " + productId;

            return this.context.tblPropertyValues.SqlQuery(query);
        }




    }
}
