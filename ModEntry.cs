using HarmonyLib;
using Sorwest.CorrosiveCobra.Cards;
using Sorwest.CorrosiveCobra.Artifacts;
using Microsoft.Extensions.Logging;
using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorwest.CorrosiveCobra;

/*
 * TO-DO LIST
 * ISogginsApi SogginsDeck
 * Corrosive Cobra overhaul:
 *      Change UnstableTanks
 *      Change OverdriveTanks
 *      Change Leaking Container
 * Reckless Fuelshot
 *      Create custom trash card
 * Flame Shot
 *      Create custom trash card
 */
public sealed class ModEntry : SimpleMod
{
    public static string Name => "Sorwest.CorrosiveCobra";
    internal bool LockedChar = false;
    internal bool NoExtraCards = false;
    internal static ModEntry Instance { get; private set; } = null!;
    internal Harmony Harmony { get; }
    internal IKokoroApi KokoroApi { get; }
    internal IDuoArtifactsApi? DuoArtifactsApi { get; }
    internal ISogginsApi? SogginsApi { get; }
    internal IMoreDifficultiesApi? MoreDifficultiesApi { get; }
    internal ILocalizationProvider<IReadOnlyList<string>> AnyLocalizations { get; }
    internal ILocaleBoundNonNullLocalizationProvider<IReadOnlyList<string>> Localizations { get; }
    internal ILocalizationProvider<IReadOnlyList<string>> AnyStoryLoc { get; }
    internal ILocaleBoundNonNullLocalizationProvider<IReadOnlyList<string>> StoryLocs { get; }
    internal IDeckEntry SlimeDeck { get; }
    internal IDeckEntry CobraDeck { get; }
    internal ICharacterEntry SlimeDizzy { get; }
    internal static Color SlimeColor => new("6BFFCD");
    internal static Color CobraColor => new("6BFFCD");
    internal static Color BlackTitle => new("000000");

    // CARD LISTS
    internal static IReadOnlyList<Type> OtherCardTypes { get; } = [
        typeof(CobraCardColorlessAbsorbArtifact),
        typeof(CobraCardColorlessSlimeSummon),
        typeof(CobraCardBooksCorrosiveCrystal),
        typeof(CobraCardBooksGainCrystal),
    ];
    internal static IReadOnlyList<Type> SlimeStarterCardTypes { get; } = [
        typeof(CobraCardHeatedEvade),
        typeof(CobraCardHurriedDefense),
    ];

    internal static IReadOnlyList<Type> SlimeCommonCardTypes { get; } = [
        typeof(CobraCardShieldAlternatorA),
        typeof(CobraCardShieldAlternatorB),
        typeof(CobraCardRecklessFuelshot),
        typeof(CobraCardFlameShot),
        typeof(CobraCardStolenFueltank),
        typeof(CobraCardUncontrolledEngines),
        typeof(CobraCardForgottenGelAmmo),
        typeof(CobraCardSlimeHeal),
        typeof(CobraCardSlimeMutation),
        typeof(CobraCardSlimeBLAST),
    ];

    internal static IReadOnlyList<Type> SlimeUncommonCardTypes { get; } = [
        typeof(CobraCardAcidicFlare),
        typeof(CobraCardCorrosiveMultishot),
        typeof(CobraCardTinkerWithTheTanks),
        typeof(CobraCardSlimeShield),
        typeof(CobraCardTankThrow),
        typeof(CobraCardFuelEjection),
    ];
    internal static IReadOnlyList<Type> SlimeRareCardTypes { get; } = [
        typeof(CobraCardCorrosionIgnition),
        typeof(CobraCardHeatHoarder),
        typeof(CobraCardEnginesOnFire),
        typeof(CobraCardSlimeHug),
        typeof(CobraCardTimestreamLeak),
        typeof(CobraCardSlimeEvolution),
    ];
    internal static IReadOnlyList<Type> CobraCardTypes { get; } = [
        typeof(CobraCardCorrosionShotStarter),
        typeof(CobraCardCorrosionBlockStarter),
        typeof(CobraCardFuelWall),
        typeof(CobraCardLeakingContainer),
    ];

