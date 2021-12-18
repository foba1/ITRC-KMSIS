# RayManager
Manages function to use raycast.

## Primary member variables
### Length
```cs
private float length = 0.35f;
```
Length of the ray.

### Divisor
```cs
private int divisor = 150;
```
Divisor which is used for analysis.

## Primary member functions
### Ratio
```cs
public float Ratio(List<GameObject> pointList, Vector3 sunVector)
```
Calculates the percentage of points in sunlight and returns it.

### GetPointOnObject
```cs
public List<RaycastHit> GetPointOnObject(GameObject building)
```
Gets points on the surface of the building object.
