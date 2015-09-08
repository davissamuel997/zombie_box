TrackMyTrends.controller 'DashboardController', ['$scope', '$http', '$location', '$state', '$stateParams', ($scope, $http, $location, $state, $stateParams) ->

  init = ->
    console.log("inside the init")
    
  currentState = ->
    $state.current.name

  $scope.requestControl = {

  }

################################################################
################# Initialize ###################################

  init()

################################################################
################# Dashboard State ##############################

  if currentState() == 'dashboard'
    $scope.greeting = 'Welcome to the Dashboard!'
    debugger
]