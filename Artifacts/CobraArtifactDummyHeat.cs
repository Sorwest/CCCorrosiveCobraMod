using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrosiveCobra.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Unreleased }, unremovable = true)]
    public class CobraArtifactDummyHeat : Artifact
    {
        public override string Name() => "COBRA MISC OVERHEAT";
        public int overheatTrigger;
        public override int? GetDisplayNumber(State s)
        {
            overheatTrigger = s.ship.heatTrigger;
            return overheatTrigger;
        }
        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTText("CURRENT OVERHEAT TRIGGER : " + overheatTrigger),
        };
    }
}
