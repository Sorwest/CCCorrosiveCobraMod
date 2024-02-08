using Nickel;

namespace Sorwest.CorrosiveCobra;

internal sealed class DialogueManager
{
    public DialogueManager(IModHelper helper)
    {
        CombatDialogue.Inject();
        EventDialogue.Inject();
        CrossModDialogue.Inject(helper);
    }
}