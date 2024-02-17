using HotChocolate.Resolvers;
using HotChocolate.Types;
using System.Threading.Tasks;
using System;

public record Payload(string? Error);
public class DomainException : Exception
{
    public DomainException() { }

    public DomainException(string? message) : base(message) { }

    public DomainException(string? message, Exception? innerException) : base(message, innerException) { }
}

public class DomainExceptionMiddleware
{
    private readonly FieldDelegate _next;

    public DomainExceptionMiddleware(FieldDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(IMiddlewareContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DomainException exception) when (SetResult(context, exception.Message)) { }
    }

    private bool SetResult(IMiddlewareContext context, string error)
    {
        Type type = context.Selection.Field.Type.NamedType().ToRuntimeType();

        if (type.IsSubclassOf(typeof(Payload)))
        {
            context.Result = (Payload)Activator.CreateInstance(type, null, error)!;

            return true;
        }

        return false;
    }
}