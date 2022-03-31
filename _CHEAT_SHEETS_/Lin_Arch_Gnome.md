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
```