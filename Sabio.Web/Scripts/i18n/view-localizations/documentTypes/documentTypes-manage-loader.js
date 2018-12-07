(function () {
    "use strict";
    angular.module(APPNAME).controller('documentTypesManageLoader', DocumentTypesManageLoader);
    DocumentTypesManageLoader.$inject = ['$translatePartialLoader'];
    function DocumentTypesManageLoader($translatePartialLoader) {
        var vm = this;
        vm.someothervalue = 'A value from the Localization Loader'
        $translatePartialLoader.addPart('/documentTypes/manage');
    }
}());