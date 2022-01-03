

using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json.Linq;
using Our.Umbraco.Hubspot.Models;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.Hubspot.Coverters
{
    public class ContentPickerValueConverter : PropertyValueConverterBase
    {
        public override bool IsConverter(IPublishedPropertyType propertyType) => propertyType.EditorAlias.Equals("Our.Umbraco.Hubspot.FormPicker");


        public override PropertyCacheLevel GetPropertyCacheLevel(IPublishedPropertyType propertyType)
            => PropertyCacheLevel.Snapshot;

        public override Type GetPropertyValueType(IPublishedPropertyType propertyType)
            => typeof(HubspotFormViewModel);

        public override object ConvertSourceToIntermediate(IPublishedElement owner, IPublishedPropertyType propertyType, object source,
            bool preview)
        {
            if (source == null)
            {
                return null;
            }

            var jObject = JObject.Parse(source.ToString());
            var jformId = jObject["Id"];
            var jportalId = jObject["PortalId"];

            if (jformId != null && jportalId != null)
            {
                var hubspotFormViewModel = new HubspotFormViewModel
                {
                    Id = jformId.Value<string>(),
                    PortalId = jportalId.Value<string>()
                };
                return hubspotFormViewModel;
            }

            return null;
        }
    }
}

