using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Queries
{
    public class GetAllProductBrandQuery : IRequest<IEnumerable<BrandResponse>>
    {

    }
    public class GetAllProductBrandQueryHandler : IRequestHandler<GetAllProductBrandQuery, IEnumerable<BrandResponse>>
    {
        private readonly IMapper _mapper;

        private readonly IBrandRepository _brandRepository;

        public GetAllProductBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public async Task<IEnumerable<BrandResponse>> Handle(GetAllProductBrandQuery request, CancellationToken cancellationToken)
        {
            var result = await _brandRepository.GetProductBrands();
            return _mapper.Map<IEnumerable<BrandResponse>>(result);
        }
    }
}
