using System.ComponentModel;
using System.Reflection;
using AppKi.Business.Features.References.Models;
using AppKi.Commons.Enums;
using AppKi.Commons.Models;
using Mediator;

namespace AppKi.Business.Features.References;

public class GetEnumReferenceTypeQuery : IRequest<ResultList<ReferenceTypeDto>>
{
    public string Type { get; }

    public GetEnumReferenceTypeQuery(string type)
    {
        Type = type;
    }
}

public class GetEnumReferenceTypeQueryHandler : IRequestHandler<GetEnumReferenceTypeQuery, ResultList<ReferenceTypeDto>>
{
    private static readonly Dictionary<Type, ReferenceTypeDto[]> Cache = new();

    private static readonly Dictionary<string, Type> Enums = new(StringComparer.OrdinalIgnoreCase)
    {
        {nameof(ExchangeProvider), typeof(ExchangeProvider)},
        {nameof(TimeRange), typeof(TimeRange)},
    };

    public ValueTask<ResultList<ReferenceTypeDto>> Handle(
        GetEnumReferenceTypeQuery request, CancellationToken cancellationToken)
    {
        return ValueTask.FromResult(Enums.TryGetValue(request?.Type?.Trim() ?? string.Empty, out var enumType)
            ? ResultList<ReferenceTypeDto>.Ok(GetValues(enumType))
            : ResultList<ReferenceTypeDto>.NotFound($"'{request?.Type}' not found"));
    }

    private static IEnumerable<ReferenceTypeDto> GetValues(Type enumType)
    {
        if (!enumType.IsEnum)
            return Enumerable.Empty<ReferenceTypeDto>();

        if (Cache.TryGetValue(enumType, out var result))
            return result;

        var values = Enum.GetValues(enumType);
        var items = (from object value in values
                let memberInfo = enumType.GetMember(value.ToString() ?? string.Empty)
                let attributes = memberInfo.First().GetCustomAttribute<DescriptionAttribute>()
                select new ReferenceTypeDto((int) value, attributes is { } ? attributes.Description : value.ToString()))
            .ToArray();

        Cache.TryAdd(enumType, items);
        return items;
    }
}