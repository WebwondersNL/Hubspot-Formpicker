using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using Our.Umbraco.Hubspot.Helpers;
using Our.Umbraco.Hubspot.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace Our.Umbraco.Hubspot.Resources
{
    [PluginController("OurUmbracoHubspot")]
    public class FormsController : UmbracoAuthorizedApiController
    {
        public List<HubspotFormDto> GetAll()
        {
            //TODO: Errorhandling
            var httpClient = Http.GetHttpClient();

            var hubspotApiKey = ConfigurationManager.AppSettings["Our.Umbraco.Hubspot.ApiKey"];

            var response = httpClient.GetAsync("https://api.hubapi.com/forms/v2/forms?hapikey=" + hubspotApiKey).Result;
            var forms = response.Content.ReadAsStringAsync().Result;
            var hubspotForms = HubspotForms.FromJson(forms);

            var formsDto = new List<HubspotFormDto>();
            foreach (var hubspotForm in hubspotForms)
            {
                var hubspotFormDto = new HubspotFormDto
                {
                    Name = hubspotForm.Name,
                    PortalId = hubspotForm.PortalId.ToString(),
                    Id = hubspotForm.Guid,
                    Fields = string.Join(", ", hubspotForm.FormFieldGroups.SelectMany(x => x.Fields).Select(y=>y.Label))
                };
                formsDto.Add(hubspotFormDto);
            }

            return formsDto;
        }
    }
}
