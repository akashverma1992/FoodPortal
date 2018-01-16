var uri = 'http://localhost:64991/api/clients/';

var app = angular.module('FoodPortal_Clients', []);

app.controller('GetClientsController', function ($scope, $http) {
    $http.get(uri).
        then(function (data, status, headers, config) {
            $scope.clients = data;
        })
});

app.controller('CreateClientController', ['$scope', 'CreateClientService',
    function ($scope, CreateClientService) {
        $scope.createClient = function () {
            var client = {
                ClientId: $scope.id,
                Name: $scope.name,
                Password: $scope.password,
                Email: $scope.email,
                Address: $scope.address,
                Contact: $scope.contact
            };
            console.log(client);
            CreateClientService.create(client);
        };
    }]);

app.factory('CreateClientService', ['$http', function ($http) {
    var create = function (client) {
        $http({
            method: 'POST',
            url: uri,
            data: client,
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(function succesCallBack(response) {
            return response;
        }), function errorCallBack() {
            return responseqe;
        }
    };

    return {
        create: create
    };
}]);