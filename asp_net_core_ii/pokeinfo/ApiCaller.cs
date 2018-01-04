using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace pokeinfo
{
	public class PokeApiRequest
	{
		public static async Task GetPokemonDataAsync(int pokeId, Action<Dictionary<string, object>> Callback)
		{
			using (var client = new HttpClient())
			{
				try
				{
					client.BaseAddress = new Uri($"http://pokeapi.co/api/v2/pokemon/{pokeId}");
					HttpResponseMessage response = await client.GetAsync("");
					response.EnsureSuccessStatusCode();
					string stringResponse = await response.Content.ReadAsStringAsync();
					Dictionary<string, object> jsonResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
					Callback(jsonResponse);
				}
				catch (HttpRequestException e)
				{
					Console.WriteLine($"Request exception: {e.Message}");
				}
			}
		}
	}
}