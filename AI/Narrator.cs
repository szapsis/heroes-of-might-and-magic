using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Heroes_of_Might_and_Magic.Models;

namespace Heroes_of_Might_and_Magic.AI
{
    public static class Narrator
    {
        private static readonly HttpClient httpClient = new HttpClient();

        //private const string OllamaUrl = "http://localhost:11434/api/generate";
        private static readonly string OllamaUrl = Environment.GetEnvironmentVariable("OLLAMA_URL") ?? "http://localhost:11434/api/generate";
        //private const string ModelName = "qwen2.5:1.5b";
        private static readonly string ModelName = Environment.GetEnvironmentVariable("OLLAMA_MODEL") ?? "qwen2.5:1.5b";

        public static async Task<string> GetBattlefieldDescription(
            Unit unit1,
            Unit unit2)
        {
            string prompt = $"""
                You are a narrator in a fantasy strategy game.

                Describe the location and atmosphere before a battle.

                First army:
                {unit1.Count} {unit1.Name}

                Second army:
                {unit2.Count} {unit2.Name}

                Write one short atmospheric paragraph in English.
                Use no more than 60 words.
                Describe only the battlefield and atmosphere.
                Do not describe the battle result.
                """;

            var requestData = new
            {
                model = ModelName,
                prompt = prompt,
                stream = false
            };

            string json = JsonSerializer.Serialize(requestData);

            using StringContent content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            try
            {
                using HttpResponseMessage response =
                    await httpClient.PostAsync(OllamaUrl, content);

                response.EnsureSuccessStatusCode();

                string responseJson =
                    await response.Content.ReadAsStringAsync();

                OllamaResponse? ollamaResponse =
                    JsonSerializer.Deserialize<OllamaResponse>(
                        responseJson,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                if (ollamaResponse == null ||
                    string.IsNullOrWhiteSpace(ollamaResponse.Response))
                {
                    return "The battlefield is silent as both armies prepare for combat.";
                }

                return ollamaResponse.Response.Trim();
            }
            catch (HttpRequestException)
            {
                return "The battlefield description is unavailable because Ollama is not running.";
            }
            catch (JsonException)
            {
                return "The battlefield description could not be processed.";
            }
        }

        private class OllamaResponse
        {
            public string Response { get; set; } = string.Empty;
        }
    }
}