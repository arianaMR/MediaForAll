(function () {
    "use strict";
    angular.module(APPNAME)
        .factory('personService', PersonServiceFactory);
    PersonServiceFactory.$inject = ['$baseService', '$sabio']
    function PersonServiceFactory($baseService, $sabio) {
        var aSabioServiceObject = sabio.services.person;
        var newService = $baseService.merge(true, {}, aSabioServiceObject, $baseService)
        console.log('person service', aSabioServiceObject);

        return newService;
    }
})();

(function () {
    "use strict";
    angular.module(APPNAME)
        .factory('chatService', ChatServiceFactory);
    ChatServiceFactory.$inject = ['$baseService', '$sabio']
    function ChatServiceFactory($baseService, $sabio) {
        var aSabioServiceObject = sabio.services.chat;
        var newService = $baseService.merge(true, {}, aSabioServiceObject, $baseService)
        console.log('chat service', aSabioServiceObject);

        return newService;
    }
})();

(function () {
    "use strict";
    angular.module(APPNAME)
        .controller('chatController', ChatController);
    ChatController.$inject = ['$baseController', '$scope', 'personService', 'chatService'];
    function ChatController($baseController
                            , $scope
                            , personService
                            , chatService) {
        var vm = this;
        vm.$scope = $scope;
        vm.name = sabio.page.currentUser;
        vm.chatId = sabio.page.chatId;
        vm.personService = personService;
        vm.chatService = chatService;
        vm.currentPersonId = sabio.page.currentPersonId;
        vm.message = '';
        vm.messages = [];
        vm.people = null;
        vm.showForm = false;
        vm.$scope.chatHub = $.connection.chatHub;
        vm.newMessage = _newMessage;
        vm.count = null;
        vm.id = null;
        vm.notify = vm.personService.getNotifier($scope);
        vm.$scope.chatHub.client.broadcastMessage = _broadcastMessage;
        vm.$scope.chatHub.client.updateUsersOnlineCount = _updateUsersOnlineCount;
        vm.showChatForm = _showChatForm;



        render();

        function render() {
            console.log(vm.chatId);
            vm.chatService.selectByChatId(vm.chatId, _onSuccessGetChat, _onError);
            vm.personService.getPeople(_onSuccessGetPeople, _onError);
            
            $.connection.hub.start()
                            .done(function () {
                                console.log('Now connected, connection ID=' + $.connection.hub.id);
                                vm.$scope.chatHub.server.onConnected();
                            })
                            .fail(function () {
                                console.log('Could not Connect!');
                            });
           
        };

        function _broadcastMessage(name, message) {
            var messageObject = {};

            messageObject.newMessage = name + ' says: ' + message;
            messageObject.id = vm.id + 1;
            vm.messages.push(messageObject);
            vm.id++;
            $scope.$apply();
        };
        function _newMessage() {
            var data = {
                "chatId": vm.chatId
                , "personId": vm.currentPersonId
                , "message": vm.message
                , "recipientName": vm.recipientName
                , "recipientNumber": vm.recipientNumber
            };
            vm.$scope.chatHub.server.sendMessage(vm.name, vm.message);
            vm.chatService.insertMessage(vm.chatId, data, _onSuccessInsertMessage, _onError);
            vm.message = '';
        };

        function _showChatForm() {
            vm.showForm = !vm.showForm;
        };

        function _updateUsersOnlineCount(count) {
            vm.notify(function () {
                vm.count = count;
            }); 
        };
        function _onSuccessGetPeople(data, xhr, status) {
            vm.notify(function () {
                console.log(data);
                vm.people = data.items;
            });
        };

        function _onSuccessInsertMessage(data, xhr, status) {
            console.log(data, xhr, status);
        }
        function _onSuccessGetChat(data, xhr, status) {
            vm.notify(function () {
                console.log(data.items);
                _formatMessages(data.items);
            });
        };

        function _formatMessages(array) {
            var message = {};
            for (var i = 0; i < array.length; i++) {
                message = {};
                message.newMessage = array[i].personName + " says: " + array[i].message;
                message.id = array[i].id
                vm.messages.push(message);
                vm.id = array[i].id
            };
            return message;
        };

        function _onError(jqXHR) {
            console.error(jqXHR)
        };
    }
})();