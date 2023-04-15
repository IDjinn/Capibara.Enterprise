using Capibara.Enterprise.Core.API.Hotel.Common;
using Capibara.Enterprise.Core.API.Hotel.Common.Enums;

namespace Capibara.Enterprise.Core.API.Hotel.Users;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed record HabboProfileInfo(
    HabboId Id,
    string Nickname,
    Gender Gender,
    Figure Figure,
    string Motto,
    DateTime RegisteredAt
);