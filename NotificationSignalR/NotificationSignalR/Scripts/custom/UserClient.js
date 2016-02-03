var UserApp = angular.module('UserApp', []);

UserApp.controller('UserController', function ($scope, $http) {

    getNotis();

    $scope.$watch('userIdBox', function () {

        console.log($scope.userIdBox);
        getUserNotifications();
        getUserName();

    });

    $scope.userIdBox = 2;


    function getUserNotifications() {

        $http.get("/api/usernotifications/" + $scope.userIdBox)
            .then(function (usernotilist) {
                $scope.usernotifs = usernotilist.data;
                console.log($scope.usernotifs);
            })

    }

    function getNotis() {
        $http.get("/api/notifications/")
            .then(function (notifs) {
                $scope.notis = notifs.data;
                console.log($scope.notis);
            })
    }

    function getUserName() {
        $http.get("/api/users/" + $scope.userIdBox)
        .then(function (userAPIResponse) {
            $scope.user = userAPIResponse.data;
            console.log($scope.user)
        })
    }
});
