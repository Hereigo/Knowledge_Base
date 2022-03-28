# EndeavourOS init:

```sh
# First of all:
sudo nano /etc/default/grub
sudo grub-mkconfig -o /boot/grub/grub.cfg

sudo pacman-mirrors --fasttrack && sudo pacman -Syyu

# Update & Upgrade Packages:
sudo yay -Syu

yay -S ufw
yay -S gufw
sudo ufw enable
sudo systemctl enable ufw # ... ->
# Created symlink /etc/systemd/system/multi-user.target.wants/ufw.service → /usr/lib/systemd/system/ufw.service.
sudo ufw status

# Enable SSD-Trim:
sudo systemctl enable fstrim.timer
sudo systemctl start fstrim.timer
sudo systemctl status fstrim.timer

# Install Packages:
yay -S remmina freerdp megasync gnome-system-monitor chrome-gnome-shell nomacs dropbox visual-studio-code-bin tlp tlpui keepassxc doublecmd-gtk2 skype 

remmina-plugin-rdesktop # possibly needed

kooha # = ScreenRecord for Wayland
simplescreenrecorder # for X11
deepin-screenshot # for X11

# TLP:
sudo tlp start
sudo systemctl enable tlp.service
sudo systemctl start tlp.service
sudo systemctl status tlp.servicey

# Remove Package:
yay -Rns [package-name]

# Remove orphaned packages:
yay -Rns $(yay -Qtdq)

# Remove useless Packages:
yay -Yc

# See Installed Apps:
yay -Qe | grep abc

# If necessary to test Microphone and Camera:
sudo pacman -S pavucontrol
```