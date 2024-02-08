using System.Collections.Generic;
using System.Linq;

namespace Sorwest.CorrosiveCobra;

internal static class EventDialogue
{
    private static ModEntry Instance => ModEntry.Instance;
    internal static void Inject()
    {
        string currentStory;
        string SlimeWho = Instance.SlimeDeck.Deck.Key();

        // INSERT TO EXISTING EVENTS
        {
            DB.story.GetNode(currentStory = "CrystallizedFriendEvent")?.lines.OfType<SaySwitch>().FirstOrDefault()?.lines.Insert(0, new CustomSay()
            {
                who = SlimeWho,
                Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1"])
            });
            DB.story.GetNode(currentStory = "GrandmaShop")?.lines.OfType<SaySwitch>().FirstOrDefault()?.lines.Insert(0, new CustomSay()
            {
                who = SlimeWho,
                Text = Instance.StoryLocs.Localize([$"{SlimeWho}.{currentStory}", "1"])
            });
        }

        // NEW DIALOGUE FOR EXISTING EVENT CONDITIONS
        {
            DB.story.all[currentStory = $"{SlimeWho}.ChoiceCardRewardOfYourColorChoice_0"] = new()
            {
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = new()
                {
                    SlimeWho
                },
                bg = "BGBootSequence",
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.LoseCharacterCard_0"] = new()
            {
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = new()
                {
                    SlimeWho
                },
                bg = "BGSupernova",
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.CrystallizedFriendEvent_0"] = new()
            {
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = new()
                {
                    SlimeWho
                },
                bg = "BGCrystalizedFriend",
                lines = new()
                {
                    new Wait()
                    {
                        secs = 1.5
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "laugh",
                    }
                }
            };
        }

        // NEW EVENTS
        {
            DB.story.all[currentStory = $"{SlimeWho}.Event_WhoAreYou_1"] = new()
            {
                type = NodeType.@event,
                priority = true,
                once = true,
                lookup = new()
                {
                    "zone_first"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                bg = "BGRunStart",
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "squint"
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "3"])
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "4"])
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "5"]),
                        loopTag = "intense"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "6"]),
                        loopTag = "laugh"
                    },
                    new SaySwitch()
                    {
                        lines = new()
                        {
                            new CustomSay()
                            {
                                who = "dizzy",
                                Text = Instance.StoryLocs.Localize([currentStory, "7", "1"]),
                                loopTag = "explains"
                            },
                            new CustomSay()
                            {
                                who = "riggs",
                                Text = Instance.StoryLocs.Localize([currentStory, "7", "2"]),
                                loopTag = "banana"
                            },
                            new CustomSay()
                            {
                                who = "peri",
                                Text = Instance.StoryLocs.Localize([currentStory, "7", "3"]),
                                loopTag = "squint"
                            },
                            new CustomSay()
                            {
                                who = "goat",
                                Text = Instance.StoryLocs.Localize([currentStory, "7", "4"]),
                                loopTag = "squint"
                            },
                            new CustomSay()
                            {
                                who = "eunice",
                                Text = Instance.StoryLocs.Localize([currentStory, "7", "5"]),
                                loopTag = "squint"
                            },
                            new CustomSay()
                            {
                                who = "hacker",
                                Text = Instance.StoryLocs.Localize([currentStory, "7", "6"]),
                                loopTag = "squint"
                            },
                            new CustomSay()
                            {
                                who = "shard",
                                Text = Instance.StoryLocs.Localize([currentStory, "7", "7"]),
                            }
                        }
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "8"])
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "9"]),
                        loopTag = "intense"
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "10"]),
                        loopTag = "worried"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "11"])
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "12"])
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "13"]),
                        loopTag = "sad"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "14"]),
                        loopTag = "sad"
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "15"]),
                        loopTag = "worried"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "16"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Event_WhoAreYou_2"] = new()
            {
                type = NodeType.@event,
                priority = true,
                once = true,
                lookup = new()
                {
                    "zone_first"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                requiredScenes = new()
                {
                    $"{SlimeWho}.Event_WhoAreYou_1",
                },
                bg = "BGRunStart",
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "3"])
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "4"]),
                        loopTag = "intense"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "5"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "6"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "7"]),
                        loopTag = "intense"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "8"])
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Event_WhoAreYou_3"] = new()
            {
                type = NodeType.@event,
                priority = true,
                once = true,
                lookup = new()
                {
                    "zone_first"
                },
                allPresent = new()
                {
                    SlimeWho,
                },
                requiredScenes = new()
                {
                    $"{SlimeWho}.Event_WhoAreYou_2",
                },
                bg = "BGRunStart",
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "3"]),
                        loopTag = "worried"
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "4"])
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "5"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "6"]),
                        loopTag = "intense"
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "7"])
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        Text = Instance.StoryLocs.Localize([currentStory, "8"])
                    }
                }
            };
        }
        {
            DB.story.all[currentStory = $"{SlimeWho}.Event_Dizzy_1"] = new()
            {
                type = NodeType.@event,
                once = true,
                lookup = new()
                {
                    "zone_first"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "dizzy"
                },
                bg = "BGRunStart",
                lines = new()
                {
                    new CustomSay()
                    {
                        who = "dizzy",
                        Text = Instance.StoryLocs.Localize([currentStory, "1"]),
                        loopTag = "squint"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "2"]),
                        loopTag = "sad"
                    },
                    new CustomSay()
                    {
                        who = "dizzy",
                        Text = Instance.StoryLocs.Localize([currentStory, "3"]),
                        loopTag = "explains"
                    },
                    new CustomSay()
                    {
                        who = "comp",
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "4"])
                    },
                    new CustomSay()
                    {
                        who = "dizzy",
                        Text = Instance.StoryLocs.Localize([currentStory, "5"]),
                        loopTag = "frown"
                    }
                }
            };
            DB.story.all[currentStory = $"{SlimeWho}.Event_Dizzy_2"] = new()
            {
                type = NodeType.@event,
                once = true,
                lookup = new()
                {
                    "zone_first"
                },
                allPresent = new()
                {
                    SlimeWho,
                    "dizzy"
                },
                requiredScenes = new()
                {
                    $"{SlimeWho}.Event_Dizzy_1",
                },
                bg = "BGRunStart",
                lines = new()
                {
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "1"])
                    },
                    new CustomSay()
                    {
                        who = "dizzy",
                        Text = Instance.StoryLocs.Localize([currentStory, "2"])
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "3"])
                    },
                    new CustomSay()
                    {
                        who = "dizzy",
                        Text = Instance.StoryLocs.Localize([currentStory, "4"]),
                        loopTag = "explains"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "5"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "6"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "dizzy",
                        Text = Instance.StoryLocs.Localize([currentStory, "7"])
                    },
                    new CustomSay()
                    {
                        who = SlimeWho,
                        flipped = true,
                        Text = Instance.StoryLocs.Localize([currentStory, "8"]),
                        loopTag = "laugh"
                    },
                    new CustomSay()
                    {
                        who = "dizzy",
                        Text = Instance.StoryLocs.Localize([currentStory, "8"]),
                        loopTag = "shrug"
                    }
                }
            };
        }
    }
}