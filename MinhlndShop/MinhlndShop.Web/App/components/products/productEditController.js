/// <reference path="../../../assets/admin/libs/node_modules/angular/angular.js" />

(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService']
    function productEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {
        //$scope.productCategory = {
        //    CreatedDate: new Date(),
        //}

        //$scope.UpdateProduct = UpdateProduct;
        //$scope.GetSeoTitle = GetSeoTitle;

        //function GetSeoTitle() {
        //    $scope.productCategory.alias = commonService.getSeoTitle($scope.productCategory.name);
        //}

        //function loadProductDetail() {

        //    let url = 'https://localhost:44373/api/ProductCategory/' + $stateParams.id;
        //    apiService.get(url, null,
        //        function (result) {
        //            $scope.productCategory = result.data;
        //        },
        //        function (error) {
        //            notificationService.displayError(error.data);
        //        }
        //    )
        //}
        //function UpdateProduct() {
        //    let url = 'https://localhost:44373/api/ProductCategory/' + $stateParams.id;
        //    apiService.put(url, $scope.productCategory,
        //        function (result) {
        //            notificationService.displaySuccess("Chỉnh sửa thành công !")
        //            $state.go('product_categories');
        //        },
        //        function (error) {
        //            notificationService.displayError("Chỉnh sửa thất bại !")
        //        }
        //    )
        //}

        //function loadParentCategory() {
        //    apiService.get('https://localhost:44373/api/ProductCategory/getParentProduct', null,
        //        function (result) {
        //            $scope.parentCategories = result.data;
        //        },
        //        function () {
        //            console.log("Can not get list parent")
        //        }
        //    )
        //}
        //loadParentCategory();
        //loadProductDetail()

    }
})(angular.module('minhlndshop.products'));
