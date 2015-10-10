# ArduiOArt

ArduiOArt is a Hardware Project which can draw given image on paper using any drawing tool(pen, pencil, sketchpen etc.). It was created in GujAThon Hackathon in Summer 2013. ArduiOArt contains two sub projects. Find more details on their links below.<br/><br/>
(1) ArduiOArt : https://github.com/ronakp/ArduiOArt <br/>
(2) ArduiOArtArduino : https://github.com/ronakp/ArduiOArtArduino

<b>ArduiOArt</b>

ArduiOArt is a C#.NET project which takes image as a input and convert it into a two dimentional color code array. After conversion, it send generated data request by request to Arduino as a serial communication. I have created this project using Visual Studio 2010.

<b>ArduiOArtArduino</b>

ArduiOArtArduino is an Arduino project which handle data stream sent by ArduiOArt and draw it on paper. It controls 3 Motors which handles X-Axis, Y-Axis and Pen Holder motor movements respectively. 

<b>Hardware</b>

Arduino : https://www.sparkfun.com/products/11021
200 RPM Motor : http://robokits.co.in/motors/200rpm-12v-dc-motor-with-gearbox
