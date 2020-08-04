'use strict';

angular.
module('gameList').
component('gameList', {
  templateUrl: 'game-list/game-list.template.html',
  controller: ['gameservice', function GameListController(gameservice) {
    var self = this;
    self.orderProp = 'age';
    gameservice.getGames().then(function (data) {
      self.gameList = data;
    });
  }]
});