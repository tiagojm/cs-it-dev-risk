using CSQuestion.Models;
using CSQuestion.Services;
using System;
using System.Globalization;

namespace CSQuestion
{
    class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            var flowPipelineService = FlowPipelineService.Instance;

            var referrDate = Convert.ToDateTime(Console.ReadLine());
            var n = Convert.ToInt32(Console.ReadLine());
            var results = new string[n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var dataRead = line.Split(' ');
                var value = Convert.ToDouble(dataRead[0]);
                var sector = dataRead[1];
                var paymentDate = Convert.ToDateTime(dataRead[2]);

                var trade = new Trade(value, sector, paymentDate);
                trade.DefineCategory(referrDate, flowPipelineService.StepList);

                results[i] = trade.Category?.CategoryName;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(results[i] ?? "");
            }

            Console.ReadKey();
        }
    }
}
