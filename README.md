# HoloLensChallenge20160809
Sample HoloLens Unity project for .NET Magic Night (2016-08-09)

## Challenge
1. Build Visual Studio solution.
2. Run App in HoloLens Emulator.
3. Use Gaze to project the cursor onto surfaces.
4. Use Gesture to make Earth drop and bounce.
5. Use Gesture to push Earth around.
6. Use Voice Command to reset Earth position.

## Machine Setup
You will need to install several tools and potentially upgrade your version of Windows to be able to develop for HoloLens.

1. Upgrade to Windows 10 Pro
1. If you’re Windows running under VMware Fusion
  1. Shutdown your Windows 10 virtual machine
  1. Open the “Virtual Machine Library”
  1. Select your Windows 10 virtual machine
  1. Click “Settings”
  1. Click “Processors & Memory”
  1. Set Memory to 8096MB
  1. Expand “Advanced Options”
  1. Check “Enable hypervisor applications in this virtual machine”
  1. Start your virtual machine up
1. Make sure Hyper-V is turned On in Windows 10
  1. Click the “Start” button
  1. Type “features” and select “Turn Windows features on or off”
  1. Turn “Hyper-V” on
1. Install [Visual Studio Update 3, HoloLens Emulator, and Unity HoloLens Technical Preview](https://developer.microsoft.com/en-us/windows/holographic/install_the_tools)

## Creating a Unity Project for HoloLens
1. Create Unity 3D project
1. Change coordinate of main camera to x:0 y:0 x:0
1. Change “Clear Flags” to “Solid Color” and set the Background color to black
1. Save project and scene as “Main”
1. Click “Edit” > “Project Settings” > “Quality”
  1. Select “Fastest” as the default level under the Windows Store Logo (green).
1. Click “Edit” > “Project Settings” > “Editor”
  1. Select “Visible Meta Files” under “Version Control”
  1. Select “Force Text” under “Asset Serialization”
1. Click “File” > “Build Settings…”
  1. Click “Add Open Scenes” button to add the Main scene
  1. Select “Windows Store” as the Platform
  1. Select “Universal 10” as the SDK
  1. Select “D3D” as UWP Build Type
  1. Check “Unity C# Project”
  1. Click “Player Settings…”
    1. Select “Publishing Settings” and under the “Capabilities” section check the following options:
      1. InternetClient
      1. Microphone
      1. SpacialPerception
    1. Select “Other Settings” and under the “Rendering” section check “Virtual Reality Supported” and “Use 16-bit Depth Buffers” (see [performance optimizations for HoloLens apps](https://developer.microsoft.com/en-us/windows/holographic/performance_recommendations_for_unity))
    1. Click “Build”
      1. Create the “App” folder in the project, navigate into the folder and start the build
1. Inside the “App” folder open the solution (*.sln file) in Visual Studio 
1. Switch architecture to “x86’ (instead of “ARM”)
1. Run under "HoloLensEmulator" instead of “LocalMachine” as the target runner
1. Attempt to run the project, it should launch the emulator

## Tips & Tricks for Getting Started
* Keep Visual Studio open and do all your coding there
* Keep emulator running at all times
* Use ESC to reset camera position in emulator ([more emulator keys](https://developer.microsoft.com/en-us/windows/holographic/advanced_emulator_input))
* Use W, A, S, D to move
* Use cursor keys to look up, down, right, and left
* Use page up/down to move up/down
* Use a mouse (if you can)
* Watch some “[HoloLens Academy](https://developer.microsoft.com/en-us/windows/holographic/academy)” tutorials
