using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Figure> Figure { get; set; }
    }
}
