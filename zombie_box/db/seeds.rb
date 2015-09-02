
user1 = User.where(:first_name => 'Samuel', :last_name => 'Davis', :email => 'davissamuel@knights.ucf.edu').first_or_create(:password => 'password', :password_confirmation => 'password')
user2 = User.where(:first_name => 'Eric', :last_name => 'Momper', :email => 'emomper23@knights.ucf.edu').first_or_create(:password => 'password', :password_confirmation => 'password')
user3 = User.where(:first_name => 'Peter', :last_name => 'Lomason', :email => 'plomason@knights.ucf.edu').first_or_create(:password => 'password', :password_confirmation => 'password')