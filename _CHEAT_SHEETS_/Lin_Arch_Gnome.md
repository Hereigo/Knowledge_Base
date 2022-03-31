# Arch Gnome or EndeavourOS init:

```sh
# First of all:
sudo nano /etc/default/grub
sudo grub-mkconfig -o /boot/grub/grub.cfg

sudo pacman-mirrors --fasttrack && sudo pacman -Syyu

# Install Packages:
yay -S ufw gufw p7zip gnome-system-monitor chrome-gnome-shell nomacs megasync dropbox visual-studio-code-bin tlp tlpui keepassxc doublecmd-gtk2 skype simplescreenrecorder deepin-screenshot remmina freerdp qmmp #Qmmp: simple music

# Additionals packages:
remmina-plugin-rdesktop # possibly needed
kooha # = ScreenRecord for Wayland

# UFW:
sudo ufw enable
sudo systemctl enable ufw # ... ->
# Created symlink /etc/systemd/system/multi-user.target.wants/ufw.service → /usr/lib/systemd/system/ufw.service.
sudo ufw status

# TLP:
sudo tlp start
sudo systemctl enable tlp.service
sudo systemctl start tlp.service
sudo systemctl status tlp.servicey

# Enable SSD-Trim:
sudo systemctl enable fstrim.timer
sudo systemctl start fstrim.timer
sudo systemctl status fstrim.timer

# Remove orphaned packages:
yay -Rns $(yay -Qtdq)

# Remove useless Packages:
yay -Yc

# See Installed Apps:
yay -Qe | grep abc

# If necessary to test Microphone and Camera:
sudo pacman -S pavucontrol

# To update FONTS cache:
fc-cache -fvh
# -f     Force re-generation of apparently up-to-date cache files, overriding the  timestamp checking.
# -r     Erase all existing cache files and rescan.
# -v     Display status information while busy.
# -h     Show summary of options.

# Disable 10 min. lock after 3 failed login.
sudo nano /etc/security/faillock.conf
# SET -> deny = 0

# Change Language bar Displaying sign.
sudo gedit /usr/share/X11/xkb/rules/evdev.xml
# 1. Find such ">en<" or ">uk<"
# 2. Change to ">EN<" or ">UK<"

```