using Microsoft.Extensions.Hosting;

namespace Capibara.Enterprise.Core.API.Hotel;

public interface IHotelService : IHostedService, IAsyncDisposable
{
}