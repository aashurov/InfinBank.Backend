﻿using MediatR;
using Serilog;

namespace InfinBank.Application.Common.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest
    : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        Log.Information("NotesRequest: {Name} {@Request}", requestName, request);
        var response = await next();
        return response;
    }
}