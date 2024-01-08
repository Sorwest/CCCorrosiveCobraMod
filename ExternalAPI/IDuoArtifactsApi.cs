using CobaltCoreModding.Definitions.ExternalItems;

namespace Sorwest.CorrosiveCobra;
public interface IDuoArtifactsApi
{
    ExternalDeck DuoArtifactDeck { get; }

    void RegisterDuoArtifact(Type type, IEnumerable<Deck> combo);
    void RegisterDuoArtifact<TArtifact>(IEnumerable<Deck> combo) where TArtifact : Artifact;
    IReadOnlySet<Deck>? GetDuoArtifactOwnership(Artifact artifact);
}