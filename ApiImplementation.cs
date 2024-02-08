using Nickel;

namespace Sorwest.CorrosiveCobra;

public sealed class ApiImplementation : IApi
{
    public IDeckEntry SlimeDeck
        => ModEntry.Instance.SlimeDeck;
    public IDeckEntry CobraDeck
        => ModEntry.Instance.CobraDeck;

    public Deck SlimeDirectDeck
        => ModEntry.Instance.SlimeDeck.Deck;
    public Deck CobraDirectDeck
        => ModEntry.Instance.CobraDeck.Deck;

    public IStatusEntry EvolveStatus
        => ModEntry.Instance.EvolveStatus;
    public IStatusEntry HeatControlStatus
        => ModEntry.Instance.HeatControlStatus;
    public IStatusEntry HeatOutbreakStatus
        => ModEntry.Instance.HeatOutbreakStatus;
    public IStatusEntry CrystalTapStatus
        => ModEntry.Instance.CrystalTapStatus;

    public Status EvolveDirectStatus
        => ModEntry.Instance.EvolveStatus.Status;
    public Status HeatControlDirectStatus 
        => ModEntry.Instance.HeatControlStatus.Status;
    public Status HeatOutbreakDirectStatus 
        => ModEntry.Instance.HeatOutbreakStatus.Status;
    public Status CrystalTapDirectStatus 
        => ModEntry.Instance.CrystalTapStatus.Status;
}
