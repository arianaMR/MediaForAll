(function () {
    "use strict";
    angular.module(APPNAME).controller('documentTypesManageLoader', DocumentTypesManageLoader);
    function DocumentTypesManageLoader($translate, $translatePartialLoader) {
        var vm = this;
        vm.someProperty = 'documentTypes.manage.controllers'
    }
}());