# MySQL beginning.

```sh
sudo apt update && sudo apt install mysql-server -y

# First Secure Configuration:
sudo mysql_secure_installation

# Enter into MySql-Shell:
sudo mysql
# or 
mysql -u root -p

# Create User with Access and Test it:

CREATE USER 'myNewUser'@'localhost' IDENTIFIED BY 'password';
# Below the way is Recommended for better secutity
CREATE USER 'myNewUser'@'localhost' IDENTIFIED WITH authentication_plugin BY 'password';

GRANT PRIVILEGE ON database.table TO 'myNewUser'@'localhost';

GRANT CREATE, ALTER, DROP, INSERT, UPDATE, DELETE, SELECT, REFERENCES, RELOAD on *.* TO 'myNewUser'@'localhost' WITH GRANT OPTION;

FLUSH PRIVILEGES;
exit
mysql -u myNewUser -p

sudo mysqladmin -p -u myNewUser version

# Check MySQL Status:
systemctl status mysql.service

# Allow in Firewall:
sudo ufw allow mysql

# MySQL Run, Stop, Make Autostarted with system: 
sudo systemctl start/stop/enable mysql

```
