//serviceProvider, configures the $translate and $translatePartialLoader services. This runs when the angular app is initialized
(function () {
    angular.module(APPNAME)
        .config(function ($translateProvider, $translatePartialLoaderProvider) {
            //determinePreferredLanguage attempts to figure out from the browser's window.navigator property what the browser's preferred language is. These aren't well standardized, so a switch is necassary to ensure we arrive at a language that matches the string we defined for our languages. 
            $translateProvider.determinePreferredLanguage();
            switch ($translateProvider.preferredLanguage()) {
                case ('en-US' || 'en-us' || 'en_US' || 'en_us' || 'en'):
                    $translateProvider.preferredLanguage('en-US');
                    break;
                //chinese simplified
                case ('zh-CN' || 'zh-cn' || 'zh_CN' || 'zh_cn' || 'zh-Hans-CN' || 'zh-Hans-cn' || 'zh_Hans_CN' || 'zh_Hans_CN' || 'zh-Hans' || 'zh_Hans' || 'zh'):
                    $translateProvider.preferredLanguage('zh-CN');
                    break;
                 /*uncomment this next case when you're ready to add traditional chinese as well
                 case ('zh-TW' || 'zh-tw' || 'zh_TW' || 'zh_tw' || 'zh-Hant-TW' || 'zh-Hant-tw' || 'zh_Hant_TW' || 'zh_Hant_TW' || 'zh-Hant' || 'zh_Hant'):
                        $translateProvider.preferredLanguage('zh-TW');*/
                    //We need to set some preferredLanguage equal to one of our strings to prevent flashes of untranslated content.
                default:
                    $translateProvider.preferredLanguage('en-US');
                    break;
            }
            //tells angular-translate to cache translation files when they're loaded and to look for them before reloading them.
                        
            $translateProvider
                //.preferredLanguage('en') //sets the default language
                .fallbackLanguage(['en-US', 'zh-CN']) //this is the series of languages that angular-translate will fallback through if a language tag in the preferredLanguage has not value. If you want to specify a series of fallback languages, pass them as items in an array.
                .useLocalStorage() //sets the client machine to remember a previous language choice, falls back to cookieStorage if browser doesn't support local storage

                /*Only one file loader configuration can be enabled at a time for angular-translate (unless you build a custom loader or a second angular app). If you change the choice of loader, then uncomment the corresponding files in the Bundle Config 
                .useUrlLoader('/endpoint/that/will/serve/JSON/data') //Preferred language must be set for this option to function.         
                .useSaticFileLoader(); //uncomment this if you want to switch over to static file loading */
                .useLoader('$translatePartialLoader', { urlTemplate: '/Scripts/i18n/view-localizations{part}-{lang}.json' })

                //.forceAsyncReload(true); //uncomment this if you are going to use the $translateProvider.translations() method anywhere in the site (this would only be the case if you were sourcing some of your translation data from within a controller and mixing it with the translation data from the JSON files, which is not recommended).

                //this prints missing translations to the console. Because loading occurs asynchronously, only pay attention to the yellow translation errors in the log after async loading is finished.
                //.useMissingTranslationHandlerLog()

                .useSanitizeValueStrategy('escape')

                //this tells angular translate. We don't have a cache set up for our angular app yet, so that would need to be set up for this to function.
                //.useLoaderCache(true);


        })

     //this places an event listener on the rootscope so that translation tables will refresh anytime a partial file is downloaded.
    .run(function ($rootScope, $translate) {
        $rootScope.$on('$translatePartialLoaderStructureChanged', function () {
            $translate.refresh();
        })
    })
})();//seriously
