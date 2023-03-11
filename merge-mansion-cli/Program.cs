using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using merge_mansion_cli.Dumper;
using merge_mansion_cli.Graphs;
using merge_mansion_cli.Models.Wikia;
using merge_mansion_cli.Wikia;
using Metaplay;
using Metaplay.Game.Logic;
using Metaplay.GameLogic.Area;
using Metaplay.GameLogic.Config.Costs;
using Metaplay.GameLogic.Hotspots;
using Metaplay.GameLogic.Player.Requirements;
using Metaplay.GameLogic.Player.Rewards;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Unity;
using Metaplay.Metaplay.Unity.ConnectionStates;

namespace merge_mansion_cli
{
    class Options
    {
        [Option('m', "mode", Required = true, HelpText = "Set the mode to dump data with\n  1: all\n  2: merge chains\n  3: areas\n  4: events\n  5: dialogs")]
        public int Mode { get; set; }

        //[Option('w', "wiki", Required = false, HelpText = "Set if the dumped data may be uploaded to the wiki.")]
        //public bool UploadWiki { get; set; } = false;
    }

    public enum Mode
    {
        All = 1,
        MergeChains,
        Areas,
        Events,
        Dialogs
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var parser = new Parser(parserSettings => parserSettings.AutoHelp = true);

            var parsedResult = parser.ParseArguments<Options>(args);

            await parsedResult
                .WithNotParsed(errors => DisplayHelp(parsedResult, errors))
                .WithParsedAsync(Execute);
        }

