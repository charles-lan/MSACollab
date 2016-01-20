var NotiApp = angular.module('NotiApp', []);

NotiApp.controller('NotiController', function ($scope, NotiService) {
    getNotis();

    function getNotis() {
        NotiService.getNotis()

            .success(function (notifs) {
                $scope.notis = notifs;
                console.log($scope.notis);
            })

            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
            });
    }
});

NotiApp.factory('NotiService', ['$http', function ($http) {

    var NotiService = {};

    NotiService.getNotis = function () {
        return $http.get('/api/Notifications');
    };

    return NotiService;
}]);

