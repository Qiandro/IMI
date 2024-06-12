using Imi.Project.Blazor.Data;
using Imi.Project.Blazor.Hubs;
using Imi.Project.Blazor.Interfaces;
using Imi.Project.Blazor.Services;
using System.ComponentModel.Design;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddTransient<IEventservice, Eventservice>();
//builder.Services.AddTransient<IGroupService, GroupSerivce>();
//builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<ILogbookManager, SignalRLogbookManager>();
builder.Services.AddScoped<HttpClient>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();



app.UseEndpoints(endpoints =>
{
    app.MapBlazorHub();
    app.MapHub<LogbookHub>("/logbookhub");
    app.MapFallbackToPage("/_Host");

});

app.Run();

