
namespace Sorwest.CorrosiveCobra;

internal sealed class HeatOutbreakManager : IStatusLogicHook
{
    public HeatOutbreakManager()
    {
        ModEntry.Instance.KokoroApi.RegisterStatusLogicHook(this, 0);
    }
    public void OnStatusTurnTrigger(State state, Combat combat, StatusTurnTriggerTiming timing, Ship ship, Status status, int oldAmount, int newAmount)
    {
        if (status != ModEntry.Instance.HeatOutbreakStatus.Status)
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