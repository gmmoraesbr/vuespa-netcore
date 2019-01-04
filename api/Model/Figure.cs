using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class Figure
    {
        [Key]
        public int FigureId { get; set; }

        public int Number { get; set; }

        public int Amount { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [NotMapped]
        public ICollection<FigureUser> FigureUser { get; set; }

    }
}