    // ARTIFACT LISTS
    internal static IReadOnlyList<Type> SlimeCommonArtifactTypes { get; } = [
        typeof(CobraArtifactSlimeHeart),
        typeof(CobraArtifactToxicCaviar),
        typeof(CobraArtifactCorrodeAttack),
        typeof(CobraArtifactDummyHeat),
    ];
    internal static IReadOnlyList<Type> SlimeBossArtifactTypes { get; } = [
        typeof(CobraArtifactPowerAcid),
        typeof(CobraArtifactDissolvent),
    ];
    internal static IReadOnlyList<Type> CobraCommonArtifactTypes { get; } = [
        typeof(CobraArtifactUnstableTanks),
        typeof(CobraArtifactFuelWalls),
    ];
    internal static IReadOnlyList<Type> CobraBossArtifactTypes { get; } = [
        typeof(CobraArtifactOverdriveTanks),
    ];
    
    // DUO ARTIFACT LISTS
    internal static IReadOnlyList<Type> DuoCardTypes { get; } = [
    
        typeof(CobraCardSlimeBooksDuo),
        typeof(CobraCardSlimeRiggsDuo),
        typeof(CobraCardSlimeIsaacDuo),
        typeof(CobraCardSlimeMaxDuo1),
        typeof(CobraCardSlimeMaxDuo2),
        typeof(CobraCardSlimeMaxDuo3),
        typeof(CobraCardSlimeMaxDuo4),
        typeof(CobraCardSlimeMaxDuo5),
        typeof(CobraCardSlimeMaxDuo6),
        typeof(CobraCardSlimeMaxDuo7),
        typeof(CobraCardSlimeMaxDuo8),
        typeof(CobraCardSlimeMaxDuoA1),
        typeof(CobraCardSlimeMaxDuoA2),
        typeof(CobraCardSlimeMaxDuoA3),
        typeof(CobraCardSlimeMaxDuoReward),
    ];
    internal static IReadOnlyList<Type> DuoArtifactTypes { get; } = [
    typeof(SlimeDizzyArtifact),
        typeof(SlimeRiggsArtifact),
        typeof(SlimePeriArtifact),
        typeof(SlimeIsaacArtifact),
        typeof(SlimeDrakeArtifact),
        typeof(SlimeMaxArtifact),
        typeof(SlimeMaxArtifactReward),
        typeof(SlimeBooksArtifact),
        typeof(SlimeCatArtifact),
    ];

    // DUO ARTIFACT MODDED LISTS
    internal static IReadOnlyList<Type> DuoSogginsCardTypes { get; } = [
        typeof(CobraCardSlimeSogginsDuoBotch),
        typeof(CobraCardSlimeSogginsDuoDouble),
    ];
    internal static IReadOnlyList<Type> DuoSogginsArtifactTypes { get; } = [
        typeof(SlimeSogginsArtifact),
    ];
    
    internal static IEnumerable<Type> AllSlimeCards
        => SlimeStarterCardTypes
        .Concat(SlimeCommonCardTypes)
        .Concat(SlimeUncommonCardTypes)
        .Concat(SlimeRareCardTypes);
    internal static IEnumerable<Type> AllSlimeArtifacts
        => CobraCommonArtifactTypes
        .Concat(CobraBossArtifactTypes);
    internal static IEnumerable<Type> AllCobraArtifacts
        => CobraCommonArtifactTypes
        .Concat(CobraBossArtifactTypes);
    internal static IEnumerable<Type> AllCards
        => AllSlimeCards
        .Concat(CobraCardTypes)
        .Concat(OtherCardTypes);
    internal static IEnumerable<Type> AllArtifacts
        => AllSlimeArtifacts
        .Concat(AllCobraArtifacts);

