using Nickel;
using System.Collections.Generic;
using System.Linq;

namespace Sorwest.CorrosiveCobra;

internal static class CrossModDialogue
{
    private static ModEntry Instance => ModEntry.Instance;
    internal static void Inject(IModHelper helper)
    {
        string currentStory;
        string SlimeWho = Instance.SlimeDeck.Deck.Key();
        string? DaveWho = helper.Content.Decks.LookupByUniqueName("Dave::rft.Dave.DaveDeck")?.Deck.Key();
        string? JohannaWho = helper.Content.Decks.LookupByUniqueName("JohannaTheTrucker::JohannaTheTrucker.JohannaDeck")?.Deck.Key();
        string? SogginsWho = helper.Content.Decks.LookupByUniqueName("Shockah.Soggins::Shockah.Soggins.Deck.Soggins")?.Deck.Key();
        string? PhilipWho = helper.Content.Decks.LookupByUniqueName("clay.PhilipTheEngineer::clay.PhilipTheMechanic.PhilipDeck")?.Deck.Key();
        string? NolaWho = helper.Content.Decks.LookupByUniqueName("Mezz.TwosCompany::Mezz.TwosCompany.NolaDeck")?.Deck.Key();
        if (DaveWho is not null)
        {
            {
                DB.story.GetNode(currentStory = $"{SlimeWho}.playedTimestreamLeak_Multi_0")?.lines.OfType<SaySwitch>().FirstOrDefault()?.lines.Insert(0, new CustomSay()
                {
                    who = DaveWho,
                    Text = Instance.StoryLocs.Localize([$"{currentStory}", "2", "9"])
                });
            }
            {
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_25"] = new()
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
                        DaveWho,
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
                            who = DaveWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"])
                        }
                    }
                };
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_26"] = new()
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
                        DaveWho,
                    },
                    lines = new()
                    {
                        new CustomSay()
                        {
                            who = DaveWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "1"])
                        },
                        new CustomSay()
                        {
                            who = SlimeWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "nervous"
                        }
                    }
                };
            }
            {
                DB.story.all[currentStory = $"{SlimeWho}.WeDidOverFiveDamage_Multi_8"] = new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 6,
                    allPresent = new()
                    {
                        SlimeWho,
                        DaveWho
                    },
                    lines = new()
                    {
                        new CustomSay()
                        {
                            who = DaveWho,
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
                DB.story.all[currentStory = $"{SlimeWho}.playedLeakingContainer_Multi_8"] = new()
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
                        DaveWho
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
                            who = DaveWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"])
                        }
                    }
                };
            }
        }
        if (JohannaWho is not null)
        {

            {
                DB.story.GetNode(currentStory = $"{SlimeWho}.playedTimestreamLeak_Multi_0")?.lines.OfType<SaySwitch>().FirstOrDefault()?.lines.Insert(0, new CustomSay()
                {
                    who = JohannaWho,
                    Text = Instance.StoryLocs.Localize([$"{currentStory}", "2", "10"])
                });
            }
            {
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_27"] = new()
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
                        JohannaWho,
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
                            who = JohannaWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "sad"
                        }
                    }
                };
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_28"] = new()
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
                        JohannaWho,
                    },
                    lines = new()
                    {
                        new CustomSay()
                        {
                            who = JohannaWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                            loopTag = "reminisce"
                        },
                        new CustomSay()
                        {
                            who = SlimeWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "sad"
                        }
                    }
                };
            }
            {
                DB.story.all[currentStory = $"{SlimeWho}.WeDidOverFiveDamage_Multi_9"] = new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 6,
                    allPresent = new()
                    {
                        SlimeWho,
                        JohannaWho
                    },
                    lines = new()
                    {
                        new CustomSay()
                        {
                            who = JohannaWho,
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
                DB.story.all[currentStory = $"{SlimeWho}.playedLeakingContainer_Multi_9"] = new()
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
                        JohannaWho
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
                            who = JohannaWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "squint"
                        }
                    }
                };
            }
        }
        if (DaveWho is not null && JohannaWho is not null)
        {
            {
                DB.story.all[currentStory = $"{SlimeWho}.WeDidOverFiveDamage_Multi_8"] = new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = new()
                    {
                        SlimeWho,
                        DaveWho,
                        JohannaWho
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
                            who = JohannaWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "scared"
                        },
                        new CustomSay()
                        {
                            who = DaveWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "3"]),
                            loopTag = "squint"
                        }
                    }
                };
            }
        }
        if (SogginsWho is not null)
        {
            {
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_29"] = new()
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
                        SogginsWho,
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
                            who = SogginsWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "smug-2"
                        }
                    }
                };
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_30"] = new()
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
                        SogginsWho,
                    },
                    lines = new()
                    {
                        new CustomSay()
                        {
                            who = SogginsWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                            loopTag = "smug-3"
                        },
                        new CustomSay()
                        {
                            who = SlimeWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "squint"
                        }
                    }
                };
            }
        }
        if (PhilipWho is not null)
        {
            {
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_31"] = new()
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
                        PhilipWho,
                    },
                    lines = new()
                    {
                        new CustomSay()
                        {
                            who = PhilipWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                            loopTag = "excited"
                        },
                        new CustomSay()
                        {
                            who = SlimeWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "nervous"
                        }
                    }
                };
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_32"] = new()
                {
                    type = NodeType.combat,
                    once = true,
                    oncePerRun = true,
                    enemyShotJustHit = true,
                    maxHull = 2,
                    requiredScenes = new()
                    {
                        "Dizzy_Memory_2"
                    },
                    oncePerCombatTags = new()
                    {
                        "aboutToDie"
                    },
                    allPresent = new()
                    {
                        SlimeWho,
                        PhilipWho,
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
                            who = PhilipWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"])
                        }
                    }
                };
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_33"] = new()
                {
                    type = NodeType.combat,
                    once = true,
                    oncePerRun = true,
                    enemyShotJustHit = true,
                    maxHull = 2,
                    requiredScenes = new()
                    {
                        $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_37"
                    },
                    oncePerCombatTags = new()
                    {
                        "aboutToDie"
                    },
                    allPresent = new()
                    {
                        SlimeWho,
                        PhilipWho,
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
                            who = PhilipWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"])
                        }
                    }
                };
            }
        }
        if (SogginsWho is not null && PhilipWho is not null)
        {
            {
                DB.story.all[currentStory = $"{SlimeWho}.ThatsALotOfDamageToUs_Multi_5"] = new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = new()
                    {
                        SlimeWho,
                        PhilipWho,
                        SogginsWho
                    },
                    lines = new()
                    {
                        new CustomSay()
                        {
                            who = SogginsWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                            loopTag = "smug-3"
                        },
                        new CustomSay()
                        {
                            who = SlimeWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "squint"
                        },
                        new CustomSay()
                        {
                            who = PhilipWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "3"])
                        }
                    }
                };
            }
        }
        if (NolaWho is not null)
        {
            string IsabelleWho = helper.Content.Decks.LookupByUniqueName("Mezz.TwosCompany::Mezz.TwosCompany.IsabelleDeck")!.Deck.Key();
            string IlyaWho = helper.Content.Decks.LookupByUniqueName("Mezz.TwosCompany::Mezz.TwosCompany.IlyaDeck")!.Deck.Key();
            string GaussWho = helper.Content.Decks.LookupByUniqueName("Mezz.TwosCompany::Mezz.TwosCompany.GaussDeck")!.Deck.Key();
            string JostWho = helper.Content.Decks.LookupByUniqueName("Mezz.TwosCompany::Mezz.TwosCompany.JostDeck")!.Deck.Key();
            {
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_34"] = new()
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
                        IlyaWho,
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
                            who = IlyaWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "happy"
                        }
                    }
                };
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_35"] = new()
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
                        IsabelleWho,
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
                            who = IsabelleWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "shocked"
                        }
                    }
                };
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_36"] = new()
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
                        NolaWho,
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
                            who = IsabelleWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "smug"
                        }
                    }
                };
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_37"] = new()
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
                        GaussWho,
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
                            who = GaussWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "angry"
                        }
                    }
                };
                DB.story.all[currentStory = $"{SlimeWho}.Duo_AboutToDieAndLoop_Multi_38"] = new()
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
                        JostWho,
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
                            who = JostWho,
                            Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                            loopTag = "nap"
                        }
                    }
                };
            }
        }
    }
}