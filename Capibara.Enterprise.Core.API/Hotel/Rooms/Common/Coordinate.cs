namespace Capibara.Enterprise.Core.API.Hotel.Rooms.Common;

public readonly record struct Coordinate(uint X, uint Y, double Z)
{
    public ChunkId ChunkId
    {
        get
        {
            var chunkX = X >> 10; // 2048 chunk size
            var chunkY = Y >> 10;
            var chunkIndex = chunkX + chunkY * 14_062_500_000_000U;
            return new ChunkId(chunkX, chunkY, chunkIndex);
        }
    }
}