# AnalysisManager
Manages all processes of analysis for the information of sunlight.

## Primary Member variables
### PointList
```cs
private List<GameObject> pointList;
```
List of the surface-point object of the building which is analyzed currently.

### SelectedPointList
```cs
private List<GameObject> selectedPointList;
```
List of the selected surface-point object of the building which is analyzed currently.

### OptimizedPointList
```cs
private List<GameObject> optimizedPointList;
```
List of the optimized surface-point object of the building which is analyzed currently. If the size of `selectedPointList` is bigger than 200, an optimization algorithm is executed, selects part of `selectedPointList`, and saves them in `optimizedPointList`.

## Primary Member functions
### Init
```cs
public void Init(GameObject building)
```
Initializes AnalysisManager. To use RayManager, gets surface-points of the building, and executes `InstantiateObject`.

### Release
```cs
public void Release()
```
Releases AnalysisManager. Clears `pointList`, `selectedPointList`, and executes `DestroyObject`.

### EstimateTime
```cs
public float EstimateTime()
```
To check environment and estimate execution time, tests and records execution time for 1 point, 1 day.

### OptimizePoints
```cs
private List<GameObject> OptimizePoints(List<GameObject> pointList)
```
If the size of `pointList` parameter is bigger than 200, executes an optimization algorithm and returns `optimizedPointList`.
