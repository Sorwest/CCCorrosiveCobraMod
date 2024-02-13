using Nickel;
using System.Collections.Generic;
using System;

namespace Sorwest.CorrosiveCobra;
public interface IDraculaApi
{
    IDeckEntry DraculaDeck { get; }

    void RegisterBloodTapOptionProvider(Status status, Func<State, Combat, Status, List<CardAction>> provider);
}