
namespace Sorwest.CorrosiveCobra;
public interface ISogginsApi
{
}
public interface ISmugHook
{
    void OnCardBotchedBySmug(State state, Combat combat, Card card) { }
    void OnCardDoubledBySmug(State state, Combat combat, Card card) { }
}