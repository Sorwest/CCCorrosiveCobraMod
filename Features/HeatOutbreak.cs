
namespace Sorwest.CorrosiveCobra;

internal sealed class HeatOutbreakManager : IStatusLogicHook
{
    private static ModEntry Instance => ModEntry.Instance;
    public HeatOutbreakManager()
    {
        Instance.KokoroApi.RegisterStatusLogicHook(this, 0);
    }
    public void OnStatusTurnTrigger(State state, Combat combat, StatusTurnTriggerTiming timing, Ship ship, Status status, int oldAmount, int newAmount)
    {
        if (status != Instance.HeatOutbreakStatus.Status)
            return;
        if (timing != StatusTurnTriggerTiming.TurnEnd)
            return;
        if (oldAmount <= 0)
            return;
        if (ship.Get(Status.heat) > 0)
            combat.Queue(new AHurt()
            {
                hurtAmount = oldAmount * ship.Get(Status.heat),
                hurtShieldsFirst = true,
                targetPlayer = ship.isPlayerShip,
                statusPulse = status
            });
    }
}