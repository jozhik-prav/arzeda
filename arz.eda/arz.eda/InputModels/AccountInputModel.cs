using System;

namespace arz.eda.InputModels
{
    public class AccountInputModel
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
        public string? Entrance { get; set; } = "";
        public string? Intercom { get; set; } = "";
        public  int Floor { get; set; }
        public string? Flat { get; set; } = "";
    }
}
