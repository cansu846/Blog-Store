using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlogStore.BussinessLayer.AnalizeCommentService
{
    public class HuggingFaceModerationService
    {
        private readonly HttpClient _httpClient;

        public HuggingFaceModerationService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<Dictionary<string, float>> GetToxicityScoresAsync(string text)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                "https://api-inference.huggingface.co/models/unitary/toxic-bert");

            request.Headers.Add("Authorization", "Bearer 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");

            var content = new
            {
                inputs = text
            };

            request.Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return null;

            var jsonString = await response.Content.ReadAsStringAsync();
            var parsed = JsonDocument.Parse(jsonString);

            var scores = new Dictionary<string, float>();

            foreach (var item in parsed.RootElement[0].EnumerateArray())
            {
                string label = item.GetProperty("label").GetString();
                float score = item.GetProperty("score").GetSingle();
                scores[label] = score;
            }

            return scores;
        }
    }


}
