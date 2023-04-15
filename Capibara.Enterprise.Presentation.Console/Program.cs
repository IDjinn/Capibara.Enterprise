using Capibara.Enterprise.Core;
using Capibara.Enterprise.Core.API.Hotel;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;
using Capibara.Enterprise.Infrastructure;
using Capibara.Enterprise.Networking;
using Capibara.Enterprise.Presentation.Console;
using Capibara.Enterprise.Presentation.RawSockets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();
builder.Configuration
    .ConfigureConsole();
builder.Services
    .AddLogging()
    .AddConsole()
    .AddRawSockets()
    .AddCore()
    .AddInfrastructure(builder.Configuration)
    .AddNetworking(builder.Configuration)
    ;


var host = builder.Build();
var hotel = host.Services.GetRequiredService<IHabboHotel>();
await hotel.StartAsync(new CancellationToken());
var player = new Coordinate(1, 2, 0f);
var other = player with { Z = 0453453.4f };
await host.RunAsync();