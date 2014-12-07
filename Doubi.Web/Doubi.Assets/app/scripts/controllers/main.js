'use strict';

/**
 * @ngdoc function
 * @name doubiwebApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the doubiwebApp
 */
angular.module('doubiwebApp')
  .controller('MainCtrl', function ($scope) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];
  });
