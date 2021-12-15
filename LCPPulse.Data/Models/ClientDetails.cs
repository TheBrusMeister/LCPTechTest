using System;

namespace LCPPulse.Data.Models
{
    public class ClientDetails
    {
        public Guid? ClientId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
    }
}
