using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Por favor, digite sua cidade:");
			var city = Console.ReadLine();	

			var requisicaoWeb = WebRequest.CreateHttp("https://api.apixu.com/v1/current.json?key=41c36e56c6aa45e5b81151508192505&q=" + city);
			requisicaoWeb.Method = "GET";
			requisicaoWeb.UserAgent = "RequisicaoWeb";

			using (var resposta = requisicaoWeb.GetResponse())
			{
				var streamDados = resposta.GetResponseStream();
				StreamReader reader = new StreamReader(streamDados);
				object objResponse = reader.ReadToEnd();
				
				dynamic post = JsonConvert.DeserializeObject(objResponse.ToString());

				var clima = post.current.temp_c;

				string[] pop = new string[] { "1 - Shape of you - Ed Sheeran",
					"2 - Perfect - Ed Sheeran", "3 - Shallow - Bradley Cooper", "4 - Sugar - Marron5" };

				string[] rock = new string[] { "1 - Sweet Emotion - Aerosmith",
					"2 - Sweet Child O Mine - Guns N Roses", "3 - Confort Number - Pink Floyd ",
					"4 - Like a rolling stone - Bob Dylan" };

				string[] classica = new string[] { "1 - Piano Peace",
					"2 - Galaxies", "3 - Scintillations", "4 -The Cold Blue" };

				Console.WriteLine("Hoje está " + clima + " graus.");
				Console.WriteLine("Sua playlist de hoje: ");

				// Para =25ºC ou mais - Pop
				if (clima >= 25)
				{
					for (int i=0; i < 4; i++)
					{
						Console.WriteLine(pop[i]);
						
					}
					
				}
				// Para clima entre 10 e 25 - Rock
				else if (clima >= 10 || clima < 25)
				{
					for (int i = 0; i < 4; i++)
					{
						Console.WriteLine(rock[i]);

					}
				}
				// Para clima < 10 - Clássicas
				else if (clima < 10)
				{
					for (int i = 0; i < 4; i++)
					{
						Console.WriteLine(classica[i]);

					}
				}

				streamDados.Close();
				resposta.Close();
				Console.WriteLine("");
				Console.WriteLine("Aperte qualquer tecla para sair...");
				Console.ReadKey();
			} 
		}
	}
}
