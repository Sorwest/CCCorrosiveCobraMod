using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;
public class CobraCardColorlessAbsorbArtifact : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("AbsorbArtifact", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = Deck.colorless,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B],
                dontOffer = ModEntry.Instance.NoExtraCards,
                unreleased = ModEntry.Instance.NoExtraCards
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "AbsorbArtifact", "name"]).Localize
        });
    }
    public override string Name() => "Absorb Artifact";

    public string GetRandomArtifact(State state)
    {
        var random1 = new Rand();
        List<string> artifactList1 = new List<string>();
        string randomArtifact1 = "";
        if (state.route is Combat)
        {
            foreach (Artifact currentartifact in state.artifacts)
            {
                if (!(currentartifact.GetMeta().unremovable))
                    artifactList1.Add(currentartifact.Key());
            }
            int index = random1.NextInt() % (artifactList1.Count);
            if (index < 0)
                return randomArtifact1;
            if (artifactList1.Count > 0)
                randomArtifact1 = artifactList1[index];
        }
        return randomArtifact1;
    }
    public override CardData GetData(State state)
    {
        CardData result = new CardData();
        result.description = ModEntry.Instance.Localizations.Localize(["card", "AbsorbArtifact", "description"]);
        switch (upgrade)
        {
            case Upgrade.None:
                result.cost = 3;
                result.singleUse = true;
                break;
            case Upgrade.A:
                result.cost = 2;
                result.singleUse = true;
                break;
            case Upgrade.B:
                result.cost = 5;
                result.exhaust = true;
                break;
        }
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        var result = new List<CardAction>();
        List<CardAction> cardActionList1 = new List<CardAction>();
        ALoseArtifact aaloseArtifact1 = new ALoseArtifact();
        aaloseArtifact1.artifactType = GetRandomArtifact(s);
        cardActionList1.Add(aaloseArtifact1);
        AHeal aaheal1 = new AHeal();
        aaheal1.healAmount = 10;
        aaheal1.targetPlayer = true;
        aaheal1.canRunAfterKill = true;
        cardActionList1.Add(aaheal1);
        result = cardActionList1;
        return result;
    }
}
