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
    public class MainNoteService:IMainNoteService
    {

        private readonly IMainNoteRepository _mainNoteRepository;
        private readonly IChildNoteRepository _childNoteRepository;

        public MainNoteService(IMainNoteRepository mainNoteRepository, IChildNoteRepository childNoteRepository)
        {
            _mainNoteRepository = mainNoteRepository;
            _childNoteRepository = childNoteRepository;
        }

        public async Task<Response<bool>> CreateMainNote(CreateMainNoteDto createMainNoteDto)
        {
            try
            {
                var note = new MainNote()
                {
                    Note = createMainNoteDto.Note,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                await _mainNoteRepository.InsertAsync(note);
                return new Response<bool>() { isSuccess = true, Data = true, List = null, Message = "Success", Status = 200 };

            }
            catch (Exception ex)
            {
                return new Response<bool>() { isSuccess = false, Data = false, List = null, Message = ex.Message, Status = 500 };
            }
        }

        public async Task<Response<bool>> DeleteMainNote(int id)
        {
            try
            {
                var note = await _mainNoteRepository.FindBy(x => x.Id == id).FirstOrDefaultAsync();
                if (note == null)
                {
                    throw new Exception("Note could not found!");
                }

                note.IsActive = false;

                await _mainNoteRepository.Update(note);
                return new Response<bool>() { isSuccess = true, Data = true, List = null, Message = "Success", Status = 200 };
            }
            catch (Exception ex)
            {
                return new Response<bool>() { isSuccess = false, Data = false, List = null, Message = ex.Message, Status = 500 };
            }

        }

        public async Task<Response<GetNoteListDto>> GetAllNotes()
        {
            try
            {
                var childNoteDtoList = new List<ChildNoteDto>();
                var list = new List<GetNoteListDto>();
                var allMainNote = await _mainNoteRepository.FindBy(x => x.IsActive == true).ToListAsync();
                var allChildNote = await _childNoteRepository.FindBy(x => x.IsActive == true).ToListAsync();

                foreach (var item in allMainNote)
                {
                    var childNote = allChildNote.Where(x => x.MainNoteId == item.Id).ToList();

                    foreach (var item2 in childNote)
                    {
                        var childDto = new ChildNoteDto()
                        {
                            Id = item2.Id,
                            MainId=item.Id,
                            Note=item2.Note   
                        };
                        childNoteDtoList.Add(childDto);
                    }
                    var mainDto = new GetNoteListDto()
                    {
                        Id = item.Id,
                        Note = item.Note,
                        ChildNotes = childNoteDtoList
                    };
                    list.Add(mainDto);
                }
                return new Response<GetNoteListDto>() { isSuccess = true, Data = null, List = list, Message = "Success", Status = 200 };

            }
            catch (Exception ex)
            {
                return new Response<GetNoteListDto>() { isSuccess = false, Data = null, List = null, Message = ex.Message, Status = 500 };
            }

        }
    }
}
