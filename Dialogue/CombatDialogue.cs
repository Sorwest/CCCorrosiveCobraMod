using System.Linq;

namespace Sorwest.CorrosiveCobra;

internal static class CombatDialogue
{
    private static ModEntry Instance => ModEntry.Instance;

    internal static void Inject()
    {
        string currentStory;
        string SlimeWho = Instance.SlimeDeck.Deck.Key();
        {
            DB.story.GetNode(currentStory = "CrabFacts1_Multi_0")?.lines.OfType<SaySwitch>().LastOrDefault()?.lines.Insert(0,
                new CustomSay()
                {
                    who = SlimeWho,
                    Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1"]),
                    loopTag = "laugh"
                }
            );
            DB.story.GetNode(currentStory = "CrabFacts2_Multi_0")?.lines.OfType<SaySwitch>().LastOrDefault()?.lines.Insert(0,
                new CustomSay()
                {
                    who = SlimeWho,
                    Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1"]),
                    loopTag = "phone"
                }
            );
            DB.story.GetNode(currentStory = "CrabFactsAreOverNow_Multi_0")?.lines.OfType<SaySwitch>().LastOrDefault()?.lines.Insert(0,
                new CustomSay()
                {
                    who = SlimeWho,
                    Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1"])
                }
            );
        }
        {
            DB.story.GetNode(currentStory = "BanditThreats_Multi_0")?.lines.OfType<SaySwitch>().LastOrDefault()?.lines.Insert(0,
                new CustomSay()
                {
                    who = SlimeWho,
                    Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1"])
                }
            );
        }
        {
            DB.story.GetNode(currentStory = "BatboyKeepsTalking_Multi_0")?.lines.OfType<SaySwitch>().LastOrDefault()?.lines.Insert(0,
                new CustomSay()
                {
                    who = SlimeWho,
                    Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1"]),
                    loopTag = "laugh"
                }
            );
        }
        {
            DB.story.GetNode(currentStory = "TentacleThreats_Multi_0")?.lines.Insert(1,
                new SaySwitch()
                {
                    lines = new()
                    {
                        new CustomSay()
                        {
                            who = SlimeWho,
                            Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1", "1"]),
                            loopTag = "laugh"
                        },
                        new CustomSay()
                        {
                            who = SlimeWho,
                            Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1", "2"])
                        },
                        new CustomSay()
                        {
                            who = SlimeWho,
                            Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1", "3"]),
                            loopTag = "sad"
                        },
                    }
                }
            );
        }
        {
            DB.story.GetNode(currentStory = "TentacleThreatsOnShellBreak_Multi_0")?.lines.Insert(1,
                new SaySwitch()
                {
                    lines = new()
                    {
                        new CustomSay()
                        {
                            who = SlimeWho,
                            Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1", "1"]),
                            loopTag = "laugh"
                        },
                        new CustomSay()
                        {
                            who = SlimeWho,
                            Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1", "2"])
                        },
                        new CustomSay()
                        {
                            who = SlimeWho,
                            Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1", "3"]),
                            loopTag = "sad"
                        }
                    }
                }
            );
        }
        {
            DB.story.GetNode(currentStory = "ArtifactGeminiCore_Multi_4")?.lines.OfType<SaySwitch>().LastOrDefault()?.lines.Insert(0,
                new CustomSay()
                {
                    who = SlimeWho,
                    Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1"]),
                    loopTag = "laugh"
                }
            );
        }
        {
            DB.story.GetNode(currentStory = "OneHitPointThisIsFine_Multi_4")?.lines.OfType<SaySwitch>().LastOrDefault()?.lines.Insert(0,
                new CustomSay()
                {
                    who = SlimeWho,
                    Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1"])
                }
            );
        }
        {
            DB.story.GetNode(currentStory = "SpikeGetsChatty_Multi_0")?.lines.OfType<SaySwitch>().LastOrDefault()?.lines.Insert(0,
                new CustomSay()
                {
                    who = SlimeWho,
                    Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1"])
                }
            );
        }
        {
            DB.story.GetNode(currentStory = "ArtifactOverclockedGeneratorSeenMaxMemory3_Multi_0")?.lines.OfType<SaySwitch>().LastOrDefault()?.lines.Insert(0,
                new CustomSay()
                {
                    who = SlimeWho,
                    Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1"]),
                    loopTag = "laugh"
                }
            );
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.HeatIncrease_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                minTurnsThisCombat = 2,
                lastTurnPlayerStatuses = new()
                {
                    Status.heat
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.WeMissedOopsie_Multi_0"] = new()
            {
                type = NodeType.combat,
                playerShotJustMissed = true,
                oncePerCombat = true,
                doesNotHaveArtifacts = new()
                {
                    "Recalibrator",
                    "GrazerBeam",
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeMissedOopsie_Multi_1"] = new()
            {
                type = NodeType.combat,
                playerShotJustMissed = true,
                oncePerCombat = true,
                doesNotHaveArtifacts = new()
                {
                    "Recalibrator",
                    "GrazerBeam",
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeMissedOopsie_Multi_2"] = new()
            {
                type = NodeType.combat,
                playerShotJustMissed = true,
                oncePerCombat = true,
                doesNotHaveArtifacts = new()
                {
                    "Recalibrator",
                    "GrazerBeam",
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeMissedOopsie_Multi_3"] = new()
            {
                type = NodeType.combat,
                playerShotJustMissed = true,
                oncePerCombat = true,
                doesNotHaveArtifacts = new()
                {
                    "Recalibrator",
                    "GrazerBeam",
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeMissedOopsie_Multi_4"] = new()
            {
                type = NodeType.combat,
                playerShotJustMissed = true,
                oncePerCombat = true,
                doesNotHaveArtifacts = new()
                {
                    "Recalibrator",
                    "GrazerBeam",
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.WeDontOverlapWithEnemyAtAll_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                shipsDontOverlapAtAll = true,
                nonePresent = new()
                {
                    "crab",
                    "scrap"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeDontOverlapWithEnemyAtAll_Multi_1"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                shipsDontOverlapAtAll = true,
                nonePresent = new()
                {
                    "crab",
                    "scrap"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeDontOverlapWithEnemyAtAll_Multi_2"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                shipsDontOverlapAtAll = true,
                nonePresent = new()
                {
                    "crab",
                    "scrap"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.WeDontOverlapWithEnemyAtAllButWeDoHaveASeekerToDealWith_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                shipsDontOverlapAtAll = true,
                oncePerCombatTags = new()
                {
                    "NoOverlapBetweenShipsSeeker"
                },
                anyDronesHostile = new()
                {
                    "missile_seeker"
                },
                nonePresent = new()
                {
                    "crab"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "dizzy"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "sad"
                    },
                    new CustomSay()
                    {
                        who = "dizzy",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "frown"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_1"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "dizzy"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "frown"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "sad"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_11"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "riggs"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    },
                    new CustomSay()
                    {
                        who = "riggs",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_12"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "peri"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "sad"
                    },
                    new CustomSay()
                    {
                        who = "peri",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "panic"
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_13"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "peri"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "peri",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "shy"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_14"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "goat"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    },
                    new CustomSay()
                    {
                        who = "goat",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_15"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "goat"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "goat",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_16"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "eunice"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = "eunice",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_16"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "eunice"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "eunice",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "sad"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_16"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "eunice"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "eunice",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "sly"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "laugh"
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_17"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "eunice"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "eunice",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "sly"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "laugh"
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_18"] = new()
            {
                type = NodeType.combat,
                priority = true,
                once = true,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                requiredScenes = new()
                {
                    "Dizzy_Memory_2",
                },
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "hacker"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "sad"
                    },
                    new CustomSay()
                    {
                        who = "hacker",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "smile"
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_19"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "hacker"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    },
                    new CustomSay()
                    {
                        who = "hacker",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_20"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "hacker"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "hacker",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "laugh"
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_21"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "shard"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "sad"
                    },
                    new CustomSay()
                    {
                        who = "shard",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "paws"
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_22"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "shard"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "shard",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "relaxed"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "nervous"
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_23"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "comp"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "transition"
                    },
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_24"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "comp"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "grumpy"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "mad"
                    },
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.BlockedAnEnemyAttackWithArmor_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 1,
                oncePerCombatTags = new()
                {
                    "WowArmorISPrettyCoolHuh"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.BlockedAnEnemyAttackWithArmor_Multi_1"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 1,
                oncePerCombatTags = new()
                {
                    "WowArmorISPrettyCoolHuh"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.BlockedAnEnemyAttackWithArmor_Multi_2"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 1,
                oncePerCombatTags = new()
                {
                    "WowArmorISPrettyCoolHuh"
                },
                allPresent = new()
                {
                SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.BlockedALotOfAttacksWithArmor_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 3,
                oncePerCombatTags = new()
                {
                    "YowzaThatWasALOTofArmorBlock"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ThatsALotOfDamageToThem_Multi_0"] = new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisTurn = 10,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ThatsALotOfDamageToUs_Multi_0"] = new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageDealtToPlayerThisTurn = 3,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "sad"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.ThatsALotOfDamageToUs_Multi_1"] = new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageDealtToPlayerThisTurn = 3,
                allPresent = new()
                {
                    SlimeWho,
                    "dizzy",
                    "riggs"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "dizzy",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "intense"
                    },
                    new CustomSay()
                    {
                        who = "riggs",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "nervous"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "3"]),
                        loopTag = "squint"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.ThatsALotOfDamageToUs_Multi_2"] = new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageDealtToPlayerThisTurn = 3,
                allPresent = new()
                {
                    SlimeWho,
                    "dizzy",
                    "peri"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "peri",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "mad"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "nervous"
                    },
                    new CustomSay()
                    {
                        who = "dizzy",
                        Text = Instance.StoryLocs.Localize([currentStory, "3"]),
                        loopTag = "intense"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.ThatsALotOfDamageToUs_Multi_3"] = new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageDealtToPlayerThisTurn = 3,
                allPresent = new()
                {
                    SlimeWho,
                    "dizzy",
                    "eunice"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    },
                    new CustomSay()
                    {
                        who = "dizzy",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "intense"
                    },
                    new CustomSay()
                    {
                        who = "eunice",
                        Text = Instance.StoryLocs.Localize([currentStory, "3"]),
                        loopTag = "sly"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.CrewWentMissing_Multi_0"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerRun = true,
                lastTurnPlayerStatuses = new()
                {
                    Status.missingDizzy,
                },
                oncePerCombatTags = new()
                {
                    "dizzyWentMissing"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "squint"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.CrewWentMissing_Multi_1"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerRun = true,
                lastTurnPlayerStatuses = new()
                {
                    Status.missingPeri,
                },
                oncePerCombatTags = new()
                {
                    "periWentMissing"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "sad"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.CrewWentMissing_Multi_2"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerRun = true,
                lastTurnPlayerStatuses = new()
                {
                    Status.missingRiggs,
                },
                oncePerCombatTags = new()
                {
                    "riggsWentMissing"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "mad"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.CrewWentMissing_Multi_3"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerRun = true,
                lastTurnPlayerStatuses = new()
                {
                    Status.missingIsaac,
                },
                oncePerCombatTags = new()
                {
                    "isaacWentMissing"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "mad"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.CrewWentMissing_Multi_4"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerRun = true,
                lastTurnPlayerStatuses = new()
                {
                    Status.missingDrake,
                },
                oncePerCombatTags = new()
                {
                    "drakeWentMissing"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "mad"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.CrewWentMissing_Multi_5"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerRun = true,
                lastTurnPlayerStatuses = new()
                {
                    Status.missingMax,
                },
                oncePerCombatTags = new()
                {
                    "maxWentMissing"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "sad"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.CrewWentMissing_Multi_6"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerRun = true,
                lastTurnPlayerStatuses = new()
                {
                    Status.missingBooks,
                },
                oncePerCombatTags = new()
                {
                    "booksWentMissing"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "dark"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.CrewWentMissing_Multi_7"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerRun = true,
                lastTurnPlayerStatuses = new()
                {
                    Status.missingCat,
                },
                oncePerCombatTags = new()
                {
                    "CatWentMissing"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "sad"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.EmptyHandWithEnergy_Multi_0"] = new()
            {
                type = NodeType.combat,
                handEmpty = true,
                minEnergy = 1,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "squint"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.EmptyHandWithEnergy_Multi_1"] = new()
            {
                type = NodeType.combat,
                handEmpty = true,
                minEnergy = 1,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.EnemyHasBrittle_Multi_0"] = new()
            {
                type = NodeType.combat,
                enemyHasBrittlePart = true,
                oncePerCombatTags = new()
                {
                    "yelledAboutBrittle"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.EnemyHasWeakness_Multi_0"] = new()
            {
                type = NodeType.combat,
                enemyHasWeakPart = true,
                oncePerCombatTags = new()
                {
                    "yelledAboutWeakness"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.JustHitGeneric_Multi_0"] = new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.JustHitGeneric_Multi_1"] = new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.JustHitGeneric_Multi_2"] = new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.JustHitGeneric_Multi_3"] = new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.JustPlayedADraculaCard_Multi_0"] = new()
            {
                type = NodeType.combat,
                whoDidThat = Deck.dracula,
                oncePerRun = true,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.LookOutMissile_Multi_0"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerRun = true,
                oncePerRunTags = new()
                {
                    "goodMissileAdvice"
                },
                anyDronesHostile = new()
                {
                    "missile_normal",
                    "missile_heavy",
                    "missile_corrode",
                    "missile_seeker",
                    "missile_breacher"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.OverheatDrakeFix_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRunTags = new()
                {
                    "OverheatDrakeFix"
                },
                whoDidThat = Deck.eunice,
                allPresent = new()
                {
                    SlimeWho,
                    "eunice"
                },
                lines = new()
                {
                    new SaySwitch()
                    {
                        lines = new()
                        {
                            new CustomSay()
                            {
                                who = SlimeWho,
                                Text = Instance.StoryLocs.Localize([currentStory, "1", "1"]),
                                loopTag = "laugh"
                            },
                            new CustomSay()
                            {
                                who = SlimeWho,
                                Text = Instance.StoryLocs.Localize([currentStory, "1", "2"])
                            },
                            new CustomSay()
                            {
                                who = SlimeWho,
                                Text = Instance.StoryLocs.Localize([currentStory, "1", "3"]),
                                loopTag = "sad"
                            }
                        }
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ShopKeepBattleInsult_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                priority = true,
                oncePerRunTags = new()
                {
                    "ShopkeepAboutToDestroyYou"
                },
                enemyIntent = "shopkeepAttack",
                allPresent = new()
                {
                    "nerd"
                },
                lines = new()
                {
                    new SaySwitch()
                    {
                        lines = new()
                        {
                            new CustomSay()
                            {
                                who = SlimeWho,
                                Text = Instance.StoryLocs.Localize([currentStory, "1", "1"]),
                                loopTag = "sad"
                            },
                            new CustomSay()
                            {
                                who = SlimeWho,
                                Text = Instance.StoryLocs.Localize([currentStory, "1", "2"]),
                                loopTag = "dark"
                            }
                        }
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.VeryManyTurns_Multi_0"] = new()
            {
                type = NodeType.combat,
                minTurnsThisCombat = 20,
                turnStart = true,
                oncePerRun = true,
                oncePerCombatTags = new()
                {
                    "veryManyTurns"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "mad"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.VeryManyTurns_Multi_1"] = new()
            {
                type = NodeType.combat,
                minTurnsThisCombat = 20,
                turnStart = true,
                oncePerRun = true,
                oncePerCombatTags = new()
                {
                    "veryManyTurns"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "sad"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.VeryManyTurns_Multi_2"] = new()
            {
                type = NodeType.combat,
                minTurnsThisCombat = 20,
                turnStart = true,
                oncePerRun = true,
                oncePerCombatTags = new()
                {
                    "veryManyTurns"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.WeAreCorroded_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lastTurnPlayerStatuses = new()
                {
                    Status.corrode
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeAreCorroded_Multi_1"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lastTurnPlayerStatuses = new()
                {
                    Status.corrode
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeAreCorroded_Multi_2"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lastTurnPlayerStatuses = new()
                {
                    Status.corrode
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactGeminiCore_Multi_0"] = new()
            {
                type = NodeType.combat,
                hasArtifacts = new()
                {
                    "GeminiCore"
                },
                oncePerRunTags = new()
                {
                    "GeminiCore"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                nonePresent = new()
                {
                    "dizzy"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactTiderunner_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                hasArtifacts = new()
                {
                    "TideRunner"
                },
                oncePerRunTags = new()
                {
                    "TideRunner"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactTiderunner_Multi_1"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                hasArtifacts = new()
                {
                    "TideRunner"
                },
                oncePerRunTags = new()
                {
                    "TideRunner"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactTridimensionalCockpit_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                hasArtifacts = new()
                {
                    "TridimensionalCockpit"
                },
                oncePerRunTags = new()
                {
                 "TridimensionalCockpit"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "squint"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ManyTurns_Multi_0"] = new()
            {
                type = NodeType.combat,
                minTurnsThisCombat = 9,
                turnStart = true,
                oncePerRun = true,
                oncePerCombatTags = new()
                {
                    "manyTurns"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "phone"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.ManyTurns_Multi_1"] = new()
            {
                type = NodeType.combat,
                minTurnsThisCombat = 9,
                turnStart = true,
                oncePerRun = true,
                requiredScenes = new()
                {
                    "Dizzy_Memory_2"
                },
                oncePerCombatTags = new()
                {
                    "manyTurns"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.OneHitPointThisIsFine_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 1,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "phone"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.OneHitPointThisIsFine_Multi_1"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 1,
                oncePerCombatTags = new()
                {
                    "aboutToDie"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.WeDidOverFiveDamage_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 6,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "dark"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeDidOverFiveDamage_Multi_1"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 6,
                allPresent = new()
                {
                    SlimeWho,
                    "riggs"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = "riggs",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeDidOverFiveDamage_Multi_2"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 6,
                allPresent = new()
                {
                    SlimeWho,
                    "riggs",
                    "peri"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = "peri",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "shy"
                    },
                    new CustomSay()
                    {
                        who = "riggs",
                        Text = Instance.StoryLocs.Localize([currentStory, "3"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeDidOverFiveDamage_Multi_3"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 6,
                allPresent = new()
                {
                    SlimeWho,
                    "goat"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "goat",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeDidOverFiveDamage_Multi_4"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 6,
                allPresent = new()
                {
                    SlimeWho,
                    "eunice"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "eunice",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeDidOverFiveDamage_Multi_5"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 6,
                allPresent = new()
                {
                    SlimeWho,
                    "hacker"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = "hacker",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeDidOverFiveDamage_Multi_6"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 6,
                allPresent = new()
                {
                    SlimeWho,
                    "shard"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "phone"
                    },
                    new CustomSay()
                    {
                        who = "shard",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "paws"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeDidOverFiveDamage_Multi_7"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 6,
                allPresent = new()
                {
                    SlimeWho,
                    "comp"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "transition"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactRecalibrator_Multi_0"] = new()
            {
                type = NodeType.combat,
                playerShotJustMissed = true,
                hasArtifacts = new()
                {
                    "Recalibrator"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactRecalibrator_Multi_1"] = new()
            {
                type = NodeType.combat,
                playerShotJustMissed = true,
                hasArtifacts = new()
                {
                    "Recalibrator"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.HandOnlyHasTrashCards_Multi_0"] = new()
            {
                type = NodeType.combat,
                handFullOfTrash = true,
                oncePerRun = true,
                oncePerCombatTags = new()
                {
                    "handOnlyHasTrashCards"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.HandOnlyHasTrashCards_Multi_1"] = new()
            {
                type = NodeType.combat,
                handFullOfTrash = true,
                oncePerRun = true,
                oncePerCombatTags = new()
                {
                    "handOnlyHasTrashCards"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "phone"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.OverheatGeneric_Multi_0"] = new()
            {
                type = NodeType.combat,
                goingToOverheat = true,
                oncePerCombatTags = new()
                {
                    "OverheatGeneric"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.OverheatGeneric_Multi_1"] = new()
            {
                type = NodeType.combat,
                goingToOverheat = true,
                oncePerCombatTags = new()
                {
                    "OverheatGeneric"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "phone"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.TheyHaveAutoDodgeLeft_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lastTurnEnemyStatuses = new()
                {
                    Status.autododgeLeft
                },
                oncePerCombatTags = new()
                {
                    "aboutAutododge"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.TheyHaveAutoDodgeRight_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lastTurnEnemyStatuses = new()
                {
                    Status.autododgeRight
                },
                oncePerCombatTags = new()
                {
                    "aboutAutododge"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.WeGotHurtButNotTooBad_Multi_0"] = new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageDealtToPlayerThisTurn = 1,
                maxDamageDealtToPlayerThisTurn = 1,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeGotHurtButNotTooBad_Multi_1"] = new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageDealtToPlayerThisTurn = 1,
                maxDamageDealtToPlayerThisTurn = 1,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.WeGotShotButTookNoDamage_Multi_0"] = new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxDamageDealtToPlayerThisTurn = 0,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.WeGotShotButTookNoDamage_Multi_1"] = new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxDamageDealtToPlayerThisTurn = 0,
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactCockpitTargetIsRelevant_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                enemyHasPart = "cockpit",
                hasArtifacts = new()
                {
                    "CockpitTarget"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactCockpitTargetIsRelevant_Multi_1"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                enemyHasPart = "cockpit",
                hasArtifacts = new()
                {
                    "CockpitTarget"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "peri"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "peri",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactJetThrustersNoRiggs_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                maxTurnsThisCombat = 1,
                oncePerRunTags = new()
                {
                    "OncePerRunThrusterJokesAboutRiggsICanMakeTheseTagsStupidlyLongIfIWant"
                },
                hasArtifacts = new()
                {
                    "JetThrusters"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                nonePresent = new()
                {
                    "riggs"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactJetThrustersNoRiggs_Multi_1"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                maxTurnsThisCombat = 1,
                oncePerRunTags = new()
                {
                    "OncePerRunThrusterJokesAboutRiggsICanMakeTheseTagsStupidlyLongIfIWant"
                },
                hasArtifacts = new()
                {
                    "JetThrusters"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                nonePresent = new()
                {
                    "riggs"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactNanofiberHull1_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                minDamageDealtToPlayerThisTurn = 1,
                maxDamageDealtToPlayerThisTurn = 1,
                oncePerRunTags = new()
                {
                    "NanofiberHull"
                },
                hasArtifacts = new()
                {
                    "NanofiberHull"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactNanofiberHull1_Multi_1"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                minDamageDealtToPlayerThisTurn = 1,
                maxDamageDealtToPlayerThisTurn = 1,
                oncePerRunTags = new()
                {
                    "NanofiberHull"
                },
                hasArtifacts = new()
                {
                    "NanofiberHull"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactNanofiberHull2_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                minDamageDealtToPlayerThisTurn = 2,
                oncePerRunTags = new()
                {
                    "NanofiberHull"
                },
                hasArtifacts = new()
                {
                    "NanofiberHull"
                },
                allPresent = new()
                {
                    SlimeWho
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactEnergyRefund_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                minCostOfCardJustPlayed = 3,
                oncePerCombatTags = new()
                {
                    "EnergyRefund"
                },
                hasArtifacts = new()
                {
                    "EnergyRefund"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "phone"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactShieldPrepIsGone_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                maxTurnsThisCombat = 1,
                oncePerRunTags = new()
                {
                    "ShieldPrepIsGoneYouFool"
                },
                doesNotHaveArtifacts = new()
                {
                    "ShieldPrep",
                    "WarpMastery"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactWarpMastery_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                maxTurnsThisCombat = 1,
                oncePerRunTags = new()
                {
                    "WarpMastery"
                },
                hasArtifacts = new()
                {
                    "WarpMastery"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactArmoredBay_Multi_0"] = new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 1,
                oncePerCombatTags = new()
                {
                    "ArmoredBae"
                },
                hasArtifacts = new()
                {
                    "ArmoredBay"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactArmoredBay_Multi_1"] = new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 1,
                oncePerCombatTags = new()
                {
                    "ArmoredBae"
                },
                hasArtifacts = new()
                {
                    "ArmoredBay"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactArmoredBay_Multi_2"] = new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 1,
                oncePerCombatTags = new()
                {
                    "ArmoredBae"
                },
                hasArtifacts = new()
                {
                    "ArmoredBay"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.ArtifactArmoredBay_Multi_3"] = new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 1,
                oncePerCombatTags = new()
                {
                    "ArmoredBae"
                },
                hasArtifacts = new()
                {
                    "ArmoredBay"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.addedSlimeMutation_Multi_0"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerCombat = true,
                oncePerRun = true,
                lookup = new()
                {
                    "addedSlimeMutation"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "dark"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.addedSlimeMutation_Multi_1"] = new()
            {
                type = NodeType.combat,
                oncePerCombat = true,
                oncePerRun = true,
                lookup = new()
                {
                    "addedSlimeMutation"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "squint"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.addedSlimeBLAST_Multi_0"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerCombat = true,
                oncePerRun = true,
                lookup = new()
                {
                    "addedSlimeBLAST"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "dark"
                    },
                    new CustomSay()
                    {
                        who = "eunice",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "sly"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.addedSlimeBLAST_Multi_1"] = new()
            {
                type = NodeType.combat,
                oncePerCombat = true,
                oncePerRun = true,
                lookup = new()
                {
                    "addedSlimeBLAST"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "squint"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.playedSlimeBLAST_Multi_0"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerCombat = true,
                oncePerRun = true,
                lookup = new()
                {
                    "playedSlimeBLAST"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "dark"
                    },
                    new CustomSay()
                    {
                        who = "eunice",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "sly"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.playedSlimeBLAST_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerCombat = true,
                oncePerRun = true,
                lookup = new()
                {
                    "playedSlimeBLAST"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.playedSlimeHug_Multi_0"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerCombat = true,
                oncePerRun = true,
                lookup = new()
                {
                    "playedSlimeHug"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "shard",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "excited"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.playedSlimeHug_Multi_1"] = new()
            {
                type = NodeType.combat,
                oncePerCombat = true,
                lookup = new()
                {
                    "playedSlimeBLAST"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = "peri",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.playedTankThrow_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lookup = new()
                {
                    "playedTankThrowNone"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "riggs",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "nervous"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.playedTankThrow_Multi_1"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lookup = new()
                {
                    "playedTankThrowA"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "hacker",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "smile"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.playedTankThrow_Multi_1"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lookup = new()
                {
                    "playedTankThrowB"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "dark"
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "feral"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.playedLeakingContainer_Multi_0"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lookup = new()
                {
                    "playedLeakingContainer"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "dizzy",
                    "peri"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "peri",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nap"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "dizzy",
                        Text = Instance.StoryLocs.Localize([currentStory, "3"]),
                        loopTag = "explains"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.playedLeakingContainer_Multi_1"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerRun = true,
                lookup = new()
                {
                    "playedLeakingContainer"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "riggs",
                    "peri"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "riggs",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "nervous"
                    },
                    new CustomSay()
                    {
                        who = "peri",
                        Text = Instance.StoryLocs.Localize([currentStory, "3"]),
                        loopTag = "mad"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.playedLeakingContainer_Multi_2"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lookup = new()
                {
                    "playedLeakingContainer"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "peri"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "peri",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "panic"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.playedLeakingContainer_Multi_3"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lookup = new()
                {
                    "playedLeakingContainer"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "goat"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "goat",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "panic"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.playedLeakingContainer_Multi_4"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lookup = new()
                {
                    "playedLeakingContainer"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "eunice"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "eunice",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "mad"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.playedLeakingContainer_Multi_5"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lookup = new()
                {
                    "playedLeakingContainer"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "hacker"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "hacker",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "smile"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.playedLeakingContainer_Multi_6"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lookup = new()
                {
                    "playedLeakingContainer"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "shard"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "shard",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "stoked"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.playedLeakingContainer_Multi_7"] = new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                lookup = new()
                {
                    "playedLeakingContainer"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "comp"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "grumpy"
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.playedTimestreamLeak_Multi_0"] = new()
            {
                type = NodeType.combat,
                priority = true,
                oncePerCombat = true,
                oncePerRun = true,
                lookup = new()
                {
                    "playedTimestreamLeak"
                },

                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "nervous"
                    },
                    new SaySwitch()
                    {
                        lines = new()
                        {
                            new CustomSay()
                            {
                                who = "dizzy",
                                Text = Instance.StoryLocs.Localize([currentStory, "2", "1"]),
                                loopTag = "explains"
                            },
                            new CustomSay()
                            {
                                who = "riggs",
                                Text = Instance.StoryLocs.Localize([currentStory, "2", "2"]),
                                loopTag = "nervous"
                            },
                            new CustomSay()
                            {
                                who = "peri",
                                Text = Instance.StoryLocs.Localize([currentStory, "2", "3"])
                            },
                            new CustomSay()
                            {
                                who = "goat",
                                Text = Instance.StoryLocs.Localize([currentStory, "2", "4"]),
                                loopTag = "panic"
                            },
                            new CustomSay()
                            {
                                who = "eunice",
                                Text = Instance.StoryLocs.Localize([currentStory, "2", "5"])
                            },
                            new CustomSay()
                            {
                                who = "hacker",
                                Text = Instance.StoryLocs.Localize([currentStory, "2", "6"]),
                                loopTag = "gloves"
                            },
                            new CustomSay()
                            {
                                who = "shard",
                                Text = Instance.StoryLocs.Localize([currentStory, "2", "7"]),
                                loopTag = "excited"
                            },
                            new CustomSay()
                            {
                                who = "comp",
                                Text = Instance.StoryLocs.Localize([currentStory, "2", "8"]),
                                loopTag = "feral"
                            }
                        }
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.hasArtifactFuelWalls_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                hasArtifacts = new()
                {
                    "CobraArtifactFuelWalls"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "crew",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.hasArtifactOverdriveTanks_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                hasArtifacts = new()
                {
                    "CobraArtifactOverdriveTanks"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "crew",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.hasArtifactUnstableTanks_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                hasArtifacts = new()
                {
                    "CobraArtifactUnstableTanks"
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "crew",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.hasArtifactCorrodeAttack_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                hasArtifacts = new()
                {
                    "CobraArtifactCorrodeAttack"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.hasArtifactDissolvent_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                hasArtifacts = new()
                {
                    "CobraArtifactDissolvent"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.hasArtifactPowerAcid_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                hasArtifacts = new()
                {
                    "CobraArtifactPowerAcid"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.hasArtifactSlimeHeart_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                hasArtifacts = new()
                {
                    "CobraArtifactSlimeHeart"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.hasArtifactToxicCaviar_Multi_0"] = new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                hasArtifacts = new()
                {
                    "CobraArtifactToxicCaviar"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
        }
    }
}