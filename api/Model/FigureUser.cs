using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class FigureUser
    {
        [Key]
        public int FigureUserId { get; set; }

        public int Number { get; set; }

        public string Status { get; set; } = "Pendente";

        public int UserOwnerId { get; set; }
        public int UserRequestId { get; set; }

        public User UserOwner { get; set; }
        public User UserRequest { get; set; }

        public int FigureId { get; set; }
        public Figure Figure { get; set; }

    }
}
