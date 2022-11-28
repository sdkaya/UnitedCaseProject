using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedCase.Common.DTO;
using UnitedCase.Common.Helper;

namespace UnitedCase.Services.IServices
{
    public interface IMainNoteService
    {
        Task<Response<bool>> CreateMainNote(CreateMainNoteDto createMainNoteDto);
        Task<Response<bool>> DeleteMainNote(int id);
        Task<Response<GetNoteListDto>> GetAllNotes();
    }
}
