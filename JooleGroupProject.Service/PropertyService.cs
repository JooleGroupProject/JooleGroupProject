using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.Data;
using JooleGroupProject.Repo;

namespace JooleGroupProject.Service
{
    class PropertyService
    {
        PropertyValueRepository propValueRepo;
        PropertyRepository propRepo;

        public PropertyService()
        {
            this.propValueRepo = new PropertyValueRepository();
            this.propRepo = new PropertyRepository();
        }

        public Dictionary<string,string> GetTechSpecsByProductId(int productId)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            IEnumerable<tblPropertyValue> propretyValues = this.propValueRepo.GetPropertyValuesByProductId(productId);
            foreach (tblPropertyValue pv in propretyValues)
            {
                tblProperty prop = propRepo.Get(pv.Property_ID);
                string propertyName = prop.Property_Name;
                if (prop.IsTechSpec == "TRUE")
                {
                    properties.Add(propertyName, pv.Value);
                }
            }
            return properties;
        }
    }
}
