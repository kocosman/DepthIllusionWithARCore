# DepthIllusionWithARCore
## Combining Off-axis projection with face tracking via ARCore

<p float="left">
  <img src="https://github.com/kocosman/DepthIllusionWithARCore/blob/master/GIFS/Crystal_hand.gif" height="400" />
	<span>     </span>
  <img src="https://github.com/kocosman/DepthIllusionWithARCore/blob/master/GIFS/Mars_Face.gif" height="400" /> 
</p>

### The app is now available in Google Play Store:  https://play.google.com/store/apps/details?id=com.kocosman.DepthIllusionDemoScenes

This is pretty much the Android version of Peder Norrby's TheParallaxView project:
https://github.com/algomystic/TheParallaxView

Here are the steps if you'd like to create the project from scratch or some settings got lost during the upload.
- New project in Unity 2019.4.20f1 with Mobile 3D example (Add Android module to this Unity version if necessary) and change Build Settings
- Install ARCore SDK for Unity v1.22.0 from https://github.com/google-ar/arcore-unity-sdk/releases
- Project settings: 
	- XR settings: Check ARCore Supported
	- Resolution and Presentation: Allowed Orientations for Auto Rotation: Keep "Landscape Right" only
	- Other settings: 
		- Color Space: Gamma
		- Uncheck Auto Graphics API
		- Remove Vulkan from Graphics API list
		- Minimum API Level: Android 7.0 Nougat (API Level 24)
	- Publishing Settings:
		- Custom Main Gradle Template
		- Custom Launcher Gradle Template

After changing the publishing settings, you need to update the custom main and launch gradle templates that we've just created. 
Here's what you need to do: https://developers.google.com/ar/develop/unity/android-11-build

There are multiple versions of each component that are not all necessarily compatible, here's all the packages and their versions from Package manager. 

![alt text](https://github.com/kocosman/DepthIllusionWithARCore/blob/master/GIFS/DepthIllusionARCore_PackageManager.png)

## The project consists of 2 main elements
- Off axis projection
- Head tracking

Michel de Brisis has a great write up and a starter project for Off-axis Projection in Unity: https://medium.com/@michel.brisis/off-axis-projection-in-unity-1572d826541e

The link to the paper he refers to is broken, you can find it here:
http://160592857366.free.fr/joe/ebooks/ShareData/Generalized%20Perspective%20Projection.pdf

For the head tracking part, I'm using the "Augment Faces" example from the ARCore package we installed earlier.

- Add ARCore Device prefab to your project and create a new SessionConfig file from Create -> Google ARCore
- Disable Plane Finding and Light Estimation
- Select Mesh in Augmented Face Mode

The DepthIllusion_ARFace_Binder Script is where you can relate the position of the projection camera to the tip of your nose. 
There's some rough calibration there from your head space to the content space. 

There are 3 scenes for displaying different uses:
- A crystal model in a grid box (https://assetstore.unity.com/packages/3d/environments/fantasy/translucent-crystals-106274)
- A mountain that is poking out the screen (https://assetstore.unity.com/packages/3d/environments/landscapes/free-background-mountain-157924)
- And Mars in honor of the Perseverance Rover (used https://github.com/Siccity/GLTFUtility to embed the gITF model from NASA's website(https://solarsystem.nasa.gov/resources/2372/mars-3d-model/))




