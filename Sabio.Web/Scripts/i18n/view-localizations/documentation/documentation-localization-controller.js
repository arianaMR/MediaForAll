//HEY!!! This file is only for demonstration purposes in the localization/documentation page
//You won't need to create a similar file for most pages when you internationalize them
//If you don't know what this controller is doing, you probably don't need it for your internationalization
//BUT, you do need the *-loader.js file

(function () {
    "use strict";
    angular.module(APPNAME).controller('documentationLocalizationController', DocumentationLocalizationController);
    DocumentationLocalizationController.$inject = ['$scope', '$baseController'];
        function DocumentationLocalizationController($scope, $baseController) {
            var vm = this;
            $baseController.merge(vm, $baseController);
            vm.someProperty = 'documentation.localization.examples.controllers';
        }
}());