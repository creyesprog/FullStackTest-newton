'use strict';

angular
    .module('core')
    .factory('gameservice', function ($http, $q) {

        // Define service calls to interact with API
        var service = {
            getGames: getGames,
            getGame: getGame,
            updateGame: updateGame
        };

        function getGames() {
            return $http({
                method: 'GET',
                url: 'https://localhost:44337/api/games'
            }).then(function successCallback(response) {
                return response.data;
            }, function errorCallback(response) {
                return "Issue with server!";
            });
        }

        function getGame(gameId) {
            return $http({
                method: 'GET',
                url: 'https://localhost:44337/api/games/' + gameId
            }).then(function successCallback(response) {
                return response.data;
            }, function errorCallback(response) {
                return "Issue with server!";
            });
        }

        function updateGame(gameObj) {
            return $http({
                method: 'PUT',
                url: 'https://localhost:44337/api/games/' + gameObj.gameId,
                data: gameObj
            }).then(function successCallback(response) {
                return response.data;
            }, function errorCallback(response) {
                return "Issue with server!";
            });
        }

        return service;
    });