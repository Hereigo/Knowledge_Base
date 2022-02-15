# LXDE Micro setup:

1. Install Debian netinstall (do not choose a DE!).
   
2. Login as root in terminal:
   
```sh
    nano /etc/apt/sources.list (contrib non-free)

    apt update && apt dist-upgrade
    apt install sudo
    usermod -a -G sudo 

    apt install network-manager xorg lxde-core lightdm synaptic
    (network-manager-gnome wireless-tools voor wireless)
    reboot

    synaptic install: firmware-linux firmware-linux-free firmware-linux-nonfree
    leafpad lxterminal tuxcmd build-essential

    synaptic install: (alsa-base) alsa-utils alsamixergui libalsaplayer0
    sudo alsactl init
    aplay /usr/share/sounds/alsa/*
    remove pulseaudio
```