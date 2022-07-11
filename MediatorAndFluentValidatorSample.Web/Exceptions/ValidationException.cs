using FluentValidation.Results;

namespace MediatrAndFluentValidationSample.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
        : base("Validation error")
    {
        Failures = new Dictionary<string, string[]>();
    }

    public ValidationException(List<ValidationFailure> failures)
        : base("Validation error")
    {
        Failures = failures
            .GroupBy(f => f.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g
                    .Select(f => f.ErrorMessage)
                    .ToArray());
    }

    public Dictionary<string, string[]> Failures { get; }

    public override string ToString()
    {
        var message = string.Join(
            " | ",
            Failures
                .Select(f =>
                    $"{f.Key}: {string.Concat(f.Value.Select(v => $"* {v}"))}"));

        return $"{message} {base.ToString()}";
    }
}
