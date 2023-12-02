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

        private static System.Drawing.Color CorrosiveCobra_Primary_Color = System.Drawing.Color.FromArgb(107, 255, 205);
        private static string CorrosiveCobra_CharacterColH = string.Format("<c={0:X2}{1:X2}{2:X2}>", (object)CorrosiveCobra_Primary_Color.R, (object)CorrosiveCobra_Primary_Color.G, (object)CorrosiveCobra_Primary_Color.B.ToString("X2"));
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
                CorrosiveCobra_Character_DefaultAnimation ?? throw new Exception("missing default animation"),
                CorrosiveCobra_Character_MiniAnimation ?? throw new Exception("missing mini animation"));
                CorrosiveCobra_Character.AddNameLocalisation(CorrosiveCobra_CharacterColH + "Dizzy?</c>",  "en");
                CorrosiveCobra_Character.AddDescLocalisation(CorrosiveCobra_CharacterColH + "DIZZY?</c>\nA friend from another timeline. His cards play with <c=keyword>heat and corrode</c>, for better, or <c=hurt>worse</c>. His jokes are still funny.", "en");
                registry.RegisterCharacter(CorrosiveCobra_Character);
            }
        }
        void IAnimationManifest.LoadManifest(IAnimationRegistry registry)
        {
            {
                CorrosiveCobra_Character_DefaultAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_DefaultAnimation",
                CobraDeck ?? throw new Exception("missing deck"),
                "neutral", false,
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
                CorrosiveCobra_Character_TalkSquintAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_TalkSquintAnimation", CobraDeck, "squint", false, TalkSquintSprites);
                registry.RegisterAnimation(CorrosiveCobra_Character_TalkSquintAnimation);
            }
            {
                CorrosiveCobra_Character_TalkLaughAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_TalkTalkLaughAnimation", CobraDeck, "talk_laugh", false, TalkLaughSprites);
                registry.RegisterAnimation(CorrosiveCobra_Character_TalkLaughAnimation);
            }
            {
                CorrosiveCobra_Character_TalkNeutralAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_TalkNeutralAnimation", CobraDeck, "talk_neutral", false, TalkNeutralSprites);
                registry.RegisterAnimation(CorrosiveCobra_Character_TalkNeutralAnimation);
            }
            {
                CorrosiveCobra_Character_TalkSadAnimation = new ExternalAnimation("CorrosiveCobra.Animation.CorrosiveCobra_Character_TalkSadAnimation", CobraDeck, "talk_sad", false, TalkSadSprites);
                registry.RegisterAnimation(CorrosiveCobra_Character_TalkSadAnimation);
            }
        }
    }
}
