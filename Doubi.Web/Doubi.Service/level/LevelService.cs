using Doubi.Core.Domain;
using Doubi.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Service.level
{
    public class LevelService
    {
        private readonly LevelRepository<Level> _levelRep;

        public LevelService()
        {
            _levelRep = new LevelRepository<Level>();
        }

        public List<Level> All_levels()
        {
            return _levelRep.SelectAll();
        }

    }
}
