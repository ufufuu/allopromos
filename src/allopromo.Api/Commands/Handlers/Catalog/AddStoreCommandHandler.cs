using allopromo.Api.Commands.Model.Catalog;
using allopromo.Api.DTOs;
using MediatR;

//using Mediator;
using System.Threading;
using System.Threading.Tasks;
using allopromo.Core.Interfaces;
using allopromo.Core.Entities;
//using Mediator.Net.Contracts;
//using Mediator.Net.Context;

namespace allopromo.Api.Commands.Handlers.Catalog
{
    public class AddStoreCommandHandler : IRequestHandler<AddStoreCommand, CreateStoreDto>
    {
        private readonly ICatalogService _catalogService;
        private readonly IStoreService _storeService;
        private readonly AutoMapper.IMapper _mapper;
        public AddStoreCommandHandler(
            ICatalogService catalogService,
            IStoreService storeService,
            AutoMapper.IMapper mapper )
        {
            _catalogService = catalogService;
            _storeService = storeService;
            _mapper = mapper;
        }
        public async Task<CreateStoreDto> Handle(AddStoreCommand request, 
            CancellationToken cancellationToken)
        {
            var store = _mapper.Map<Store>(request.Model);
            _storeService.CreateStoreAsync(store, "", "", "");
            return request.Model;
        }
        /*
        public Task<CreateStoreDto> Handle(IReceiveContext<AddStoreCommand> context, 
            CancellationToken cancellationToken)
        {
            var tttr= context.
            throw new System.NotImplementedException();
        }
        */
    }
}