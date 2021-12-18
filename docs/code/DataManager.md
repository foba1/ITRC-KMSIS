# DataManager
Manages building data.

## Primary member variables
### BuildingData
```cs
private string[,] buildingData;
```
This contains all data of buildings in DongJakGu.

### ExtraData
```cs
public ExtraData extraData;
```
This contains another data for save-file.

## Primary member functions
### SearchWithText
```cs
public List<GameObject> SearchWithText(string text)
```
Searches buildings with text and returns result of search.

### Save
```cs
public void Save()
```
Saves all data of current state as save-file.

### Load
```cs
private void Load()
```
Loads all data from save-file and updates current state.

### SearchFile
```cs
private string SearchFile(string fileName)
```
Searches file on the directory with the name of file.

## Primary member class
### Building
```cs
public class Building
```
This is class for saving information about buildings. Through this class, saves information about building objects, like name, position, scale, rotation, index, state, and so on.

### UserData
```cs
public class UserData
```
This is class for saving information about user. Through this class, saves information about current state, like information of camera (transform information).

### ExtraData
```cs
public class ExtraData
```
This is class for saving extra information about user. Through this class, saves search & sunlight records.
