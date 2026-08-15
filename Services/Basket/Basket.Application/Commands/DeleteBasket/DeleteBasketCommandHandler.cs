using AutoMapper;
using Basket.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Application.Commands.DeleteBasket
{
    public class DeleteBasketCommand:IRequest<bool>
    {
        public string username {  get; set; }
        public DeleteBasketCommand(string username)
        {
            this.username= username;
        }
    }
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, bool>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public DeleteBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
                await _basketRepository.DeleteBasket(request.username);
                return true;
            
        }
    }
}
