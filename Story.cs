using CobaltCoreModding.Definitions.ExternalItems;
using CobaltCoreModding.Definitions.ModContactPoints;

namespace CorrosiveCobra
{
    public partial class Manifest
    {
        public void LoadManifest(IStoryRegistry storyRegistry)
        {
            var SlimeWho = (CobraDeck ?? throw new Exception("Missing CobraDeck")).GlobalName;
            var DaveWho = "rft.Dave.DaveDeck";
            var JohannaWho = "JohannaTheTrucker.JohannaDeck";
            //LeakingContainerPlayedAndSlimeIsHere_Multi
            // (TO FIX) MODDED TO DO
            {
                var LeakingContainerPlayedAndSlimeIsHere_Multi_0 = new ExternalStory("CorrosiveCobra.Story.LeakingContainerPlayedAndSlimeIsHere_Multi_0",
                    new StoryNode() // Native CobaltCore class, containing numerous options regarding the shout's trigger. Listed are only the most common, but feel free to explore
                    {
                        type = NodeType.combat, // Mark the story as a combat shout
                        priority = true, // Forces this story to be selected before other valid ones when the database is queried, useful for debugging.

                        once = false,
                        oncePerCombat = true,
                        oncePerRun = false, // Self explanatory

                        lookup = new HashSet<string>() // This is a list of tags that queries look for in various situations, very useful for triggering shouts in specific situations !
                        {
                            "leakingContainerShout" // We'll feed this string to a CardAction's dialogueSelector field in EWandererDemoCard, so that this shout triggers when we play the upgrade B of the card
                        },

                        allPresent = new HashSet<string>() // this checks for the presence of a list of characters.
                        {
                            SlimeWho,
                        }
                    },
                    new List<object>()
                    {
                        new ExternalStory.ExternalSay()
                        {
                            Who = SlimeWho,
                            Delay = 0,
                            What = "Have we always had a hole in the fuel tanks?",
                            LoopTag = "laugh" // the specific animation that should play during the shout. "neutral" is default
                        },
                        new SaySwitch()
                        {
                            lines = new List<Say> {
                                new Say()
                                {
                                    who = "dizzy",
                                    loopTag = "explains",
                                    hash = "dizzyLeakingContainer"
                                },
                                new Say()
                                {
                                    who = "riggs",
                                    loopTag = "nervous",
                                    hash = "riggsLeakingContainer"
                                },
                                new Say()
                                {
                                    who = "peri",
                                    loopTag = "panic",
                                    hash = "periLeakingContainer"
                                },
                                new Say()
                                {
                                    who = "max",
                                    loopTag = "smile",
                                    hash = "maxLeakingContainer"
                                },
                                new Say() {
                                    who = "eunice",
                                    loopTag = "mad",
                                    hash = "drakeLeakingContainer"
                                },
                                new Say() {
                                    who = "books",
                                    loopTag = "stoked",
                                    hash = "booksLeakingContainer"
                                },
                                //MODDED CHARACTERS
                                new Say() {
                                    who = DaveWho,
                                    hash = "daveLeakingContainer"
                                },
                            }
                        }
                    });
                LeakingContainerPlayedAndSlimeIsHere_Multi_0.AddLocalisation("dizzyLeakingContainer", "Oh. Don't let Peri go there.");
                LeakingContainerPlayedAndSlimeIsHere_Multi_0.AddLocalisation("riggsLeakingContainer", "Ah! I spilled my boba!");
                LeakingContainerPlayedAndSlimeIsHere_Multi_0.AddLocalisation("periLeakingContainer", "WHY ARE WE BREAKING OUR SHIP?");
                LeakingContainerPlayedAndSlimeIsHere_Multi_0.AddLocalisation("maxLeakingContainer", "Work smarter, not harder");
                LeakingContainerPlayedAndSlimeIsHere_Multi_0.AddLocalisation("drakeLeakingContainer", "What?! We're not WAITING! Let's PUNCH 'EM!");
                LeakingContainerPlayedAndSlimeIsHere_Multi_0.AddLocalisation("booksLeakingContainer", "Oooh!");
                LeakingContainerPlayedAndSlimeIsHere_Multi_0.AddLocalisation("daveLeakingContainer", "Is this a high roll?");
                storyRegistry.RegisterStory(LeakingContainerPlayedAndSlimeIsHere_Multi_0);
            }
            //SlimeHeatIncrease_Multi
            {
                var SlimeHeatIncrease_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeHeatIncrease_Multi0",
                    new StoryNode()
                    {
                        type = NodeType.combat,
                        oncePerCombat = true,
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
                            LoopTag = "laugh"
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
                            Who = "slime",
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
                            "Dizzy_2",
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
                            What = "I had a Whole new campaign planned out.",
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
            }
            //SlimeBanditThreats_Multi
            // (TO FIX)
            {
                var SlimeBanditThreats_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeBanditThreats_Multi_0",
                    new StoryNode()
                    {
                        type = NodeType.combat,
                        priority = true,
                        turnStart = true,
                        maxTurnsThisCombat = 1,
                        oncePerCombatTags = new HashSet<string>()
                        {
                            "BanditThreats"
                        },
                        allPresent = new HashSet<string>()
                        {
                            SlimeWho,
                            "bandit"
                        }
                    },
                    new List<object>()
                    {
                        new ExternalStory.ExternalSay()
                        {
                            Who = "bandit",
                            LoopTag = "smile",
                            What = "Mornin' y'all. Three servings of missiles, coming right up."
                        },
                        new ExternalStory.ExternalSay()
                        {
                            Who = SlimeWho,
                            What = "Oh! Tasty!",
                        },
                    });
                storyRegistry.RegisterStory(SlimeBanditThreats_Multi_0);
            }
            //SlimeBatboyKeepsTalking_Multi
            {
                var SlimeBatboyKeepsTalking_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeBatboyKeepsTalking_Multi_0",
                    new StoryNode()
                    {
                        type = NodeType.combat,
                        turnStart = true,
                        oncePerCombatTags = new HashSet<string>()
                        {
                            "batboyshutupyouBigNERD"
                        },
                        allPresent = new HashSet<string>()
                        {
                            SlimeWho,
                            "batboy"
                        }
                    },
                    new List<object>()
                    {
                        new ExternalStory.ExternalSay()
                        {
                            Who = "batboy",
                            What = "Do you like my custom engines? They all glow different colors."
                        },
                        new ExternalStory.ExternalSay()
                        {
                            Who = SlimeWho,
                            LoopTag = "laugh",
                            What = "Nice! I have my own Cherenkov radiation lamp!"
                        },
                    });
                storyRegistry.RegisterStory(SlimeBatboyKeepsTalking_Multi_0);
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
                        new SaySwitch()
                        {
                            lines = new List<Say> {
                                new Say()
                                {
                                    who = "tentacle",
                                    hash = "tentacleDialogue0"
                                },
                                new Say()
                                {
                                    who = "tentacle",
                                    hash = "tentacleDialogue1"
                                },
                                new Say()
                                {
                                    who = "tentacle",
                                    hash = "tentacleDialogue2"
                                },
                            }
                        },
                        new SaySwitch()
                        {
                            lines = new List<Say> {
                                new Say()
                                {
                                    who = SlimeWho,
                                    loopTag = "laugh",
                                    hash = "tentacleDialogueAnswer0"
                                },
                                new Say()
                                {
                                    who = SlimeWho,
                                    hash = "tentacleDialogueAnswer1"
                                },
                                new Say()
                                {
                                    who = SlimeWho,
                                    loopTag = "sad",
                                    hash = "tentacleDialogueAnswer2"
                                },
                            }
                        },
                    });
                SlimeTentacleThreats_Multi_0.AddLocalisation("tentacleDialogue0", "GLARP");
                SlimeTentacleThreats_Multi_0.AddLocalisation("tentacleDialogue1", "GLARP");
                SlimeTentacleThreats_Multi_0.AddLocalisation("tentacleDialogue2", "GLARP");
                SlimeTentacleThreats_Multi_0.AddLocalisation("tentacleDialogueAnswer0", "Haha. You're funny.");
                SlimeTentacleThreats_Multi_0.AddLocalisation("tentacleDialogueAnswer1", "Ah... aha... Hm... I see!");
                SlimeTentacleThreats_Multi_0.AddLocalisation("tentacleDialogueAnswer2", "To shreds you say?");
                storyRegistry.RegisterStory(SlimeTentacleThreats_Multi_0);
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
                            maxDamageDealtToPlayerThisTurn = 1,
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
                            maxDamageDealtToPlayerThisTurn = 1,
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
            //SlimeBlockedAnEnemyAttackWithArmor_Multi
            {
                var SlimeBlockedAnEnemyAttackWithArmor_Multi_0 = new ExternalStory("CorrosiveCobra.Story.SlimeBlockedAnEnemyAttackWithArmor_Multi_0",
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
                storyRegistry.RegisterStory(SlimeBlockedAnEnemyAttackWithArmor_Multi_0);
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
                        new SaySwitch()
                        {
                            lines = new List<Say>
                            {
                                new Say()
                                {
                                    who = SlimeWho,
                                    loopTag = "laugh",
                                    hash = "slimeOverheatFix0"
                                },
                                new Say()
                                {
                                    who = SlimeWho,
                                    hash = "slimeOverheatFix1"
                                },
                                new Say()
                                {
                                    who = SlimeWho,
                                    loopTag = "sad",
                                    hash = "slimeOverheatFix2"
                                },
                            }
                        }
                    });
                SlimeOverheatDrakeFix_Multi_0.AddLocalisation("slimeOverheatFix0", "Did you turn on the AC?");
                SlimeOverheatDrakeFix_Multi_0.AddLocalisation("slimeOverheatFix1", "Oh. Nice save, Drake.");
                SlimeOverheatDrakeFix_Multi_0.AddLocalisation("slimeOverheatFix2", "I liked being liquid-er.");
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
                        new SaySwitch()
                        {
                            lines = new List<Say>
                            {
                                new Say()
                                {
                                    who = SlimeWho,
                                    loopTag = "sad",
                                    hash = "slimeShopAboutToDie0"
                                },
                                new Say()
                                {
                                    who = SlimeWho,
                                    loopTag = "dark",
                                    hash = "slimeShopAboutToDie1"
                                },
                            }
                        }
                    });
                SlimeShopKeepBattleInsult_0.AddLocalisation("slimeShopAboutToDie0", "I see...");
                SlimeShopKeepBattleInsult_0.AddLocalisation("slimeShopAboutToDie1", "Loop time, then.");
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
            // (DIRTY PRIORITY) (TO FIX)
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
                    var SlimeArtifactGeminiCore_Multi_1 = new ExternalStory("CorrosiveCobra.Story.SlimeArtifactGeminiCore_Multi_1",
                        new StoryNode()
                        {
                            priority = true,
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
                                SlimeWho,
                                "dizzy"
                            }
                        },
                        new List<object>()
                        {
                            new ExternalStory.ExternalSay()
                            {
                                Who = "dizzy",
                                What = "Do you guys prefer the blue or the red side? I'm a blue guy."
                            },
                            new ExternalStory.ExternalSay()
                            {
                                Who = SlimeWho,
                                LoopTag = "laugh",
                                What = "I'm a green guy.",
                            },
                        });
                    storyRegistry.RegisterStory(SlimeArtifactGeminiCore_Multi_1);
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
                                "Dizzy_2"
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
            // (TO FIX)
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
            }
            //SlimeWeDidOverFiveDamage_Multi
            //MODDED TO DO
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
        }
    }
}