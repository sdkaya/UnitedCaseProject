using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedCase.Entity.Entities
{
    public class MainNote : AbstractEntity
    {
        [Key]
        public int Id { get; set; }
        public string Note { get; set; }
        public virtual ICollection<ChildNote> ChildNotes { get; set; }  
    }
}
