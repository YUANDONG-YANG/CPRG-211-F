using System.Globalization;
using System.IO;
using FlightsApp.Data.Model;
using Microsoft.Maui.Storage;

namespace FlightsApp.Data.Tool
{
    public static class LoadData
    {
        /// <summary>
        /// 同步读取 MAUI 应用包中的 CSV 文件，并解析为 Flight 对象列表。
        /// 注意：CSV 文件需放在 Resources/Raw 下，并设置 Build Action 为 MauiAsset。
        /// </summary>
        /// <param name="csvFileName">CSV 文件名，例如 "flights.csv"</param>
        /// <returns>包含解析后 Flight 对象的列表</returns>
        public static List<Flight> LoadFlightsFromCsv(string csvFileName)
        {
            var flights = new List<Flight>();

            // 同步获取流（通过 .GetAwaiter().GetResult() 阻塞等待）
            using var stream = FileSystem.OpenAppPackageFileAsync(csvFileName).GetAwaiter().GetResult();
            using var reader = new StreamReader(stream);

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var columns = line.Split(',');
                if (columns.Length < 8)
                    continue;

                if (!int.TryParse(columns[6], out var duration))
                    duration = 0;

                if (!decimal.TryParse(columns[7], NumberStyles.Any, CultureInfo.InvariantCulture, out var cost))
                    cost = 0m;

                flights.Add(new Flight(
                    columns[0].Trim(),
                    columns[1].Trim(),
                    columns[2].Trim(),
                    columns[3].Trim(),
                    columns[4].Trim(),
                    columns[5].Trim(),
                    duration,
                    cost
                ));
            }

            return flights;
        }
    }
}
