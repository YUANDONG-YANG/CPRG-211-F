using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightsApp.Data.Tool;
using FlightsApp.Data.Model;

namespace FlightsApp.Data.Service
{
    public interface IFlightsService
    {
        Task<List<Flight>> SearchFlightsAsync(string from, string to, string day);
        Task<string> ReserveFlightAsync(string flightCode, string? name, string? citizenship);
    }
    public class FlightsService : IFlightsService
    {
        // 直接将 LoadFlightsFromCsv 返回的 List<Flight> 赋值给 listFlights
        public String flightsCsvPath = "Properties/Raw/flights.csv";
        public Task<List<Flight>> SearchFlightsAsync(string from, string to, string day)
        {

            List<Flight> listFlights = LoadData.LoadFlightsFromCsv(flightsCsvPath);
            // 如果所有参数均为 "Any"，直接返回全部航班数据
            if (string.Equals(from, "Any", StringComparison.OrdinalIgnoreCase)
                && string.Equals(to, "Any", StringComparison.OrdinalIgnoreCase)
                && string.Equals(day, "Any", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(listFlights);
            }
            else
            {
                // 使用 LINQ 根据非 "Any" 的条件过滤数据
                IEnumerable<Flight> query = listFlights;

                if (!string.Equals(from, "Any", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(f => f.From.Equals(from, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.Equals(to, "Any", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(f => f.To.Equals(to, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.Equals(day, "Any", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(f => f.Day.Equals(day, StringComparison.OrdinalIgnoreCase));
                }

                return Task.FromResult(query.ToList());
            }
        }


        public Task<string> ReserveFlightAsync(string flightCode, string? name, string? citizenship)
        {
            // 模拟生成预订代码
            var code = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            return Task.FromResult(code);
        }
    }
}
