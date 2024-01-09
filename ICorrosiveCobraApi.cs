using CobaltCoreModding.Definitions.ExternalItems;

namespace Sorwest.CorrosiveCobra;

internal interface ICorrosiveCobraApi
{
    ExternalDeck CobraDeck { get; }
    ExternalDeck CobraShipDeck { get; }
    ExternalStatus EvolveStatus { get; }
    ExternalStatus HeatOutbreakStatus { get; }
    ExternalStatus HeatControlStatus { get; }
    ExternalGlossary AEvolveStatus_Glossary { get; }
}
