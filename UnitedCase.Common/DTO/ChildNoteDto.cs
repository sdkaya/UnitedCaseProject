using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedCase.Common.DTO
{
    public class ChildNoteDto
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public int MainId { get; set; }
    }
}
