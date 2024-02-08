using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class SlimeIsaacArtifact : Artifact, IModdedArtifact
{
	public static void Register(IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("SlimeIsaacArtifact", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
				pools = [ArtifactPool.Common]
			},
			Sprite = ModEntry.Instance.Sprites["SlimeIsaacArtifactSprite"].Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeIsaacArtifact", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeIsaacArtifact", "description"]).Localize
		});
		ModEntry.Instance.DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeIsaacArtifact), new[] { ModEntry.Instance.SlimeDeck.Deck, Deck.goat });
	}
	public int counter;
	public int TRIGGER = 5;
	public override void OnReceiveArtifact(State state)
	{
		counter = 0;
		return;
	}
	public override int? GetDisplayNumber(State s)
	{
		if (counter > 0 && counter < TRIGGER)
			return counter;
		return null;
	}
	public override Spr GetSprite()
	{
		Spr sprite = new Spr();
		if (counter < TRIGGER)
			sprite = ModEntry.Instance.Sprites["SlimeIsaacArtifactSprite"].Sprite;
		else
			sprite = ModEntry.Instance.Sprites["SlimeIsaacArtifactSprite_Off"].Sprite;
		return sprite;
	}
	public override void OnCombatStart(State state, Combat combat)
	{
		CobraCardSlimeIsaacDuo duoCard = new()
		{
			temporaryOverride = true,
		};
		AAddCard aAddCard1 = new()
		{
			amount = 1,
			card = duoCard,
			destination = CardDestination.Hand,
		};
		combat.QueueImmediate(aAddCard1);
		Pulse();
	}
	public override void OnTurnStart(State state, Combat combat)
	{
		if (combat.turn <= TRIGGER)
			counter += 1;
		if (counter == TRIGGER)
		{
			counter += 1;
			AStatus aStatus1 = new AStatus()
			{
				status = Status.droneShift,
				statusAmount = 5,
				targetPlayer = true,
			};
			combat.QueueImmediate(aStatus1);
			this.Pulse();
		}
	}
	public override void OnCombatEnd(State state)
	{
		counter = 0;
	}
	public override List<Tooltip>? GetExtraTooltips()
	{
		var tooltips = new List<Tooltip>()
		{
			new TTCard()
			{
				card = new CobraCardSlimeIsaacDuo()
			}
		};
		return tooltips;
	}
}