using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Dynamic;

namespace pokeinfo.Controllers
{
    public class PokemonController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("{id}")]
        public IActionResult Pokemon(int id)
        {
            var pokeInfo = new Dictionary<string, object>();
            PokeApiRequest.GetPokemonDataAsync(id, ApiResponse => 
            {
                pokeInfo = ApiResponse;
            }).Wait();
            ViewData["name"] = pokeInfo["name"];
                        // ViewData["type"] = "";
            List<object> types = JsonConvert.DeserializeObject<List<object>>(pokeInfo["types"].ToString());
            Dictionary<string, object> type1 = JsonConvert.DeserializeObject<Dictionary<string, object>>(types[0].ToString());
            string typeString = JsonConvert.DeserializeObject<Dictionary<string, string>>(type1["type"].ToString())["name"];
            if (types.Count > 1)
            {
                Dictionary<string, object> type2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(types[1].ToString());
                string type2string = JsonConvert.DeserializeObject<Dictionary<string, string>>(type2["type"].ToString())["name"];
                typeString = $"{typeString} / {type2string}";

            }
            ViewData["type"] = typeString;
            ViewData["height"] = pokeInfo["height"];
            ViewData["weight"] = pokeInfo["weight"];
            var sprites = JsonConvert.DeserializeObject<Dictionary<string, object>>(pokeInfo["sprites"].ToString());
            ViewData["img_url"] = sprites["front_default"];
            return View();
        }

    }
}
