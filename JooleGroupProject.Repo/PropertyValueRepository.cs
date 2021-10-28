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
        public Dictionary<string, string> GetTechSpecProperties(int productId)
        {
            Dictionary<string, string> techSpecProps = new Dictionary<string, string>();
            var properties = from v in this.entities
                             join p in context.tblProperties
                             on v.Property_ID equals p.Property_ID
                             where v.Product_ID == productId && p.IsTechSpec == "TRUE"
                             select new
                             {
                                 PropertyName = p.Property_Name,
                                 PropertyValue = v.Value
                             };
            foreach (var prop in properties)
            {
                techSpecProps.Add(prop.PropertyName, prop.PropertyValue);
            }
            return techSpecProps;
        }

        public Dictionary<string, string> GetTypeProperties(int productId)
        {
            Dictionary<string, string> typeProps = new Dictionary<string, string>();
            var properties = from v in this.entities
                             join p in context.tblProperties
                             on v.Property_ID equals p.Property_ID
                             where v.Product_ID == productId && p.IsType == "TRUE"
                             select new
                             {
                                 PropertyName = p.Property_Name,
                                 PropertyValue = v.Value
                             };
            foreach (var prop in properties)
            {
                typeProps.Add(prop.PropertyName, prop.PropertyValue);
            }
            return typeProps;
        }
    }
}
