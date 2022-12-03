using System;

namespace Backend.Console.Dto
{
    public class AcceptHandshakeDto
    {
        public string Username { get; set; }
        public Guid HandshakeId { get; set; }
    }
}
