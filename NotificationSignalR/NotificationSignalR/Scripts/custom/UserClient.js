var UserApp = angular.module('UserApp', []);

UserApp.controller('UserController', function ($scope, UserService) {
    getUserNotifications();

    function getUserNotifications() {
        UserService.getUserNotifications()

            .success(function (usernotilist) {
                $scope.usernotifs = usernotilist;
                console.log($scope.usernotifs);
            })

            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
            });
    }
});

UserApp.factory('UserService', ['$http', function ($http) {

    var UserService = {};

    UserService.getUserNotifications = function () {
        return $http.get('/api/UserNotifications');
    };

    return UserService;
}]);

UserApp.controller('NotiController', function ($scope, NotiService) {
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

UserApp.factory('NotiService', ['$http', function ($http) {

    var NotiService = {};

    NotiService.getNotis = function () {
        return $http.get('/api/Notifications');
    };

    return NotiService;
}]);

UserApp.filter('searchFor', function () {
    return function (arr, searchString) {
        if (!searchString) {
            return arr;
        }
        var result = [];
        searchString = searchString.toLowerCase();
        angular.forEach(arr, function (item) {
            if (item.title.toLowerCase().indexOf(searchString) !== -1) {
                result.push(item);
            }
        });
        return result;
    };
});