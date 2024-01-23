using System.Text.RegularExpressions;

namespace BookCatalogTask
{
    public static class HtmlParser
    {
        public static async Task<int?> FillPagesAsync(string identifier)
        {
            string url = $"https://archive.org/details/{identifier}";

            // Use a method to download the HTML content asynchronously
            string htmlContent = await DownloadHtmlAsync(url);

            // Parse the HTML content to find the number of pages
            return ParseNumberOfPages(htmlContent);
        }

        private static async Task<string> DownloadHtmlAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }

        private static int? ParseNumberOfPages(string htmlContent)
        {
            Match match = Regex.Match(htmlContent, @"<span itemprop=""numberOfPages"">(\d+)</span>");
            if (match.Success)
            {
                return int.Parse(match.Groups[1].Value);
            }

            return null; // Unable to find the number of pages
        }
    }
}
