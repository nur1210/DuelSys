using System.Net;
using AspNetCoreHero.ToastNotification;
using DAL;
using Logic.Interfaces;
using Logic.Services;
using Logic.Validator;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = new PathString("/Login");
        options.AccessDeniedPath = new PathString("/Index");
    });

builder.Services.AddNotyf
    (config =>
    {
        config.DurationInSeconds = 10;
        config.IsDismissable = true;
        config.Position = NotyfPosition.BottomRight;
    });


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<Validation>();
builder.Services.AddSingleton<SportService>();
builder.Services.AddSingleton<TournamentService>();
builder.Services.AddSingleton<TournamentSystemService>();
builder.Services.AddSingleton<MatchService>();
builder.Services.AddSingleton<ResultService>();


builder.Services.AddSingleton<IUserDB, UserDB>();
builder.Services.AddSingleton<ISportDB, SportDB>();
builder.Services.AddSingleton<ITournamentDB, TournamentDB>();
builder.Services.AddSingleton<ITournamentSystemDB, TournamentSystemDB>();
builder.Services.AddSingleton<IMatchDB, MatchDB>();
builder.Services.AddSingleton<IResultDB, ResultDB>();


var app = builder.Build();

 if (app.Environment.IsDevelopment())
 {
     app.UseDeveloperExceptionPage();
 }
 else
 {
     app.UseExceptionHandler(errorApp =>
     {
         errorApp.Run(async context =>
         {
             context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;;
             context.Response.ContentType = "text/html";

             await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
             await context.Response.WriteAsync("ERROR!<br><br>\r\n");

             var exceptionHandlerPathFeature =
                 context.Features.Get<IExceptionHandlerPathFeature>();

             if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
             {
                 await context.Response.WriteAsync(
                     "File error thrown!<br><br>\r\n");
             }

             await context.Response.WriteAsync(
                 "<a href=\"/\">Home</a><br>\r\n");
             await context.Response.WriteAsync("</body></html>\r\n");
             await context.Response.WriteAsync(new string(' ', 512));
         });
     });
     app.UseHsts();
 }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();
