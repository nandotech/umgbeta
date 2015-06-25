(function () {
    "use strict";

    angular
            .module("common.services")
            .factory("productResource",
            ["$resource",
                "appSettings",
                "currentUser",
                productResource])

    function productResource($resource, appSettings, currentUser) {
        return $resource(appSettings.serverPath + "/api/products/:productId", null,
            {
                'get': {
                    headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                },
                'save': {
                    method: 'POST',
                    headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                },
                'update': {
                    method: 'PUT',
                    headers: {'Authorization': 'Bearer ' + currentUser.getProfile().token }
                },
                'query': {
                    isArray: true,
                    headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                }
            });

    }
}());