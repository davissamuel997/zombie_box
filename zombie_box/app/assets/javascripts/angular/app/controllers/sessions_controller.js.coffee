TrackMyTrends.controller 'SessionsController', ['$scope', 'SessionsService', '$http', '$location', '$state', '$stateParams', ($scope, SessionsService, $http, $location, $state, $stateParams) ->

  init = ->

  currentState = ->
  	$state.current.name

################################################################
##################### Login Control ############################

  $scope.loginControl = {


  }

################################################################
##################### Request Control ##########################

  $scope.requestControl = {
  	sign_out: ->
      SessionsService.signOut.query({}, (responseData) ->
        window.location = '/users/sign_in'
      )
  }

################################################################
#################### Sign Up Control ###########################

  $scope.signUpControl = {

    activeOrganizations: []

    getActiveOrganizations: ->
      if this.organizations && this.organizations.length == 0
        SessionsService.getActiveOrganizations.query({}, (responseData) ->
          $scope.signUpControl.activeOrganizations = responseData.activeOrganizations
        )

  }

################################################################
###################### View Control ############################

  $scope.viewControl = {

    selectedView: 'login'

    changeView: (view) ->
      if view && view.length > 0
        this.selectedView = view

        this.prepareView()

    prepareView: ->
      if this.selectedView == 'sign_up'
        $scope.signUpControl.getActiveOrganizations()

  }

################################################################
################# Initial data load ############################

  init()

################################################################
################# Index Route ##################################

  if currentState() == 'sign_in'
    console.log("inside the sign in route")

  if currentState() == 'sign_out'
  	console.log("inside the sign out route")

]