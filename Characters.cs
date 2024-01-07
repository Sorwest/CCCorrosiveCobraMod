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
                new Type[]
                    {
                        //typeof(CobraArtifactDummyHeat)
                    },
                CorrosiveCobra_Character_TalkNeutralAnimation ?? throw new Exception("missing default animation"),
                CorrosiveCobra_Character_MiniAnimation ?? throw new Exception("missing mini animation"));
                CorrosiveCobra_Character.AddNameLocalisation($"<c={CobraColor}>Dizzy?</c>", "en");
                CorrosiveCobra_Character.AddDescLocalisation($"<c={CobraColor}>Dizzy?</c>\nA friend from another timeline. His cards play with <c=keyword>heat and corrode</c>, for better, or <c=hurt>worse</c>. His jokes are still funny.", "en");
                registry.RegisterCharacter(CorrosiveCobra_Character);
            }
        }
        void IAnimationManifest.LoadManifest(IAnimationRegistry registry)
        {
            {
                CorrosiveCobra_Character_DefaultAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_DefaultAnimation",
                    CobraDeck ?? throw new Exception("missing deck"),
                    "default", false,
                    new ExternalSprite[] { CorrosiveCobra_CharacterPortrait_Sprite ?? throw new Exception("missing portrait") });

                registry.RegisterAnimation(CorrosiveCobra_Character_DefaultAnimation);
            }
            {
                CorrosiveCobra_Character_MiniAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_MiniAnimation",
                    CobraDeck ?? throw new Exception("missing deck"),
                    "mini", false,
                    new ExternalSprite[] { CorrosiveCobra_CharacterMini_Sprite ?? throw new Exception("missing mini") });

                registry.RegisterAnimation(CorrosiveCobra_Character_MiniAnimation);
            }
            {
                CorrosiveCobra_Character_GameoverAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_GameoverAnimation",
                CobraDeck ?? throw new Exception("missing deck"),
                "gameover", false,
                new ExternalSprite[] { CorrosiveCobra_CharacterGameover_Sprite ?? throw new Exception("missing portrait") });

                registry.RegisterAnimation(CorrosiveCobra_Character_GameoverAnimation);
            }
            {
                CorrosiveCobra_Character_TalkSquintAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_TalkSquintAnimation",
                    CobraDeck,
                    "squint",
                    false,
                    TalkSquintSprites);
                registry.RegisterAnimation(CorrosiveCobra_Character_TalkSquintAnimation);
            }
            {
                CorrosiveCobra_Character_TalkLaughAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_TalkTalkLaughAnimation",
                    CobraDeck,
                    "laugh",
                    false,
                    TalkLaughSprites);
                registry.RegisterAnimation(CorrosiveCobra_Character_TalkLaughAnimation);
            }
            {
                CorrosiveCobra_Character_TalkNeutralAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_TalkNeutralAnimation",
                    CobraDeck,
                    "neutral",
                    false,
                    TalkNeutralSprites);
                registry.RegisterAnimation(CorrosiveCobra_Character_TalkNeutralAnimation);
            }
            {
                CorrosiveCobra_Character_TalkSadAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_TalkSadAnimation",
                    CobraDeck,
                    "sad",
                    false,
                    TalkSadSprites);
                registry.RegisterAnimation(CorrosiveCobra_Character_TalkSadAnimation);
            }
            {
                CorrosiveCobra_Character_TalkMadAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_TalkMadAnimation",
                    CobraDeck,
                    "mad",
                    false,
                    TalkMadSprites);
                registry.RegisterAnimation(CorrosiveCobra_Character_TalkMadAnimation);
            }
            {
                CorrosiveCobra_Character_TalkDarkAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_TalkDarkAnimation",
                    CobraDeck,
                    "dark",
                    false,
                    TalkDarkSprites);
                registry.RegisterAnimation(CorrosiveCobra_Character_TalkDarkAnimation);
            }
            {
                CorrosiveCobra_Character_TalkPhoneAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_TalkPhoneAnimation",
                    CobraDeck,
                    "phone",
                    false,
                    TalkPhoneSprites);
                registry.RegisterAnimation(CorrosiveCobra_Character_TalkPhoneAnimation);
            }
            {
                CorrosiveCobra_Character_TalkNervousAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_TalkNervousAnimation",
                    CobraDeck,
                    "nervous",
                    false,
                    TalkNervousSprites);
                registry.RegisterAnimation(CorrosiveCobra_Character_TalkNervousAnimation);
            }
        }
    }
}
