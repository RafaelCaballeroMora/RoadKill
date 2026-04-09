# RoadKill

This is a Unity project.

## Requirements

- Unity Editor `6000.4.0f1`
- Unity Hub
- Git
- A code editor such as VS Code or Rider

## Clone The Project

```powershell
git clone <repository-url>
cd RoadKill
```

## Open On Another Machine

1. Install Unity Hub if it is not already installed.
2. Install Unity Editor `6000.4.0f1` through Unity Hub.
3. Clone the repository on the new machine.
4. Open the project folder in Unity Hub.
5. Let Unity finish importing packages and generating the `Library` folder.

## Development Workflow

- Make changes in Unity, then save your scenes and assets.
- Commit only the project files that matter:
  - `Assets/`
  - `Packages/`
  - `ProjectSettings/`
- Do not commit generated folders like:
  - `Library/`
  - `Temp/`
  - `Logs/`
  - `UserSettings/`

## Notes

- The Unity version for this project is defined in [`ProjectSettings/ProjectVersion.txt`](ProjectSettings/ProjectVersion.txt).
- Package versions are defined in [`Packages/manifest.json`](Packages/manifest.json).
- The `Library` folder is recreated automatically by Unity on each machine, so it does not need to be shared.

## If The Project Does Not Open Correctly

- Confirm you are using the correct Unity version.
- Delete the local `Library/` folder and reopen the project if imports get corrupted.
- Make sure the packages in `Packages/manifest.json` can be downloaded on that machine.
