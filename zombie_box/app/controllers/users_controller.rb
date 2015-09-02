class UsersController < ApplicationController

  # skip_before_filter :authenticate_user!, only: []

  respond_to :json, :html

  def welcome
  end

  def user_params
    params.require(:user).permit(:first_name, :last_name, :email, :phone_number)
  end

  private :user_params
end
