using FluentValidation;
using MediatR;
using MediatrAndFluentValidationSample;
using MediatrAndFluentValidationSample.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<DbContext>();
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();