using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddAsync(MessageSendModel message, string userEmail)
        {
            Message newMessage = new()
            {
                CreateTime = DateTime.Now,
                Title = message.Title,
                MessageText = message.MessageText,
                Sender = userEmail,
                Receiver = message.Receiver
            };
            await unitOfWork.MessageRepository.AddAsync(newMessage);
            await unitOfWork.SaveAsync();
        }

        public IEnumerable<MessageModel> GetAll(string userEmail)
        {
            var result = unitOfWork.MessageRepository.FindAll().Where(x => x.Receiver == userEmail);
            return mapper.Map<IEnumerable<MessageModel>>(result);
        }

        public async Task<MessageModel> GetByIdAsync(int id)
        {
            var result = await unitOfWork.MessageRepository.GetByIdAsync(id);
            return mapper.Map<MessageModel>(result);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await unitOfWork.MessageRepository.DeleteByIdAsync(id);
        }
    }
}
