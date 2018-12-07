(function () {
    "use strict";
    angular.module(APPNAME)
        .controller('sharedLocalizationController', SharedLocalizationController);
    SharedLocalizationController.$inject = ['$scope', '$baseController', '$translate', '$window'];
    function SharedLocalizationController($scope, $baseController, $translate, $window) {
        var vm = this;
        vm.$scope = $scope;
        $baseController.merge(vm, $baseController);
        vm.currentLanguage = $translate.proposedLanguage();
        vm.isEnglish = null;
        vm.isChineseCn = null;
        vm.isChineseTw = null;
        vm.isSpanish = null;
        vm.topFlag = null;
        vm.topKey = null;
        vm.topText = null;
        vm.changeLanguage = changeLanguage;
        _isCurrentLanguage(vm.currentLanguage);

        function changeLanguage(langKey) {
            $translate.use(langKey);
            vm.currentLanguage = $translate.proposedLanguage();
            _isCurrentLanguage();
            //if we're at the property details page, we need to refresh
            if ((vm.$document[0].URL).includes('properties') || (vm.$document[0].URL).includes('Properties')) {
                $window.location.reload();
            }
        }

        function _isCurrentLanguage() {
            switch (vm.currentLanguage) {
                case ('en-US'):
                    vm.isEnglish = true;
                    vm.isChineseCn = false;
                    vm.isChineseTw = false;
                    vm.isSpanish = false;
                    vm.topFlag = "/assets/images/flags/us.png";
                    vm.topKey= 'en-US';
                    vm.topText = 'ENGLISH';
                    break;
                case ('zh-CN'):
                    vm.isEnglish = false;
                    vm.isChineseCn = true;
                    vm.isChineseTw = false;
                    vm.isSpanish = false;
                    vm.topFlag = "/assets/images/flags/cn.png";
                    vm.topKey = 'zh-CN';
                    vm.topText = '简体';
                    break;
                case ('zh-TW'):
                    vm.isEnglish = false;
                    vm.isCwhineseCn = false;
                    vm.isChineseTw = true;
                    vm.isSpanish = false;
                    vm.topFlag = "/assets/images/flags/tw.png";
                    vm.topKey = 'zh-TW';
                    vm.topText = '繁體';
                    break;
                case ('es'):
                    vm.isEnglish = false;
                    vm.isCwhineseCn = false;
                    vm.isChineseTw = false;
                    vm.isSpanish = true;
                    vm.topFlag = "/assets/images/flags/es.png";
                    vm.topKey = 'es';
                    vm.topText = 'ESPAÑOL';
                    break;
                default:
                    vm.isEnglish = true;
                    vm.isChineseCn = false;
                    vm.isChineseTw = false;
                    vm.isSpanish = false;
                    vm.topFlag = "/assets/images/flags/us.png";
                    vm.topKey= 'en-US';
                    vm.topText = 'ENGLISH';
                    break;
            }
        }
    }
}())