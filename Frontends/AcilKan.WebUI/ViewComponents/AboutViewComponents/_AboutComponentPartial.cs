using AcilKan.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AcilKan.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutComponentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync() 
        { 
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7132/api/Abouts");

            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAboutDto>(jsonData);
                return View(values);
            }

            return View(); 
        }
    }
}
