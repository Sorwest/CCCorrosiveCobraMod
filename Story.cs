using CobaltCoreModding.Definitions.ExternalItems;
using CobaltCoreModding.Definitions.ModContactPoints;

namespace CorrosiveCobra
{
    public partial class Manifest
    {
        public void LoadManifest(IStoryRegistry storyRegistry)
        {
            var SlimeWho = "Sorwest.CorrosiveCobra.CobraDeck";
            var DaveWho = "rft.Dave.DaveDeck";
            var JohannaWho = "JohannaTheTrucker.JohannaDeck";
            var NolaWho = "Mezz.TwosCompany.NolaDeck";
            var IsabelleWho = "Mezz.TwosCompany.IsabelleDeck";
            var IlyaWho = "Mezz.TwosCompany.IlyaDeck";
            var SogginsWho = "Shockah.Soggins.Deck.Soggins";
            var PhilipWho = "clay.PhilipTheMechanic.PhilipDeck";
            // ================ 
            // MID COMBAT SHOUTS
            // ================
            {
                //SlimeHeatIncrease_Multi
                {
                    var SlimeHeatIncrease_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeHeatIncrease_Multi0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            minTurnsThisCombat = 2,
                            lastTurnPlayerStatuses = new HashSet<Status>()
                            {
                                Status.heat
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "Oh, my suit is melting. Cool.",
                                LoopTag = "laugh",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeHeatIncrease_Multi_0);
                }
                //SlimeWeMissedOopsie_Multi
                {
                    {
                        var SlimeWeMissedOopsie_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeWeMissedOopsie_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            playerShotJustMissed = true,
                            oncePerCombat = true,
                            doesNotHaveArtifacts = new HashSet<string>()
                            {
                                "Recalibrator",
                                "GrazerBeam",
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "Was that calculated?",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeWeMissedOopsie_Multi_0);
                    }
                    {
                        var SlimeWeMissedOopsie_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeWeMissedOopsie_Multi_1",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            playerShotJustMissed = true,
                            oncePerCombat = true,
                            doesNotHaveArtifacts = new HashSet<string>()
                            {
                                "Recalibrator",
                                "GrazerBeam",
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "Uhh...",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeWeMissedOopsie_Multi_1);
                    }
                    {
                        var SlimeWeMissedOopsie_Multi_2 = new ExternalStory("CorrosiveCobra.Story.SlimeWeMissedOopsie_Multi_2",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            playerShotJustMissed = true,
                            oncePerCombat = true,
                            doesNotHaveArtifacts = new HashSet<string>()
                            {
                                "Recalibrator",
                                "GrazerBeam",
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "I hate to say it, but we missed.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeWeMissedOopsie_Multi_2);
                    }
                    {
                        var SlimeWeMissedOopsie_Multi_3 = new ExternalStory("CorrosiveCobra.Story.SlimeWeMissedOopsie_Multi_3",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            playerShotJustMissed = true,
                            oncePerCombat = true,
                            doesNotHaveArtifacts = new HashSet<string>()
                            {
                                "Recalibrator",
                                "GrazerBeam",
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "Hm... Let me get the manual.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeWeMissedOopsie_Multi_3);
                    }
                    {
                        var SlimeWeMissedOopsie_Multi_4 = new ExternalStory("CorrosiveCobra.Story.SlimeWeMissedOopsie_Multi_4",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            playerShotJustMissed = true,
                            oncePerCombat = true,
                            doesNotHaveArtifacts = new HashSet<string>()
                            {
                                "Recalibrator",
                                "GrazerBeam",
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "Where's the auto-aim?",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeWeMissedOopsie_Multi_4);
                    }
                }
                //SlimeWeDontOverlapWithEnemyAtAll_Multi
                {
                    {
                        var SlimeWeDontOverlapWithEnemyAtAll_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDontOverlapWithEnemyAtAll_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            shipsDontOverlapAtAll = true,
                            nonePresent = new HashSet<string>()
                            {
                                "crab",
                                "scrap"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "Let's uh... tactically retreat.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeWeDontOverlapWithEnemyAtAll_Multi_0);
                    }
                    {
                        var SlimeWeDontOverlapWithEnemyAtAll_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDontOverlapWithEnemyAtAll_Multi_1",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            shipsDontOverlapAtAll = true,
                            nonePresent = new HashSet<string>()
                            {
                                "crab",
                                "scrap"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "What's over here?",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeWeDontOverlapWithEnemyAtAll_Multi_1);
                    }
                    {
                        var SlimeWeDontOverlapWithEnemyAtAll_Multi_2 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDontOverlapWithEnemyAtAll_Multi_2",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            shipsDontOverlapAtAll = true,
                            nonePresent = new HashSet<string>()
                            {
                                "crab",
                                "scrap"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "Farewell.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeWeDontOverlapWithEnemyAtAll_Multi_2);
                    }
                }
                //SlimeWeDontOverlapWithEnemyAtAllButWeDoHaveASeekerToDealWith_Multi
                {
                    {
                        var SlimeWeDontOverlapWithEnemyAtAllButWeDoHaveASeekerToDealWith_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDontOverlapWithEnemyAtAllButWeDoHaveASeekerToDealWith_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            shipsDontOverlapAtAll = true,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "NoOverlapBetweenShipsSeeker"
                            },
                            anyDronesHostile = new HashSet<string>()
                            {
                                "missile_seeker"
                            },
                            nonePresent = new HashSet<string>()
                            {
                                "crab"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "We gotta deal with that Seeker somehow.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeWeDontOverlapWithEnemyAtAllButWeDoHaveASeekerToDealWith_Multi_0);
                    }
                }
                //SlimeDuo_AboutToDieAndLoop_Multi
                //MODDED TO DO
                {
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "dizzy"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "Nearly time to time loop again, huh.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "dizzy",
                                LoopTag = "frown",
                                What = "Nearly time to ti-- Ah... Huh.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_0);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_1",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "dizzy"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "frown",
                                What = "Nearly time to time loop again, huh.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "Nearly time to ti-- Ah. Huh. Yeah.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_1);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_11 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_11",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "riggs"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "Time loop time?",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "riggs",
                                What = "Hey, don't give up yet!"
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_11);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_12 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_12",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "peri"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "We almost had it.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "peri",
                                LoopTag = "panic",
                                What = "Enough crying! Everyone evacuate, I'll take over!"
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_12);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_13 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_13",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "peri"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "peri",
                                LoopTag = "shy",
                                What = "This was a good try. Will you fight with us next time?"
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "I hope so.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_13);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_14 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_14",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "goat"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "It's looking... kinda bad.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "goat",
                                What ="For sure!"
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_14);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_15 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_15",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "goat"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "goat",
                                What = "GG."
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "LMAO.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_15);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_16 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_16",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "eunice"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "I can patch the ship. I can!",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "eunice",
                                What = "Give it up. Just enjoy the view."
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_16);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_17 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_17",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "eunice"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "eunice",
                                LoopTag = "sly",
                                What = "We're going down."
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "We had fun, though!",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_17);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_18 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_18",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            requiredScenes = new HashSet<string>()
                            {
                                "Dizzy_Memory_2",
                            },
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "hacker"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "I had a whole new campaign planned out.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "hacker",
                                LoopTag = "smile",
                                What = "Next loop we gotta run it."
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_18);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_19 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_19",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "hacker"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "Next time's the charm.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "hacker",
                                What = "Well played."
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_19);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_2 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_2",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "hacker"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "hacker",
                                What = "Game over, man."
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "Who should I give MVP?",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_2);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_21 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_21",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "shard"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "Is this it?",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "shard",
                                LoopTag = "paws",
                                What = "We can still do this!"
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_21);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_22 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_22",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "shard"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "shard",
                                LoopTag = "relaxed",
                                What = "Hey, what are we gonna do after this?"
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "Trying to focus here, Books!",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_22);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_23 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_23",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "comp"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "Loop time?",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                LoopTag = "transition",
                                What = "Loop time."
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_23);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_24 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_24",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "comp"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                LoopTag = "grumpy",
                                What = "Reset time."
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "mad",
                                What = "Maybe we can still do this!",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_24);
                    }
                    //MODDED CHARACTERS
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_25 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_25",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                             "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                DaveWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "I don't see a way out.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = DaveWho,
                                What = "The house of cards comes tumbling down.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_25);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_26 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_26",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                DaveWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = DaveWho,
                                What = "We need to find a backdoor soon or we're done for.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "We can do something, surely?",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_26);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_27 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_27",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                JohannaWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "Oh. Oh, this is not good.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = JohannaWho,
                                LoopTag = "sad",
                                What = "We're gonna vanish soon, guys.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_27);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_28 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_28",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                JohannaWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = JohannaWho,
                                LoopTag = "reminisce",
                                What = "Guess we're doing Plan Z.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "This one's a wash.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_28);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_29 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_29",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                SogginsWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "Ship is in critical condition, is everyone alri--",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SogginsWho,
                                LoopTag = "smug-2",
                                What = "Please spare me! I'll do anything!",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_29);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_30 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_30",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                SogginsWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SogginsWho,
                                LoopTag = "smug-3",
                                What = "Do something slime boy! I'm too cute to die!",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "squint",
                                What = "...",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_30);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_31 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_31",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                IlyaWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "phone",
                                What = "Ripperonni.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = IlyaWho,
                                LoopTag = "happy",
                                What = "Going down in a blaze.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_31);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_32 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_32",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                IsabelleWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "phone",
                                What = "Ripperonni.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = IsabelleWho,
                                LoopTag = "shocked",
                                What = "I don't think this is a good place or time to joke around.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_32);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_33 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_33",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                NolaWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "phone",
                                What = "Ripperonni.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = NolaWho,
                                LoopTag = "smug",
                                What = "I'm getting one with pineapple first thing next time.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_33);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_34 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_34",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                NolaWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "phone",
                                What = "Ripperonni.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = NolaWho,
                                LoopTag = "smug",
                                What = "I'm getting one with pineapple first thing next time.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_34);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_35 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_35",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                NolaWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "phone",
                                What = "Ripperonni.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = NolaWho,
                                LoopTag = "smug",
                                What = "I'm getting one with pineapple first thing next time.",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_35);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_36 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_36",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                PhilipWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = PhilipWho,
                                LoopTag = "excited",
                                What = "We're exploding 80% of the time here.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What =  "Don't give up!",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_36);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_37 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_37",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            once = true,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            requiredScenes = new HashSet<string>()
                            {
                                "Dizzy_Memory_2"
                            },
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                PhilipWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "This gives me a campaign idea for next loop.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = PhilipWho,
                                What =  "What's that and can I play?",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_37);
                    }
                    {
                        var SlimeDuo_AboutToDieAndLoop_Multi_38 = new ExternalStory("CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_38",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            enemyShotJustHit = true,
                            maxHull = 2,
                            requiredScenes = new HashSet<string>()
                            {
                                "CorrosiveCobra.Story.SlimeDuo_AboutToDieAndLoop_Multi_35"
                            },
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "aboutToDie"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                PhilipWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "This gives me a campaign idea for next loop.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = PhilipWho,
                                What =  "I made a new badass cannoneer, can I play it next time?",
                            },
                        });
                        storyRegistry.RegisterStory(SlimeDuo_AboutToDieAndLoop_Multi_38);
                    }
                }
                //SlimeBanditThreats_Multi
                {
                    var injectDialogue0 = new ExternalStoryInjector("BanditThreats_Multi_0",
                        ExternalStoryInjector.QuickInjection.Beginning, 1,
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "Oh! Tasty!",
                            },
                        });
                    storyRegistry.RegisterInjector(injectDialogue0);
                    
                }
                //SlimeBatboyKeepsTalking_Multi
                {
                    var injectDialogue0 = new ExternalStoryInjector("BatboyKeepsTalking_Multi_0",
                        ExternalStoryInjector.QuickInjection.Beginning, 1,
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "Nice! I have my own Cherenkov radiation lamp!"
                            },
                        });
                    storyRegistry.RegisterInjector(injectDialogue0);
                }
                //SlimeTentacleThreats_Multi
                // (TO FIX)
                {
                    var SlimeTentacleThreats_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeTentacleThreats_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            priority = true,
                            turnStart = true,
                            maxTurnsThisCombat = 3,
                            allPresent = new HashSet<string>()
                            {
                            SlimeWho,
                            "tentacle"
                            }
                        },
                        new List<object>()
                        {
                        new ExternalStory.ExternalSaySwitch(new List<ExternalStory.ExternalSay>
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "tentacle",
                                What = "GLARP"
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "tentacle",
                                What = "GLORP"
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "tentacle",
                                What = "GLURP"
                            },
                        }),
                        new ExternalStory.ExternalSaySwitch(new List<ExternalStory.ExternalSay>
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "Haha. You're funny."
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "Ah... aha... Hm... I see!"
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "To shreds you say?"
                            },
                        }),
                        });
                    storyRegistry.RegisterStory(SlimeTentacleThreats_Multi_0);
                }
                //SlimeTentacleThreatsOnShellBreak_Multi
                // (TO FIX)
                {
                    var SlimeTentacleThreatsOnShellBreak_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeTentacleThreatsOnShellBreak_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            priority = true,
                            turnStart = true,
                            enemyIntent = "cracked",
                            allPresent = new HashSet<string>()
                            {
                            SlimeWho,
                            "tentacle"
                            },
                            oncePerRunTags = new HashSet<string>()
                            {
                                "youCrackedTheStarnacleShellBro"
                            },
                        },
                        new List<object>()
                        {
                        new ExternalStory.ExternalSaySwitch(new List<ExternalStory.ExternalSay>
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "tentacle",
                                What = "GLARP GLORP!!"
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "tentacle",
                                What = "GLORP GLURP!!"
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "tentacle",
                                What = "GLURP GLARP!!"
                            },
                        }),
                        new ExternalStory.ExternalSaySwitch(new List<ExternalStory.ExternalSay>
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "YES I KNOW RIGHT?!"
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "No, not really."
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "Oh wow. That's... That's so sad."
                            },
                        }),
                        });
                    storyRegistry.RegisterStory(SlimeTentacleThreatsOnShellBreak_Multi_0);
                }
                //SlimeBlockedAnEnemyAttackWithArmor_Multi
                {
                    {
                        var SlimeBlockedAnEnemyAttackWithArmor_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeBlockedAnEnemyAttackWithArmor_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                enemyShotJustHit = true,
                                minDamageBlockedByPlayerArmorThisTurn = 1,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "WowArmorISPrettyCoolHuh"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                                new List<object>()
                                {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "Huh, this armor is great!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeBlockedAnEnemyAttackWithArmor_Multi_0);
                    }
                    {
                        var SlimeBlockedAnEnemyAttackWithArmor_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeBlockedAnEnemyAttackWithArmor_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                enemyShotJustHit = true,
                                minDamageBlockedByPlayerArmorThisTurn = 1,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "WowArmorISPrettyCoolHuh"
                                },
                                allPresent = new HashSet<string>()
                                {
                                SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "Nice try, buddy. That was armored!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeBlockedAnEnemyAttackWithArmor_Multi_1);
                    }
                    {
                        var SlimeBlockedAnEnemyAttackWithArmor_Multi_2 = new ExternalStory("CorrosiveCobra.Story.SlimeBlockedAnEnemyAttackWithArmor_Multi_2",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                enemyShotJustHit = true,
                                minDamageBlockedByPlayerArmorThisTurn = 1,
                                oncePerRun = true,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "WowArmorISPrettyCoolHuh"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Maybe we should armor up the kitchen too.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeBlockedAnEnemyAttackWithArmor_Multi_2);
                    }
                }
                //SlimeBlockedALotOfAttacksWithArmor_Multi
                {
                    var SlimeBlockedALotOfAttacksWithArmor_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeBlockedALotOfAttacksWithArmor_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            enemyShotJustHit = true,
                            minDamageBlockedByPlayerArmorThisTurn = 3,
                            oncePerRun = true,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "YowzaThatWasALOTofArmorBlock"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "Wait, you targeted the armor? Why?",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeBlockedALotOfAttacksWithArmor_Multi_0);
                }
                //SlimeThatsALotOfDamageToThem_Multi
                {
                    var SlimeThatsALotOfDamageToThem_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeThatsALotOfDamageToThem_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            playerShotJustHit = true,
                            minDamageDealtToEnemyThisTurn = 10,
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "We are just CRUSHING them now!",
                                LoopTag = "laugh"
                            },
                        });
                    storyRegistry.RegisterStory(SlimeThatsALotOfDamageToThem_Multi_0);
                }
                //SlimeThatsALotOfDamageToUs_Multi
                {
                    var SlimeThatsALotOfDamageToUs_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeThatsALotOfDamageToUs_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            enemyShotJustHit = true,
                            minDamageDealtToPlayerThisTurn = 3,
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "Ah! Did that hit my room?",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeThatsALotOfDamageToUs_Multi_0);
                }
                {
                    var SlimeThatsALotOfDamageToUs_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeThatsALotOfDamageToUs_Multi_1",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            enemyShotJustHit = true,
                            minDamageDealtToPlayerThisTurn = 3,
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "dizzy",
                                "riggs"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "dizzy",
                                LoopTag = "intense",
                                What = "That looked like a heavy blow.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "riggs",
                                LoopTag = "nervous",
                                What = "Ah! My hidden boba room!",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "squint",
                                What = "You had even more boba?",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeThatsALotOfDamageToUs_Multi_1);
                }
                {
                    var SlimeThatsALotOfDamageToUs_Multi_2 = new ExternalStory("CorrosiveCobra.Story.SlimeThatsALotOfDamageToUs_Multi_2",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            enemyShotJustHit = true,
                            minDamageDealtToPlayerThisTurn = 3,
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "dizzy",
                                "peri"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "peri",
                                LoopTag = "mad",
                                What = "Dizzy, have you seen Dizzy?!",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "Oh man, I haven't, that was a pretty big hit.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "dizzy",
                                LoopTag = "intense",
                                What = "I'm here, I'm here! I'm fine.",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeThatsALotOfDamageToUs_Multi_2);
                }
                {
                    var SlimeThatsALotOfDamageToUs_Multi_3 = new ExternalStory("CorrosiveCobra.Story.SlimeThatsALotOfDamageToUs_Multi_3",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            enemyShotJustHit = true,
                            minDamageDealtToPlayerThisTurn = 3,
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "dizzy",
                                "eunice"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "Heavy hit received. Raising the yellow alert.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "dizzy",
                                LoopTag = "intense",
                                What = "Systems all working stll. Keeping the yellow alert up.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "eunice",
                                LoopTag = "sly",
                                What = "You're overreacting.",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeThatsALotOfDamageToUs_Multi_3);
                }
                {
                    var SlimeThatsALotOfDamageToUs_Multi_4 = new ExternalStory("CorrosiveCobra.Story.SlimeThatsALotOfDamageToUs_Multi_4",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            enemyShotJustHit = true,
                            minDamageDealtToPlayerThisTurn = 3,
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                DaveWho,
                                JohannaWho
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "Ouch, I stubbed my toe.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = JohannaWho,
                                LoopTag = "scared",
                                What = "Not good.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = DaveWho,
                                LoopTag = "squint",
                                What = "You have toes?",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeThatsALotOfDamageToUs_Multi_4);
                }
                {
                    var SlimeThatsALotOfDamageToUs_Multi_5 = new ExternalStory("CorrosiveCobra.Story.SlimeThatsALotOfDamageToUs_Multi_5",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            enemyShotJustHit = true,
                            minDamageDealtToPlayerThisTurn = 3,
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                PhilipWho,
                                SogginsWho
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SogginsWho,
                                LoopTag = "smug-3",
                                What = "Someone save me, please.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "squint",
                                What = "...",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = PhilipWho,
                                LoopTag = "squint",
                                What = "Toad Of The Year.",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeThatsALotOfDamageToUs_Multi_5);
                }
                //SlimeCrewWentMissing_Multi
                {
                    {
                        var SlimeCrewWentMissing_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeCrewWentMissing_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                priority = true,
                                oncePerRun = true,
                                lastTurnPlayerStatuses = new HashSet<Status>()
                                {
                                    Status.missingDizzy,
                                },
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "dizzyWentMissing"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "squint",
                                    What = "Huh? Where did I go? I mean, where did the other I go?",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeCrewWentMissing_Multi_0);
                    }
                    {
                        var SlimeCrewWentMissing_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeCrewWentMissing_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                priority = true,
                                oncePerRun = true,
                                lastTurnPlayerStatuses = new HashSet<Status>()
                                {
                                    Status.missingPeri,
                                },
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "periWentMissing"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "sad",
                                    What = "Huh? Huh? Peri? PERI?!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeCrewWentMissing_Multi_1);
                    }
                    {
                        var SlimeCrewWentMissing_Multi_2 = new ExternalStory("CorrosiveCobra.Story.SlimeCrewWentMissing_Multi_2",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                priority = true,
                                oncePerRun = true,
                                lastTurnPlayerStatuses = new HashSet<Status>()
                                {
                                    Status.missingRiggs,
                                },
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "riggsWentMissing"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "mad",
                                    What = "Did you take Riggs?! Give her back!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeCrewWentMissing_Multi_2);
                    }
                    {
                        var SlimeCrewWentMissing_Multi_3 = new ExternalStory("CorrosiveCobra.Story.SlimeCrewWentMissing_Multi_3",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                priority = true,
                                oncePerRun = true,
                                lastTurnPlayerStatuses = new HashSet<Status>()
                                {
                                    Status.missingIsaac,
                                },
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "isaacWentMissing"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "mad",
                                    What = "ISAAC!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeCrewWentMissing_Multi_3);
                    }
                    {
                        var SlimeCrewWentMissing_Multi_4 = new ExternalStory("CorrosiveCobra.Story.SlimeCrewWentMissing_Multi_4",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                priority = true,
                                oncePerRun = true,
                                lastTurnPlayerStatuses = new HashSet<Status>()
                                {
                                    Status.missingDrake,
                                },
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "drakeWentMissing"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "mad",
                                    What = "Drake?! What did you do to Drake?!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeCrewWentMissing_Multi_4);
                    }
                    {
                        var SlimeCrewWentMissing_Multi_5 = new ExternalStory("CorrosiveCobra.Story.SlimeCrewWentMissing_Multi_5",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                priority = true,
                                oncePerRun = true,
                                lastTurnPlayerStatuses = new HashSet<Status>()
                                {
                                    Status.missingMax,
                                },
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "maxWentMissing"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "sad",
                                    What = "Max!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeCrewWentMissing_Multi_5);
                    }
                    {
                        var SlimeCrewWentMissing_Multi_6 = new ExternalStory("CorrosiveCobra.Story.SlimeCrewWentMissing_Multi_6",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                priority = true,
                                oncePerRun = true,
                                lastTurnPlayerStatuses = new HashSet<Status>()
                                {
                                    Status.missingBooks,
                                },
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "booksWentMissing"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "dark",
                                    What = "GIVE BOOKS BACK.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeCrewWentMissing_Multi_6);
                    }
                    {
                        var SlimeCrewWentMissing_Multi_7 = new ExternalStory("CorrosiveCobra.Story.SlimeCrewWentMissing_Multi_7",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                priority = true,
                                oncePerRun = true,
                                lastTurnPlayerStatuses = new HashSet<Status>()
                                {
                                    Status.missingCat,
                                },
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "CatWentMissing"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "sad",
                                    What = "Cat! Oh no?!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeCrewWentMissing_Multi_7);
                    }
                }
                //SlimeEmptyHandWithEnergy_Multi
                {
                    {
                        var SlimeEmptyHandWithEnergy_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeEmptyHandWithEnergy_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                handEmpty = true,
                                minEnergy = 1,
                                allPresent = new HashSet<string>()
                                    {
                                        SlimeWho
                                    }
                            },
                                new List<object>()
                                {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "squint",
                                What = "Can we, like, not restrict ourselves to a metaphorical draw cycle?",
                            },
                            });
                        storyRegistry.RegisterStory(SlimeEmptyHandWithEnergy_Multi_0);
                    }
                    {
                        var SlimeEmptyHandWithEnergy_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeEmptyHandWithEnergy_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                handEmpty = true,
                                minEnergy = 1,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "nervous",
                                    What = "All done a bit early, huh?",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeEmptyHandWithEnergy_Multi_1);
                    }
                }
                //EnemyHasBrittle_Multi
                {
                    var EnemyHasBrittle_Multi_0 = new ExternalStory("CorrosiveCobra.Story.EnemyHasBrittle_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            enemyHasBrittlePart = true,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "yelledAboutBrittle"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "Let's lock-on to that brittle spot!",
                            },
                        });
                    storyRegistry.RegisterStory(EnemyHasBrittle_Multi_0);
                }
                //EnemyHasWeakness_Multi
                {
                    var EnemyHasWeakness_Multi_0 = new ExternalStory("CorrosiveCobra.Story.EnemyHasWeakness_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            enemyHasWeakPart = true,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "yelledAboutWeakness"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "Is that a weak spot? Nice!",
                            },
                        });
                    storyRegistry.RegisterStory(EnemyHasWeakness_Multi_0);
                }
                //SlimeJustHitGeneric_Multi
                {
                    {
                        var SlimeJustHitGeneric_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeJustHitGeneric_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 1,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "Nice shot.",
                            },
                            });
                        storyRegistry.RegisterStory(SlimeJustHitGeneric_Multi_0);
                    }
                    {
                        var SlimeJustHitGeneric_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeJustHitGeneric_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 1,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "On target.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeJustHitGeneric_Multi_1);
                    }
                    {
                        var SlimeJustHitGeneric_Multi_2 = new ExternalStory("CorrosiveCobra.Story.SlimeJustHitGeneric_Multi_2",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 1,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Nicely done.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeJustHitGeneric_Multi_2);
                    }
                    {
                        var SlimeJustHitGeneric_Multi_3 = new ExternalStory("CorrosiveCobra.Story.SlimeJustHitGeneric_Multi_3",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 1,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Got them.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeJustHitGeneric_Multi_3);
                    }
                }
                //SlimeJustPlayedADraculaCard_Multi
                {
                    var SlimeJustPlayedADraculaCard_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeJustPlayedADraculaCard_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            whoDidThat = Deck.dracula,
                            oncePerRun = true,
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "Thanks, Dracula!",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeJustPlayedADraculaCard_Multi_0);
                }
                //SlimeLookOutMissile_Multi
                {
                    var SlimeLookOutMissile_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeLookOutMissile_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            priority = true,
                            oncePerRun = true,
                            oncePerRunTags = new HashSet<string>()
                            {
                                "goodMissileAdvice"
                            },
                            anyDronesHostile = new HashSet<string>()
                            {
                                "missile_normal",
                                "missile_heavy",
                                "missile_corrode",
                                "missile_seeker",
                                "missile_breacher"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "That missile looks nasty.",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeLookOutMissile_Multi_0);
                }
                //SlimeOverheatDrakeFix_Multi
                {
                    var SlimeOverheatDrakeFix_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeOverheatDrakeFix_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRunTags = new HashSet<string>()
                            {
                                "OverheatDrakeFix"
                            },
                            whoDidThat = Deck.eunice,
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "eunice"
                            }
                        },
                        new List<object>()
                        {
                        new ExternalStory.ExternalSaySwitch(new List<ExternalStory.ExternalSay>
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "Did you turn on the AC?"
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "Oh. Nice save, Drake."
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "I liked being liquid-er."
                            },
                        }),
                        });
                    storyRegistry.RegisterStory(SlimeOverheatDrakeFix_Multi_0);
                }
                //SlimeShopKeepBattleInsult
                {
                    var SlimeShopKeepBattleInsult_0 = new ExternalStory("CorrosiveCobra.Story.SlimeShopKeepBattleInsult_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            turnStart = true,
                            priority = true,
                            oncePerRunTags = new HashSet<string>()
                            {
                                "ShopkeepAboutToDestroyYou"
                            },
                            enemyIntent = "shopkeepAttack",
                            allPresent = new HashSet<string>()
                            {
                                "nerd"
                            }
                        },
                        new List<object>()
                        {
                        new ExternalStory.ExternalSaySwitch(new List<ExternalStory.ExternalSay>
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "sad",
                                What = "I see..."
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "dark",
                                What = "Loop time, then."
                            },
                        }),
                        });
                    storyRegistry.RegisterStory(SlimeShopKeepBattleInsult_0);
                }
                //SlimeVeryManyTurns_Multi
                {
                    {
                        var SlimeVeryManyTurns_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeVeryManyTurns_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                minTurnsThisCombat = 20,
                                turnStart = true,
                                oncePerRun = true,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "veryManyTurns"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "mad",
                                    What = "Why are we still here?",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeVeryManyTurns_Multi_0);
                    }
                    {
                        var SlimeVeryManyTurns_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeVeryManyTurns_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                minTurnsThisCombat = 20,
                                turnStart = true,
                                oncePerRun = true,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "veryManyTurns"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "sad",
                                    What = "We're really doing 18 hour shifts, huh.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeVeryManyTurns_Multi_1);
                    }
                    {
                        var SlimeVeryManyTurns_Multi_2 = new ExternalStory("CorrosiveCobra.Story.SlimeVeryManyTurns_Multi_2",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                minTurnsThisCombat = 20,
                                turnStart = true,
                                oncePerRun = true,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "veryManyTurns"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Dinner's ready. Pause the loop, son.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeVeryManyTurns_Multi_2);
                    }
                }
                //SlimeWeAreCorroded_Multi
                {
                    {
                        var SlimeWeAreCorroded_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeWeAreCorroded_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lastTurnPlayerStatuses = new HashSet<Status>()
                                {
                                    Status.corrode
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "Oh? We're corroded! Nice.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeAreCorroded_Multi_0);
                    }
                    {
                        var SlimeWeAreCorroded_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeWeAreCorroded_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lastTurnPlayerStatuses = new HashSet<Status>()
                                {
                                    Status.corrode
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "I love poison, but the ship not so much.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeAreCorroded_Multi_1);
                    }
                    {
                        var SlimeWeAreCorroded_Multi_2 = new ExternalStory("CorrosiveCobra.Story.SlimeWeAreCorroded_Multi_2",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lastTurnPlayerStatuses = new HashSet<Status>()
                                {
                                    Status.corrode
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "Oooh! The controls are flashing green, so techy!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeAreCorroded_Multi_2);
                    }
                }
                //SlimeArtifactGeminiCore_Multi
                {
                    {
                        var SlimeArtifactGeminiCore_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactGeminiCore_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                hasArtifacts = new HashSet<string>()
                                {
                                    "GeminiCore"
                                },
                                oncePerRunTags = new HashSet<string>()
                                {
                                    "GeminiCore"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                                nonePresent = new HashSet<string>()
                                {
                                    "dizzy"
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "Oooh! Nice colors. Where's the green side?",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactGeminiCore_Multi_0);
                    }
                    {
                        var injectDialogue0 = new ExternalStoryInjector("ArtifactGeminiCore_Multi_4",
                            ExternalStoryInjector.QuickInjection.Beginning, 1,
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "I'm a green guy.",
                                },
                            });
                        storyRegistry.RegisterInjector(injectDialogue0);
                    }
                }
                //SlimeArtifactTiderunner_Multi
                {
                    {
                        var SlimeArtifactTiderunner_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactTiderunner_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                turnStart = true,
                                oncePerRun = true,
                                maxTurnsThisCombat = 1,
                                hasArtifacts = new HashSet<string>()
                                {
                                    "TideRunner"
                                },
                                oncePerRunTags = new HashSet<string>()
                                {
                                    "TideRunner"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "The wood grain in the dorms is a really nice touch. What is this, birch?",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactTiderunner_Multi_0);
                    }
                    {
                        var SlimeArtifactTiderunner_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactTiderunner_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                turnStart = true,
                                oncePerRun = true,
                                maxTurnsThisCombat = 1,
                                hasArtifacts = new HashSet<string>()
                                {
                                    "TideRunner"
                                },
                                oncePerRunTags = new HashSet<string>()
                                {
                                    "TideRunner"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "Oh, I love this ship. It bounces around like me!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactTiderunner_Multi_1);
                    }
                }
                //SlimeArtifactTridimensionalCockpit_Multi
                {
                    {
                        var SlimeArtifactTridimensionalCockpit_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactTridimensionalCockpit_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                turnStart = true,
                                oncePerRun = true,
                                maxTurnsThisCombat = 1,
                                hasArtifacts = new HashSet<string>()
                                {
                                    "TridimensionalCockpit"
                                },
                                oncePerRunTags = new HashSet<string>()
                                {
                                 "TridimensionalCockpit"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "squint",
                                    What = "So like, what would a tetradimensional Cockpit even LOOK like?",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactTridimensionalCockpit_Multi_0);
                    }
                }
                //SlimeManyTurns_Multi
                {
                    {
                        var SlimeManyTurns_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeManyTurns_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                minTurnsThisCombat = 9,
                                turnStart = true,
                                oncePerRun = true,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "manyTurns"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "phone",
                                    What = "No rush. I'll order pizza then.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeManyTurns_Multi_0);
                    }
                    {
                        var SlimeManyTurns_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeManyTurns_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                minTurnsThisCombat = 9,
                                turnStart = true,
                                oncePerRun = true,
                                requiredScenes = new HashSet<string>()
                                {
                                    "Dizzy_Memory_2"
                                },
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "manyTurns"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "Anyone up for Checkers?",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeManyTurns_Multi_1);
                    }
                }
                //SlimeOneHitPointThisIsFine_Multi
                {
                    {
                        var SlimeOneHitPointThisIsFine_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeOneHitPointThisIsFine_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                enemyShotJustHit = true,
                                maxHull = 1,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "aboutToDie"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "phone",
                                    What = "Hi, yes... Yes... Extra pepperoni, yes.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeOneHitPointThisIsFine_Multi_0);
                    }
                    {
                        var SlimeOneHitPointThisIsFine_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeOneHitPointThisIsFine_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                enemyShotJustHit = true,
                                maxHull = 1,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "aboutToDie"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "This is fine.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeOneHitPointThisIsFine_Multi_1);
                    }
                    {
                        var injectDialogue0 = new ExternalStoryInjector("OneHitPointThisIsFine_Multi_4",
                            ExternalStoryInjector.QuickInjection.Beginning, 1,
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Not at all!",
                                },
                            });
                        storyRegistry.RegisterInjector(injectDialogue0);
                    }
                }
                //SlimeWeDidOverFiveDamage_Multi
                //MODDED
                {
                    {
                        var SlimeWeDidOverFiveDamage_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDidOverFiveDamage_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 6,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "dark",
                                    What = "Weak.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeDidOverFiveDamage_Multi_0);
                    }
                    {
                        var SlimeWeDidOverFiveDamage_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDidOverFiveDamage_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 6,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "riggs"
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Wow! That was insane!",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "riggs",
                                    What = "Do it again!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeDidOverFiveDamage_Multi_1);
                    }
                    {
                        var SlimeWeDidOverFiveDamage_Multi_2 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDidOverFiveDamage_Multi_2",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 6,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "riggs",
                                    "peri"
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Didn't know our cannons could handle that.",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "peri",
                                    LoopTag = "shy",
                                    What = "...",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "riggs",
                                    What = "YEAH! Take that, loser!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeDidOverFiveDamage_Multi_2);
                    }
                    {
                        var SlimeWeDidOverFiveDamage_Multi_3 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDidOverFiveDamage_Multi_3",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 6,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "goat"
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "goat",
                                    What = "Nice shot!",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Yeah!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeDidOverFiveDamage_Multi_3);
                    }
                    {
                        var SlimeWeDidOverFiveDamage_Multi_4 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDidOverFiveDamage_Multi_4",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 6,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "eunice"
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "eunice",
                                    What = "THAT's the spirit! Keep it up!",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Wow.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeDidOverFiveDamage_Multi_4);
                    }
                    {
                        var SlimeWeDidOverFiveDamage_Multi_5 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDidOverFiveDamage_Multi_5",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 6,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "hacker"
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Good job, everyone.",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "hacker",
                                    What = "Rolled a 19.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeDidOverFiveDamage_Multi_5);
                    }
                    {
                        var SlimeWeDidOverFiveDamage_Multi_6 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDidOverFiveDamage_Multi_6",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 6,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "shard"
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "phone",
                                    What = "A serving of humble pie, coming right up!",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "shard",
                                    LoopTag = "paws",
                                    What = "Oh, oh! Can you get me a pretzel?!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeDidOverFiveDamage_Multi_6);
                    }
                    {
                        var SlimeWeDidOverFiveDamage_Multi_7 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDidOverFiveDamage_Multi_7",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 6,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "comp"
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "comp",
                                    LoopTag = "transition",
                                    What = "Successful attack. Enemy will be finished soon.",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "That was huge.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeDidOverFiveDamage_Multi_7);
                    }
                    //MODDED CHARACTERS
                    {
                        var SlimeWeDidOverFiveDamage_Multi_8 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDidOverFiveDamage_Multi_8",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 6,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    DaveWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = DaveWho,
                                    What = "Lady Luck is on our side today!",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Great job.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeDidOverFiveDamage_Multi_8);
                    }
                    {
                        var SlimeWeDidOverFiveDamage_Multi_9 = new ExternalStory("CorrosiveCobra.Story.SlimeWeDidOverFiveDamage_Multi_9",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                playerShotJustHit = true,
                                minDamageDealtToEnemyThisAction = 6,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    JohannaWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = JohannaWho,
                                    What = "That's some big damage!",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Wow.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeDidOverFiveDamage_Multi_9);
                    }
                }
                //SlimeArtifactRecalibrator_Multi
                {
                    {
                        var SlimeArtifactRecalibrator_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactRecalibrator_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                playerShotJustMissed = true,
                                hasArtifacts = new HashSet<string>()
                                {
                                    "Recalibrator"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Ha! Joke's on you, this was the plan all along!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactRecalibrator_Multi_0);
                    }
                    {
                        var SlimeArtifactRecalibrator_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactRecalibrator_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                playerShotJustMissed = true,
                                hasArtifacts = new HashSet<string>()
                                {
                                    "Recalibrator"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Missed. Recalibrating.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactRecalibrator_Multi_1);
                    }
                }
                //SlimeHandOnlyHasTrashCards_Multi
                {
                    {
                        var SlimeHandOnlyHasTrashCards_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeHandOnlyHasTrashCards_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                handFullOfTrash = true,
                                oncePerRun = true,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "handOnlyHasTrashCards"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Okay, maybe it was a bad idea to turn off the roomba.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeHandOnlyHasTrashCards_Multi_0);
                    }
                    {
                        var SlimeHandOnlyHasTrashCards_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeHandOnlyHasTrashCards_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                handFullOfTrash = true,
                                oncePerRun = true,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "handOnlyHasTrashCards"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "phone",
                                    What = "Hi. Room service?",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeHandOnlyHasTrashCards_Multi_1);
                    }
                }
                //SlimeOverheatGeneric_Multi
                {
                    {
                        var SlimeOverheatGeneric_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeOverheatGeneric_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                goingToOverheat = true,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "OverheatGeneric"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "nervous",
                                    What = "Oh, this might be too toasty.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeOverheatGeneric_Multi_0);
                    }
                    {
                        var SlimeOverheatGeneric_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeOverheatGeneric_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                goingToOverheat = true,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "OverheatGeneric"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "phone",
                                    What = "Yes, two cold packs. No, just two.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeOverheatGeneric_Multi_1);
                    }
                }
                //SlimeTheyHaveAutoDodge Multis
                {
                    {
                        var SlimeTheyHaveAutoDodgeLeft_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeTheyHaveAutoDodgeLeft_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lastTurnEnemyStatuses = new HashSet<Status>()
                                {
                                    Status.autododgeLeft
                                },
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "aboutAutododge"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "nervous",
                                    What = "Ah. The enemy is primed to dodge.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeTheyHaveAutoDodgeLeft_Multi_0);
                    }
                    {
                        var SlimeTheyHaveAutoDodgeRight_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeTheyHaveAutoDodgeRight_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lastTurnEnemyStatuses = new HashSet<Status>()
                                {
                                    Status.autododgeRight
                                },
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "aboutAutododge"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "nervous",
                                    What = "Ah. The enemy is primed to dodge.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeTheyHaveAutoDodgeRight_Multi_0);
                    }
                }
                //SlimeWeGotHurtButNotTooBad_Multi
                {
                    {
                        var SlimeWeGotHurtButNotTooBad_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeWeGotHurtButNotTooBad_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                enemyShotJustHit = true,
                                minDamageDealtToPlayerThisTurn = 1,
                                maxDamageDealtToPlayerThisTurn = 1,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "That tickled my funny bone.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeGotHurtButNotTooBad_Multi_0);
                    }
                    {
                        var SlimeWeGotHurtButNotTooBad_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeWeGotHurtButNotTooBad_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                enemyShotJustHit = true,
                                minDamageDealtToPlayerThisTurn = 1,
                                maxDamageDealtToPlayerThisTurn = 1,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Nothing a band-aid can't fix.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeGotHurtButNotTooBad_Multi_1);
                    }
                }
                //SlimeWeGotShotButTookNoDamage_Multi
                {
                    {
                        var SlimeWeGotShotButTookNoDamage_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeWeGotShotButTookNoDamage_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                enemyShotJustHit = true,
                                maxDamageDealtToPlayerThisTurn = 0,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "Nothing to report. Hah!",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeGotShotButTookNoDamage_Multi_0);
                    }
                    {
                        var SlimeWeGotShotButTookNoDamage_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeWeGotShotButTookNoDamage_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                enemyShotJustHit = true,
                                maxDamageDealtToPlayerThisTurn = 0,
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "Ship shows no damage from that attack.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeWeGotShotButTookNoDamage_Multi_1);
                    }
                }
                //SlimeArtifactCockpitTargetIsRelevant_Multi
                {
                    {
                        var SlimeArtifactCockpitTargetIsRelevant_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactCockpitTargetIsRelevant_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                turnStart = true,
                                oncePerRun = true,
                                maxTurnsThisCombat = 1,
                                enemyHasPart = "cockpit",
                                hasArtifacts = new HashSet<string>()
                                {
                                    "CockpitTarget"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Cockpit targetting systems, online.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactCockpitTargetIsRelevant_Multi_0);
                    }
                    {
                        var SlimeArtifactCockpitTargetIsRelevant_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactCockpitTargetIsRelevant_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                turnStart = true,
                                oncePerRun = true,
                                maxTurnsThisCombat = 1,
                                enemyHasPart = "cockpit",
                                hasArtifacts = new HashSet<string>()
                                {
                                    "CockpitTarget"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "peri"
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "peri",
                                    What = "Focus their piloting.",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Roger.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactCockpitTargetIsRelevant_Multi_1);
                    }
                }
                //SlimeArtifactJetThrustersNoRiggs_Multi
                {
                    {
                        var SlimeArtifactJetThrustersNoRiggs_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactJetThrustersNoRiggs_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                turnStart = true,
                                maxTurnsThisCombat = 1,
                                oncePerRunTags = new HashSet<string>()
                                {
                                    "OncePerRunThrusterJokesAboutRiggsICanMakeTheseTagsStupidlyLongIfIWant"
                                },
                                hasArtifacts = new HashSet<string>()
                                {
                                    "JetThrusters"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                                nonePresent = new HashSet<string>()
                                {
                                    "riggs"
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "These thrusters make me wonder what Riggs is doing right now.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactJetThrustersNoRiggs_Multi_0);
                    }
                    {
                        var SlimeArtifactJetThrustersNoRiggs_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactJetThrustersNoRiggs_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                turnStart = true,
                                maxTurnsThisCombat = 1,
                                oncePerRunTags = new HashSet<string>()
                                {
                                    "OncePerRunThrusterJokesAboutRiggsICanMakeTheseTagsStupidlyLongIfIWant"
                                },
                                hasArtifacts = new HashSet<string>()
                                {
                                    "JetThrusters"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                                nonePresent = new HashSet<string>()
                                {
                                    "riggs"
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "These thrusters make me miss Riggs. I wonder where she is.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactJetThrustersNoRiggs_Multi_1);
                    }
                }
                //SlimeArtifactNanofiberHull1_Multi
                {
                    {
                        var SlimeArtifactNanofiberHull1_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactNanofiberHull1_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                turnStart = true,
                                minDamageDealtToPlayerThisTurn = 1,
                                maxDamageDealtToPlayerThisTurn = 1,
                                oncePerRunTags = new HashSet<string>()
                                {
                                    "NanofiberHull"
                                },
                                hasArtifacts = new HashSet<string>()
                                {
                                    "NanofiberHull"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "That'll get nanofixed right out.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactNanofiberHull1_Multi_0);
                    }
                    {
                        var SlimeArtifactNanofiberHull1_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactNanofiberHull1_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                turnStart = true,
                                minDamageDealtToPlayerThisTurn = 1,
                                maxDamageDealtToPlayerThisTurn = 1,
                                oncePerRunTags = new HashSet<string>()
                                {
                                    "NanofiberHull"
                                },
                                hasArtifacts = new HashSet<string>()
                                {
                                    "NanofiberHull"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "The bots will deal with that, don't worry.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactNanofiberHull1_Multi_1);
                    }
                }
                //SlimeArtifactNanofiberHull2_Multi
                {
                    var SlimeArtifactNanofiberHull2_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactNanofiberHull2_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            turnStart = true,
                            minDamageDealtToPlayerThisTurn = 2,
                            oncePerRunTags = new HashSet<string>()
                            {
                                "NanofiberHull"
                            },
                            hasArtifacts = new HashSet<string>()
                            {
                                "NanofiberHull"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "Our nanobuddies will heal some of that, at least.",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeArtifactNanofiberHull2_Multi_0);
                }
                //SlimeSpikeGetsChatty_Multi
                {
                    var injectDialogue0 = new ExternalStoryInjector("SpikeGetsChatty_Multi_0",
                        ExternalStoryInjector.QuickInjection.Beginning, 1,
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "We're ready, yeah.",
                            },
                        });
                    storyRegistry.RegisterInjector(injectDialogue0);
                }
                //SlimeArtifactEnergyRefund_Multi
                {
                    var SlimeArtifactEnergyRefund_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactEnergyRefund_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            oncePerRun = true,
                            minCostOfCardJustPlayed = 3,
                            oncePerCombatTags = new HashSet<string>()
                            {
                                "EnergyRefund"
                            },
                            hasArtifacts = new HashSet<string>()
                            {
                                "EnergyRefund"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "phone",
                                What = "Does an extra large have a discount too?",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeArtifactEnergyRefund_Multi_0);
                }
                //SlimeArtifactOverclockedGeneratorSeenMaxMemory3_Multi
                {
                    var injectDialogue0 = new ExternalStoryInjector("ArtifactOverclockedGeneratorSeenMaxMemory3_Multi_0",
                        ExternalStoryInjector.QuickInjection.Beginning, 1,
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "Don't let Peri hear it. She's still mad about the core.",
                            },
                        });
                    storyRegistry.RegisterInjector(injectDialogue0);
                }
                //SlimeArtifactShieldPrepIsGone_Multi
                {
                    var SlimeArtifactShieldPrepIsGone_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactShieldPrepIsGone_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            turnStart = true,
                            maxTurnsThisCombat = 1,
                            oncePerRunTags = new HashSet<string>()
                            {
                                "ShieldPrepIsGoneYouFool"
                            },
                            doesNotHaveArtifacts = new HashSet<string>()
                            {
                                "ShieldPrep",
                                "WarpMastery"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "We'll be fine without warp prep, right?",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeArtifactShieldPrepIsGone_Multi_0);
                }
                //SlimeArtifactWarpMastery_Multi
                {
                    var SlimeArtifactWarpMastery_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactWarpMastery_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            turnStart = true,
                            maxTurnsThisCombat = 1,
                            oncePerRunTags = new HashSet<string>()
                            {
                                "WarpMastery"
                            },
                            hasArtifacts = new HashSet<string>()
                            {
                                "WarpMastery"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "Everyone knows Green makes stuff Stronger.",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeArtifactWarpMastery_Multi_0);
                }
                //SlimeArtifactArmoredBay_Multi
                {
                    {
                        var SlimeArtifactArmoredBay_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactArmoredBay_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                enemyShotJustHit = true,
                                minDamageBlockedByPlayerArmorThisTurn = 1,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "ArmoredBae"
                                },
                                hasArtifacts = new HashSet<string>()
                                {
                                    "ArmoredBay"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "In my timeline, we armored the Artemis' cockpit. It was Easy Mode.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactArmoredBay_Multi_0);
                    }
                    {
                        var SlimeArtifactArmoredBay_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactArmoredBay_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                enemyShotJustHit = true,
                                minDamageBlockedByPlayerArmorThisTurn = 1,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "ArmoredBae"
                                },
                                hasArtifacts = new HashSet<string>()
                                {
                                    "ArmoredBay"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "In my timeline, we armored the Gemini's cannons. It was Easy Mode.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactArmoredBay_Multi_1);
                    }
                    {
                        var SlimeArtifactArmoredBay_Multi_2 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactArmoredBay_Multi_2",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                enemyShotJustHit = true,
                                minDamageBlockedByPlayerArmorThisTurn = 1,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "ArmoredBae"
                                },
                                hasArtifacts = new HashSet<string>()
                                {
                                    "ArmoredBay"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "In my timeline, we armored the Jupiter's comms. It was Easy Mode.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactArmoredBay_Multi_2);
                    }
                    {
                        var SlimeArtifactArmoredBay_Multi_3 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactArmoredBay_Multi_3",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                enemyShotJustHit = true,
                                minDamageBlockedByPlayerArmorThisTurn = 1,
                                oncePerCombatTags = new HashSet<string>()
                                {
                                    "ArmoredBae"
                                },
                                hasArtifacts = new HashSet<string>()
                                {
                                    "ArmoredBay"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                },
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "In my timeline, we didn't even armor the Ares' cannons. It was Easy Mode either way.",
                                },
                            });
                        storyRegistry.RegisterStory(SlimeArtifactArmoredBay_Multi_3);
                    }
                }
            }
            // ================ 
            // CARD LOOKUPS
            // ================
            {
                //addedSlimeMutation_Multi
                {
                    {
                        var addedSlimeMutation_Multi_0 = new ExternalStory("CorrosiveCobra.Story.addedSlimeMutation_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                priority = true,
                                oncePerCombat = true,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "addedSlimeMutation"
                                },

                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "dark",
                                    What = "KAME...",
                                },
                            });
                        storyRegistry.RegisterStory(addedSlimeMutation_Multi_0);
                    }
                    {
                        var addedSlimeMutation_Multi_1 = new ExternalStory("CorrosiveCobra.Story.addedSlimeMutation_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerCombat = true,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "addedSlimeMutation"
                                },

                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "squint",
                                    What = "I'm changing...",
                                },
                            });
                        storyRegistry.RegisterStory(addedSlimeMutation_Multi_1);
                    }
                }
                //addedSlimeBLAST_Multi
                {
                    {
                        var addedSlimeBLAST_Multi_0 = new ExternalStory("CorrosiveCobra.Story.addedSlimeBLAST_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                priority = true,
                                oncePerCombat = true,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "addedSlimeBLAST"
                                },

                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "dark",
                                    What = "HAME...",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "eunice",
                                    LoopTag = "sly",
                                    What = "Ah, I see.",
                                },
                            });
                        storyRegistry.RegisterStory(addedSlimeBLAST_Multi_0);
                    }
                    {
                        var addedSlimeBLAST_Multi_1 = new ExternalStory("CorrosiveCobra.Story.addedSlimeBLAST_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerCombat = true,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "addedSlimeBLAST"
                                },

                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "squint",
                                    What = "I'm... stronger...",
                                },
                            });
                        storyRegistry.RegisterStory(addedSlimeBLAST_Multi_1);
                    }
                }
                //playedSlimeBLAST_Multi
                {
                    {
                        var playedSlimeBLAST_Multi_0 = new ExternalStory("CorrosiveCobra.Story.playedSlimeBLAST_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                priority = true,
                                oncePerCombat = true,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedSlimeBLAST"
                                },

                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "dark",
                                    What = "HADOUKEN!!!",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "eunice",
                                    LoopTag = "sly",
                                    What = "Wow! Now we'll get sued by two IPs simultaneously.",
                                },
                            });
                        storyRegistry.RegisterStory(playedSlimeBLAST_Multi_0);
                    }
                    {
                        var playedSlimeBLAST_Multi_1 = new ExternalStory("CorrosiveCobra.Story.playedSlimeBLAST_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerCombat = true,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedSlimeBLAST"
                                },

                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "Oh, nevermind, it was the cannon.",
                                },
                            });
                        storyRegistry.RegisterStory(playedSlimeBLAST_Multi_1);
                    }
                }
                //playedSlimeHug_Multi
                {
                    {
                        var playedSlimeHug_Multi_0 = new ExternalStory("CorrosiveCobra.Story.playedSlimeHug_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                priority = true,
                                oncePerCombat = true,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedSlimeHug"
                                },

                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "I'll take care of the trash now.",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "shard",
                                    LoopTag = "excited",
                                    What = "Oh, oh! If you find treasure please tell me!",
                                },
                            });
                        storyRegistry.RegisterStory(playedSlimeHug_Multi_0);
                    }
                    {
                        var playedSlimeHug_Multi_1 = new ExternalStory("CorrosiveCobra.Story.playedSlimeHug_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerCombat = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedSlimeBLAST"
                                },

                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "The trash should be easier to manage now.",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "peri",
                                    What = "Aprreciated.",
                                },
                            });
                        storyRegistry.RegisterStory(playedSlimeHug_Multi_1);
                    }
                }
                //playedTankThrow_Multi
                {
                    {
                        var playedTankThrow_Multi_0 = new ExternalStory("CorrosiveCobra.Story.playedTankThrow_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedTankThrowNone"
                                },

                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "Jumpy!",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "riggs",
                                    LoopTag = "nervous",
                                    What = "W-wo-wo-woah.",
                                },
                            });
                        storyRegistry.RegisterStory(playedTankThrow_Multi_0);
                    }
                    {
                        var playedTankThrow_Multi_1 = new ExternalStory("CorrosiveCobra.Story.playedTankThrow_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedTankThrowA"
                                },

                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "laugh",
                                    What = "We won't be needing these, anyway.",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "hacker",
                                    LoopTag = "smile",
                                    What = "Infinite tanks glitch. Genius.",
                                },
                            });
                        storyRegistry.RegisterStory(playedTankThrow_Multi_1);
                    }
                    {
                        var playedTankThrow_Multi_2 = new ExternalStory("CorrosiveCobra.Story.playedTankThrow_Multi_2",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedTankThrowB"
                                },

                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    LoopTag = "dark",
                                    What = "The best defense is a barrage of poison.",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "comp",
                                    LoopTag = "feral",
                                    What = "Agreed.",
                                },
                            });
                        storyRegistry.RegisterStory(playedTankThrow_Multi_2);
                    }
                }
                //playedLeakingContainer_Multi_0_Multi
                // MODDED
                {
                    {
                        var playedLeakingContainer_Multi_0 = new ExternalStory("CorrosiveCobra.Story.playedLeakingContainer_Multi_0",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedLeakingContainer"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "dizzy",
                                    "peri"
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "peri",
                                    LoopTag = "nap",
                                    What = "Zzz..."
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Have we always had a hole in the fuel tanks?",
                                    LoopTag = "laugh"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "dizzy",
                                    LoopTag = "explains",
                                    What = "Oh. Don't let Peri go there."
                                },
                            });
                        storyRegistry.RegisterStory(playedLeakingContainer_Multi_0);
                    }
                    {
                        var playedLeakingContainer_Multi_1 = new ExternalStory("CorrosiveCobra.Story.playedLeakingContainer_Multi_1",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedLeakingContainer"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "riggs",
                                    "peri"
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Have we always had a hole in the fuel tanks?",
                                    LoopTag = "laugh"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "riggs",
                                    LoopTag = "nervous",
                                    What = "Ah! I spilled my boba!"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "peri",
                                    LoopTag = "mad",
                                    What = "Everyone, focus!"
                                },
                            });
                        storyRegistry.RegisterStory(playedLeakingContainer_Multi_1);
                    }
                    {
                        var playedLeakingContainer_Multi_2 = new ExternalStory("CorrosiveCobra.Story.playedLeakingContainer_Multi_2",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedLeakingContainer"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "peri"
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Have we always had a hole in the fuel tanks?",
                                    LoopTag = "laugh"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "peri",
                                    LoopTag = "panic",
                                    What = "WHY ARE WE BREAKING OUR SHIP?"
                                },
                            });
                        storyRegistry.RegisterStory(playedLeakingContainer_Multi_2);
                    }
                    {
                        var playedLeakingContainer_Multi_3 = new ExternalStory("CorrosiveCobra.Story.playedLeakingContainer_Multi_3",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedLeakingContainer"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "goat"
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Have we always had a hole in the fuel tanks?",
                                    LoopTag = "laugh"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "goat",
                                    LoopTag = "panic",
                                    What = "OH MY GOD. THE SHIP IS BREAKING!"
                                },
                            });
                        storyRegistry.RegisterStory(playedLeakingContainer_Multi_3);
                    }
                    {
                        var playedLeakingContainer_Multi_4 = new ExternalStory("CorrosiveCobra.Story.playedLeakingContainer_Multi_4",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedLeakingContainer"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "eunice"
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Now we relax and wait!",
                                    LoopTag = "laugh"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "eunice",
                                    LoopTag = "mad",
                                    What = "What?! We're not WAITING! Let's PUNCH 'EM!"
                                },
                            });
                        storyRegistry.RegisterStory(playedLeakingContainer_Multi_4);
                    }
                    {
                        var playedLeakingContainer_Multi_5 = new ExternalStory("CorrosiveCobra.Story.playedLeakingContainer_Multi_5",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedLeakingContainer"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "hacker"
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Have we always had a hole in the fuel tanks?",
                                    LoopTag = "laugh"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "hacker",
                                    LoopTag = "smile",
                                    What = "Work smarter, not harder"
                                },
                            });
                        storyRegistry.RegisterStory(playedLeakingContainer_Multi_5);
                    }
                    {
                        var playedLeakingContainer_Multi_6 = new ExternalStory("CorrosiveCobra.Story.playedLeakingContainer_Multi_6",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedLeakingContainer"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "shard"
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Have we always had a hole in the fuel tanks?",
                                    LoopTag = "laugh"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "shard",
                                    LoopTag = "stoked",
                                    What = "Oooh!"
                                },
                            });
                        storyRegistry.RegisterStory(playedLeakingContainer_Multi_6);
                    }
                    {
                        var playedLeakingContainer_Multi_7 = new ExternalStory("CorrosiveCobra.Story.playedLeakingContainer_Multi_7",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedLeakingContainer"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    "comp"
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Have we always had a hole in the fuel tanks?",
                                    LoopTag = "laugh"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "comp",
                                    LoopTag = "grumpy",
                                    What = "Please stop breaking the ship."
                                },
                            });
                        storyRegistry.RegisterStory(playedLeakingContainer_Multi_7);
                    }
                    //MODDED CHARACTERS
                    {
                        var playedLeakingContainer_Multi_8 = new ExternalStory("CorrosiveCobra.Story.playedLeakingContainer_Multi_8",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedLeakingContainer"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    DaveWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Have we always had a hole in the fuel tanks?",
                                    LoopTag = "laugh"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = DaveWho,
                                    What = "Is this a low roll?"
                                },
                            });
                        storyRegistry.RegisterStory(playedLeakingContainer_Multi_8);
                    }
                    {
                        var playedLeakingContainer_Multi_9 = new ExternalStory("CorrosiveCobra.Story.playedLeakingContainer_Multi_9",
                            new StoryNode()
                            {
                                type = NodeType.combat,
                                oncePerRun = true,
                                lookup = new HashSet<string>()
                                {
                                    "playedLeakingContainer"
                                },
                                allPresent = new HashSet<string>()
                                {
                                    SlimeWho,
                                    JohannaWho
                                }
                            },
                            new List<object>()
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = SlimeWho,
                                    What = "Have we always had a hole in the fuel tanks?",
                                    LoopTag = "laugh"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = JohannaWho,
                                    LoopTag = "squint",
                                    What = "Careful with the ship, Slime. We've only got one."
                                },
                            });
                        storyRegistry.RegisterStory(playedLeakingContainer_Multi_9);
                    }
                }
                //playedTimestreamLeak_Multi
                {
                    var playedTimestreamLeak_Multi_0 = new ExternalStory("CorrosiveCobra.Story.playedTimestreamLeak_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            priority = true,
                            oncePerCombat = true,
                            oncePerRun = true,
                            lookup = new HashSet<string>()
                            {
                                "playedTimestreamLeak"
                            },

                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "nervous",
                                What = "Anyone else see that rupture in spacetime right behind the enemy?",
                            },
                            new ExternalStory.ExternalSaySwitch(new List<ExternalStory.ExternalSay>
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "dizzy",
                                    LoopTag = "explains",
                                    What = "Yeah. What else is new?",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "riggs",
                                    LoopTag = "nervous",
                                    What = "That sounds scary.",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "peri",
                                    What = "It looks like it attacked the enemy. Beware.",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "goat",
                                    LoopTag = "panic",
                                    What = "That is not good.",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "eunice",
                                    What = "Yeah, and?",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "hacker",
                                    LoopTag = "gloves",
                                    What = "Are we in the Matrix?",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "shard",
                                    LoopTag = "excited",
                                    What = "Wow!",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "comp",
                                    LoopTag = "feral",
                                    What = "I'll make sure we reach the Cobalt.",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = DaveWho,
                                    What = "The timer is on.",
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = JohannaWho,
                                    What = "...",
                                }
                            })
                        });
                    storyRegistry.RegisterStory(playedTimestreamLeak_Multi_0);
                }
            }
            // ================ 
            // CUSTOM ARTIFACT REACTIONS
            // ================
            {
                //hasArtifactCorrodeAttack_Multi
                {
                    var hasArtifactCorrodeAttack_Multi_0 = new ExternalStory("CorrosiveCobra.Story.hasArtifactCorrodeAttack_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            turnStart = true,
                            oncePerRun = true,
                            maxTurnsThisCombat = 1,
                            hasArtifacts = new HashSet<string>()
                            {
                                "CobraArtifactCorrodeAttack"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "Let the corrode stacking begin!",
                            },
                        });
                    storyRegistry.RegisterStory(hasArtifactCorrodeAttack_Multi_0);
                }
                //hasArtifactDissolvent_Multi
                {
                    var hasArtifactDissolvent_Multi_0 = new ExternalStory("CorrosiveCobra.Story.hasArtifactDissolvent_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            turnStart = true,
                            oncePerRun = true,
                            maxTurnsThisCombat = 1,
                            hasArtifacts = new HashSet<string>()
                            {
                                "CobraArtifactDissolvent"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "Woah! I'm 10% more liquid than a minute ago. Cool!",
                            },
                        });
                    storyRegistry.RegisterStory(hasArtifactDissolvent_Multi_0);
                }
                //hasArtifactFuelWalls_Multi
                {
                    var hasArtifactFuelWalls_Multi_0 = new ExternalStory("CorrosiveCobra.Story.hasArtifactFuelWalls_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            turnStart = true,
                            oncePerRun = true,
                            maxTurnsThisCombat = 1,
                            hasArtifacts = new HashSet<string>()
                            {
                                "CobraArtifactFuelWalls"
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "crew",
                                What = "Dealing with the heat should be easier now.",
                            },
                        });
                    storyRegistry.RegisterStory(hasArtifactFuelWalls_Multi_0);
                }
                //hasArtifactOverdriveTanks_Multi
                {
                    var hasArtifactOverdriveTanks_Multi_0 = new ExternalStory("CorrosiveCobra.Story.hasArtifactOverdriveTanks_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            turnStart = true,
                            oncePerRun = true,
                            maxTurnsThisCombat = 1,
                            hasArtifacts = new HashSet<string>()
                            {
                                "CobraArtifactOverdriveTanks"
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "crew",
                                What = "Oh man. Maybe we should've bought the Megaship Air Cooler 5000. I'm melting here.",
                            },
                        });
                    storyRegistry.RegisterStory(hasArtifactOverdriveTanks_Multi_0);
                }
                //hasArtifactUnstableTanks_Multi
                {
                    var hasArtifactUnstableTanks_Multi_0 = new ExternalStory("CorrosiveCobra.Story.hasArtifactUnstableTanks_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            turnStart = true,
                            oncePerRun = true,
                            maxTurnsThisCombat = 1,
                            hasArtifacts = new HashSet<string>()
                            {
                                "CobraArtifactUnstableTanks"
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "crew",
                                What = "Siri, AC to 0 K, thanks.",
                            },
                        });
                    storyRegistry.RegisterStory(hasArtifactUnstableTanks_Multi_0);
                }
                //hasArtifactPowerAcid_Multi
                {
                    var hasArtifactPowerAcid_Multi_0 = new ExternalStory("CorrosiveCobra.Story.hasArtifactPowerAcid_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            turnStart = true,
                            oncePerRun = true,
                            maxTurnsThisCombat = 1,
                            hasArtifacts = new HashSet<string>()
                            {
                                "CobraArtifactPowerAcid"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "Now all we need to do is give the enemy some Corrode.",
                            },
                        });
                    storyRegistry.RegisterStory(hasArtifactPowerAcid_Multi_0);
                }
                //hasArtifactSlimeHeart_Multi
                {
                    var hasArtifactSlimeHeart_Multi_0 = new ExternalStory("CorrosiveCobra.Story.hasArtifactSlimeHeart_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            turnStart = true,
                            oncePerRun = true,
                            maxTurnsThisCombat = 1,
                            hasArtifacts = new HashSet<string>()
                            {
                                "CobraArtifactSlimeHeart"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                What = "Now there's two of me! The roomba me, and me!",
                            },
                        });
                    storyRegistry.RegisterStory(hasArtifactSlimeHeart_Multi_0);
                }
                //hasArtifactToxicCaviar_Multi
                {
                    var hasArtifactToxicCaviar_Multi_0 = new ExternalStory("CorrosiveCobra.Story.hasArtifactToxicCaviar_Multi_0",
                        new StoryNode()
                        {
                            type = NodeType.combat,
                            turnStart = true,
                            oncePerRun = true,
                            maxTurnsThisCombat = 1,
                            hasArtifacts = new HashSet<string>()
                            {
                                "CobraArtifactToxicCaviar"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "Oh, my favorite dish!",
                            },
                        });
                    storyRegistry.RegisterStory(hasArtifactToxicCaviar_Multi_0);
                }
            }
            // ================ 
            // NEW EVENTS
            // ================
            {
                //SlimeEvent_WhoAreYou
                {
                    var SlimeEvent_WhoAreYou_1 = new ExternalStory("CorrosiveCobra.Story.SlimeEvent_WhoAreYou_1",
                        new StoryNode()
                        {
                            type = NodeType.@event,
                            priority = true,
                            once = true,
                            bg = "BGRunStart",
                            lookup = new HashSet<string>()
                            {
                                "zone_first"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                LoopTag = "squint",
                                What = "Yawn...",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                What = "Alright everyone, new loop, new -",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                What = "Hi CAT.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                What = "Hi.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                LoopTag = "intense",
                                What = "WAIT! WHO EVEN ARE YOU!",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                LoopTag = "laugh",
                                What = "Hm? I'm Dizzy?",
                            },
                            new ExternalStory.ExternalSaySwitch(new List<ExternalStory.ExternalSay>
                            {
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "dizzy",
                                    LoopTag = "explains",
                                    What = "That makes total sense. You're Dizzy."
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "riggs",
                                    LoopTag = "banana",
                                    What = "You're not Dizzy, I know Dizzy and he would never wear a spacesuit."
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "peri",
                                    LoopTag = "squint",
                                    What = "What is going on. Who is this?"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "goat",
                                    LoopTag = "squint",
                                    What = "Have you always looked like that?"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "eunice",
                                    LoopTag = "squint",
                                    What = "Uh-huh. Now tell us the truth."
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "hacker",
                                    LoopTag = "squint",
                                    What = "Is that a rare skin?"
                                },
                                new ExternalStory.ExternalSay()
                                {
                                    Who = "shard",
                                    What = "Hi!"
                                }
                            }),
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                What = "...",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                LoopTag = "intense",
                                What = "...",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                LoopTag = "worried",
                                What = "Oh... This isn't good.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                What = "Where am I? Where's Peri and Riggs and Isaac and Max and...",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                What = "...",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                LoopTag = "sad",
                                What = "...",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                LoopTag = "sad",
                                What = "What happened?",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                LoopTag = "worried",
                                What = "This is bad. The timestream must be collapsing. We're running out of time. You're from another timeline, Dizzy.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                What = "Oh, okay.",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeEvent_WhoAreYou_1);
                }
                {
                    var SlimeEvent_WhoAreYou_2 = new ExternalStory("CorrosiveCobra.Story.SlimeEvent_WhoAreYou_2",
                        new StoryNode()
                        {
                            type = NodeType.@event,
                            priority = true,
                            once = true,
                            bg = "BGRunStart",
                            lookup = new HashSet<string>()
                            {
                                "zone_first"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            },
                            requiredScenes = new HashSet<string>()
                            {
                                "CorrosiveCobra.Story.SlimeEvent_WhoAreYou_1",
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                What = "Hi second Dizzy.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                What = "Hi!",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                What = "I wonder why the timestream brought you here.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                LoopTag = "intense",
                                What = "Maybe you're an evil Dizzy from an evil timeline that has come to destroy our universe.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                LoopTag = "laugh",
                                What = "Haha, you're funny.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                LoopTag = "laugh",
                                What = "...",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                LoopTag = "intense",
                                What = "...",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                What = "...",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeEvent_WhoAreYou_2);
                }
                {
                    var SlimeEvent_WhoAreYou_3 = new ExternalStory("CorrosiveCobra.Story.SlimeEvent_WhoAreYou_3",
                        new StoryNode()
                        {
                            type = NodeType.@event,
                            priority = true,
                            once = true,
                            bg = "BGRunStart",
                            lookup = new HashSet<string>()
                            {
                                "zone_first"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                            },
                            requiredScenes = new HashSet<string>()
                            {
                                "CorrosiveCobra.Story.SlimeEvent_WhoAreYou_2",
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                What = "Is the CAT from your timeline, like, cooler?",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                What = "Yeah.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                LoopTag = "worried",
                                What = "Oh.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                What = "But I'm great in my own way, right?",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                LoopTag = "laugh",
                                What = "Sure.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                LoopTag = "intense",
                                What = "...",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                What = "...",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                What = "Thanks.",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeEvent_WhoAreYou_3);
                }
                //SlimeEvent_Dizzy
                {
                    var SlimeEvent_Dizzy_1 = new ExternalStory("CorrosiveCobra.Story.SlimeEvent_Dizzy_1",
                        new StoryNode()
                        {
                            type = NodeType.@event,
                            once = true,
                            bg = "BGRunStart",
                            lookup = new HashSet<string>()
                            {
                                "zone_first"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "dizzy"
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "dizzy",
                                LoopTag = "squint",
                                What = "If you're here, what's happening over in your timeline?",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                LoopTag = "sad",
                                What = "I don't know.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "dizzy",
                                LoopTag = "explains",
                                What = "Maybe this is all a dream and when we wake up we'll be back to before all this crazy stuff happened? Me in my timeline and you in yours?",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "comp",
                                Flipped = true,
                                What = "Negative. We are stuck in this time loop.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "dizzy",
                                LoopTag = "frown",
                                What = "Ah.",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeEvent_Dizzy_1);
                }
                {
                    var SlimeEvent_Dizzy_2 = new ExternalStory("CorrosiveCobra.Story.SlimeEvent_Dizzy_2",
                        new StoryNode()
                        {
                            type = NodeType.@event,
                            once = true,
                            bg = "BGRunStart",
                            lookup = new HashSet<string>()
                            {
                                "zone_first"
                            },
                            allPresent = new HashSet<string>()
                            {
                                SlimeWho,
                                "dizzy"
                            },
                            requiredScenes = new HashSet<string>()
                            {
                                "CorrosiveCobra.Story.SlimeEvent_Dizzy_1",
                            },
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                What = "Hey, Dizzy.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "dizzy",
                                What = "Hey.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                What = "Is everyone in this timeline meat-based lifeforms?",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "dizzy",
                                LoopTag = "explains",
                                What = "Most of us, yes.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                LoopTag = "laugh",
                                What = "Cool, cool.",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                LoopTag = "laugh",
                                What = "...",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "dizzy",
                                What = "...",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                Flipped = true,
                                LoopTag = "laugh",
                                What = "Why, though?",
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = "dizzy",
                                LoopTag = "shrug",
                                What = "...",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeEvent_Dizzy_2);
                }
            }
        }
    }
}