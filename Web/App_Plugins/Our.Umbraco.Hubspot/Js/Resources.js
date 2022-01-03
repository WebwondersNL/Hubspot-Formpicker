//adds the resource to umbraco.resources module:
angular.module('umbraco.resources').factory('hubspotResources',
    function ($q, $http, umbRequestHelper) {
        //the factory object returned
        return {
            //this calls the ApiController we setup earlier
            getHubspotFormsList: function (id) {
                return umbRequestHelper.resourcePromise(
                    $http.get("backoffice/OurUmbracoHubspot/Forms/GetAll"), "");
            }
        };
    }
); 