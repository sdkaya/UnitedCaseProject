using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedCase.Entity.Entities;
using UnitedCase.Repository.IRepository;

namespace UnitedCase.Repository.Repository
{
    public class ChildNoteRepository : GenericRepository<ChildNote>, IChildNoteRepository
    {

        public ChildNoteRepository(UnitedCaseProjectDbContext context) : base(context)
        {

        }
    }
}
