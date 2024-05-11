using DatumIT_Blog.Presentation.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureMvc();

builder.Services.ConfigureCors();

builder.Services.ConfigureSwagger();

builder.Services.ConfigureDependencies();

builder.Services.ConfigureDependencies(nameof(DatumIT_Blog));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // Code for Development here.
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "my-API v1");
        options.EnableTryItOutByDefault();
    });

    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/DatumIT_Blog")
        {
            context.Response.Redirect("/swagger/index.html");
            return;
        }

        await next();
    });
}
else if (app.Environment.IsStaging())
{
    // Code for Homologation here.
}
else if (app.Environment.IsProduction())
{
    // Code for Production here.

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();