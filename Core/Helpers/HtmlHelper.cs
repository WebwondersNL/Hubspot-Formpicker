﻿using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Our.Umbraco.Hubspot.Models;

namespace Our.Umbraco.Hubspot.Helpers
{
    public static class HubspotHtmlExtensions
    {
        public static IHtmlString RenderHubspotForm(this HtmlHelper htmlHelper, HubspotFormViewModel hubspotFormViewModel)
        {
            return htmlHelper.Partial("~/App_Plugins/Our.Umbraco.Hubspot/Render/HubspotForm.cshtml", hubspotFormViewModel);
        }
    }
}
