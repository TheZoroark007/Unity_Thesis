How to build:

- Install Unity 2022.2 and Windows build support
- Install Azure Kinect SDK v. 1.4.1 from here: https://download.microsoft.com/download/3/d/6/3d6d9e99-a251-4cf3-8c6a-8e108e960b4b/Azure%20Kinect%20SDK%201.4.1.exe 
- Install Azure Kinect Body Tracking SDK v. 1.1.2  from here: https://www.microsoft.com/en-us/download/details.aspx?id=104221
- Download https://github.com/microsoft/Azure-Kinect-Samples/tree/master/body-tracking-samples/sample_unity_bodytracking , follow the instructions there on how to receive the needed files to get Azure Kinect working, then move these files to this project
  - In case you are stuck at step 1 and can't get NuGet to work: Try opening the Unity Project in Unity, then set VS as external tool, then Click on "Assets -> Open C# Project" despite of what the guide suggests. Then continue from the line that says "In Visual Studio: Select Tools..."
- Open up this Unity Project
- Let Unity install the needed Packages
- Open the ARCore Scene
- Save and restart Unity if you get any errors
- In case you get error "catching exception for background thread result = K4A_RESULT_FAILED", see this issue: https://github.com/microsoft/Azure-Kinect-Sensor-SDK/issues/1600
- Do NOT enable the "Canvas_Android" Asset in the Unity Editor
- Click on "Build and run"

The mobile App can be found here: https://drive.google.com/file/d/1zZ7YGFEcMt-pvAT8716p94zKC7B9S785/view?usp=sharing
This Repository uses Zxing.Net whichs License can be found here: https://github.com/zxing/zxing/blob/master/LICENSE
