﻿using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using MediatR;

namespace GreenMarket.Features.Commands.ProductCategoryCommands.ProductCategoryCommandRequest;

public readonly record struct UpdateProductCategoryRequest(
    int Id,
    ProductCategoryBaseInfo ProductCategoryBaseInfo) : IRequest<BaseResult>;