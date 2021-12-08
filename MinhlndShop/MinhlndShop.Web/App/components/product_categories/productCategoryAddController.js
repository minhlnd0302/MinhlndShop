/// <reference path="../../../assets/admin/libs/node_modules/angular/angular.js" />

(function (app) { 
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state']
    function productCategoryAddController($scope, apiService, notificationService, $state) {
        $scope.productCategory = {
            CreatedDate : new Date(),
        }
        
        $scope.AddProductCategory = AddProductCategory;

        function AddProductCategory() {
            let url = 'https://localhost:44373/api/ProductCategory';
            apiService.post(url, $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess("Tạo thành công !")
                    $state.go('product_categories');
                },
                function (error) {
                    notificationService.displayError("Tạo thất bại !") 
                }
            )
        }

        function loadParentCategory() { 
            apiService.get('https://localhost:44373/api/ProductCategory/getParentProduct', null,
                function (result) {
                    $scope.parentCategories = result.data; 
                },
                function () {
                    console.log("Can not get list parent") 
                }
            )
        }
        loadParentCategory(); 
        
    }
})(angular.module('minhlndshop.product_categories'));