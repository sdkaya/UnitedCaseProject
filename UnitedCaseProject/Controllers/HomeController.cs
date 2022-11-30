using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UnitedCase.Common.DTO;
using UnitedCase.Services.IServices;
using UnitedCaseProject.Models;

namespace UnitedCaseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMainNoteService _mainNoteService;
        private readonly IChildNoteService _childNoteService;

        public HomeController(ILogger<HomeController> logger, IMainNoteService mainNoteService, IChildNoteService childNoteService)
        {
            _logger = logger;
            _mainNoteService = mainNoteService;
            _childNoteService = childNoteService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mainNoteService.GetAllNotes();
            return View(result.List);
        }


        public IActionResult CreateMainNote()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMainNote(string note)
        {
            var result = await _mainNoteService.CreateMainNote(note);

            if (result.isSuccess)
                return Json((new { response = true }));
            else
                return Json(new { response = false });
        }
        [HttpPost]
        public async Task<IActionResult> AddChildNote(CreateChildNoteDto dto)
        {
            var result = await _childNoteService.CreateChildNote(dto);

            if (result.isSuccess)
                return Json((new { response = true }));
            else
                return Json(new { response = false });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMainNote(int id)
        {
            var result = await _mainNoteService.DeleteMainNote(id);

            if (result.isSuccess)
                return Json((new { response = true }));
            else
                return Json(new { response = false });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteChildNote(int id)
        {
            var result = await _childNoteService.DeleteChildNote(id);

            if (result.isSuccess)
                return Json((new { response = true }));
            else
                return Json(new { response = false });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
