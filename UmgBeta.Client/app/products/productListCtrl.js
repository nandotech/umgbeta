(function () {
    "use strict";
    angular
        .module("productManagement")
        .controller("ProductListCtrl",
                    ["productResource", ProductListCtrl]);

function ProductListCtrl(productResource) {
    var vm = this;
    
    //vm.searchCriteria = "GDN";
    vm.sortProperty = "Price";
    vm.sortDirection = "desc";

    productResource.query(
        {
            //$filter: "contains(ProductCode,'" + vm.searchCriteria + "')" +
            //    " or contains(ProductName,'"+ vm.searchCriteria + "')",
            $orderby: vm.sortProperty + " " + vm.sortDirection
        }, function (data) {
        vm.products = data;
    });
}


}());