using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedCase.Entity.Entities;
using UnitedCase.Repository.IRepository;

namespace UnitedCase.Repository.Repository
{
    public class MainNoteRepository : GenericRepository<MainNote>, IMainNoteRepository
    {

        public MainNoteRepository(UnitedCaseProjectDbContext context) : base(context)
        {

        }
    }
}
