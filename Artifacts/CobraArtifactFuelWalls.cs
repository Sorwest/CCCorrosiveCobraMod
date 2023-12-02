using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorrosiveCobra.Cards;

namespace CorrosiveCobra.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class CobraArtifactFuelWalls : Artifact
    {
        public override string Name() => "FUEL WALLS";
        public override void OnReceiveArtifact(State state)
        {
            state.GetCurrentQueue().Add((CardAction)new AAddCard()
            {
                amount = 3,
                card = (Card)new CobraCardFuelWall()
            });
        }
        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTCard()
            {
                card = (Card) new CobraCardFuelWall()
            },
        };
    }
}
