/// <reference path="../../../assets/admin/libs/node_modules/angular/angular.js" />


(function (app) {
    app.controller('productListController', productListController);

    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.products = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getProducts = getProducts;
        $scope.keyword = '';
        $scope.search = search;
        $scope.changeStatus = changeStatus;
        $scope.deleteProduct = deleteProduct;
        $scope.selectAll = selectAll;
        $scope.deleteMulti = deleteMulti;
        $scope.isAll = false;

        function deleteMulti() {
            var listId = $scope.selected.map(function (product) {
                return product.id
            });
            let url = 'https://localhost:44373/api/Product/deleteMulti';
            let success = function (result) {
                getProducts();
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
        }

        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                })
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                })
                $scope.isAll = false;
            }
        }

        $scope.$watch("products", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDeleteMulti').removeClass('disabled');
            }
            else {
                $('#btnDeleteMulti').addClass('disabled');
            }
        }, true)

        function deleteProduct(id) {
            $ngBootbox.confirm('Are you sure want to delete this item !')
                .then(
                    function () {
                        //var config = {
                        //    params: null,
                        //    url: 'https://localhost:44373/api/Product/' + id,
                        //}

                        var url = 'https://localhost:44373/api/Product/' + id;


                        apiService.del(url, null,
                            function (result) {
                                getProducts()
                                notificationService.displaySuccess('Delete item successful !')
                            },
                            function (error) {
                                notificationService.displayError('Delete item failed !')
                            }
                        )
                    }
                )

        }

        function changeStatus(productId) {
            let urlGet = 'https://localhost:44373/api/Product/' + productId;
            apiService.get(urlGet, null,
                function (result) {
                    let data = result.data;
                    data.status = data.status ? false : true;

                    let urlPut = 'https://localhost:44373/api/Product/' + productId;
                    apiService.put(urlPut, data,
                        function (result) {
                            getProducts();
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
            getProducts();
        }

        function getProducts(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 4
                }
            }
            apiService.get('https://localhost:44373/api/Product', config,
                function (result) {
                    if (result.data.totalCount === 0) {
                        notificationService.displayWarning("Không có bản ghi nào được tìm thấy");
                    }
                    else {
                        notificationService.displaySuccess(`Đã tìm thấy ${result.data.totalCount} bản ghi`)
                    }

                    $scope.products = result.data.items;
                    $scope.page = result.data.page;
                    $scope.totalPages = result.data.totalPages;
                    $scope.totalCount = result.data.totalCount;
                },
                function () {
                    console.log("load product category failed")
                }
            )
        }

        $scope.getProducts();
    }
})(angular.module('minhlndshop.products'))