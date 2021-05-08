using AutoMapper;
using Philcosa.Application.Features.Products.Commands.CreateProduct;
using Philcosa.Application.Features.Products.Queries.GetAllProducts;
using Philcosa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Philcosa.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
