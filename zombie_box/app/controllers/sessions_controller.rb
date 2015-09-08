class SessionsController < Devise::SessionsController

  skip_before_filter :require_login, :only => [:new, :create]

  respond_to :json, :html

  layout 'login'

  def get_current_user
    if current_user.present?
      response = {errors: false, current_user: current_user}

      if current_user.activated_organization_id.present? && current_user.activated_organization_id.to_i > 0
        response[:activated_organization] = Organization.find(current_user.activated_organization_id)
      else
        response[:activated_organization] = nil
      end

      if current_user.activated_dealer_id.present? && current_user.activated_dealer_id.to_i > 0
        response[:activated_dealer] = Dealer.find(current_user.activated_dealer_id)
      else
        response[:activated_dealer] = nil
      end

      respond_with response
    else
      respond_with nil
    end
  end

  protected
  def auth_options
    { :scope => resource_name, :recall => "#{controller_path}#new" }
  end

end