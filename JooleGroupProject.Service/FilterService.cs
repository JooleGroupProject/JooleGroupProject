using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.Repo;
using JooleGroupProject.Data;

namespace JooleGroupProject.Service
{
    public class FilterService
    {
        private TypeFilterRepository typeFilterRepository;
        private TechSpecFilterRepository techSpecFilterRepository;
        public FilterService()
        {
            this.typeFilterRepository = new TypeFilterRepository();
            this.techSpecFilterRepository = new TechSpecFilterRepository();
        }

        public Dictionary<string, List<string>> getTypeFiltersBySubCatId(int subCatId)
        {
            return this.typeFilterRepository.GetTypeFiltersBySubCatId(subCatId);
        }

        public Dictionary<string, KeyValuePair<int, int>> GetTechSpecFiltersBySubCatId(int subCatId)
        {
            return this.techSpecFilterRepository.GetTechSpecFiltersBySubCatId(subCatId);
        }

        public IEnumerable<tblSpecFilter> GetTechSpecFiltersBySubCat2(int subCatId)
        {
            return this.techSpecFilterRepository.GetTechSpecFiltersBySubCatId2(subCatId);
        }
    }
}
