# Stock Trader
__ECE 4180 Spring 2021 Final Project__  
Matthew Tan, Gracen Wallace  

## Parts List
* mBED microcontroller & USB cable
* Raspberry Pi 4 & 16GB SD card loaded with Raspbian OS
* Raspberry Pi mini-HDMI to HDMI cable
* Raspberry Pi power cable
* DC barrel jack mount & 5V wall wart
* Jumper wires
* Styrofoam
* Cardboard
* Servo
* HDMI monitor

## Schematic
_insert schematic here_  

## Installing & running GUI on the Raspberry Pi  
1. Install mono for the Pi, to run .NET applications in Linux  
```
sudo apt-get upgrade  
sudo apt-get install mono-complete
```
2. Install nuget for the Pi, to support Nuget .NET packages  
```
sudo apt-get install nuget
```
3. Pull GitHub repository to Pi  
```
git clone https://github.com/gracenw/stock_trader
```
4. Navigate to repository folder  
```
cd stock_trader
```
5. Load Nuget packages (specifically, RestSharp for HTTP requests)  
```
nuget restore stock_trader.sln  
```
6. Run executable to load GUI on Pi (make sure mBED is already plugged into Pi's USB port)
```
mono /home/pi/stock_trader/stock_trader/bin/Debug/stock_trader.exe
```

## mBED Source Code
```c
//insert source code here for mbed
```

__documentation requirements so we dont have to keep checking the canvas announcement:__  
Documentation on the project web page must include team member names, a parts list, schematic, source code, photos, and videos. Many students use this as an example of their work when interviewing, so it is worth additional effort to do a good job! The web page should explain the project idea, provide instructions, code, and hardware setups so that anyone could recreate your project along with photos and videos along with all team member names. Avoid posting web pages at random free web hosting sites (These can often disappear in a month) and somewhat silly meaningless names in titles like “My 4180 Project”. GitHub can have a documentation page. Documentation is a bit more critical this term since I can’t see your project this term!
