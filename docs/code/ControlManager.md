# ControlManager
Manages functions to be controlled by user.

## Primary member variables
### DragSelectBox
```cs
public RectTransform dragSelectBox;
```
RectTransform variable which is used when user drags the mouse on the screen.

### Buildings
```cs
private GameObject buildings;
```
This is the parent object of building objects. Through this object, approaches to the child building objects.

### ImportedBuildings
```cs
private GameObject importedBuildings;
```
This is the parent object of imported building objects. Through this object, approaches to the child imported building objects.

### MainCamera
```cs
private GameObject mainCamera;
```
Main camera object.

## Primary member functions
### ZoomCamera
```cs
public void ZoomCamera()
```
Updates zoom of main camera when user scrolls the mouse.

### RotateCamera
```cs
public void RotateCamera()
```
Updates rotation of main camera when user moves camera using the mouse.

### UpdateDragSelectBox
```cs
private void UpdateDragSelectBox(Vector2 currentMousePosition)
```
Updates `dragSelectBox` with mouse position when user drags the mouse to select building objects.
