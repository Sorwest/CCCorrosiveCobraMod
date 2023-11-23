using CobaltCoreModding.Definitions;
using CobaltCoreModding.Definitions.ExternalItems;
using CobaltCoreModding.Definitions.ModContactPoints;
using CobaltCoreModding.Definitions.ModManifests;
using CorrosiveCobra.Artifacts;
using CorrosiveCobra.Cards;
using Microsoft.Extensions.Logging;

// Structure using parchmentengineer's armada mod, check them out!
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
        IGlossaryManifest
    {
        public string Name => "Sorwest.CorrosiveCobra";
        public IEnumerable<DependencyEntry> Dependencies => Array.Empty<DependencyEntry>();
        public DirectoryInfo? ModRootFolder { get; set; }
        public ILogger? Logger { get; set; }

        private static System.Drawing.Color CorrosiveCobra_Primary_Color = System.Drawing.Color.FromArgb(107, 255, 205);
        public static ExternalShip? CorrosiveCobra_Main { get; private set; }
        public static ExternalStarterShip? CorrosiveCobra_StarterShip { get; private set; }
        public static ExternalDeck? CobraDeck { get; private set; }
        public static ExternalDeck? CobraShipDeck { get; private set; }

        //character art sprites
        public static ExternalCharacter? CorrosiveCobra_Character { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_CharacterDefaultAnimation { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_CharacterMiniAnimation { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_CharacterGameoverAnimation { get; private set; }
        public static ExternalAnimation? CorrosiveCobra_CharacterSquintAnimation { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CharacterMini_Sprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CharacterPortrait_Sprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CharacterPanelFrame_Sprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CharacterGameover_Sprite { get; private set; }
        public static ExternalSprite? CorrosiveCobra_CharacterSquint_Sprite { get; private set; }

        //icons sprites
        public static ExternalSprite? UnstableTanksSprite { get; private set; }
        public static ExternalSprite? OverdriveTanksSprite { get; private set; }
        public static ExternalSprite? SlimeHeartSprite { get; private set; }
        public static ExternalSprite? ToxicCaviarSprite { get; private set; }
        public static ExternalSprite? CorrodeAttackSprite { get; private set; }
        public static ExternalSprite? PowerAcidSprite { get; private set; }
        public static ExternalSprite? DissolventSprite { get; private set; }
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
        public static ExternalArtifact? UnstableTanksArtifact { get; private set; }
        public static ExternalArtifact? OverdriveTanksArtifact { get; private set; }
        public static ExternalArtifact? SlimeHeartArtifact { get; private set; }
        public static ExternalArtifact? ToxicCaviarArtifact { get; private set; }
        public static ExternalArtifact? CorrodeAttackArtifact { get; private set; }
        public static ExternalArtifact? PowerAcidArtifact { get; private set; }
        public static ExternalArtifact? DissolventArtifact { get; private set; }

        //cards
        public static ExternalCard? CorrosionStarter { get; private set; }
        public static ExternalCard? CorrosionBlockStarter { get; private set; }
        public static ExternalCard? FuelEjection { get; private set; }
        public static ExternalCard? TankThrow { get; private set; }
        public static ExternalCard? HeatedEvade { get; private set; }
        public static ExternalCard? HurriedDefense { get; private set; }
        public static ExternalCard? LeakingContainer { get; private set; }
        public static ExternalCard? BooksCorrosiveCrystal { get; private set; }
        public static ExternalCard? BooksGainCrystal { get; private set; }
        public static ExternalCard? ColorlessSlimeSummon { get; private set; }
        public static ExternalCard? CorrosionIgnition { get; private set; }
        public static ExternalCard? SlimeShield { get; private set; }
        public static ExternalCard? SlimeHeal { get; private set; }
        public static ExternalCard? TinkerWithTheTanks { get; private set; }
        public static ExternalCard? TimestreamLeak { get; private set; }
        public static ExternalCard? CorrosiveMultishot { get; private set; }
        public static ExternalCard? SlimeEvolution { get; private set; }
        public static ExternalCard? SlimeMutation { get; private set; }
        public static ExternalCard? SlimeBLAST { get; private set; }
        public static ExternalCard? SlimeHug { get; private set; }
        public static ExternalCard? RecklessFuelshot { get; private set; }
        public static ExternalCard? AbsorbArtifact { get; private set; }
        public static ExternalCard? EnginesOnFire { get; private set; }
        public static ExternalCard? HeatHoarder { get; private set; }
        public static ExternalCard? ShieldAlternatorA { get; private set; }
        public static ExternalCard? ShieldAlternatorB { get; private set; }
        public static ExternalCard? AcidicFlare { get; private set; }

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
                BooksCorrosiveCrystal = new ExternalCard("CorrosiveCobra.BooksCorrosiveCrystal", typeof(BooksCorrosiveCrystal), card_DefaultArt ?? throw new Exception("missing card_DefaultArt"), ExternalDeck.GetRaw((int)Deck.shard));
                registry.RegisterCard(BooksCorrosiveCrystal);
                BooksCorrosiveCrystal.AddLocalisation("Corrosive Crystal");
            }
            {
                BooksGainCrystal = new ExternalCard("CorrosiveCobra.FuelFreezing", typeof(BooksGainCrystal), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.shard));
                registry.RegisterCard(BooksGainCrystal);
                BooksGainCrystal.AddLocalisation("Fuel Freezing");
            }

            // CAT Cards

            {
                ColorlessSlimeSummon = new ExternalCard("CorrosiveCobra.ColorlessSlimeSummon", typeof(ColorlessSlimeSummon), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));
                registry.RegisterCard(ColorlessSlimeSummon);
                ColorlessSlimeSummon.AddLocalisation("Dizzy?.EXE", "Add 1 of {0} <c=cardtrait>discount, temp</c> <c={1}>{2}</c> cards to your hand.");
            }
            {
                AbsorbArtifact = new ExternalCard("CorrosiveCobra.AbsorbArtifact", typeof(AbsorbArtifact), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));
                registry.RegisterCard(AbsorbArtifact);
                AbsorbArtifact.AddLocalisation("Absorb Artifact", desc: "<c=hurt>Lose a random artifact</c>. <c=healing>Heal 10</c>.");
            }

            //CORROSIVE COBRA Cards

            {
                CorrosionStarter = new ExternalCard("CorrosiveCobra.CorrosionStarter", typeof(CorrosionStarter), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));
                registry.RegisterCard(CorrosionStarter);
                CorrosionStarter.AddLocalisation("Corrosive Fuelshot");
            }
            {
                CorrosionBlockStarter = new ExternalCard("CorrosiveCobra.CorrosionBlockStarter", typeof(CorrosionBlockStarter), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));
                registry.RegisterCard(CorrosionBlockStarter);
                CorrosionBlockStarter.AddLocalisation("Basic Heat Protection");
            }

            // DIZZY SLIME CARDS

            {
                FuelEjection = new ExternalCard("CorrosiveCobra.FuelEjection", typeof(FuelEjection), card_DefaultArt, CobraDeck);
                registry.RegisterCard(FuelEjection);
                FuelEjection.AddLocalisation("Fuel Ejection");
            }
            {
                TankThrow = new ExternalCard("CorrosiveCobra.TankThrow", typeof(TankThrow), card_DefaultArt, CobraDeck);
                registry.RegisterCard(TankThrow);
                TankThrow.AddLocalisation("Tank Throw");
            }
            {
                HeatedEvade = new ExternalCard("CorrosiveCobra.HeatedEvade", typeof(HeatedEvade), card_DefaultArt, CobraDeck);
                registry.RegisterCard(HeatedEvade);
                HeatedEvade.AddLocalisation("Heated Evade");
            }
            {
                HurriedDefense = new ExternalCard("CorrosiveCobra.HurriedDefense", typeof(HurriedDefense), card_DefaultArt, CobraDeck);
                registry.RegisterCard(HurriedDefense);
                HurriedDefense.AddLocalisation("Hurried Defense");
            }
            {
                LeakingContainer = new ExternalCard("CorrosiveCobra.LeakingContainer", typeof(LeakingContainer), card_DefaultArt, CobraDeck);
                registry.RegisterCard(LeakingContainer);
                LeakingContainer.AddLocalisation("Leaking Container");
            }
            {
                CorrosionIgnition = new ExternalCard("CorrosiveCobra.CorrosionIgnition", typeof(CorrosionIgnition), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CorrosionIgnition);
                CorrosionIgnition.AddLocalisation("Corrosion Ignition");
            }
            {
                SlimeShield = new ExternalCard("CorrosiveCobra.SlimeShield", typeof(SlimeShield), card_DefaultArt, CobraDeck);
                registry.RegisterCard(SlimeShield);
                SlimeShield.AddLocalisation("Slime Shield", desc: "Gain <c=keyword>2</c> <c=status>shield</c>.\nAdd a <c=card>Slime Heal </c> to your <c=keyword>draw pile</c>.", descA: "Gain <c=keyword>1</c> <c=status>shield</c>.\nAdd a <c=card>Slime Heal A</c> to your <c=keyword>draw pile</c>.", descB: "Gain <c=keyword>1</c> <c=status>shield</c>.\nAdd a <c=card>Slime Heal B</c> to your <c=keyword>draw pile</c>.");
            }
            {
                SlimeHeal = new ExternalCard("CorrosiveCobra.SlimeHeal", typeof(SlimeHeal), card_DefaultArt, CobraDeck);
                registry.RegisterCard(SlimeHeal);
                SlimeHeal.AddLocalisation("Slime Heal");
            }
            {
                TinkerWithTheTanks = new ExternalCard("CorrosiveCobra.TinkerWithTheTanks", typeof(TinkerWithTheTanks), card_DefaultArt, CobraDeck);
                registry.RegisterCard(TinkerWithTheTanks);
                TinkerWithTheTanks.AddLocalisation("Tinker With The Tanks", desc: "<c=healing>Heal 1</c>.\nGain a <c=card>Leaking Container</c>.", descA: "<c=healing>Heal 1</c>.\nGain a <c=card>Leaking Container A</c>.", descB: "<c=healing>Heal 1</c>.\nGain a <c=card>Leaking Container B</c>.");
            }
            {
                TimestreamLeak = new ExternalCard("CorrosiveCobra.TimestreamLeak", typeof(TimestreamLeak), card_DefaultArt, CobraDeck);
                registry.RegisterCard(TimestreamLeak);
                TimestreamLeak.AddLocalisation("Timestream Leak", desc: "Enemy gains <c=keyword>{0}</c> <c=status>corrode</c>. +1 for every second time ever played. {1}", descB: "Enemy gains <c=keyword>{0}</c> <c=status>corrode</c>.");
            }
            {
                CorrosiveMultishot = new ExternalCard("CorrosiveCobra.CorrosiveMultishot", typeof(CorrosiveMultishot), card_DefaultArt, CobraDeck);
                registry.RegisterCard(CorrosiveMultishot);
                CorrosiveMultishot.AddLocalisation("Corrosive Multishot");
            }
            {
                SlimeEvolution = new ExternalCard("CorrosiveCobra.SlimeEvolution", typeof(SlimeEvolution), card_DefaultArt, CobraDeck);
                registry.RegisterCard(SlimeEvolution);
                SlimeEvolution.AddLocalisation("Slime Evolution", desc: "Put a <c=card>Slime Mutation</c> in your <c=keyword>discard pile</c>. Draw <c=keyword>1</c>.", descB: "Put a <c=card>Slime Mutation</c> in your <c=keyword>draw pile</c>. Draw <c=keyword>1</c>.");
            }
            {
                SlimeMutation = new ExternalCard("CorrosiveCobra.SlimeMutation", typeof(SlimeMutation), card_DefaultArt, CobraDeck);
                registry.RegisterCard(SlimeMutation);
                SlimeMutation.AddLocalisation("Slime Mutation", desc: "Put a <c=card>SLIME BLAST!!</c> in your <c=keyword>discard pile</c>.");
            }
            {
                SlimeBLAST = new ExternalCard("CorrosiveCobra.SlimeBLAST", typeof(SlimeBLAST), card_DefaultArt, CobraDeck);
                registry.RegisterCard(SlimeBLAST);
                SlimeBLAST.AddLocalisation("SLIME BLAST!!", desc: "Attack.\nDmg = Double of all your statuses.{0}");
            }
            {
                SlimeHug = new ExternalCard("CorrosiveCobra.SlimeHug", typeof(SlimeHug), card_DefaultArt, CobraDeck);
                registry.RegisterCard(SlimeHug);
                SlimeHug.AddLocalisation("Slime Hug");
            }
            {
                RecklessFuelshot = new ExternalCard("CorrosiveCobra.RecklessFuelshot", typeof(RecklessFuelshot), card_DefaultArt, CobraDeck);
                registry.RegisterCard(RecklessFuelshot);
                RecklessFuelshot.AddLocalisation("Reckless Fuelshot", desc: "Attack for <c=redd>{0}</c> damage. Add {1} <c=card>Toxic</c> to your <c=keyword>draw pile</c>.", descA: "Attack for <c=redd>{0}</c> damage. Add {1} <c=card>Toxic</c> to your <c=keyword>discard pile</c>.");
            }
            {
                EnginesOnFire = new ExternalCard("CorrosiveCobra.EnginesOnFire", typeof(EnginesOnFire), card_DefaultArt, CobraDeck);
                registry.RegisterCard(EnginesOnFire);
                EnginesOnFire.AddLocalisation("Engines! On Fire!");
            }
            {
                HeatHoarder = new ExternalCard("CorrosiveCobra.HeatHoarder", typeof(HeatHoarder), card_DefaultArt, CobraDeck);
                registry.RegisterCard(HeatHoarder);
                HeatHoarder.AddLocalisation("Heat Hoarder", desc: "Gain <c=keyword>{0}</c> <c=status>Heat Control</c>. Add {1} non-temp <c=card>Miasma</c> to your <c=keyword>draw pile</c>.");
            }
            {
                ShieldAlternatorA = new ExternalCard("CorrosiveCobra.ShieldAlternatorA", typeof(ShieldAlternatorA), card_DefaultArt, CobraDeck);
                registry.RegisterCard(ShieldAlternatorA);
                ShieldAlternatorA.AddLocalisation("Shield Replica", desc: "Gain <c=keyword>1</c> <c=status>shield</c>.\nAdd a <c=card>Temp Shield Replica</c> to your <c=keyword>draw pile</c>.", descB: "Gain <c=keyword>1</c> <c=status>shield</c>.\nAdd a <c=card>Temp Shield Replica</c> to your hand.");
            }
            {
                ShieldAlternatorB = new ExternalCard("CorrosiveCobra.ShieldAlternatorB", typeof(ShieldAlternatorB), card_DefaultArt, CobraDeck);
                registry.RegisterCard(ShieldAlternatorB);
                ShieldAlternatorB.AddLocalisation("Temp Shield Replica", desc: "Gain <c=keyword>2</c> <c=status>temp shield</c>.\nAdd a <c=card>Shield Replica</c> to your hand.");
            }
            {
                AcidicFlare = new ExternalCard("CorrosiveCobra.AcidicFlare", typeof(AcidicFlare), card_DefaultArt, CobraDeck);
                registry.RegisterCard(AcidicFlare);
                AcidicFlare.AddLocalisation("Acidic Flare", desc: "Turn <c=redd>ALL</c> <c=status>heat</c> into <c=status>corrode</c>.", descA: "Turn <c=redd>ALL</c> <c=status>corrode</c> into <c=status>heat</c>. Gain a <c=card>Corrosion Ignition A</c>.", descB: "Turn <c=redd>ALL</c> <c=status>heat</c> into <c=status>corrode</c>. Gain a <c=card>Corrosion Ignition B</c>.");
            }
        }
        public void LoadManifest(IArtifactRegistry registry)
        {
            {
                UnstableTanksArtifact = new ExternalArtifact("CorrosiveCobra.Artifacts.UnstableTanks",
                    typeof(UnstableTanks),
                    UnstableTanksSprite ?? throw new Exception("missing UnstableTanks artifact sprite"));

                UnstableTanksArtifact.AddLocalisation("UNSTABLE TANKS",
                    "Gain 1 extra <c=energy>ENERGY</c> every turn. <c=hurt>Gain 1 heat each turn</c>. At the start of battle, gain a <c=card>Leaking Container</c>.");

                registry.RegisterArtifact(UnstableTanksArtifact);
            }
            {
                OverdriveTanksArtifact = new ExternalArtifact("CorrosiveCobra.Artifacts.OverdriveTanks",
                    typeof(OverdriveTanks),
                    OverdriveTanksSprite ?? throw new Exception("missing OverdriveTanks artifact sprite"),
                    exclusiveToShips: new string[1]
                    {
                        "CorrosiveCobra_StarterShip"
                    });

                OverdriveTanksArtifact.AddLocalisation("OVERDRIVE TANKS",
                    "Replaces <c=artifact>UNSTABLE FUELTANKS</c>. Gain 2 extra <c=energy>ENERGY</c> every turn. <c=hurt>Gain 2 heat each turn</c>. At the start of battle, gain a <c=card>Leaking Container</c>.");

                registry.RegisterArtifact(OverdriveTanksArtifact);
            }
            {
                SlimeHeartArtifact = new ExternalArtifact("CorrosiveCobra.Artifacts.SlimeHeart",
                    typeof(SlimeHeart),
                    SlimeHeartSprite ?? throw new Exception("missing SlimeHeart artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                SlimeHeartArtifact.AddLocalisation("SLIME HEART",
                    "Gain 1 <c=status>EVOLVE</c> at the start of your first turn of combat.");

                registry.RegisterArtifact(SlimeHeartArtifact);
            }
            {
                ToxicCaviarArtifact = new ExternalArtifact("CorrosiveCobra.Artifacts.ToxicCaviar",
                    typeof(ToxicCaviar),
                    ToxicCaviarSprite ?? throw new Exception("missing ToxicCaviar artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                ToxicCaviarArtifact.AddLocalisation("TOXIC CAVIAR",
                    "Lose 1 <c=status>CORRODE</c> each turn, <c=healing>and if you do</c>, the enemy gains <c=keyword>2</c>.");

                registry.RegisterArtifact(ToxicCaviarArtifact);
            }
            {
                CorrodeAttackArtifact = new ExternalArtifact("CorrosiveCobra.Artifacts.CorrodeAttack",
                    typeof(CorrodeAttack),
                    CorrodeAttackSprite ?? throw new Exception("missing CorrodeAttack artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                CorrodeAttackArtifact.AddLocalisation("ACID ARSENAL",
                    "Every 7 <c=goat>Dizzy?</c> cards played, fire for 1 <c=status>CORRODE</c>.");

                registry.RegisterArtifact(CorrodeAttackArtifact);
            }
            {
                PowerAcidArtifact = new ExternalArtifact("CorrosiveCobra.Artifacts.PowerAcid",
                    typeof(PowerAcid),
                    PowerAcidSprite ?? throw new Exception("missing PowerAcid artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                PowerAcidArtifact.AddLocalisation("POWERACID",
                    "<c=hurt>Draw 1 less card per turn</c>. At the end of your turn, the enemy triggers <c=status>CORRODE</c>.");

                registry.RegisterArtifact(PowerAcidArtifact);
            }
            {
                DissolventArtifact = new ExternalArtifact("CorrosiveCobra.Artifacts.Dissolvent",
                    typeof(Dissolvent),
                    DissolventSprite ?? throw new Exception("missing Dissolvent artifact sprite"),
                    ownerDeck: CobraDeck ?? throw new Exception("missing CobraDeck."));

                DissolventArtifact.AddLocalisation("DISSOLVENT",
                    "Gain 1 extra <c=energy>ENERGY</c> every turn. <c=hurt>The first time each turn you are dealt damage, you receive an extra 2 damage.");

                registry.RegisterArtifact(DissolventArtifact);
            }
        }
    }
}