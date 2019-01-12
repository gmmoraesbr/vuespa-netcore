using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class FigureUser
    {
        public int FigureUserId { get; set; }
        public int NumberOwner { get; set; }
        public int NumberRequest { get; set; }
        public string Status { get; set; } = "Pendente";

        public int UserOwnerId { get; set; }
        public int UserRequestId { get; set; }

        public User UserOwner { get; set; }
        public User UserRequest { get; set; }

        public int FigureOwnerId { get; set; }
        public int FigureRequestId { get; set; }

        public Figure FigureOwner { get; set; }
        public Figure FigureRequest { get; set; }

    }
}
