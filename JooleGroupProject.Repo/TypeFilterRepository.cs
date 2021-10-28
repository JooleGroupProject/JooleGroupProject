using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.Data;

namespace JooleGroupProject.Repo
{
    public class TypeFilterRepository: Repository<tblTypeFilter>
    {
        public Dictionary<string,List<string>> GetTypeFiltersBySubCatId(int subCatId)
        {
            Dictionary<string, List<string>> propOptions = new Dictionary<string, List<string>>();
            var props= from f in this.entities
                   join p in context.tblProperties
                   on f.Property_ID equals p.Property_ID
                   where f.SubCategory_ID == subCatId
                   select new
                   {
                       PropertyName = p.Property_Name,
                       PropertyOptions = f.Type_Name
                   };
            foreach(var p in props)
            {
                if (propOptions.ContainsKey(p.PropertyName)){
                    propOptions[p.PropertyName].Add(p.PropertyOptions);
                }
                else {
                    propOptions[p.PropertyName] = new List<string> { p.PropertyOptions };
                }
            }
            return propOptions;

        }

    }
}
