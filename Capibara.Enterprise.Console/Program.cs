using Capibara.Enterprise.Console;
using Capibara.Enterprise.Core;
using Capibara.Enterprise.Core.API.Hotel;
using Capibara.Enterprise.Networking;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();
builder.Services
    .AddLogging()
    .AddConsole()
    .AddCore()
    .AddNetworking(builder.Configuration)
    ;


var host = builder.Build();
var hotel = host.Services.GetRequiredService<IHabboHotel>();
await hotel.StartAsync(new CancellationToken());
await host.RunAsync();