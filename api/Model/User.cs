using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("Users")]
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FigureExchangeTotal { get; set; }

        public IList<Figure> Figure { get; set; }
        
        public ICollection<FigureUser> FigureUserOwner { get; set; }
        public ICollection<FigureUser> FigureUserRequest { get; set; }
    }
}
