using CobaltCoreModding.Definitions.ExternalItems;
using CobaltCoreModding.Definitions.ModContactPoints;
using CobaltCoreModding.Definitions.ModManifests;
using CorrosiveCobra.Cards;

namespace CorrosiveCobra
{
    public partial class Manifest :
        ICharacterManifest,
        IAnimationManifest
    {
        void ICharacterManifest.LoadManifest(ICharacterRegistry registry)
        {
            {
                CorrosiveCobra_Character = new ExternalCharacter("CorrosiveCobra.Character.DizzySlime",
                CobraDeck ?? throw new Exception("Missing Deck"),
                CorrosiveCobra_CharacterPanelFrame_Sprite ?? throw new Exception("Missing Portrait"),
                new Type[]
                    {
                        typeof(CobraCardHeatedEvade),
                        typeof(CobraCardHurriedDefense)
                    },
                new Type[0],
                CorrosiveCobra_CharacterDefaultAnimation ?? throw new Exception("missing default animation"),
                CorrosiveCobra_CharacterMiniAnimation ?? throw new Exception("missing mini animation"));
                CorrosiveCobra_Character.AddNameLocalisation("Dizzy?");
                CorrosiveCobra_Character.AddDescLocalisation("<c=goat>DIZZY?</c>\nA friend from another timeline. His cards play with <c=keyword>heat and corrode</c>, for better, or <c=hurt>worse</c>. His jokes are still funny.", "en");
                registry.RegisterCharacter(CorrosiveCobra_Character);
            }
        }
        void IAnimationManifest.LoadManifest(IAnimationRegistry registry)
        {
            {
                CorrosiveCobra_CharacterDefaultAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_CharacterDefaultAnimation",
                CobraDeck ?? throw new Exception("missing deck"),
                "neutral", false,
                new ExternalSprite[] { CorrosiveCobra_CharacterPortrait_Sprite ?? throw new Exception("missing portrait") });

                registry.RegisterAnimation(CorrosiveCobra_CharacterDefaultAnimation);
            }
            {
                CorrosiveCobra_CharacterMiniAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_CharacterMiniAnimation",
                CobraDeck ?? throw new Exception("missing deck"),
                "mini", false,
                new ExternalSprite[] { CorrosiveCobra_CharacterMini_Sprite ?? throw new Exception("missing mini") });

                registry.RegisterAnimation(CorrosiveCobra_CharacterMiniAnimation);
            }
            {
                CorrosiveCobra_CharacterGameoverAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_CharacterGameoverAnimation",
                CobraDeck ?? throw new Exception("missing deck"),
                "gameover", false,
                new ExternalSprite[] { CorrosiveCobra_CharacterGameover_Sprite ?? throw new Exception("missing portrait") });

                registry.RegisterAnimation(CorrosiveCobra_CharacterGameoverAnimation);
            }
            {
                CorrosiveCobra_CharacterSquintAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_CharacterSquintAnimation",
                CobraDeck ?? throw new Exception("missing deck"),
                "squint", false,
                new ExternalSprite[] { CorrosiveCobra_CharacterSquint_Sprite ?? throw new Exception("missing portrait") });

                registry.RegisterAnimation(CorrosiveCobra_CharacterSquintAnimation);
            }
        }
    }
}
