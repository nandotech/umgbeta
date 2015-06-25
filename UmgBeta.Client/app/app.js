(function () {
    "use strict";

    var app = angular.module("productManagement",
                            ["common.services",
                            "ui.router"]);

    app.config(["$stateProvider",
                "$urlRouterProvider",
                function ($stateProvider, $urlRouterProvider) {
                    $urlRouterProvider.otherwise("/");
                    $stateProvider
                        .state("home", {
                            url: "/",
                            templateUrl: "splash.html"
                        })
                    //Products
                    .state("productList", {
                        url: "/products",
                        templateUrl: "app/products/productListView.html",
                        controller: "ProductListCtrl",
                        controllerAs: "vm"
                    })
                    .state("productEdit", {
                        url: "/products/edit/:productId",
                        templateUrl: "app/products/productEditView.html",
                        controller: "ProductEditCtrl",
                        controllerAs: 'vm',
                        resolve: {
                            productResource: "productResource",

                            product: function (productResource, $stateParams) {
                                var productId = $stateParams.productId;
                                return productResource.get(
                                    { productId: productId }).$promise;
                            }
                        }
                    });
                }]
        
        );

}());