    internal IShipEntry CobraShip { get; }
    internal IStatusEntry EvolveStatus { get; }
    internal IStatusEntry HeatOutbreakStatus { get; }
    internal IStatusEntry HeatControlStatus { get; }
    internal IStatusEntry CrystalTapStatus { get; }
    internal IStatusEntry OxidationStatus { get; }
    internal IList<string> FaceSprites { get; } = [
        "Crystal",
        "Dark",
        "Gameover",
        "Laugh",
        "Mad",
        "Mini",
        "Nervous",
        "Neutral",
        "Phone",
        "Sad",
        "Squint"
    ];
    internal IList<string> CardBGs { get; } = [
        "CardBackgroud",
        "CorrodeSprite",
        "CorrosionIgnitionSprite",
        "BoxHeatSprite",
        "Split3_2TopSprite",
        "Split3_2BottomSprite",
        "SplitHalfTopSprite",
        "SplitHalfBottomSprite",
        "SeekerCobraSprite",
        "FumeCannonSprite",
        "EvolveBackgroundSprite",
        "RecklessFuelshotSprite",
        "CorrosiveMultishotSprite",
        "RepairsSprite",
        "SlimeBlastSprite",
        "BlockShotSprite",
        "HeatSprite",
        "GoatDroneSprite",
        "CannonCardSprite",
        "CorrosionBlockStarter",
    ];
    internal IList<string> ArtifactSprites { get; } = [
        //artifact sprites
        "UnstableTanksSprite",
        "OverdriveTanksSprite",
        "SlimeHeartSprite",
        "ToxicCaviarSprite",
        "CorrodeAttackSprite",
        "PowerAcidSprite",
        "DissolventSprite",
        "DummyHeatSprite",
        "FuelWallsSprite",

        //duo artifact sprites
        "SlimeDizzyArtifactSprite",
        "SlimeRiggsArtifactSprite",
        "SlimePeriArtifactSprite",
        "SlimeIsaacArtifactSprite",
        "SlimeIsaacArtifactSprite_Off",
        "SlimeDrakeArtifactSprite",
        "SlimeDrakeArtifactSprite_Off",
        "SlimeMaxArtifactSprite",
        "SlimeMaxArtifactRewardSprite",
        "SlimeBooksArtifactSprite",
        "SlimeCatArtifactSprite",
        "SlimeCatArtifactSprite_Off",

        //modded duo artifact sprites
        "SlimeSogginsArtifactSprite",
        "SlimeSogginsArtifactSprite_Off",
    ];
    internal IList<string> IconSprites { get; } = [
        "HeatCostSatisfied",
        "HeatCostUnsatisfied",
        "CorrodeCostSatisfied",
        "CorrodeCostUnsatisfied",
        "IncomingCorrodeIcon",
        "EvolveStatusSprite",
        "HeatOutbreakStatusSprite",
        "HeatControlStatusSprite",
        "PlayRandomCardHand",
        "PlayRandomCardDeck",
        "PlayRandomCardDiscard",
        "PlayRandomCardExhaust",

        //duo icon sprites
        "CobraFieldSprite",
        "CrystalTapStatusSprite",
    ];
    internal IList<string> PartSprites { get; } = [
        "CorrosiveCobra_CannonSprite",
        "CorrosiveCobra_WingLeftSprite",
        "CorrosiveCobra_MissileBaySprite",
        "CorrosiveCobra_CockpitSprite",
        "CorrosiveCobra_ScaffoldingSprite",
        "CorrosiveCobra_ChassisSprite",
    ];
    internal Dictionary<string, ISpriteEntry> Sprites { get; } = [];

