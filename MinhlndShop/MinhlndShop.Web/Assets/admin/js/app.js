/// <reference path="../../node_modules/angular/angular.js" /> 
var myApp = angular.module('myModule', []);

myApp.controller("myControllerSchool", myControllerSchool);
//myApp.controller("myControllerStudent", myControllerStudent);
//myApp.controller("myControllerTeacher", myControllerTeacher);
myApp.service('Validator', Validator);
myApp.directive('minhlndShopDirective', minhlndShopDirective);

myControllerSchool.$inject = ['$scope', 'Validator'];

myApp.$inject = ['$scope'];


// ------------------ * declare * ------------------------//
//function myControllerStudent($scope) {
//    /*$scope.message = "This is my message from Student"*/
    
//}

//function myControllerTeacher($scope) {
//    $scope.message = "This is my message from Teacher"
//} 

function myControllerSchool($scope, Validator) {
    //$scope.message = "This is my message from School";
    //Validator.checkNumber(12);
    //$scope.number = 5;
    $scope.checkNumber = function () {
        Validator.checkNumber($scope.number);
    }
}

// ----------------- * Service * ------------------------// 
function Validator($window) {
    return {
        checkNumber: checkNumber,
    }
    function checkNumber(input) {
        if (input % 2 == 0) {
            $window.alert("This is even");
        }
        else {
            $window.alert('This is odd')
        }
    }
}

function minhlndShopDirective() {
    return {
        template : "<p> My first direactive </p>"
    }
}