        private static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errors)
        {
            var helpText = HelpText.AutoBuild(result, h =>
            {
                h.AdditionalNewLineAfterOption = false;
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }, e => e);

            Console.WriteLine(helpText);
        }

        private static async Task Execute(Options o)
        {
            // Setup system
            var isSetup = SetupSystem();
            if (!isSetup)
                return;

            // Dump data to files
            Dump(o);

            // Dump data to wiki
            //if (o.UploadWiki)
            //    await DumpWiki(o);

            Console.WriteLine("Done.");
        }

        private static bool SetupSystem()
        {
            Console.WriteLine("Setup game session...");

            try
            {
            Initialize:
                MetaplayCore.Initialize();

                var client = new MetaplayClient();

                MetaplaySDK.Connection.Connect();

                while (ClientGlobal.SharedGameConfig == null)
                {
                    client.Update();

                    if (MetaplaySDK.Connection.State.Status == ConnectionStatus.Error)
                    {
                        if (MetaplaySDK.Connection.State is TerminalError.LogicVersionMismatch me)
                        {
                            GlobalOptions.MinVersion = me.ServerAcceptedVersions.MinVersion;
                            GlobalOptions.MaxVersion = me.ServerAcceptedVersions.MaxVersion;

                            MetaplayCore.Reset();

                            goto Initialize;
                        }

                        if (MetaplaySDK.Connection.State is TerminalError.InMaintenance maintenance)
                        {
                            Console.WriteLine("Servers are in maintenance.");
                            return false;
                        }

                        Console.WriteLine($"Connection Error ({MetaplaySDK.Connection.State.GetType().Name})");
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Aborted ({e.Message})");
                return false;
            }

            return true;
        }

        private static void Dump(Options o)
        {
            switch ((Mode)o.Mode)
            {
                case Mode.All:
                    DumpHelper.DumpAll();
                    break;

                case Mode.MergeChains:
                    DumpHelper.DumpMergeChains();
                    break;

                case Mode.Areas:
                    DumpHelper.DumpAreas();
                    break;

                case Mode.Events:
                    DumpHelper.DumpEvents();
                    break;

                case Mode.Dialogs:
                    DumpHelper.DumpDialogs();
                    break;
            }
        }

        private static async Task DumpWiki(Options o)
        {
            // TODO: Implement uploader to wiki
            Console.Write("Dump data to wiki... ");

            switch ((Mode)o.Mode)
            {
                case Mode.All:
                    DumpHelper.UploadAll();
                    break;

                case Mode.MergeChains:
                    DumpHelper.GetMergeChainData();
                    break;

                case Mode.Areas:
                    var areas = DumpHelper.GetAreaData();

                    var hotspotChildren = new Dictionary<HotspotId, IList<HotspotDefinition>>();
                    foreach (var hotspot in ClientGlobal.SharedGameConfig.HotspotDefinitions.EnumerateAll())
                    {
                        var def = (HotspotDefinition)hotspot.Value;
                        if (def.UnlockingParentRefs.Count <= 0)
                            continue;

                        foreach (var parent in def.UnlockingParentRefs)
                        {
                            var parentId = (HotspotId)parent.KeyObject;
                            if (!hotspotChildren.ContainsKey(parentId))
                                hotspotChildren[parentId] = new List<HotspotDefinition>();

                            hotspotChildren[parentId].Add((HotspotDefinition)hotspot.Value);
                        }
                    }

                    var hotspotLookup = areas.ToDictionary(x => x, y => GetTaskNodes(y, hotspotChildren));

                    var table = new WikiaTable(new WikiaText[] { "#", "Name", "Needs", "Opens", "Items", "Rewards" });
                    table.Classes.Add("article-table");

                    for (var ai = 0; ai < areas.Count; ai++)
                    {
                        var area = areas[ai];
                        if (area.AreaId.Value != "Driveway")
                            continue;

                        CreateHotspotTable(hotspotLookup[area].Where(x => x.Parents.Count <= 0).ToArray(), areas, hotspotLookup, new List<Node<HotspotDefinition>>(), table);

                        //var hotspots = hotspotLookup[area];
                        //for (var hi = 0; hi < hotspots.Count; hi++)
                        //{
                        //    var hotspot = hotspots[hi];

                        //    var values = new List<WikiaText>();

                        //    values.Add($"{ai + 1}-{hi + 1}");
                        //    values.Add(LocMan.GetHotspotDescription(hotspot.Data.Item1.Id));
                        //    values.Add(hotspot.Parents.Count <= 0 ? "-" : string.Join("<br>", hotspot.Parents.Cast<Node<(HotspotDefinition, AreaInfo)>>().Select(x => $"{areas.IndexOf(x.Data.Item2) + 1}-{hotspotLookup[x.Data.Item2].IndexOf(x) + 1}")));
                        //    values.Add(hotspot.Children.Count <= 0 ? "-" : string.Join("<br>", hotspot.Children.Cast<Node<(HotspotDefinition, AreaInfo)>>().Select(x => $"{areas.IndexOf(x.Data.Item2) + 1}-{hotspotLookup[x.Data.Item2].IndexOf(x) + 1}")));
                        //    values.Add(GetRequirements(hotspot.Data.Item1));
                        //    values.Add(GetRewards(hotspot.Data.Item1));

                        //    table.Rows.Add(values.ToArray());
                        //}
                    }

                    var wiki = await WikiaHelper.CreateWikia("https://merge-mansion.fandom.com/", "Diablovia@Merge_Mansion_Bot", "cg6baqk19bf279ok14knlu6k6q8t8fsd");
                    var page = await WikiaHelper.CreatePage(wiki, "API_Test_Page");
                    await WikiaHelper.UpdatePage(page, table.ToString());

                    break;

                case Mode.Events:
                    DumpHelper.GetEventData();
                    break;

                case Mode.Dialogs:
                    Console.WriteLine("Skip wiki upload for dialog images.");
                    return;
            }

            Console.WriteLine("Ok");
        }

        private static string GetRequirements(HotspotDefinition hotspot)
        {
            var requirements = new List<string>();
            foreach (var req in hotspot.RequirementsList)
            {
                switch (req)
                {
                    case PlayerItemRequirement it:
                        requirements.Add($"{(it.Requirement > 1 ? $"{it.Requirement}x" : string.Empty)}{{{{Item|{LocMan.GetItemCategoryName(it.Item)}|{it.Item.LevelNumber}}}}}");
                        break;

                    default:
                        throw new InvalidOperationException($"Unknown requirement {req.GetType().Name} for hotspots.");
                }
            }

            return string.Join("<br>", requirements);
        }

        private static string GetRewards(HotspotDefinition hotspot)
        {
            var rewards = new List<string>();
            foreach (var rew in hotspot.Rewards)
            {
                switch (rew)
                {
                    case RewardItem it:
                        rewards.Add($"{(it.Amount > 1 ? $"{it.Amount}x" : string.Empty)}{{{{Item|{LocMan.GetItemCategoryName(it.ItemRef.Ref)}|{it.ItemRef.Ref.LevelNumber}}}}}");
                        break;

                    case RewardExperience ex:
                        rewards.Add($"{{{{XP}}}}{ex.Amount}");
                        break;

                    default:
                        throw new InvalidOperationException($"Unknown reward {rew.GetType().Name} for hotspots.");
                }
            }

            return string.Join("<br>", rewards);
        }

        private static void CreateHotspotTable(IEnumerable<Node<HotspotDefinition>> hotspots, IList<AreaInfo> areas, IDictionary<AreaInfo, IList<Node<HotspotDefinition>>> hotspotLookup, IList<Node<HotspotDefinition>> processedNodes, WikiaTable table)
        {
            foreach (var hotspot in hotspots)
            {
                var areaId = areas.IndexOf(hotspot.Data.AreaRef.Ref);

                var values = new List<WikiaText>();

                values.Add($"{areaId + 1}-{hotspotLookup[hotspot.Data.AreaRef.Ref].IndexOf(hotspot) + 1}");
                values.Add(LocMan.GetHotspotDescription(hotspot.Data.Id));
                values.Add(hotspot.Parents.Count <= 0 ? "-" : string.Join("<br>", hotspot.Parents.Cast<Node<HotspotDefinition>>().Select(x => $"{areas.IndexOf(x.Data.AreaRef.Ref) + 1}-{hotspotLookup[x.Data.AreaRef.Ref].IndexOf(x) + 1}")));
                values.Add(hotspot.Children.Count <= 0 ? "-" : string.Join("<br>", hotspot.Children.Cast<Node<HotspotDefinition>>().Select(x => $"{areas.IndexOf(x.Data.AreaRef.Ref) + 1}-{hotspotLookup[x.Data.AreaRef.Ref].IndexOf(x) + 1}")));
                values.Add(GetRequirements(hotspot.Data));
                values.Add(GetRewards(hotspot.Data));

                table.Rows.Add(values.ToArray());

                if (processedNodes.Contains(hotspot)) 
                    continue;

                processedNodes.Add(hotspot);
                CreateHotspotTable(hotspot.Children.OfType<Node<HotspotDefinition>>(), areas, hotspotLookup, processedNodes, table);
            }
        }

        private static IList<Node<HotspotDefinition>> GetTaskNodes(AreaInfo area, Dictionary<HotspotId, IList<HotspotDefinition>> hotspotChildren)
        {
            // Put direct tasks of area into node hierarchy
            var hotspotDict = new Dictionary<HotspotId, Node<HotspotDefinition>>();
            foreach (var hotspot in area.HotspotsRefs.Where(x => (HotspotId)x.KeyObject != HotspotId.None).OrderBy(x => x.KeyObject))
            {
                var hotspotId = (HotspotId)hotspot.KeyObject;
                if (!hotspotDict.TryGetValue(hotspotId, out var node))
                    hotspotDict[hotspotId] = node = new Node<HotspotDefinition>(hotspot.Ref) { Text = GetNodeText(hotspot.Ref) };

                // Add parents of this hotspot
                foreach (var unlockParent in hotspot.Ref.UnlockingParentRefs)
                {
                    var unlockId = (HotspotId)unlockParent.KeyObject;
                    if (!hotspotDict.TryGetValue(unlockId, out var unlockParentNode))
                        hotspotDict[unlockId] = unlockParentNode = new Node<HotspotDefinition>((hotspot.Ref))
                        {
                            Text = GetNodeText((HotspotDefinition)ClientGlobal.SharedGameConfig.HotspotDefinitions.GetInfoByKey(unlockId))
                        };

                    unlockParentNode.AddChild(node);
                }

                // Add children of this hotspot
                if (hotspotChildren.ContainsKey(hotspotId))
                    foreach (var unlockChild in hotspotChildren[hotspotId])
                    {
                        var unlockId = unlockChild.Id;
                        if (!hotspotDict.TryGetValue(unlockId, out var unlockChildNode))
                            hotspotDict[unlockId] = unlockChildNode = new Node<HotspotDefinition>((unlockChild))
                            {
                                Text = GetNodeText(unlockChild)
                            };

                        node.AddChild(unlockChildNode);
                    }
            }

            return hotspotDict.Values.ToArray();
        }

        private static string GetNodeText(HotspotDefinition hotspot)
        {
            if (hotspot == null)
                return null;

            var res = hotspot.ConfigKey + Environment.NewLine + LocMan.GetHotspotDescription(hotspot.ConfigKey);

            foreach (var req in hotspot.RequirementsList)
            {
                if (req is PlayerItemRequirement pir)
                    res += Environment.NewLine + LocMan.GetItemName(pir.Item.ConfigKey) + " x" + pir.Requirement;
                else if (req is CostRequirement cr && cr.RequiredCost is CurrencyCost cc)
                    res += Environment.NewLine + "Coins x" + cc.CurrencyAmount;
            }

            return res;
        }
    }
}
