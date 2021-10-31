using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using JooleGroupProject.Data;

namespace JooleGroupProject.Repo
{
    public class TechSpecFilterRepository: Repository<tblSpecFilter>
    {
        public Dictionary<string,KeyValuePair<int,int>> GetTechSpecFiltersBySubCatId(int subCatId)
        {
            Dictionary<string, KeyValuePair<int, int>> techSpecFilters = new Dictionary<string, KeyValuePair<int, int>>();

            var props = from f in this.entities
                        join p in context.tblProperties
                        on f.Property_ID equals p.Property_ID
                        where f.SubCategory_ID == subCatId
                        select new
                        {
                            Propertyname = p.Property_Name,
                            Min = f.Min_value,
                            Max = f.Max_value
                        };
            foreach(var p in props)
            {
                techSpecFilters.Add(p.Propertyname, new KeyValuePair<int, int>(int.Parse(p.Min), int.Parse(p.Max)));
            }

            return techSpecFilters;
        }

        public IEnumerable<tblSpecFilter> GetTechSpecFiltersBySubCatId2(int subCatId)
        {

            return this.context.tblSpecFilters.Include(p => p.tblProperty).Where(p=>p.SubCategory_ID == subCatId);
        }
    }
}
