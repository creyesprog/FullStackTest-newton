'use strict';

// Prepare routes here
angular.
module('gameApp').
config(['$stateProvider', function ($stateProvider) {
  $stateProvider.state('gameList', {
    url: '',
    component: 'gameList'
  });

  $stateProvider.state('detail', {
    url: '/details/:gameId',
    component: 'gameDetail'
  });
}]);