using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Replica.Application;
using Replica.Infrastructure;
using Replica.Infrastructure.Context;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddAuthorization()
    .AddRouting(x => x.LowercaseUrls = true)
    .AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Replica API",
        Description = "API of the lounge bar control system",
        Contact = new OpenApiContact
        {
            Name = "Roman Tymoshchuk",
            Email = "roman.tymoshchuk@oa.edu.ua"
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.\n\nExample: 'Bearer {token}'",
        Name = "Authorization",
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");

app.UseSwagger()
   .UseSwaggerUI(options =>
   {
       options.SwaggerEndpoint("/swagger/v1/swagger.json", "Replica API v1");
   });

app.UseHttpsRedirection()
   .UseBlazorFrameworkFiles()
   .UseStaticFiles()
   .UseRouting()
   .UseAuthorization()
   .UseAuthentication();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
