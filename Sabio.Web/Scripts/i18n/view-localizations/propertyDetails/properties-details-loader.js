(function () {
    "use strict";
    angular.module(APPNAME)
        .controller('propertiesDetailsLoader', PropertiesDetailsLoader);
    PropertiesDetailsLoader.$inject = ['$translatePartialLoader'];
    function PropertiesDetailsLoader($translatePartialLoader) {
        $translatePartialLoader.addPart('/propertyDetails/details');
    }
}());