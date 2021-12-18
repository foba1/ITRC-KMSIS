# SunManager
Manages information of sun.

## Primary member variables
### DegToRad
```cs
private double degToRad = 0.01745329251;
```
Variable which is used when convert degree to radian.

### RadToDeg
```cs
private double radToDeg = 57.2957795131;
```
Variable which is used when convert radian to degree.

## Primary member functions
### Calculate
```cs
public List<double> Calculate(int month, int day, float clock)
```
Calculates information about sun, like azimuth, altitude, sunrise, sunset. This values are calculated as below.

![image](https://user-images.githubusercontent.com/51505940/146635503-f0967122-653a-44dd-b3b3-237be017d4de.png)
----------------------------------------------
![image](https://user-images.githubusercontent.com/51505940/146635523-0bd1c0b1-b3e1-463d-ac84-ddf84ec1e5f1.png)

## CalculateSunVector
```cs
public Vector3 CalculateSunVector(double azimuth, double altitude)
```
Calculates directional-light-forward variable from azimuth, altitude.
