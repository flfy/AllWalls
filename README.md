# AllWalls

**AllWalls** is an essential QoL mod for *Data Center*, which aims to automatically unlock all wall sections when loading a game.
---

## Features

- Unlocks all wall sections. That is it.
---

## Requirements

- **[MelonLoader](https://melonwiki.xyz/#/)**
---

## Installation

1. Install **MelonLoader** for **Data Center**.
3. [Download]() the latest `.dll` release of **AllWalls**
4. Drag and drop `AllWalls.dll` into your **Data Center/Mods** folder.

```
Data Center/
└── Mods/
    └── AllWalls.dll
```

5. Launch the game. When loading a save, all walls will be unlocked.
---
## Building from Source

### Prerequisites

- .NET SDK 6.0 or newer.
- A working **Data Center** install with **MelonLoader** already installed.

### Setup

Set `gamepath` in `Local.Build.props` to your **Data Center** game folder containing **Data Center.exe**.

```xml
<Project>
  <PropertyGroup>
    <gamepath>/path/to/Data Center</gamepath>
  </PropertyGroup>
</Project>
```

### Build

Run:

```bash
dotnet build AllWalls.csproj
```

The compiled DLL is written to:

```text
bin/2.1.1/Debug/net6.0/AllWalls.dll
```

After the build completes, the project also copies `AllWalls.dll` into your game's `Mods` folder:

```text
<gamepath>/Mods/AllWalls.dll
```
