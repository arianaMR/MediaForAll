(function () {
    "use strict";
    angular.module(APPNAME)
        .controller('propertiesDetailsController', propertiesDetailsController);
    propertiesDetailsController.$inject = ['$translatePartialLoader'];
    function propertiesDetailsController($translatePartialLoader) {
        var vm = this;
        vm.someothervalue = 'Some Other Value!'
        $translatePartialLoader.addPart('/properties/details');
    }
}());