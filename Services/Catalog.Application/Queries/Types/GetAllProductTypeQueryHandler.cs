using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Queries.Types
{
    public class GetAllProductTypeQuery : IRequest<IEnumerable<TypeResponse>>
    {

    }
    public class GetAllProductTypeQueryHandler : IRequestHandler<GetAllProductTypeQuery, IEnumerable<TypeResponse>>

    {
        private readonly IMapper _mapper;

        private readonly ITypeRepository _typeRepository;

        public GetAllProductTypeQueryHandler(IMapper mapper, ITypeRepository typeRepository)
        {
            _mapper = mapper;
            _typeRepository = typeRepository;
        }
        public async Task<IEnumerable<TypeResponse>> Handle(GetAllProductTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _typeRepository.GetProductTypes();
            return _mapper.Map<IEnumerable<TypeResponse>>(result);
        }

    }
}
