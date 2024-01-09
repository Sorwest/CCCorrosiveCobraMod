using FMOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorwest.CorrosiveCobra.Actions;
public class ACobraField : CardAction
{
    public override void Begin(G g, State s, Combat c)
    {
        foreach (StuffBase stuffBase in c.stuff.Values.ToList<StuffBase>())
        {
            c.stuff.Remove(stuffBase.x);
            Missile missile1 = new Missile();
            if (s.ship.Get(Status.backwardsMissiles) > 0)
                missile1.targetPlayer = true;
            else
                missile1.targetPlayer = false;
            missile1.missileType = MissileType.corrode;
            missile1.x = stuffBase.x;
            missile1.xLerped = stuffBase.xLerped;
            missile1.bubbleShield = stuffBase.bubbleShield;
            missile1.age = stuffBase.age;
            Missile missile2 = missile1;
            c.stuff[stuffBase.x] = (StuffBase)missile2;
        }
        Audio.Play(new GUID?(FSPRO.Event.Status_PowerDown));
    }

    public override List<Tooltip> GetTooltips(State s)
    {
        if (s.route is Combat route)
        {
            foreach (StuffBase stuffBase in route.stuff.Values)
                stuffBase.hilight = 2;
        }
        return new List<Tooltip>()
    {
      (Tooltip) new TTGlossary(Manifest.ACobraField_Glossary?.Head ?? throw new Exception("Missing ACobraField_Glossary"), Array.Empty<object>())
    };
    }

    public override Icon? GetIcon(State s) => new Icon?(new Icon((Spr)Manifest.CobraFieldSprite!.Id!, new int?(), Colors.textMain));
}
