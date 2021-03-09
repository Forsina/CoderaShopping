app.controller('UserController', [
    '$scope', '$uibModal', 'UserService',

    function ($scope, $uibModal, UserService) {

        getAllUsers();

        //function getAllUsers() {
        //    UserService.getAll().then(
        //        function (response) {
        //            $scope.allUsers = response.data;
        //        },
        //        function (response) {
        //            console.log(response.error);
        //        }
        //    )
        //}

        function getAllUsers() {

            $scope.currentPage = 1;
            $scope.maxSize = 5;

            UserService.countUsers().then(function (response) {
                $scope.usersLenght = response.data;
                //debugger;
            });

            UserService.paginateUsers($scope.currentPage, $scope.maxSize).then
                (function (response) {
                    $scope.allUsers = response.data;
                });

            $scope.change = function (userId) {
                UserService.getById(userId).then
                    (function (response) {
                        $scope.allUsers = response.data;
                    });
            }

            $scope.changePage = function () {
                UserService.paginateUsers($scope.currentPage, $scope.maxSize).then
                    (function (response) {
                        $scope.allUsers = {};
                        $scope.allUsers = response.data;
                    });
            }
        }

        //Add User
        $scope.openAddModal = function () {
            //debugger
            $scope.modalName = 'Add';
            var modalInstance = $uibModal.open({
                templateUrl: 'app/users/add-edit-user.html',
                controller: 'AddEditUserController',
                scope: $scope,
                resolve: {
                    userId: function () {
                        return undefined;
                    }
                }
            });
            modalInstance.result.then(function (result) {
                getAllUsers();
            })
        }

        //Edit User
        $scope.openEditModal = function (UserId) {
            //debugger
            $scope.modalName = 'Edit';
            var modalInstance = $uibModal.open({
                templateUrl: 'app/users/add-edit-user.html',
                controller: 'AddEditUserController',
                scope: $scope,
                resolve: {
                    userId: function () {
                        return UserId;
                    }
                }
            });
            modalInstance.result.then(function (result) {
                getAllUsers();
            })
        }

        //Delete User
        $scope.openDeleteModal = function (UserId) {
            //debugger
            var modalInstance = $uibModal.open({
                templateUrl: 'app/commonDelete/common-delete.html',
                controller: "CommonDeleteController",
                resolve: {
                    param: function () {
                        return UserId;
                    },
                    service: function () {
                        return UserService.delete;
                    }
                }
            });
            modalInstance.result.then(function (result) {
                getAllUsers();
            })
        }
    }
]);

app.filter('enumStatus', function () {
    return function (input) {
        var myEnum = {
            1: "Active",
            2: "Disabled",
            3: "InActive",
            4: "Locked"
        };
        return myEnum[input];
    }
});