namespace Capibara.Enterprise.Core.API.Networking.Sockets;

public class SocketSettings
{
    public const string SectionName = nameof(SocketSettings);

    public const int BUFFER_SIZE = 417792;
    public const int SKIP_BYTES_LENGTH = sizeof(int);
    public const int LENGTH_FIELD_SIZE = sizeof(int);

    public string Host { get; set; }
    public int Port { get; set; }
}