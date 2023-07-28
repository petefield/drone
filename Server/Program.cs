using blazor.signalr.Server;
using Drone;
using SignalRChat.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
     {
         options.AddPolicy("AllowAll",
             builder =>
             {
                 builder
                 .AllowAnyOrigin() 
                 .AllowAnyMethod()
                 .AllowAnyHeader();
             });
     });

builder.Services.AddSingleton<IDrone, Drone.Drone>();
builder.Services.AddSingleton<IXboxController, XboxController>();
builder.Services.AddSingleton<ISignalRController, SignalRController>();
builder.Services.AddSingleton<ISignalRBridge,SignalRBridge>();
builder.Services.AddSingleton<IDroneController, DroneController> ();

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

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapHub<MessageHub>("/messagehub");
app.MapControllers();
app.MapFallbackToFile("/index.html");
app.Services.GetRequiredService<IXboxController>().Start();
app.Services.GetRequiredService<IDroneController>().Start();
app.Run();
