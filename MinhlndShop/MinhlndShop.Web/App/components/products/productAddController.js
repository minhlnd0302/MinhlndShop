/// <reference path="../../../assets/admin/libs/node_modules/angular/angular.js" />

(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state','commonService']
    function productAddController($scope, apiService, notificationService, $state, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
        }
        $scope.ckeditorOptions = {
            language: 'en',
            allowedContent: true,
            entities: false
        }
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function startup() {
            $('#eCardFooter').kendoEditor({
                stylesheets: [
                    "./css/editor.css",
                ],
                tools: [
                    "bold",
                    "italic",
                    "underline",
                    "strikethrough",
                    "justifyLeft",
                    "justifyCenter",
                    "justifyRight",
                    "justifyFull",
                    "insertUnorderedList",
                    "insertOrderedList",
                    "insertUpperRomanList",
                    "insertLowerRomanList",
                    "indent",
                    "outdent",
                    "createLink",
                    "unlink",
                    "insertImage",
                    "insertFile",
                    "subscript",
                    "superscript",
                    "tableWizard",
                    "createTable",
                    "addRowAbove",
                    "addRowBelow",
                    "addColumnLeft",
                    "addColumnRight",
                    "deleteRow",
                    "deleteColumn",
                    "mergeCellsHorizontally",
                    "mergeCellsVertically",
                    "splitCellHorizontally",
                    "splitCellVertically",
                    "tableAlignLeft",
                    "tableAlignCenter",
                    "tableAlignRight",
                    "viewHtml",
                    "formatting",
                    "cleanFormatting",
                    "copyFormat",
                    "applyFormat",
                    "fontName",
                    "fontSize",
                    "foreColor",
                    "backColor",
                    "print"
                ]
            });
        }

        $scope.AddProduct = AddProduct;

        function AddProduct() {
            let url = 'https://localhost:44373/api/Product';
            apiService.post(url, $scope.product,
                function (result) {
                    notificationService.displaySuccess("Tạo thành công !")
                    $state.go('products');
                },
                function (error) {
                    notificationService.displayError("Tạo thất bại !")
                }
            )
        }

        function loadProductCategory() {
            apiService.get('https://localhost:44373/api/ProductCategory/getParentProduct', null,
                function (result) {
                    $scope.productCategories = result.data;
                },
                function () {
                    console.log("Can not get list parent")
                }
            )
        } 
        loadProductCategory(); 
    }
})(angular.module('minhlndshop.products'));