/// <reference path="../assets/admin/libs/node_modules/angular/angular.js" />
(function () {
    angular.module('minhlndshop', [ 'minhlndshop.products',
                                    'minhlndshop.product_categories',
                                    'minhlndshop.common'
                                    ]
                                ).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider']

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        })
        $urlRouterProvider.otherwise('/admin');
    }
})();