'use strict';

/**
 * @ngdoc function
 * @name doubiwebApp.controller:AboutCtrl
 * @description
 * # AboutCtrl
 * Controller of the doubiwebApp
 */
angular.module('doubiwebApp')
  .controller('AboutCtrl', function ($scope) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];
  });
