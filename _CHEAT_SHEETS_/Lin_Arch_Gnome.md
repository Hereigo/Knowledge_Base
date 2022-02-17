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
yay -S remmina megasync gnome-system-monitor lollypop dropbox telegram-desktop visual-studio-code-bin skypeforlinux-stable-bin tlp tlpui keepassxc viber doublecmd-gtk2 kooha # =ScreenRec 4 Wayland

# TLP:
sudo tlp start
sudo systemctl enable tlp.service
sudo systemctl start tlp.service
sudo systemctl status tlp.service

# Remove Package:
yay -Rns [package-name]

# Remove orphaned packages:
yay -Rns $(yay -Qtdq)

# Remove useless Packages:
yay -Yc

# See Installed Apps:
yay -Qe 
yay -Qe | grep abc

# If necessary to test Microphone and Camera:
sudo pacman -S pavucontrol
```