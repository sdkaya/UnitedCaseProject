using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedCase.Entity.Entities
{
    public class ChildNote : AbstractEntity
    {
        [Key]
        public int Id { get; set; }
        public string Note { get; set; }

        public virtual MainNote MainNote { get; set; }

        [ForeignKey("MainNote")]
        public int MainNoteId { get; set; }

    }
}
