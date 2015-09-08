TrackMyTrends.factory 'SessionsService', ['$resource', '$http', '$q', ($resource, $http, $q) ->

  getActiveOrganizations: $resource "/get_active_organizations.json", {}, query: { method: 'GET', isArray: false }

  getCurrentUser: $resource "/users/current_user.json", {}, query: { method: 'GET', isArray: false }

  signOut: $resource "/users/sign_out.json", {}, query: { method: 'GET', isArray: false }

]