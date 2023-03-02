using Microsoft.EntityFrameworkCore;
using Replica.Application;
using Replica.Infrastructure;
using Replica.Infrastructure.Context;
using Replica.Server.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddAuthorization()
    .AddCustomAuthentication(builder.Configuration)
    .AddCustomSwagger()
    .AddRouting(x => x.LowercaseUrls = true)
    .AddControllers();

var connectionString = builder.Configuration.GetConnectionString("ReplicaDb");

builder.Services.AddDbContext<ReplicaDbContext>(options =>
options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Replica.Infrastructure")));

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
