(function () {
    "use strict";
    angular.module(APPNAME)
        .controller('landingPageIndexLoader', LandingPageIndexLoader);
    LandingPageIndexLoader.$inject = ['$translatePartialLoader'];
    function LandingPageIndexLoader($translatePartialLoader) {
        $translatePartialLoader.addPart('/landingPage/index');
    }
}());