(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            return input ? 'Active' : 'UnActive';
        }
    })
})(angular.module('minhlndshop.common'));