    public ModEntry(IPluginPackage<IModManifest> package, IModHelper helper, ILogger logger) : base(package, helper, logger)
    {
        Instance = this;
        Harmony = new(package.Manifest.UniqueName);
        KokoroApi = helper.ModRegistry.GetApi<IKokoroApi>("Shockah.Kokoro")!;

        DuoArtifactsApi = helper.ModRegistry.GetApi<IDuoArtifactsApi>("Shockah.DuoArtifacts");
        SogginsApi = helper.ModRegistry.GetApi<ISogginsApi>("Shockah.DuoArtifacts");
        MoreDifficultiesApi = helper.ModRegistry.GetApi<IMoreDifficultiesApi>("TheJazMaster.MoreDifficulties");

        _ = new EvolveManager();
        _ = new HeatControlManager();
        _ = new HeatOutbreakManager();
        _ = new CrystalTapManager();

        CustomTTGlossary.ApplyPatches(Harmony);

        AnyLocalizations = new JsonLocalizationProvider(
            tokenExtractor: new SimpleLocalizationTokenExtractor(),
            localeStreamFunction: locale => package.PackageRoot.GetRelativeFile($"i18n/{locale}.json").OpenRead()
        );
        Localizations = new MissingPlaceholderLocalizationProvider<IReadOnlyList<string>>(
            new CurrentLocaleOrEnglishLocalizationProvider<IReadOnlyList<string>>(AnyLocalizations)
        );
        AnyStoryLoc = new JsonLocalizationProvider(
            tokenExtractor: new SimpleLocalizationTokenExtractor(),
            localeStreamFunction: locale => package.PackageRoot.GetRelativeFile($"i18n/story/{locale}.json").OpenRead()
        );
        StoryLocs = new MissingPlaceholderLocalizationProvider<IReadOnlyList<string>>(
            new CurrentLocaleOrEnglishLocalizationProvider<IReadOnlyList<string>>(AnyStoryLoc)
        );

        // SPRITE REGISTRATION BLOCK
        IFileInfo file;
        foreach (string face in FaceSprites)
        {
            for (int frame = 0; frame < 10; frame++)
            {
                file = package.PackageRoot.GetRelativeFile($"assets/character/{face}/Slime_{face}_{frame}.png");
                if (file.Exists)
                    Sprites.Add(key: $"slime_{face.ToLower()}_{frame}", value: helper.Content.Sprites.RegisterSprite(file));
                else
                    break;
            }
        }
        file = package.PackageRoot.GetRelativeFile($"assets/character/Slime_PanelFrame_0.png");
        if (file.Exists && !Sprites.ContainsKey("slime_panel"))
            Sprites.Add(key: "slime_panel", value: helper.Content.Sprites.RegisterSprite(file));

        file = package.PackageRoot.GetRelativeFile($"assets/cardborder/BorderSlime.png");
        if (file.Exists && !Sprites.ContainsKey("slime_border"))
            Sprites.Add(key: "slime_border", value: helper.Content.Sprites.RegisterSprite(file));
        file = package.PackageRoot.GetRelativeFile($"assets/cardborder/BorderCobra.png");
        if (file.Exists && !Sprites.ContainsKey("cobra_border"))
            Sprites.Add(key: "cobra_border", value: helper.Content.Sprites.RegisterSprite(file));


        foreach (string bg in CardBGs)
        {
            file = package.PackageRoot.GetRelativeFile($"assets/cardbg/{bg}.png");
            if (file.Exists)
                Sprites.Add(key: $"{bg}", value: helper.Content.Sprites.RegisterSprite(file));
        }

        foreach (string arti in ArtifactSprites)
        {
            file = package.PackageRoot.GetRelativeFile($"assets/artifacts/{arti}.png");
            if (!file.Exists)
                file = package.PackageRoot.GetRelativeFile($"assets/artifacts/Duo/{arti}.png");
            if (file.Exists)
                Sprites.Add(key: $"{arti}", value: helper.Content.Sprites.RegisterSprite(file));
        }

        foreach (string icon in IconSprites)
        {
            file = package.PackageRoot.GetRelativeFile($"assets/icons/{icon}.png");
            if (!file.Exists)
                file = package.PackageRoot.GetRelativeFile($"assets/icons/Duo/{icon}.png");
            if (file.Exists)
                Sprites.Add(key: $"{icon}", value: helper.Content.Sprites.RegisterSprite(file));
        }

        foreach (string part in PartSprites)
        {
            file = package.PackageRoot.GetRelativeFile($"assets/ship/{part}.png");
            if (file.Exists)
                Sprites.Add(key: $"{part}", value: helper.Content.Sprites.RegisterSprite(file));
        }

        // STATUS REGISTRATION BLOCK
        EvolveStatus = helper.Content.Statuses.RegisterStatus("EvolveStatus", new()
        {
            Definition = new()
            {
                icon = Sprites["EvolveStatusSprite"].Sprite,
                color = SlimeColor,
                isGood = true
            },
            Name = AnyLocalizations.Bind(["status", "EvolveStatus", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "EvolveStatus", "description"]).Localize
        });
        HeatControlStatus = helper.Content.Statuses.RegisterStatus("HeatControlStatus", new()
        {
            Definition = new()
            {
                icon = Sprites["HeatControlStatusSprite"].Sprite,
                color = SlimeColor,
                isGood = true
            },
            Name = AnyLocalizations.Bind(["status", "HeatControlStatus", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "HeatControlStatus", "description"]).Localize
        });
        HeatOutbreakStatus = helper.Content.Statuses.RegisterStatus("HeatOutbreakStatus", new()
        {
            Definition = new()
            {
                icon = Sprites["HeatOutbreakStatusSprite"].Sprite,
                color = SlimeColor,
                isGood = true
            },
            Name = AnyLocalizations.Bind(["status", "HeatOutbreakStatus", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "HeatOutbreakStatus", "description"]).Localize
        });
        CrystalTapStatus = helper.Content.Statuses.RegisterStatus("CrystalTapStatus", new()
        {
            Definition = new()
            {
                icon = Sprites["CrystalTapStatusSprite"].Sprite,
                color = SlimeColor,
                isGood = true
            },
            Name = AnyLocalizations.Bind(["status", "CrystalTapStatus", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "CrystalTapStatus", "description"]).Localize
        });
        OxidationStatus = helper.Content.Statuses.LookupByUniqueName("Shockah.Kokoro::Shockah.Kokoro.Status.Oxidation")!;

        // DECK REGISTRATION BLOCK
        SlimeDeck = helper.Content.Decks.RegisterDeck("Slime", new()
        {
            Definition = new() { color = SlimeColor, titleColor = BlackTitle },
            DefaultCardArt = Sprites["CardBackgroud"].Sprite,
            BorderSprite = Sprites["slime_border"].Sprite,
            Name = AnyLocalizations.Bind(["character", "slime", "name"]).Localize,
        });
        CobraDeck = helper.Content.Decks.RegisterDeck("Cobra", new()
        {
            Definition = new() { color = CobraColor, titleColor = BlackTitle },
            DefaultCardArt = Sprites["CardBackgroud"].Sprite,
            BorderSprite = Sprites["cobra_border"].Sprite,
            Name = AnyLocalizations.Bind(["ship", "cobra", "name"]).Localize,
        });

        // CHARACTER REGISTRATION BLOCK
        SlimeDizzy = helper.Content.Characters.RegisterCharacter("Slime", new()
        {
            Deck = SlimeDeck.Deck,
            StartLocked = LockedChar,
            Description = AnyLocalizations.Bind(["character", "slime", "description"]).Localize,
            BorderSprite = Sprites["slime_panel"].Sprite,
            StarterCardTypes = SlimeStarterCardTypes,
            ExeCardType = typeof(CobraCardColorlessSlimeSummon),
            NeutralAnimation = new()
            {
                Deck = SlimeDeck.Deck,
                LoopTag = "neutral",
                Frames = [
                    Sprites["slime_neutral_0"].Sprite,
                    Sprites["slime_neutral_1"].Sprite,
                    Sprites["slime_neutral_2"].Sprite,
                    Sprites["slime_neutral_3"].Sprite,
                    Sprites["slime_neutral_4"].Sprite,
                    Sprites["slime_neutral_5"].Sprite,
                ]
            },
            MiniAnimation = new()
            {
                Deck = SlimeDeck.Deck,
                LoopTag = "mini",
                Frames = [
                   Sprites["slime_mini_0"].Sprite
                ]
            }
        });
        helper.Content.Characters.RegisterCharacterAnimation("slime_gameover", new()
        {
            Deck = SlimeDeck.Deck,
            LoopTag = "gameover",
            Frames = [
                Sprites["slime_gameover_0"].Sprite,
            ]
        });
        helper.Content.Characters.RegisterCharacterAnimation("slime_mad", new()
        {
            Deck = SlimeDeck.Deck,
            LoopTag = "mad",
            Frames = [
                Sprites["slime_mad_0"].Sprite,
                Sprites["slime_mad_1"].Sprite,
                Sprites["slime_mad_2"].Sprite,
                Sprites["slime_mad_3"].Sprite,
                Sprites["slime_mad_4"].Sprite,
                Sprites["slime_mad_5"].Sprite,
            ]
        });
        helper.Content.Characters.RegisterCharacterAnimation("slime_phone", new()
        {
            Deck = SlimeDeck.Deck,
            LoopTag = "phone",
            Frames = [
                Sprites["slime_phone_0"].Sprite,
                Sprites["slime_phone_1"].Sprite,
                Sprites["slime_phone_2"].Sprite,
                Sprites["slime_phone_3"].Sprite,
                Sprites["slime_phone_4"].Sprite,
                Sprites["slime_phone_5"].Sprite,
            ]
        });
        helper.Content.Characters.RegisterCharacterAnimation("slime_dark", new()
        {
            Deck = SlimeDeck.Deck,
            LoopTag = "dark",
            Frames = [
                Sprites["slime_dark_0"].Sprite,
                Sprites["slime_dark_1"].Sprite,
                Sprites["slime_dark_2"].Sprite,
                Sprites["slime_dark_3"].Sprite,
                Sprites["slime_dark_4"].Sprite,
                Sprites["slime_dark_5"].Sprite,
            ]
        });
        helper.Content.Characters.RegisterCharacterAnimation("slime_sad", new()
        {
            Deck = SlimeDeck.Deck,
            LoopTag = "sad",
            Frames = [
                Sprites["slime_sad_0"].Sprite,
                Sprites["slime_sad_1"].Sprite,
                Sprites["slime_sad_2"].Sprite,
                Sprites["slime_sad_3"].Sprite,
                Sprites["slime_sad_4"].Sprite,
                Sprites["slime_sad_5"].Sprite,
            ]
        });
        helper.Content.Characters.RegisterCharacterAnimation("slime_laugh", new()
        {
            Deck = SlimeDeck.Deck,
            LoopTag = "laugh",
            Frames = [
                Sprites["slime_laugh_0"].Sprite,
                Sprites["slime_laugh_1"].Sprite,
                Sprites["slime_laugh_2"].Sprite,
                Sprites["slime_laugh_3"].Sprite,
                Sprites["slime_laugh_4"].Sprite,
                Sprites["slime_laugh_5"].Sprite,
            ]
        });
        helper.Content.Characters.RegisterCharacterAnimation("slime_nervous", new()
        {
            Deck = SlimeDeck.Deck,
            LoopTag = "nervous",
            Frames = [
                Sprites["slime_nervous_0"].Sprite,
                Sprites["slime_nervous_1"].Sprite,
                Sprites["slime_nervous_2"].Sprite,
                Sprites["slime_nervous_3"].Sprite,
                Sprites["slime_nervous_4"].Sprite,
                Sprites["slime_nervous_5"].Sprite,
            ]
        });
        helper.Content.Characters.RegisterCharacterAnimation("slime_squint", new()
        {
            Deck = SlimeDeck.Deck,
            LoopTag = "squint",
            Frames = [
                Sprites["slime_squint_0"].Sprite,
                Sprites["slime_squint_1"].Sprite,
                Sprites["slime_squint_2"].Sprite,
                Sprites["slime_squint_3"].Sprite,
                Sprites["slime_squint_4"].Sprite,
                Sprites["slime_squint_5"].Sprite,
            ]
        });
        helper.Content.Characters.RegisterCharacterAnimation("slime_crystal", new()
        {
            Deck = SlimeDeck.Deck,
            LoopTag = "crystal",
            Frames = [
                Sprites["slime_crystal_0"].Sprite,
            ]
        });

        // SHIP BLOCK
        var cobraWing = helper.Content.Ships.RegisterPart("cobra_wing", new()
        {
            Sprite = Sprites["CorrosiveCobra_WingLeftSprite"].Sprite
        });
        var cobraCannon = helper.Content.Ships.RegisterPart("cobra_cannon", new()
        {
            Sprite = Sprites["CorrosiveCobra_CannonSprite"].Sprite
        });
        var cobraCockpit = helper.Content.Ships.RegisterPart("cobra_cockpit", new()
        {
            Sprite = Sprites["CorrosiveCobra_CockpitSprite"].Sprite
        });
        var cobraMissiles = helper.Content.Ships.RegisterPart("cobra_missiles", new()
        {
            Sprite = Sprites["CorrosiveCobra_MissileBaySprite"].Sprite
        });
        CobraShip = helper.Content.Ships.RegisterShip("Cobra", new ShipConfiguration()
        {
            Ship = new StarterShip()
            {
                ship = new Ship()
                {
                    hull = 11,
                    hullMax = 11,
                    shieldMaxBase = 4,
                    parts =
                    {
                        new Part
                        {
                            type = PType.wing,
                            skin = cobraWing.UniqueName,
                            damageModifier = PDamMod.none
                        },
                        new Part
                        {
                            type = PType.cannon,
                            skin = cobraCannon.UniqueName,
                            damageModifier = PDamMod.armor
                        },
                        new Part
                        {
                            type = PType.cockpit,
                            skin = cobraCockpit.UniqueName,
                        },
                        new Part
                        {
                            type = PType.missiles,
                            skin = cobraMissiles.UniqueName,
                            damageModifier = PDamMod.weak
                        },
                        new Part
                        {
                            type = PType.wing,
                            skin = cobraWing.UniqueName,
                            flip = true
                        }
                    }
                },
                cards =
                {
                    new CannonColorless(),
                    new DodgeColorless(),
                    new CobraCardCorrosionBlockStarter(),
                    new CobraCardCorrosionShotStarter(),
                },
                artifacts =
                {
                    new ShieldPrep(),
                    new CobraArtifactUnstableTanks()
                }
            },
            ExclusiveArtifactTypes = new HashSet<Type>()
            {
                typeof(CobraArtifactUnstableTanks),
                typeof(CobraArtifactOverdriveTanks),
                typeof(CobraArtifactFuelWalls)
            },

            UnderChassisSprite = Sprites["CorrosiveCobra_ChassisSprite"].Sprite,
            Name = AnyLocalizations.Bind(["ship", "cobra", "name"]).Localize,
            Description = AnyLocalizations.Bind(["ship", "cobra", "description"]).Localize,

        });
        // CARD REGISTRATION BLOCK
        foreach (var cardType in AllCards)
            AccessTools.DeclaredMethod(cardType, nameof(IModdedCard.Register))?.Invoke(null, [package, helper]);

        // ARTIFACT REGISTRATION BLOCK
        foreach (var artifactType in AllArtifacts)
            AccessTools.DeclaredMethod(artifactType, nameof(IModdedArtifact.Register))?.Invoke(null, [helper]);

        // DUO ARTIFACT BLOCK
        if (DuoArtifactsApi is not null)
        {
            foreach (var cardType in DuoCardTypes)
                AccessTools.DeclaredMethod(cardType, nameof(IModdedCard.Register))?.Invoke(null, [package, helper]);

            foreach (var artifactType in DuoArtifactTypes)
                AccessTools.DeclaredMethod(artifactType, nameof(IModdedArtifact.Register))?.Invoke(null, [helper]);
            
            // MODDED DUO BLOCK
            if (SogginsApi is not null)
            {
                foreach (var cardType in DuoSogginsCardTypes)
                    AccessTools.DeclaredMethod(cardType, nameof(IModdedCard.Register))?.Invoke(null, [package, helper]);

                foreach (var artifactType in DuoSogginsArtifactTypes)
                    AccessTools.DeclaredMethod(artifactType, nameof(IModdedArtifact.Register))?.Invoke(null, [helper]);

            }
        }

        // MORE DIFFICULTIES OPTIONS BLOCK
        MoreDifficultiesApi?.RegisterAltStarters(
            deck: SlimeDeck.Deck,
            starterDeck: new StarterDeck
            {
                cards = new()
                {
                    new CobraCardShieldAlternatorA(),
                    new CobraCardFlameShot(),
                    new CobraCardSlimeHug()
                }
            }
        );

        // DIALOGUE INJECTION BLOCK
        _ = new DialogueManager(helper);
    }
}