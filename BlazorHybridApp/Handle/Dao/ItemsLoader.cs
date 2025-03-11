using BlazorHybridApp.Handle.Constant;
using BlazorHybridApp.Handle.Models;
using Microsoft.Extensions.Logging;

namespace BlazorHybridApp.Handle.Tool
{

    public interface IItemsLoader
    {
        public List<Item> LoadItemsFromCsv();
    }
    class ItemsLoader : IItemsLoader
    {
        private readonly ILogger<ItemsLoader> logger;

        public ItemsLoader(ILogger<ItemsLoader> logger)
        {
            this.logger = logger;
        }

        public List<Item> LoadItemsFromCsv()
        {
            var items = new List<Item>();
            var filePath = Path.Combine(AppConstants.ITEMS_FILE);
            if (!File.Exists(filePath))
            {
                return items;
            }
            using var stream = FileSystem.OpenAppPackageFileAsync(AppConstants.ITEMS_FILE).GetAwaiter().GetResult();
            using var reader = new StreamReader(stream);

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var columns = line.Split(',')
                                  .Select(c => c.Trim())
                                  .ToArray();

                if (columns.Length < 3)
                    continue;

                if (!int.TryParse(columns[0], out var id))
                {
                    continue;
                }

                var title = columns[1];

                bool isDone = bool.TryParse(columns[2], out var parsedBool) ? parsedBool : false;

                try
                {
                    var item = new Item(id, title, isDone);
                    items.Add(item);
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "loading Items.csv error: {Message}", ex.Message);
                }

            }
            return items;
        }
    }
}
