using CobaltCoreModding.Definitions;
using CobaltCoreModding.Definitions.ExternalItems;
using CobaltCoreModding.Definitions.ModContactPoints;
using CobaltCoreModding.Definitions.ModManifests;
using CorrosiveCobra.Artifacts;
using CorrosiveCobra.Cards;
using Microsoft.Extensions.Logging;

// Many thanks to parchmentengineer and theirs armada mod, check them out!
// https://github.com/parchmentEngineer/parchmentArmada/releases/
// So many thanks to EWanderer's selfless dedication to making the Cobalt Core modding community THRIVE!! Check Arin and EWanderer's collab project!
// https://github.com/Ewanderer/CCMod.JohannaTheTrucker/releases/

namespace CorrosiveCobra
{
    public partial class Manifest :
        ISpriteManifest,
        IManifest,
        IShipPartManifest,
        IShipManifest,
        ICharacterManifest,
        IAnimationManifest,
        IStartershipManifest,
        IArtifactManifest,
        ICardManifest,
        IDeckManifest,
        IStatusManifest,
        IGlossaryManifest,
        IStoryManifest
    {
        public string Name => "Sorwest.CorrosiveCobra";

        public static System.Drawing.Color CorrosiveCobra_Primary_Color = System.Drawing.Color.FromArgb(107, 255, 205);
        public static string CorrosiveCobra_CharacterColH = string.Format("<c={0:X2}{1:X2}{2:X2}>", (object)CorrosiveCobra_Primary_Color.R, (object)CorrosiveCobra_Primary_Color.G, (object)CorrosiveCobra_Primary_Color.B.ToString("X2"));
        public IEnumerable<DependencyEntry> Dependencies => new DependencyEntry[]
            {
            };
        public DirectoryInfo? ModRootFolder { get; set; }
        public ILogger? Logger { get; set; }
        public static ExternalShip? CorrosiveCobra_Main { get; private set; }
        public static ExternalStarterShip? CorrosiveCobra_StarterShip { get; private set; }
        public static ExternalDeck? CobraDeck { get; private set; }
        public static ExternalDeck? CobraShipDeck { get; private set; }

        //character art sprites
        public static ExternalCharacter? CorrosiveCobra_Character { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CharacterMini_Sprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CharacterPortrait_Sprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CharacterPanelFrame_Sprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CharacterGameover_Sprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CharacterSquint_Sprite { get; private set; }

        //character animation sprites
        public static ExternalAnimation? CorrosiveCobra_Character_DefaultAnimation { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_Character_MiniAnimation { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_Character_GameoverAnimation { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_Character_TalkLaughAnimation { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_Character_TalkNeutralAnimation { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_Character_TalkSquintAnimation { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_Character_TalkSadAnimation { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_Character_TalkMadAnimation { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_Character_TalkDarkAnimation { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_Character_TalkPanicAnimation { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_Character_TalkNervousAnimation { get; private set; }
        public static List<ExternalSprite> TalkLaughSprites { get; private set; } = new List<ExternalSprite>();
        public static List<ExternalSprite> TalkNeutralSprites { get; private set; } = new List<ExternalSprite>();
        public static List<ExternalSprite> TalkSquintSprites { get; private set; } = new List<ExternalSprite>();
        public static List<ExternalSprite> TalkSadSprites { get; private set; } = new List<ExternalSprite>();
        public static List<ExternalSprite> TalkMadSprites { get; private set; } = new List<ExternalSprite>();
        public static List<ExternalSprite> TalkDarkSprites { get; private set; } = new List<ExternalSprite>();
        public static List<ExternalSprite> TalkPanicSprites { get; private set; } = new List<ExternalSprite>();
        public static List<ExternalSprite> TalkNervousSprites { get; private set; } = new List<ExternalSprite>();

        //icons sprites
        public static ExternalSprite? UnstableTanksSprite { get; private set; }
        public static ExternalSprite? OverdriveTanksSprite { get; private set; }
        public static ExternalSprite? SlimeHeartSprite { get; private set; }
        public static ExternalSprite? ToxicCaviarSprite { get; private set; }
        public static ExternalSprite? CorrodeAttackSprite { get; private set; }
        public static ExternalSprite? PowerAcidSprite { get; private set; }
        public static ExternalSprite? DissolventSprite { get; private set; }
        public static ExternalSprite? DummyHeatSprite { get; private set; }
        public static ExternalSprite? IncomingCorrodeIcon { get; private set; }
        public static ExternalSprite? EvolveStatusSprite { get; private set; }
        public static ExternalSprite? HeatOutbreakStatusSprite { get; private set; }
        public static ExternalSprite? HeatControlStatusSprite { get; private set; }

        //background art sprites
        public static ExternalSprite? CorrosiveCobra_CardBackgroud { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CorrodeSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CorrosionIgnitionSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_BoxHeatSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_SplitTopSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_SplitBottomSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_SeekerCobraSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_FumeCannonSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_EvolveBackgroundSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_RecklessFuelshotSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CorrosiveMultishotSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_RepairsSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_SlimeBlastSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_BlockShotSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_HeatSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_GoatDroneSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CannonCardSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CorrosionBlockStarter { get; private set; }

        //ship parts sprites
        public static ExternalSprite? CorrosiveCobra_CannonSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_WingLeftSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_WingRightSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_MissileBaySprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CockpitSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_ScaffoldingSprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_ChassisSprite { get; private set; }

        // card borders sprites
        public static ExternalSprite? BorderCobraCommon { get; private set; }
        public static ExternalSprite? BorderCobraUncommon { get; private set; }
        public static ExternalSprite? BorderCobraRare { get; private set; }

        //artifacts
        public static ExternalArtifact? CobraArtifactUnstableTanks { get; private set; }
        public static ExternalArtifact? CobraArtifactOverdriveTanks { get; private set; }
        public static ExternalArtifact? CobraArtifactSlimeHeart { get; private set; }
        public static ExternalArtifact? CobraArtifactToxicCaviar { get; private set; }
        public static ExternalArtifact? CobraArtifactCorrodeAttack { get; private set; }
        public static ExternalArtifact? CobraArtifactPowerAcid { get; private set; }
        public static ExternalArtifact? CobraArtifactDissolvent { get; private set; }
        public static ExternalArtifact? CobraArtifactDummyHeat { get; private set; }

        //cards
        public static ExternalCard? CobraCardCorrosionStarter { get; private set; }
        public static ExternalCard? CobraCardCorrosionBlockStarter { get; private set; }
        public static ExternalCard? CobraCardFuelEjection { get; private set; }
        public static ExternalCard? CobraCardTankThrow { get; private set; }
        public static ExternalCard? CobraCardHeatedEvade { get; private set; }
        public static ExternalCard? CobraCardHurriedDefense { get; private set; }
        public static ExternalCard? CobraCardLeakingContainer { get; private set; }
        public static ExternalCard? CobraCardBooksCorrosiveCrystal { get; private set; }
        public static ExternalCard? CobraCardBooksGainCrystal { get; private set; }
        public static ExternalCard? CobraCardColorlessSlimeSummon { get; private set; }
        public static ExternalCard? CobraCardCorrosionIgnition { get; private set; }
        public static ExternalCard? CobraCardSlimeShield { get; private set; }
        public static ExternalCard? CobraCardSlimeHeal { get; private set; }
        public static ExternalCard? CobraCardTinkerWithTheTanks { get; private set; }
        public static ExternalCard? CobraCardTimestreamLeak { get; private set; }
        public static ExternalCard? CobraCardCorrosiveMultishot { get; private set; }
        public static ExternalCard? CobraCardSlimeEvolution { get; private set; }
        public static ExternalCard? CobraCardSlimeMutation { get; private set; }
        public static ExternalCard? CobraCardSlimeBLAST { get; private set; }
        public static ExternalCard? CobraCardSlimeHug { get; private set; }
        public static ExternalCard? CobraCardRecklessFuelshot { get; private set; }
        public static ExternalCard? CobraCardColorlessAbsorbArtifact { get; private set; }
        public static ExternalCard? CobraCardEnginesOnFire { get; private set; }
        public static ExternalCard? CobraCardHeatHoarder { get; private set; }
        public static ExternalCard? CobraCardShieldAlternatorA { get; private set; }
        public static ExternalCard? CobraCardShieldAlternatorB { get; private set; }
        public static ExternalCard? CobraCardAcidicFlare { get; private set; }

        //ship parts
        public static ExternalPart? CorrosiveCobra_Cannon { get; private set; }
        public static ExternalPart? CorrosiveCobra_MissileBay { get; private set; }
        public static ExternalPart? CorrosiveCobra_Cockpit { get; private set; }
        public static ExternalPart? CorrosiveCobra_Scaffolding { get; private set; }
        public static ExternalPart? CorrosiveCobra_WingLeft { get; private set; }
        public static ExternalPart? CorrosiveCobra_WingRight { get; private set; }
        public static ExternalGlossary? AIncomingCorrode_Glossary { get; private set; }
        public static ExternalGlossary? AEvolveStatus_Glossary { get; private set; }
        public DirectoryInfo? GameRootFolder { get; set; }
        void ISpriteManifest.LoadManifest(ISpriteRegistry artRegistry)
        {
            if (this.ModRootFolder == null)
                throw new Exception("Root Folder not set");

            //ship parts
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "ShipPart", Path.GetFileName("CorrosiveCobra_CannonSprite.png"));
                CorrosiveCobra_CannonSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_CannonSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CannonSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "ShipPart", Path.GetFileName("CorrosiveCobra_WingLeftSprite.png"));
                CorrosiveCobra_WingLeftSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_WingLeftSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_WingLeftSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "ShipPart", Path.GetFileName("CorrosiveCobra_MissileBaySprite.png"));
                CorrosiveCobra_MissileBaySprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_MissileBaySprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_MissileBaySprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "ShipPart", Path.GetFileName("CorrosiveCobra_CockpitSprite.png"));
                CorrosiveCobra_CockpitSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_CockpitSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CockpitSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "ShipPart", Path.GetFileName("CorrosiveCobra_ScaffoldingSprite.png"));
                CorrosiveCobra_ScaffoldingSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_ScaffoldingSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_ScaffoldingSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "ShipPart", Path.GetFileName("CorrosiveCobra_ChassisSprite.png"));
                CorrosiveCobra_ChassisSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_ChassisSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_ChassisSprite);
            }

            //character sprites
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", Path.GetFileName("CorrosiveCobra_CharacterPortrait_Sprite.png"));
                CorrosiveCobra_CharacterPortrait_Sprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_CharacterPortrait_Sprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CharacterPortrait_Sprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", Path.GetFileName("CorrosiveCobra_CharacterMini_Sprite.png"));
                CorrosiveCobra_CharacterMini_Sprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_CharacterMini_Sprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CharacterMini_Sprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", Path.GetFileName("CorrosiveCobra_CharacterPanelFrame_Sprite.png"));
                CorrosiveCobra_CharacterPanelFrame_Sprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_CharacterPanelFrame_Sprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CharacterPanelFrame_Sprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", Path.GetFileName("CorrosiveCobra_CharacterGameover_Sprite.png"));
                CorrosiveCobra_CharacterGameover_Sprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_CharacterGameover_Sprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CharacterGameover_Sprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", Path.GetFileName("CorrosiveCobra_CharacterSquint_Sprite.png"));
                CorrosiveCobra_CharacterSquint_Sprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_CharacterSquint_Sprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CharacterSquint_Sprite);
            }

            //talk animations
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_laugh");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = new ExternalSprite("CorrosiveCobra.Character.DizzySlime.TalkLaugh" + i, files[i]);
                    TalkLaughSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_neutral");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = new ExternalSprite("CorrosiveCobra.Character.DizzySlime.TalkNeutral" + i, files[i]);
                    TalkNeutralSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_squint");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = (new ExternalSprite("CorrosiveCobra.Character.DizzySlime.TalkSquint" + i, files[i]));
                    TalkSquintSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_sad");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = (new ExternalSprite("CorrosiveCobra.Character.DizzySlime.TalkSad" + i, files[i]));
                    TalkSadSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_mad");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = (new ExternalSprite("CorrosiveCobra.Character.DizzySlime.TalkMad" + i, files[i]));
                    TalkMadSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_dark");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = (new ExternalSprite("CorrosiveCobra.Character.DizzySlime.TalkDark" + i, files[i]));
                    TalkDarkSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_panic");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = (new ExternalSprite("CorrosiveCobra.Character.DizzySlime.TalkPanic" + i, files[i]));
                    TalkPanicSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }
            {
                var dir_path = Path.Combine(ModRootFolder.FullName, "Sprites", "Character", "talk_nervous");
                var files = Directory.GetFiles(dir_path).Select(e => new FileInfo(e)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var spr = (new ExternalSprite("CorrosiveCobra.Character.DizzySlime.TalkNervous" + i, files[i]));
                    TalkNervousSprites.Add(spr);
                    artRegistry.RegisterArt(spr);
                }
            }

            //icon sprites
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icon", Path.GetFileName("IncomingCorrodeIcon.png"));
                IncomingCorrodeIcon = new ExternalSprite("CorrosiveCobra.sprites.IncomingCorrodeIcon", new FileInfo(path));
                artRegistry.RegisterArt(IncomingCorrodeIcon);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icon", Path.GetFileName("EvolveStatusSprite.png"));
                EvolveStatusSprite = new ExternalSprite("CorrosiveCobra.sprites.EvolveStatusSprite", new FileInfo(path));
                artRegistry.RegisterArt(EvolveStatusSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icon", Path.GetFileName("HeatOutbreakStatusSprite.png"));
                HeatOutbreakStatusSprite = new ExternalSprite("CorrosiveCobra.sprites.HeatOutbreakStatusSprite", new FileInfo(path));
                artRegistry.RegisterArt(HeatOutbreakStatusSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icon", Path.GetFileName("HeatControlStatusSprite.png"));
                HeatControlStatusSprite = new ExternalSprite("CorrosiveCobra.sprites.HeatControlStatusSprite", new FileInfo(path));
                artRegistry.RegisterArt(HeatControlStatusSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icon", Path.GetFileName("UnstableTanksSprite.png"));
                UnstableTanksSprite = new ExternalSprite("CorrosiveCobra.sprites.UnstableTanksSprite", new FileInfo(path));
                artRegistry.RegisterArt(UnstableTanksSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icon", Path.GetFileName("OverdriveTanksSprite.png"));
                OverdriveTanksSprite = new ExternalSprite("CorrosiveCobra.sprites.OverdriveTanksSprite", new FileInfo(path));
                artRegistry.RegisterArt(OverdriveTanksSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icon", Path.GetFileName("SlimeHeartSprite.png"));
                SlimeHeartSprite = new ExternalSprite("CorrosiveCobra.sprites.SlimeHeartSprite", new FileInfo(path));
                artRegistry.RegisterArt(SlimeHeartSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icon", Path.GetFileName("ToxicCaviarSprite.png"));
                ToxicCaviarSprite = new ExternalSprite("CorrosiveCobra.sprites.ToxicCaviarSprite", new FileInfo(path));
                artRegistry.RegisterArt(ToxicCaviarSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icon", Path.GetFileName("CorrodeAttackSprite.png"));
                CorrodeAttackSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrodeAttackSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrodeAttackSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icon", Path.GetFileName("PowerAcidSprite.png"));
                PowerAcidSprite = new ExternalSprite("CorrosiveCobra.sprites.PowerAcidSprite", new FileInfo(path));
                artRegistry.RegisterArt(PowerAcidSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icon", Path.GetFileName("DissolventSprite.png"));
                DissolventSprite = new ExternalSprite("CorrosiveCobra.sprites.DissolventSprite", new FileInfo(path));
                artRegistry.RegisterArt(DissolventSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Icon", Path.GetFileName("DummyHeatSprite.png"));
                DummyHeatSprite = new ExternalSprite("CorrosiveCobra.sprites.DummyHeatSprite", new FileInfo(path));
                artRegistry.RegisterArt(DummyHeatSprite);
            }

            //card background
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_CardBackgroud.png"));
                CorrosiveCobra_CardBackgroud = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_CardBackgroud", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CardBackgroud);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_CorrodeSprite.png"));
                CorrosiveCobra_CorrodeSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_CorrodeSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CorrodeSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_CorrosionIgnitionSprite.png"));
                CorrosiveCobra_CorrosionIgnitionSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_CorrosionIgnitionSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CorrosionIgnitionSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_SplitTopSprite.png"));
                CorrosiveCobra_SplitTopSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_SplitTopSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_SplitTopSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_SplitBottomSprite.png"));
                CorrosiveCobra_SplitBottomSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_SplitBottomSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_SplitBottomSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_BoxHeatSprite.png"));
                CorrosiveCobra_BoxHeatSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_BoxHeatSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_BoxHeatSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_SeekerCobraSprite.png"));
                CorrosiveCobra_SeekerCobraSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_SeekerCobraSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_SeekerCobraSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_FumeCannonSprite.png"));
                CorrosiveCobra_FumeCannonSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_FumeCannonSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_FumeCannonSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_EvolveBackgroundSprite.png"));
                CorrosiveCobra_EvolveBackgroundSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_EvolveBackgroundSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_EvolveBackgroundSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_SlimeBlastSprite.png"));
                CorrosiveCobra_SlimeBlastSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_SlimeBlastSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_SlimeBlastSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_RecklessFuelshotSprite.png"));
                CorrosiveCobra_RecklessFuelshotSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_RecklessFuelshotSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_RecklessFuelshotSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_CorrosiveMultishotSprite.png"));
                CorrosiveCobra_CorrosiveMultishotSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_CorrosiveMultishotSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CorrosiveMultishotSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_RepairsSprite.png"));
                CorrosiveCobra_RepairsSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_RepairsSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_RepairsSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_BlockShotSprite.png"));
                CorrosiveCobra_BlockShotSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_BlockShotSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_BlockShotSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_HeatSprite.png"));
                CorrosiveCobra_HeatSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_HeatSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_HeatSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_GoatDroneSprite.png"));
                CorrosiveCobra_GoatDroneSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_GoatDroneSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_GoatDroneSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_CannonCardSprite.png"));
                CorrosiveCobra_CannonCardSprite = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_CannonCardSprite", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CannonCardSprite);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBackground", Path.GetFileName("CorrosiveCobra_CorrosionBlockStarter.png"));
                CorrosiveCobra_CorrosionBlockStarter = new ExternalSprite("CorrosiveCobra.sprites.CorrosiveCobra_CorrosionBlockStarter", new FileInfo(path));
                artRegistry.RegisterArt(CorrosiveCobra_CorrosionBlockStarter);
            }


            //card border
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBorder", Path.GetFileName("BorderCobraCommon.png"));
                BorderCobraCommon = new ExternalSprite("CorrosiveCobra.sprites.BorderCobraCommon", new FileInfo(path));
                artRegistry.RegisterArt(BorderCobraCommon);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBorder", Path.GetFileName("BorderCobraUncommon.png"));
                BorderCobraUncommon = new ExternalSprite("CorrosiveCobra.sprites.BorderCobraUncommon", new FileInfo(path));
                artRegistry.RegisterArt(BorderCobraUncommon);
            }
            {
                var path = Path.Combine(ModRootFolder.FullName, "Sprites", "CardBorder", Path.GetFileName("BorderCobraRare.png"));
                BorderCobraRare = new ExternalSprite("CorrosiveCobra.sprites.BorderCobraRare", new FileInfo(path));
                artRegistry.RegisterArt(BorderCobraRare);
            }
        }
        public void LoadManifest(IDeckRegistry registry)
        {
            ExternalSprite cardArtDefault = ExternalSprite.GetRaw(495);
            ExternalSprite borderSprite = BorderCobraCommon ?? throw new Exception();
            CobraDeck = new ExternalDeck(
                "CorrosiveCobra.CobraDeck",
                CorrosiveCobra_Primary_Color,
                System.Drawing.Color.Black,
                cardArtDefault,
                borderSprite,
                null);
            registry.RegisterDeck(Manifest.CobraDeck);
            CobraShipDeck = new ExternalDeck(
                "CorrosiveCobra.CobraShipDeck",
                CorrosiveCobra_Primary_Color,
                System.Drawing.Color.Black,
                cardArtDefault,
                borderSprite,
                null);
            registry.RegisterDeck(Manifest.CobraShipDeck);
        }
        void IGlossaryManifest.LoadManifest(IGlossaryRegisty registry)
        {
            AIncomingCorrode_Glossary = new ExternalGlossary("CorrosiveCobra.Glossary.AIncomingCorrode", "CorrosiveCobraIncomingCorrode", false, ExternalGlossary.GlossayType.action, IncomingCorrodeIcon ?? throw new Exception("Missing IncomingCorrode Icon"));
            AIncomingCorrode_Glossary.AddLocalisation("en", "Recoil Corrode", "<c=hurt>Apply to self</c> <c=keyword>{0}</c> <c=status>Corrode</c>.", null);
            registry.RegisterGlossary(AIncomingCorrode_Glossary);

            AEvolveStatus_Glossary = new ExternalGlossary("CorrosiveCobra.Glossary.AEvolveStatus", "CorrosiveCobraEvolveStatusGlossary", false, ExternalGlossary.GlossayType.action, EvolveStatusSprite ?? throw new Exception("Missing EvolveStatus Icon"));
            AEvolveStatus_Glossary.AddLocalisation("en", "Evolve", "Whenever you draw a <c=trash>Trash</c> card, <c=keyword>draw {0}</c>.", null);
            registry.RegisterGlossary(AEvolveStatus_Glossary);

        }
        void ICardManifest.LoadManifest(ICardRegistry registry)
        {
            var card_DefaultArt = CorrosiveCobra_CardBackgroud;

            // BOOKS Cards

            {
                CobraCardBooksCorrosiveCrystal = new ExternalCard("CorrosiveCobra.CobraCardCorrosiveCrystal", typeof(CobraCardBooksCorrosiveCrystal), card_DefaultArt ?? throw new Exception("missing card_DefaultArt"), ExternalDeck.GetRaw((int)Deck.shard));
                registry.RegisterCard(CobraCardBooksCorrosiveCrystal);
                CobraCardBooksCorrosiveCrystal.AddLocalisation("Corrosive Crystal");
            }
            {
                CobraCardBooksGainCrystal = new ExternalCard("CorrosiveCobra.CobraCardFuelFreezing", typeof(CobraCardBooksGainCrystal), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.shard));
                registry.RegisterCard(CobraCardBooksGainCrystal);
                CobraCardBooksGainCrystal.AddLocalisation("Fuel Freezing");
            }

            // CAT Cards

            {
                CobraCardColorlessSlimeSummon = new ExternalCard("CorrosiveCobra.CobraCardColorlessSlimeSummon", typeof(CobraCardColorlessSlimeSummon), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));
                registry.RegisterCard(CobraCardColorlessSlimeSummon);
                CobraCardColorlessSlimeSummon.AddLocalisation("Dizzy?.EXE", "Add 1 of {0} <c=cardtrait>discount, temp</c> {1}{2} cards to your hand.");
            }
            {
                CobraCardColorlessAbsorbArtifact = new ExternalCard("CorrosiveCobra.CobraCardColorlessAbsorbArtifact", typeof(CobraCardColorlessAbsorbArtifact), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));
                registry.RegisterCard(CobraCardColorlessAbsorbArtifact);
                CobraCardColorlessAbsorbArtifact.AddLocalisation("Absorb Artifact", desc: "<c=hurt>Lose a random artifact</c>. <c=healing>Heal 10</c>.");
            }

            //CORROSIVE COBRA Cards

            {
                CobraCardCorrosionStarter = new ExternalCard("CorrosiveCobra.CobraCardCorrosionStarter", typeof(CobraCardCorrosionStarter), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));
                registry.RegisterCard(CobraCardCorrosionStarter);
                CobraCardCorrosionStarter.AddLocalisation("Corrosive Fuelshot");
            }
            {
                CobraCardCorrosionBlockStarter = new ExternalCard("CorrosiveCobra.CobraCardCorrosionBlockStarter", typeof(CobraCardCorrosionBlockStarter), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));
                registry.RegisterCard(CobraCardCorrosionBlockStarter);
                CobraCardCorrosionBlockStarter.AddLocalisation("Basic Heat Protection");
            }

            // DIZZY SLIME CARDS

            {
                CobraCardFuelEjection = new ExternalCard("CorrosiveCobra.CobraCardFuelEjection", typeof(CobraCardFuelEjection), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardFuelEjection);
                CobraCardFuelEjection.AddLocalisation("Fuel Ejection");
            }
            {
                CobraCardTankThrow = new ExternalCard("CorrosiveCobra.CobraCardTankThrow", typeof(CobraCardTankThrow), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardTankThrow);
                CobraCardTankThrow.AddLocalisation("Tank Throw");
            }
            {
                CobraCardHeatedEvade = new ExternalCard("CorrosiveCobra.CobraCardHeatedEvade", typeof(CobraCardHeatedEvade), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardHeatedEvade);
                CobraCardHeatedEvade.AddLocalisation("Heated Evade");
            }
            {
                CobraCardHurriedDefense = new ExternalCard("CorrosiveCobra.CobraCardHurriedDefense", typeof(CobraCardHurriedDefense), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardHurriedDefense);
                CobraCardHurriedDefense.AddLocalisation("Hurried Defense");
            }
            {
                CobraCardLeakingContainer = new ExternalCard("CorrosiveCobra.CobraCardLeakingContainer", typeof(CobraCardLeakingContainer), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardLeakingContainer);
                CobraCardLeakingContainer.AddLocalisation("Leaking Container");
            }
            {
                CobraCardCorrosionIgnition = new ExternalCard("CorrosiveCobra.CobraCardCorrosionIgnition", typeof(CobraCardCorrosionIgnition), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardCorrosionIgnition);
                CobraCardCorrosionIgnition.AddLocalisation("Corrosion Ignition");
            }
            {
                CobraCardSlimeShield = new ExternalCard("CorrosiveCobra.CobraCardSlimeShield", typeof(CobraCardSlimeShield), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardSlimeShield);
                CobraCardSlimeShield.AddLocalisation("Slime Shield", desc: "Gain <c=keyword>2</c> <c=status>shield</c>.\nAdd a <c=card>Slime Heal </c> to your <c=keyword>draw pile</c>.", descA: "Gain <c=keyword>1</c> <c=status>shield</c>.\nAdd a <c=card>Slime Heal A</c> to your <c=keyword>draw pile</c>.", descB: "Gain <c=keyword>1</c> <c=status>shield</c>.\nAdd a <c=card>Slime Heal B</c> to your <c=keyword>draw pile</c>.");
            }
            {
                CobraCardSlimeHeal = new ExternalCard("CorrosiveCobra.CobraCardSlimeHeal", typeof(CobraCardSlimeHeal), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardSlimeHeal);
                CobraCardSlimeHeal.AddLocalisation("Slime Heal");
            }
            {
                CobraCardTinkerWithTheTanks = new ExternalCard("CorrosiveCobra.CobraCardTinkerWithTheTanks", typeof(CobraCardTinkerWithTheTanks), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardTinkerWithTheTanks);
                CobraCardTinkerWithTheTanks.AddLocalisation("Tinker With The Tanks", desc: "<c=healing>Heal 1</c>.\nGain a <c=card>Leaking Container</c>.", descA: "<c=healing>Heal 1</c>.\nGain a <c=card>Leaking Container A</c>.", descB: "<c=healing>Heal 1</c>.\nGain a <c=card>Leaking Container B</c>.");
            }
            {
                CobraCardTimestreamLeak = new ExternalCard("CorrosiveCobra.CobraCardTimestreamLeak", typeof(CobraCardTimestreamLeak), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardTimestreamLeak);
                CobraCardTimestreamLeak.AddLocalisation("Timestream Leak", desc: "Enemy gains <c=keyword>{0}</c> <c=status>corrode</c>. +1 for every second time ever played. {1}", descB: "Enemy gains <c=keyword>{0}</c> <c=status>corrode</c>.");
            }
            {
                CobraCardCorrosiveMultishot = new ExternalCard("CorrosiveCobra.CobraCardCorrosiveMultishot", typeof(CobraCardCorrosiveMultishot), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardCorrosiveMultishot);
                CobraCardCorrosiveMultishot.AddLocalisation("Corrosive Multishot");
            }
            {
                CobraCardSlimeEvolution = new ExternalCard("CorrosiveCobra.CobraCardSlimeEvolution", typeof(CobraCardSlimeEvolution), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardSlimeEvolution);
                CobraCardSlimeEvolution.AddLocalisation("Slime Evolution", desc: "Put a <c=card>Slime Mutation</c> in your <c=keyword>discard pile</c>. Draw <c=keyword>1</c>.", descB: "Put a <c=card>Slime Mutation</c> in your <c=keyword>draw pile</c>. Draw <c=keyword>1</c>.");
            }
            {
                CobraCardSlimeMutation = new ExternalCard("CorrosiveCobra.CobraCardSlimeMutation", typeof(CobraCardSlimeMutation), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardSlimeMutation);
                CobraCardSlimeMutation.AddLocalisation("Slime Mutation", desc: "Put a <c=card>SLIME BLAST!!</c> in your <c=keyword>discard pile</c>.");
            }
            {
                CobraCardSlimeBLAST = new ExternalCard("CorrosiveCobra.CobraCardSlimeBLAST", typeof(CobraCardSlimeBLAST), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardSlimeBLAST);
                CobraCardSlimeBLAST.AddLocalisation("SLIME BLAST!!", desc: "Attack.\nDmg = Double of all your statuses.{0}");
            }
            {
                CobraCardSlimeHug = new ExternalCard("CorrosiveCobra.CobraCardSlimeHug", typeof(CobraCardSlimeHug), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardSlimeHug);
                CobraCardSlimeHug.AddLocalisation("Slime Hug");
            }
            {
                CobraCardRecklessFuelshot = new ExternalCard("CorrosiveCobra.CobraCardRecklessFuelshot", typeof(CobraCardRecklessFuelshot), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardRecklessFuelshot);
                CobraCardRecklessFuelshot.AddLocalisation("Reckless Fuelshot", desc: "Attack for <c=redd>{0}</c> damage. Add {1} <c=card>Toxic</c> to your <c=keyword>draw pile</c>.", descA: "Attack for <c=redd>{0}</c> damage. Add {1} <c=card>Toxic</c> to your <c=keyword>discard pile</c>.");
            }
            {
                CobraCardEnginesOnFire = new ExternalCard("CorrosiveCobra.CobraCardEnginesOnFire", typeof(CobraCardEnginesOnFire), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardEnginesOnFire);
                CobraCardEnginesOnFire.AddLocalisation("Engines! On Fire!");
            }
            {
                CobraCardHeatHoarder = new ExternalCard("CorrosiveCobra.CobraCardHeatHoarder", typeof(CobraCardHeatHoarder), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardHeatHoarder);
                CobraCardHeatHoarder.AddLocalisation("Heat Hoarder", desc: "Gain <c=keyword>{0}</c> <c=status>Heat Control</c>. Add {1} non-temp <c=card>Miasma</c> to your <c=keyword>draw pile</c>.");
            }
            {
                CobraCardShieldAlternatorA = new ExternalCard("CorrosiveCobra.CobraCardShieldAlternatorA", typeof(CobraCardShieldAlternatorA), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardShieldAlternatorA);
                CobraCardShieldAlternatorA.AddLocalisation("Shield Replica", desc: "Gain <c=keyword>1</c> <c=status>shield</c>.\nAdd a <c=card>Temp Shield Replica</c> to your <c=keyword>draw pile</c>.", descB: "Gain <c=keyword>1</c> <c=status>shield</c>.\nAdd a <c=card>Temp Shield Replica</c> to your hand.");
            }
            {
                CobraCardShieldAlternatorB = new ExternalCard("CorrosiveCobra.CobraCardShieldAlternatorB", typeof(CobraCardShieldAlternatorB), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardShieldAlternatorB);
                CobraCardShieldAlternatorB.AddLocalisation("Temp Shield Replica", desc: "Gain <c=keyword>2</c> <c=status>temp shield</c>.\nAdd a <c=card>Shield Replica</c> to your hand.");
            }
            {
                CobraCardAcidicFlare = new ExternalCard("CorrosiveCobra.CobraCardAcidicFlare", typeof(CobraCardAcidicFlare), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CobraCardAcidicFlare);
                CobraCardAcidicFlare.AddLocalisation("Acidic Flare", desc: "Turn <c=redd>ALL</c> <c=status>heat</c> into <c=status>corrode</c>.", descA: "Turn <c=redd>ALL</c> <c=status>corrode</c> into <c=status>heat</c>. Gain a <c=card>Corrosion Ignition A</c>.", descB: "Turn <c=redd>ALL</c> <c=status>heat</c> into <c=status>corrode</c>. Gain a <c=card>Corrosion Ignition B</c>.");
            }
        }
        public void LoadManifest(IArtifactRegistry registry)
        {
            {
                CobraArtifactUnstableTanks = new ExternalArtifact("CorrosiveCobra.Artifacts.CobraArtifactUnstableTanks",
                    typeof(CobraArtifactUnstableTanks),
                    UnstableTanksSprite ?? throw new Exception("missing UnstableTanks artifact sprite"));

                CobraArtifactUnstableTanks.AddLocalisation("UNSTABLE TANKS",
                    "Gain 1 extra <c=energy>ENERGY</c> every turn. <c=hurt>Gain 1 heat each turn</c>. At the start of battle, gain a <c=card>Leaking Container</c>.");

                registry.RegisterArtifact(CobraArtifactUnstableTanks);
            }
            {
                CobraArtifactOverdriveTanks = new ExternalArtifact("CorrosiveCobra.Artifacts.CobraArtifactOverdriveTanks",
                    typeof(CobraArtifactOverdriveTanks),
                    OverdriveTanksSprite ?? throw new Exception("missing OverdriveTanks artifact sprite"));

                CobraArtifactOverdriveTanks.AddLocalisation("OVERDRIVE TANKS",
                    "Replaces <c=artifact>UNSTABLE FUELTANKS</c>. Gain 2 extra <c=energy>ENERGY</c> every turn. <c=hurt>Gain 2 heat each turn</c>. At the start of battle, gain a <c=card>Leaking Container</c>.");

                registry.RegisterArtifact(CobraArtifactOverdriveTanks);
            }
            {
                CobraArtifactSlimeHeart = new ExternalArtifact("CorrosiveCobra.Artifacts.CobraArtifactSlimeHeart",
                    typeof(CobraArtifactSlimeHeart),
                    SlimeHeartSprite ?? throw new Exception("missing SlimeHeart artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                CobraArtifactSlimeHeart.AddLocalisation("SLIME HEART",
                    "Gain 1 <c=status>EVOLVE</c> at the start of your first turn of combat.");

                registry.RegisterArtifact(CobraArtifactSlimeHeart);
            }
            {
                CobraArtifactToxicCaviar = new ExternalArtifact("CorrosiveCobra.Artifacts.CobraArtifactToxicCaviar",
                    typeof(CobraArtifactToxicCaviar),
                    ToxicCaviarSprite ?? throw new Exception("missing ToxicCaviar artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                CobraArtifactToxicCaviar.AddLocalisation("TOXIC CAVIAR",
                    "Lose 1 <c=status>CORRODE</c> each turn. <c=healing>If you do</c>, the enemy gains <c=keyword>2</c>.");

                registry.RegisterArtifact(CobraArtifactToxicCaviar);
            }
            {
                CobraArtifactCorrodeAttack = new ExternalArtifact("CorrosiveCobra.Artifacts.CobraArtifactCorrodeAttack",
                    typeof(CobraArtifactCorrodeAttack),
                    CorrodeAttackSprite ?? throw new Exception("missing CorrodeAttack artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                CobraArtifactCorrodeAttack.AddLocalisation("ACID ARSENAL",
                    "Every 7 <c=goat>Dizzy?</c> cards played, fire for 1 <c=status>CORRODE</c>.");

                registry.RegisterArtifact(CobraArtifactCorrodeAttack);
            }
            {
                CobraArtifactPowerAcid = new ExternalArtifact("CorrosiveCobra.Artifacts.CobraArtifactPowerAcid",
                    typeof(CobraArtifactPowerAcid),
                    PowerAcidSprite ?? throw new Exception("missing PowerAcid artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                CobraArtifactPowerAcid.AddLocalisation("POWERACID",
                    "<c=hurt>Draw 1 less card per turn</c>. At the end of your turn, the enemy triggers <c=status>CORRODE</c>.");

                registry.RegisterArtifact(CobraArtifactPowerAcid);
            }
            {
                CobraArtifactDissolvent = new ExternalArtifact("CorrosiveCobra.Artifacts.CobraArtifactDissolvent",
                    typeof(CobraArtifactDissolvent),
                    DissolventSprite ?? throw new Exception("missing Dissolvent artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                CobraArtifactDissolvent.AddLocalisation("DISSOLVENT",
                    "Gain 1 extra <c=energy>ENERGY</c> every turn. <c=hurt>The first time each turn you are dealt damage, you receive an extra 2 damage.");

                registry.RegisterArtifact(CobraArtifactDissolvent);
            }
            {
                CobraArtifactDummyHeat = new ExternalArtifact("CorrosiveCobra.Artifacts.CobraArtifactDummyHeat",
                    typeof(CobraArtifactDummyHeat),
                    DummyHeatSprite ?? throw new Exception("missing DummyHeat artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                CobraArtifactDummyHeat.AddLocalisation("MISC ARTIFACT", "<c=status>OVERHEAT TRIGGER</c>.");

                registry.RegisterArtifact(CobraArtifactDummyHeat);
            }
        }
    }
}