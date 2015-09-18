#= require ng-rails-csrf
#= require angularjs/rails/resource

$ ->
  alert_div = $("#alert_notification")
  if alert_div[0]
    console.log alert_div[0].innerHTML
    $.gritter.add
      title: "<i class=\"fa fa-warning\"></i> Notice"
      text: alert_div[0].innerHTML
      sticky: false
      time: ""
      class_name: "gritter-notice"

window.gritterAdd = (title) ->
  if $.gritter
    $.gritter.add
      title: title
      sticky: false
      time: 10001
      class_name: "gritter-regular"
      before_open: ->
        false  if $(".gritter-item-wrapper").length is 1