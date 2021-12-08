/// <reference path="../../../assets/admin/libs/node_modules/angular/angular.js" />


(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getProductCategories = getProductCategories;
        $scope.keyword = '';
        $scope.search = search;
        $scope.changeStatus = changeStatus;
        $scope.deleteProductCategory = deleteProductCategory;
        $scope.selectAll = selectAll;
        $scope.deleteMulti = deleteMulti;
        $scope.isAll = false; 

        function deleteMulti() { 
            var listId = $scope.selected.map(function (productCategory) {
                return productCategory.id
            });
            let url = 'https://localhost:44373/api/ProductCategory/deleteMulti';
            let success = function (result) {
                getProductCategories();
                notificationService.displaySuccess("Delete successful !")
            }
            let fail = function (error) {
                notificationService.displayError('Delete unsuccessful !')
            }
            var data = {
                'listid': listId
            }
            var config = { 
                params: {
                    listid: JSON.stringify(listId),
                } 
            }
            apiService.del(url, config, success, fail);

            //var settings = {
            //    "url": "https://localhost:44373/api/ProductCategory/deleteMulti",
            //    "method": "DELETE",
            //    "timeout": 0,
            //    "headers": {
            //        "Content-Type": "application/json"
            //    },
            //    "data": JSON.stringify(listId),
            //};

            //$.ajax(settings).done(function (response) {
            //    console.log(response);
            //});

        }

        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                })
                $scope.isAll = true; 
            }
            else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                })
                $scope.isAll = false; 
            }
        }

        $scope.$watch("productCategories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true }); 
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDeleteMulti').removeClass('disabled');
            }
            else {
                $('#btnDeleteMulti').addClass('disabled'); 
            }
        }, true)

        function deleteProductCategory(id) {
            $ngBootbox.confirm('Are you sure want to delete this item !')
                .then(
                    function () {
                        //var config = {
                        //    params: null,
                        //    url: 'https://localhost:44373/api/ProductCategory/' + id,
                        //}

                        var url = 'https://localhost:44373/api/ProductCategory/' + id;


                        apiService.del(url, null,
                            function (result) {
                                getProductCategories()
                                notificationService.displaySuccess('Delete item successful !')
                            },
                            function (error) {
                                notificationService.displayError('Delete item failed !')
                            }
                        )
                    }
                )

        }

        function changeStatus(productCategoryId) {
            let urlGet = 'https://localhost:44373/api/ProductCategory/' + productCategoryId;
            apiService.get(urlGet, null,
                function (result) {
                    let data = result.data;
                    data.status = data.status ? false : true;

                    let urlPut = 'https://localhost:44373/api/ProductCategory/' + productCategoryId;
                    apiService.put(urlPut, data,
                        function (result) {
                            getProductCategories();
                            notificationService.displaySuccess("Chỉnh sửa thành công !")
                        },
                        function (error) {
                            notificationService.displayError("Chỉnh sửa thất bại !")
                        }
                    )

                },
                function (error) {
                    notificationService.displayError(error.data);
                }
            )
        }
        function search() {
            getProductCategories();
        }

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 4
                }
            }
            apiService.get('https://localhost:44373/api/ProductCategory', config,
                function (result) {
                    if (result.data.totalCount === 0) {
                        notificationService.displayWarning("Không có bản ghi nào được tìm thấy");
                    }
                    else {
                        notificationService.displaySuccess(`Đã tìm thấy ${result.data.totalCount} bản ghi`)
                    }

                    $scope.productCategories = result.data.items;
                    $scope.page = result.data.page;
                    $scope.totalPages = result.data.totalPages;
                    $scope.totalCount = result.data.totalCount;
                },
                function () {
                    console.log("load product category failed")
                }
            )
        }

        $scope.getProductCategories();
    }
})(angular.module('minhlndshop.product_categories'))