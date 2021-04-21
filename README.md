# Stock Trader
__ECE 4180 Spring 2021 Final Project__  
Matthew Tan, Gracen Wallace  

## Parts List
* [mBED microcontroller & cable](https://www.sparkfun.com/products/9564)
* [Raspberry Pi 4 basic kit](https://www.canakit.com/raspberry-pi-4-basic-kit.html)
* [16GB SD card](https://www.sparkfun.com/products/15051) with [Raspbian OS](https://www.raspberrypi.org/documentation/installation/noobs.md)
* [Raspberry Pi micro-HDMI to HDMI cable](https://www.adafruit.com/product/4302?gclid=Cj0KCQjw1PSDBhDbARIsAPeTqrd1HVeETRREtpcVv8ZM6UxX5sJTC2wGqX1TRvw2GPZ63em6XvAB6BsaAtaoEALw_wcB)
* [DC barrel jack mount](https://www.sparkfun.com/products/10811) 
* [5V wall wart](https://www.sparkfun.com/products/12889)
* [Jumper wires](https://www.sparkfun.com/products/11026)
* [Servo](https://www.sparkfun.com/products/11884)
* Styrofoam
* Cardboard
* HDMI monitor

## Schematic
![schematic](schematic.png)

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
3. Pull GitHub repository to Pi (be sure to pull while in the /home/pi folder)  
```
git clone https://github.com/gracenw/stock_trader
```
4. Navigate to repository folder  
```
cd stock_trader
```
5. Get a free API key from [IEXCloud](https://iexcloud.io/) and paste into stock_trader/token.txt
6. Load Nuget packages (specifically, RestSharp for HTTP requests)  
```
nuget restore stock_trader.sln  
```
7. Run executable to load GUI on Pi (make sure mBED is already plugged into Pi's USB port)
```
mono /home/pi/stock_trader/stock_trader/bin/Debug/stock_trader.exe
```

## mBED Source Code
```c
//insert source code here for mbed
```
