
namespace Sorwest.CorrosiveCobra;

internal sealed class HeatControlManager : IStatusLogicHook
{
    private static ModEntry Instance => ModEntry.Instance;
    public HeatControlManager()
    {
        Instance.KokoroApi.RegisterStatusLogicHook(this, 0);
    }
    public void OnStatusTurnTrigger(State state, Combat combat, StatusTurnTriggerTiming timing, Ship ship, Status status, int oldAmount, int newAmount)
    {
        if (status != Instance.HeatControlStatus.Status)
            return;
        if (timing != StatusTurnTriggerTiming.TurnEnd)
            return;
        if (oldAmount <= 0)
            return;
        combat.Queue(new AIncreaseHeatTrigger()
        {
            targetPlayer = ship.isPlayerShip,
            amount = 1
        });
        ship.PulseStatus(Instance.HeatControlStatus.Status);
    }
    public bool HandleStatusTurnAutoStep(State state, Combat combat, StatusTurnTriggerTiming timing, Ship ship, Status status, ref int amount, ref StatusTurnAutoStepSetStrategy setStrategy)
    {
        if (status != Instance.HeatControlStatus.Status)
            return false;
        if (timing != StatusTurnTriggerTiming.TurnEnd)
            return false;
        if (amount > 0)
            amount --;
        return false;
    }
}
public class AIncreaseHeatTrigger : CardAction
{
    public bool targetPlayer;
    public int amount;
    public override void Begin(G g, State s, Combat c)
    {
        Ship ship = targetPlayer ? s.ship : c.otherShip;
        ship.heatTrigger += amount;
    }
}