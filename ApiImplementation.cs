using CobaltCoreModding.Definitions.ExternalItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorwest.CorrosiveCobra;
public sealed class ApiImplementation : ICorrosiveCobraApi
{
	private static Manifest Instance => Manifest.Instance;
	public ExternalDeck CobraDeck
		=> Manifest.CobraDeck!;
	public ExternalDeck CobraShipDeck
		=> Manifest.CobraShipDeck!;
	public ExternalStatus EvolveStatus
		=> Manifest.EvolveStatus!;
	public ExternalStatus HeatOutbreakStatus
		=> Manifest.HeatOutbreakStatus!;
	public ExternalStatus HeatControlStatus
		=> Manifest.HeatControlStatus!;
	public ExternalGlossary AEvolveStatus_Glossary
		=> Manifest.AEvolveStatus_Glossary!;
}