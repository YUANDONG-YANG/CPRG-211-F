using System.Globalization;
using BlazorHybridApp.Handle.Constant;
using BlazorHybridApp.Handle.Models;
using Microsoft.Extensions.Logging;

namespace BlazorHybridApp.Handle.Tool
{

    public interface IItemsSaver
    {
        public Boolean SaveItemsIntoCsv(List<Item> items);
    }
    class ItemsSaver(ILogger<ItemsLoader> logger) : IItemsSaver
    {
        public bool SaveItemsIntoCsv(List<Item> items)
        {
            try
            {
                string filePath = AppConstants.ITEMS_FILE;

                string? directory = Path.GetDirectoryName(filePath);

                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    logger.LogInformation("Created directory: {Directory}", directory);
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    logger.LogInformation("deleted firstly：{FilePath}", filePath);
                }

                using (var writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine("Id,Title,IsDone");

                    foreach (var item in items)
                    {
                        string line = string.Format(CultureInfo.InvariantCulture, "{0},{1},{2}",
                                                    item.Id,
                                                    item.Title,
                                                    item.IsDone);
                        writer.WriteLine(line);
                    }
                }

                logger.LogInformation("save items.csv successfully：{FilePath}", filePath);
                return true;
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex, "save items.csv file error !");
                return false;
            }
        }
    }
}
