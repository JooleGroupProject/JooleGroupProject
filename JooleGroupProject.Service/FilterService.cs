using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.Repo;

namespace JooleGroupProject.Service
{
    public class FilterService
    {
        private TypeFilterRepository typeFilterRepository;
        public FilterService()
        {
            this.typeFilterRepository = new TypeFilterRepository();
        }

        public Dictionary<string, List<string>> getTypeFiltersBySubCatId(int subCatId)
        {
            return this.typeFilterRepository.GetTypeFiltersBySubCatId(subCatId);
        }
    }
}
