using allopromo.Api.DTOs;
using MediatR;

namespace allopromo.Api.Commands.Model.Catalog
{
    public class AddStoreCommand: IRequest<CreateStoreDto>
    {
        public CreateStoreDto Model { get; set; }
    }
}