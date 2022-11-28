using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedCase.Common.DTO;
using UnitedCase.Common.Helper;

namespace UnitedCase.Services.IServices
{
    public interface IChildNoteService
    {
        Task<Response<bool>> CreateChildNote(CreateChildNoteDto createChildNoteDto);
        Task<Response<bool>> DeleteChildNote(int id);
    }
}
