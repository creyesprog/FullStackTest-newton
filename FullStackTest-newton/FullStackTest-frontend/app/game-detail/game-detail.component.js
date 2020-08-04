'use strict';

angular.
module('gameDetail').
component('gameDetail', {
  templateUrl: 'game-detail/game-detail.template.html',
  controller: ['$state', '$stateParams', 'gameservice',
    function GameDetailController($state, $stateParams, gameservice) {
      var self = this;

      gameservice.getGame($stateParams.gameId).then(function (data) {
        self.game = data;
      });

      self.submit = function submit() {
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
  ]
});