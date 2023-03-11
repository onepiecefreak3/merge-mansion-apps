using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using merge_mansion_cli.Wikia.Parser;
using WikiClientLibrary.Client;
using WikiClientLibrary.Pages;
using WikiClientLibrary.Wikia.Sites;

namespace merge_mansion_cli.Wikia
{
    static class WikiaHelper
    {
        private const string UserAgent_ = "MergeMansionDumper/1.0 (Discord: Merge Mansion Community)";

        public static async Task<WikiaSite> CreateWikia(string url, string botUser, string botPassword)
        {
            var client = new WikiClient { ClientUserAgent = UserAgent_ };
            var site = new WikiaSite(client, url);

            await site.Initialization;
            await site.LoginAsync(botUser, botPassword);

            return site;
        }

        public static async Task<WikiPage> CreatePage(WikiaSite site, string id)
        {
            var page = new WikiPage(site, id);
            await page.RefreshAsync();

            return page;
        }

        public static async Task UpdatePage(WikiPage page, string content)
        {
            page.Content = content;
            await page.UpdateContentAsync($"Bot update at {DateTime.Now}");
        }

        public static async Task<string> GetWikText(WikiaSite site, string page)
        {
            var token = await site.InvokeMediaWikiApiAsync(new MediaWikiFormRequestMessage(new Dictionary<string, string>
            {
                ["action"] = "visualeditor",
                ["page"] = page,
                ["paction"] = "wikitext",
                ["format"] = "json"
            }), CancellationToken.None);

            if (token["visualeditor"]?.Value<string>("result") != "success")
                return null;

            return token["visualeditor"].Value<string>("content");
        }
    }
}
