'use strict';

angular.
module('gameDetail').
component('gameDetail', {
  templateUrl: 'game-detail/game-detail.template.html',
  controller: ['$state', '$stateParams', 'gameservice', '$scope',
    function GameDetailController($state, $stateParams, gameservice, $scope) {
      var self = this;

      gameservice.getGame($stateParams.gameId).then(function (data) {
        self.game = data;
      });

      $scope.submitForm = function (isValid) {
        if (isValid) {
          var gameDetailsObj = {
            gameId: self.game.gameId,
            title: self.game.title,
            rating: self.game.rating,
            developer: self.game.developer,
            genre: self.game.genre,
            description: self.game.description
          };

          gameservice.updateGame(gameDetailsObj).then(function (data) {
            self.game = data;
            $state.go('gameList');
          });
        }
      }
    }
  ]
});