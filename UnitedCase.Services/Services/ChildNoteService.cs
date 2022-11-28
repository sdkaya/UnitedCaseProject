using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedCase.Common.DTO;
using UnitedCase.Common.Helper;
using UnitedCase.Entity.Entities;
using UnitedCase.Repository.IRepository;
using UnitedCase.Services.IServices;

namespace UnitedCase.Services.Services
{
    public class ChildNoteService: IChildNoteService
    {
        private readonly IMainNoteRepository _mainNoteRepository;
        private readonly IChildNoteRepository _childNoteRepository;

        public ChildNoteService(IMainNoteRepository mainNoteRepository, IChildNoteRepository childNoteRepository)
        {
            _mainNoteRepository = mainNoteRepository;
            _childNoteRepository = childNoteRepository;
        }

        public async Task<Response<bool>> CreateChildNote(CreateChildNoteDto createChildNoteDto)
        {
            try
            {
                var note = new ChildNote()
                {
                    Note = createChildNoteDto.Note,
                    MainNoteId = createChildNoteDto.MainNoteId, 
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                await _childNoteRepository.InsertAsync(note);
                return new Response<bool>() { isSuccess = true, Data = true, List = null, Message = "Success", Status = 200 };

            }
            catch (Exception ex)
            {
                return new Response<bool>() { isSuccess = false, Data = false, List = null, Message = ex.Message, Status = 500 };
            }
        }
        public async Task<Response<bool>> DeleteChildNote(int id)
        {
            try
            {
                var note = await _childNoteRepository.FindBy(x => x.Id == id).FirstOrDefaultAsync();
                if (note == null)
                {
                    throw new Exception("Note could not found!");
                }

                note.IsActive = false;

                await _childNoteRepository.Update(note);
                return new Response<bool>() { isSuccess = true, Data = true, List = null, Message = "Success", Status = 200 };
            }
            catch (Exception ex)
            {
                return new Response<bool>() { isSuccess = false, Data = false, List = null, Message = ex.Message, Status = 500 };
            }

        }
    }
}
