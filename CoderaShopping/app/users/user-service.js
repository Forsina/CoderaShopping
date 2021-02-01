app.factory('UserService', [
    "$http", "appUrl",

    function ($http, appUrl) {
        var userService = this;

        userService.getAll = function () {
            return $http.post(appUrl + "Users/GetAll", null);
        }

        userService.getById = function (id) {
            return $http.post(appUrl + "Users/GetById", { userId: id });
        }

        userService.createUser = function (userModel) {
            return $http.post(appUrl + "Users/CreateUser", userModel);
        }

        userService.editUser = function (userModel) {
            return $http.post(appUrl + "Users/EditUser", userModel);
        }

        userService.delete = function (id) {
            return $http.post(appUrl + "Users/Delete", { userId: id });
        }

        userService.countUsers = function () {
            return $http.post(appUrl + "Users/UserListCount", null);
        }
       
        userService.paginateUsers = function (page, size) {
            return $http.post(appUrl + "Users/PaginateUsers/?page=" + page + "&size=" + size);
        }

        userService.searchByName = function (userName) {
            return $http.post(appUrl + "Users/SearchName", userName);
        }

        userService.searchByStatus = function (userStatus) {
            return $http.post(appUrl + "Users/SearchStatus", userStatus);
        }

        return userService;
    }
]);