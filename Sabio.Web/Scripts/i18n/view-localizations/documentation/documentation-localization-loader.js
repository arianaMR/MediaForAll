(function () {
    "use strict";
    angular.module(APPNAME)
        .controller('documentationLocalizationLoader', DocumentationLocalizationLoader);
    DocumentationLocalizationLoader.$inject = ['$translatePartialLoader'];
    function DocumentationLocalizationLoader($translatePartialLoader) {
        $translatePartialLoader.addPart('/documentation/localization');
        //don't copy these next two line into your localization. It's only for documentation.
        var vm = this;
        vm.someothervalue = 'Some Other Value!'
    }
}());