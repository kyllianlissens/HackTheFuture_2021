using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HTF2021
{

    internal class B1Json
    {
        public string Date1 { get; set; }
        public string Date2 { get; set; }

    }
    internal static class B1
    {

        private static string testUrl = "api/path/2/easy/Sample";
        private static string productionUrl = "api/path/2/easy/Puzzle";

        private static readonly HTTPInstance clientInstance = new HTTPInstance();

        internal static void LocalExecution()
        {
            Console.WriteLine("-Local Execution: \n");
            B1Json b1Json = new B1Json();
            b1Json.Date1 = "15hh29DD2028YYYY51mm27ss10MM";
            b1Json.Date2 = "11mm1691YYYY16hh14DD01ss06MM";
            var localExecution = calculateDifference(b1Json.Date1, b1Json.Date2);
            Console.WriteLine(localExecution);
        }

        internal async static Task TestExecution()
        {
            Console.WriteLine("-Test Execution: \n");
            var testData = await clientInstance.client.GetFromJsonAsync<B1Json>(testUrl);
            Console.WriteLine($"Test endpoint data: {testData}");
            var testSolution = calculateDifference(testData.Date1, testData.Date2);
            Console.WriteLine(testSolution);
            var testPostResponse = await clientInstance.client.PostAsJsonAsync<double>(testUrl, testSolution);
            var testPostResponseValue = await testPostResponse.Content.ReadAsStringAsync();
            Console.WriteLine(testPostResponseValue);
        }

        internal async static Task ProductionExecution()
        {
            Console.WriteLine("-Production Execution: \n");
            var testData = await clientInstance.client.GetFromJsonAsync<B1Json>(productionUrl);
            Console.WriteLine($"Production endpoint data: {testData} \n");
            Console.WriteLine($"Production 1: {testData.Date1}\n");
            Console.WriteLine($"Production 2: {testData.Date2}\n");
            var testSolution = calculateDifference(testData.Date1, testData.Date2);
            Console.WriteLine($"Production solution {testSolution}");

            var testPostResponse = await clientInstance.client.PostAsJsonAsync<double>(productionUrl, testSolution);
            var testPostResponseValue = await testPostResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"Production endpoint response: {testPostResponseValue}");
        }

        internal static DateTime parseRandomDate(string date)
        {

            int seconds_int = 0;
            int minutes_int = 0;
            int hour_int = 0;
            if (date.Contains("ss"))
            {
                string[] temp_seconds = date.Split("ss");
                string seconds = temp_seconds[0].Substring(temp_seconds[0].Length - 2);
                seconds_int = int.Parse(seconds);

                string[] temp_minutes = date.Split("mm");
                string minutes = temp_minutes[0].Substring(temp_minutes[0].Length - 2);
                minutes_int = int.Parse(minutes);

                string[] temp_hours = date.Split("hh");
                string hours = temp_hours[0].Substring(temp_hours[0].Length - 2);
                hour_int = int.Parse(hours);
            }


            string[] temp_day = date.Split("DD");
            string day = temp_day[0].Substring(temp_day[0].Length - 2);
            int day_int = int.Parse(day);

            string[] temp_month = date.Split("MM");
            string month = temp_month[0].Substring(temp_month[0].Length - 2);
            int month_int = int.Parse(month);

            string[] temp_year = date.Split("YYYY");
            string year = temp_year[0].Substring(temp_year[0].Length - 4);
            int year_int = int.Parse(year);


            DateTime dateTime = new DateTime(year_int, month_int, day_int, hour_int, minutes_int, seconds_int);

            return dateTime;
        }

        internal static double calculateDifference(string temp_date1, string temp_date2)
        {
            DateTime date1 = parseRandomDate(temp_date1);
            DateTime date2 = parseRandomDate(temp_date2);
            TimeSpan diff = date1.Subtract(date2);

            double seconds = diff.TotalSeconds;
            if (seconds < 0)
                seconds *= -1;
            return seconds;
        }
    }
}
