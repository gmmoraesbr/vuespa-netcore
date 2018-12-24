using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class Figure
    {
        public int FigureId { get; set; }

        public int Number { get; set; }

        public int Amount { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
