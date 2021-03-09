app.controller('CommonDeleteController', [
    "$scope", "$uibModalInstance", "param", "service",
    function ($scope, $uibModalInstance, param, service) {

        $scope.delete = function () {
            service(param).then(
                function (response) {
                    $uibModalInstance.close();
                },
                function (response) {
                    alert(response.error)
                }
            )
        };

        $scope.dismiss = function () {
            $uibModalInstance.dismiss();
        };

    }]);
