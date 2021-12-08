/// <reference path="../../../assets/admin/libs/node_modules/angular/angular.js" />  
(function () {
    angular.module('minhlndshop.product_categories', ['minhlndshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider']

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('product_categories', {
                url: "/product_categories",
                templateUrl: "/app/components/product_categories/productCategoryListView.html",
                controller: "productCategoryListController"
            })
            .state('product_category_add', {
                url: "/product_category_add",
                templateUrl: "/app/components/product_categories/productCategoryAddView.html",
                controller: "productCategoryAddController"
            })
            .state('product_category_edit', {
                url: "/product_category_edit/:id",
                templateUrl: "/app/components/product_categories/productCategoryEditView.html",
                controller: "productCategoryEditController"
            })
    }
})();