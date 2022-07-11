namespace MediatrAndFluentValidationSample.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class CacheDurationAttribute : Attribute
{
    public CacheDurationAttribute(double hours)
    {
        Hours = hours;
    }

    public double Hours { get; set; }

}