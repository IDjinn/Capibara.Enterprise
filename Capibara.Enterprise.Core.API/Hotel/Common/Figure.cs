namespace Capibara.Enterprise.Core.API.Hotel.Common;

public record Figure(string FigureData)
{
    public override string ToString()
    {
        return FigureData;
    }
}