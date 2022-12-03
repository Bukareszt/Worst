using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Backend.Package.Entities;
using Backend.Persistence;
using Backend.Console.Dto;

namespace Backend.Console.Services
{
    public class HandshakeService
    {
        private readonly ILogger<HandshakeService> logger;
        private readonly IUserRepository userRepository;
        private readonly IHandshakeRepository repository;

        public HandshakeService(IHandshakeRepository repository, IUserRepository userRepository, ILogger<HandshakeService> logger)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public Guid CreateHandshake(string username, string associatedContacts)
        {
            var giver = userRepository.GetUser(username);
            var id = Guid.NewGuid();

            logger.LogInformation($" handshake for user with ID: {giver.Id}");

            repository.CreateHandshake(new Handshake
            {
                Id = id,
                GiverId = giver.Id,
                AssociatedContacts = associatedContacts
            });


            return id;
        }

        public void AcceptHandshake(string username, Guid handshakeId)
        {
            var handshake = repository.GetHandshake(handshakeId);
            userRepository.AddContact(username, handshake.GiverId);
        }
    }
}
