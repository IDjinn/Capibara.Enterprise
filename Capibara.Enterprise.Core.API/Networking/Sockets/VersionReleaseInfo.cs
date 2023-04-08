namespace Capibara.Enterprise.Core.API.Networking.Sockets;

public readonly record struct VersionReleaseInfo(
    string Production,
    string Type,
    int Platform,
    int Category
);