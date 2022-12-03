using Microsoft.AspNetCore.Mvc;
using Backend.Console.Services;
using Backend.Package.Entities;
using Backend.Console.Dto;

namespace Backend.Console
{
    public class HandshakeResult
    {
        public Guid Handshake;
    }


    [ApiController]
    [Route("contact")]
    public class CantactExchangeController : ControllerBase
    {
        private readonly ILogger<CantactExchangeController> logger;
        private readonly HandshakeService handshakeService;

        public CantactExchangeController(HandshakeService handshakeService, ILogger<CantactExchangeController> logger)
        {
            this.logger = logger;
            this.handshakeService = handshakeService;
        }

        [HttpPost]
        [Route("generate")]
        public HandshakeResult CreateHandshakeToken(CreateHandshakeDto request)
        {
            logger.LogInformation(
                "Creating handshake token for user: {User} with Contacts: {Contacts}",
                request.Username,
                request.AssociatedContacts);

            return new HandshakeResult
            {
                Handshake = handshakeService.CreateHandshake(request.Username, request.AssociatedContacts)
            };
        }

        [HttpPost]
        [Route("accept")]
        public void AcceptHandshakeToken(AcceptHandshakeDto request)
        {
            logger.LogInformation($"User: {request.Username} accepts handshake with id {request.HandshakeId}");
            handshakeService.AcceptHandshake(request.Username, request.HandshakeId);
        }
    }
}
