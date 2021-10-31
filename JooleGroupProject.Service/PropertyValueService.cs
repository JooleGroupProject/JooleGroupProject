using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.Data;
using JooleGroupProject.Repo;

namespace JooleGroupProject.Service
{
    public class PropertyValueService
    {
        private PropertyValueRepository propertyValueRepository;

        public PropertyValueService()
        {
            this.propertyValueRepository = new PropertyValueRepository();
        }

        public IEnumerable<tblPropertyValue> GetAllProduct()
        {
            IEnumerable<tblPropertyValue> propertyValues = this.propertyValueRepository.GetAll();
            return propertyValues;
        }

        public IEnumerable<tblPropertyValue> GetPropertyValuesByProductId(int id)
        {
            return this.propertyValueRepository.GetPropertyValuesByProductId(id);
        }


        public IEnumerable<tblPropertyValue> GetUseTypeByProductId(int id)
        {
            return this.propertyValueRepository.GetUseTypeByProductId(id);
        }

        public IEnumerable<tblPropertyValue> GetApplicationByProductId(int id)
        {
            return this.propertyValueRepository.GetApplicationByProductId(id);
        }

        public IEnumerable<tblPropertyValue> GetAccessoriesByProductId(int id)
        {
            return this.propertyValueRepository.GetAccessoriesByProductId(id);
        }
        public IEnumerable<tblPropertyValue> GetAirflowByProductId(int id)
        {
            return this.propertyValueRepository.GetAirflowByProductId(id);
        }

        public IEnumerable<tblPropertyValue> GetPowerByProductId(int id)
        {
            return this.propertyValueRepository.GetPowerByProductId(id);
        }

        public IEnumerable<tblPropertyValue> GetOperatingVoltageByProductId(int id)
        {
            return this.propertyValueRepository.GetOperatingVoltageByProductId(id);
        }

        public IEnumerable<tblPropertyValue> GetFanSpeedByProductId(int id)
        {
            return this.propertyValueRepository.GetFanSpeedByProductId(id);
        }

        public IEnumerable<tblPropertyValue> GetNumFanSpeedByProductId(int id)
        {
            return this.propertyValueRepository.GetNumFanSpeedByProductId(id);
        }

        public IEnumerable<tblPropertyValue> GetSoundAtMaxSpeedByProductId(int id)
        {
            return this.propertyValueRepository.GetSoundAtMaxSpeedByProductId(id);
        }



    }
}
