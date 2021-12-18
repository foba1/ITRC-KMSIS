# BuildingManager
Manages functions to select or delect buildings, to change view mode, and so on.

## Primary member variables
### SelectedBuildingsList
```cs
private List<GameObject> selectedBuildingsList;
```
List of selected buildings. The buildings included in `selectedBuildingsList` are represented as green.

### DeletedBuildingsList
```cs
private List<GameObject> deletedBuildingsList;
```
List of deleted buildings. The buildings included in `deletedBuildingsList` are not shown on the screen.

## Primary member functions
