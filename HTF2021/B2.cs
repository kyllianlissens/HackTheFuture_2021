using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HTF2021
{
	internal class B2Json
	{
		public string Value { get; set; }

	}
	internal static class B2
	{

		private static string testUrl = "api/path/2/medium/Sample";
		private static string productionUrl = "api/path/2/medium/Puzzle";

		private static readonly HTTPInstance clientInstance = new HTTPInstance();
		internal static void LocalExecution()
		{
			Console.WriteLine("-Local Execution: \n");
			var testData = 2.229422381483193E+129;
			Console.WriteLine($"Test endpoint data: {testData}");
			var testSolution = LongestRepeatedSubstring(testData.ToString("F"));
			Console.WriteLine(testSolution);


		}

		internal async static Task TestExecution()
		{
			Console.WriteLine("-Test Execution: \n");
			var testData = await clientInstance.client.GetFromJsonAsync<double>(testUrl);
			Console.WriteLine($"Test endpoint data: {testData}");
			var testSolution = LongestRepeatedSubstring(testData.ToString("F"));
			Console.WriteLine(testSolution);
			var testPostResponse = await clientInstance.client.PostAsJsonAsync<string>(testUrl, testSolution);
			var testPostResponseValue = await testPostResponse.Content.ReadAsStringAsync();
			Console.WriteLine(testPostResponseValue);
		}

		internal async static Task ProductionExecution()
		{
			Console.WriteLine("-Production Execution: \n");
			var testData = await clientInstance.client.GetFromJsonAsync<double>(productionUrl);
			Console.WriteLine($"Production endpoint data: {Double.Parse(testData.ToString(), System.Globalization.NumberStyles.Float)} \n");
			var testSolution = LongestRepeatedSubstring(testData.ToString("F"));
			Console.WriteLine(testSolution);

			//var testPostResponse = await clientInstance.client.PostAsJsonAsync<string>(productionUrl, testSolution);
			//var testPostResponseValue = await testPostResponse.Content.ReadAsStringAsync();
			//Console.WriteLine($"Production endpoint response: {testPostResponseValue}");

		}

		static string LongestRepeatedSubstring(string str)
		{
			if (string.IsNullOrEmpty(str))
				return null;

			int N = str.Length;
			string[] substrings = new string[N];

			for (int i = 0; i < N; i++)
			{
				substrings[i] = str.Substring(i);
			}
			Array.Sort(substrings);


			string[] substring = new string[N];
			for (int i = 0; i < N - 1; i++)
			{
				substring[i] = LongestCommonString(substrings[i], substrings[i + 1]);
			}

			int count = 0;
			int biggest = 0;
			string mostOccuring = "";
			for (int i = 0; i < substring.Length; i++)
			{
				if (!string.IsNullOrEmpty(substring[i]))
				{
					if (substring[i].Length > 1)
					{
						count++;
						if (Regex.Matches(str, substring[i]).Count > biggest)
						{
							biggest = substring[i].Length;
							mostOccuring = substring[i];
						}
					}
				}
			}

			string result = count.ToString() + mostOccuring;
			return result;
		}

		static string LongestCommonString(string a, string b)
		{
			int n = Math.Min(a.Length, b.Length);
			string result = "";

			for (int i = 0; i < n; i++)
			{
				if (a[i] == b[i])
					result = result + a[i];
				else
					break;
			}
			return result;
		}
	}


}
