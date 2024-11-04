using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Stock.API.Configurations.Swagger;
using Stock.API.Filters;
using Stock.CrossCutting.Configurations;
using Stock.CrossCutting.IoC;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(config =>
{
    config.Filters.Add(typeof(GlobalExceptionFilter));
}).AddJsonOptions(x =>
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();

builder.Services.AddIoC(builder.Configuration);

builder.Services.AddDatabaseContext(builder.Configuration);

builder.Services.AddApiFluentValidations();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerPage(app.Services.GetService<IApiVersionDescriptionProvider>());
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
