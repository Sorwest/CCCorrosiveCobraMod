using Nickel;

namespace Sorwest.CorrosiveCobra;

public interface IApi
{
    IDeckEntry SlimeDeck { get; }
    IDeckEntry CobraDeck { get; }

    Deck SlimeDirectDeck { get; }
    Deck CobraDirectDeck { get; }

    IStatusEntry EvolveStatus { get; }
    IStatusEntry HeatControlStatus { get; }
    IStatusEntry HeatOutbreakStatus { get; }
    IStatusEntry CrystalTapStatus { get; }

    Status EvolveDirectStatus { get; }
    Status HeatControlDirectStatus { get; }
    Status HeatOutbreakDirectStatus { get; }
    Status CrystalTapDirectStatus { get; }
}
