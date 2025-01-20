using WebApi.Extensions;

//using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureApplication();

var app = builder.Build();

app.ConfigurePipeline();

app.Run();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddApplicationServices(builder);



//var app = builder.Build();

//app.MapApplicationEndpoints();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();


//app.UseAuthentication();
//app.UseAuthorization();

//app.Run();
