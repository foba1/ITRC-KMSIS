# ImportManager
Manages function to import buildings.

## Primary member variables
### PrefabBuildings
```cs
public GameObject[] prefabBuildings;
```
This is sample model objects for user.

## Primary member functions
### ImportFromPath
```cs
public void ImportFromPath(string path)
```
Imports building from file.

### ImportFromPrefab
```cs
public void ImportFromPrefab(int index)
```
Imports building from sample model in `prefabBuildings`.
