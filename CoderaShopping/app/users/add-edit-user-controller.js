app.controller('AddEditUserController', [
    "$scope", "$uibModalInstance", "userId", 'UserService',
    function ($scope, $uibModalInstance, userId, UserService) {

        $scope.defaultStatus = [
            { id: '1', value: "Active" },
            { id: '2', value: "Disabled" },
            { id: '3', value: "InActive" },
            { id: '4', value: "Locked" }
        ];

        $scope.userModel = {
            UserId: null,
            FirstName: "",
            LastName: "",
            Email: "",
            Password: "",
            Mobile: "",
            Street: "",
            City: "",
            Zip: "",
            Country: "",
            UserStatus: ""
        };

        //$scope.submitErrors = false;
        //$scope.date = new Date();
        //$scope.format = 'dd-MM-yyyy';

        $scope.submitted = false;

        if (userId) {
            UserService.getById(userId).then(
                function (response) {
                    $scope.userModel = response.data;
                },
                function (response) {
                    alert(response.error)
                }
            )
        }

        $scope.addEditUser = function (form) {
            $scope.submitted = true;

            if (!form.$valid) {
                return;
            }
            //debugger
            if (userId) {   // povikaj edit
                UserService.editUser($scope.userModel).then(
                    function (response) {
                        $uibModalInstance.close();
                    },
                    function (response) {
                        alert(response.error)
                    }
                )
            }
            else {  // povikaj add
                UserService.createUser($scope.userModel).then(
                    function (response) {
                        $uibModalInstance.close();
                    },
                    function (response) {
                        alert(response.error)
                    }
                )
            }
        }

        $scope.dismiss = function () {
            $uibModalInstance.dismiss();
        };

        //$scope.reset = function () {
        //    $scope.$broadcast('show-errors-reset');
        //    $scope.user = { firstName: '' };
        //}

    }
]);

//app.directive('showErrors', function ($timeout) {
//    return {
//        restrict: 'A',
//        require: '^form',
//        link: function (scope, el, attrs, formCtrl) {
//            // find the text box element, which has the 'name' attribute
//            var inputEl = el[0].querySelector("[firstName]");
//            // convert the native text box element to an angular element
//            var inputNgEl = angular.element(inputEl);
//            // get the name on the text box
//            var inputName = inputNgEl.attr('firstName');

//            // only apply the has-error class after the user leaves the text box
//            var blurred = false;
//            inputNgEl.bind('blur', function () {
//                blurred = true;
//                el.toggleClass('has-error', formCtrl[inputName].$invalid);
//            });

//            scope.$watch(function () {
//                return formCtrl[inputName].$invalid
//            }, function (invalid) {
//                // we only want to toggle the has-error class after the blur
//                // event or if the control becomes valid
//                if (!blurred && invalid) { return }
//                el.toggleClass('has-error', invalid);
//            });

//            scope.$on('show-errors-check-validity', function () {
//                el.toggleClass('has-error', formCtrl[inputName].$invalid);
//            });

//            scope.$on('show-errors-reset', function () {
//                $timeout(function () {
//                    el.removeClass('has-error');
//                }, 0, false);
//            });
//        }
//    }
//});
