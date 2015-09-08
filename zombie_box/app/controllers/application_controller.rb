class ApplicationController < ActionController::Base
  # Prevent CSRF attacks by raising an exception.
  # For APIs, you may want to use :null_session instead.
  protect_from_forgery with: :exception
  include Devise::Controllers::Helpers

  INCOMING_REQUESTS = [
  ]

  before_filter :configure_permitted_parameters, if: :devise_controller?
  before_filter :authenticate_user!, except: INCOMING_REQUESTS

  # rescue_from CanCan::AccessDenied do |exception|
  #   response = {root: true , alert: exception.message}
  #   respond_with response
  # end

  protected

  def configure_permitted_parameters
    devise_parameter_sanitizer.for(:sign_up) << [:first_name, :last_name]
  end
end
