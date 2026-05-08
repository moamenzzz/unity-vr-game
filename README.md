# Unity VR Game - Single Room with Interactive Table

A simple VR game built with Unity featuring a single room with a large table and three interactive boxes that can be opened from the top.

## Project Overview

**Game Description:**
- Environment: One enclosed room
- Center: Large interactive table
- Interactive Objects: 3 boxes on the table that can be opened/closed
- VR Interaction: Grab and open boxes using VR controllers

## Requirements

- Unity 2022.3 LTS or later
- XR Plugin Management
- OpenXR Plugin (for VR support)
- Compatible VR headset (Meta Quest, HTC Vive, Valve Index, etc.)

## Project Structure

```
Assets/
├── Scenes/
│   └── MainScene.unity
├── Scripts/
│   ├── VRInteraction/
│   │   ├── BoxInteraction.cs
│   │   └── VRController.cs
│   └── Managers/
│       └── GameManager.cs
├── Models/
│   ├── Room/
│   ├── Table/
│   └── Boxes/
├── Materials/
└── Prefabs/
    ├── Box.prefab
    └── Table.prefab
```

## How to Set Up

1. Clone this repository
2. Open the project in Unity
3. Install XR Plugin Management and OpenXR from Package Manager
4. Open `Assets/Scenes/MainScene.unity`
5. Configure your VR device in Edit > Project Settings > XR Plugin Management
6. Press Play to test

## Controls

- **Grab**: Use grip button on VR controller to grab boxes
- **Open/Close**: Move controller upward while grabbing to open the box lid
- **Movement**: Use thumbstick to move around the room

## Features

- [x] Single room environment
- [x] Central table with 3 interactive boxes
- [x] Box opening/closing mechanics
- [ ] Advanced physics interactions
- [ ] Sound effects
- [ ] Particle effects

## Development Notes

This project focuses on creating an immersive VR interaction experience within a confined space. The game prioritizes intuitive hand controls and comfortable user experience.

## License

MIT
