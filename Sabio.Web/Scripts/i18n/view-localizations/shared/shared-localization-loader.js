(function () {
    angular.module(APPNAME)
        .controller("sharedLocalizationLoader", SharedLocalizationLoader);

    SharedLocalizationLoader.$inject = ['$scope', '$translatePartialLoader'];

    function SharedLocalizationLoader($scope, $translatePartialLoader) {
        $translatePartialLoader.addPart('/shared/_layoutSmarty');
        $translatePartialLoader.addPart('/shared/stylesheet');
    }
}());