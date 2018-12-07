(function () {
    "use strict";
    angular.module(APPNAME)
        .controller('usersRegisterLoader', UsersRegisterLoader);
    UsersRegisterLoader.$inject = ['$translatePartialLoader'];
    function UsersRegisterLoader($translatePartialLoader) {
        var vm = this;
        vm.someothervalue = 'Some Other Value!'
        $translatePartialLoader.addPart('/Users/Register');
    }
}());