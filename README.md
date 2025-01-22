<div align="center">    
 
# UnrealGenSyn

[![Project Website](http://img.shields.io/badge/Project-Website-green.svg)]()

## Synthetic video generation framework

<img src="Assets/UnrealGenSyn.png">
 
</div>

## Description   

We introduce a novel framework developed within Unreal Engine 5, designed to generate human action video data in hyper-realistic virtual environments. Our framework mitigates the scarcity and limited diversity of existing datasets for  infrequent actions or routine tasks by utilizing synthetic motion generation through text-guided generative motion models, Gaussian Splatting 3D reconstruction, and MetaHuman avatars. 
The utility of the framework is demonstrated by its ability to produce a synthetic video dataset depicting various human actions in diverse settings. The quality and resolution of the RGB videos and depth maps generated represents a significant advance in the field. Additionally, a graph is generated from the rendered scene, detecting objects and their relationships, thus adding valuable contextual information to the video data. 
This capability to generate data across a wide range of actions and environments positions our framework as an invaluable tool for broader applications, including digital twin creation and dataset augmentation



## Documentation
  
### Gaussian Splating
To load Gaussian Point Clouds the [LumaAI](https://lumalabs.ai/) software and plugin has been used. This plugin is already installed in the project. The individual scenes must be saved in _.uasset_ format in the ```Content > Scenes``` folder. You can find examples in the [data release]().

### Motion generation

The [motion-diffusion-model](https://github.com/GuyTevet/motion-diffusion-model) has been used to generate human animations from text prompts. The output of the model is a skeleton in 24-joint [SMPL format](https://khanhha.github.io/posts/SMPL-model-introduction/). This data is saved in a .pkl file. 

Afterwards, a script must be used to convert this animation to .fbx format. In our case we have used [SMPL-to-FBX](https://github.com/softcat477/SMPL-to-FBX). The IKRetargeter component (named _RTG_SMPL_FBX_Mannequin_ in the project) has to be configured in the Unreal Engine project to match the bones of the imported SMPL skeleton with those of the MetaHuman.

The project includes the assets of 4 Metahumans, but the assets of the face are missing as they take up a lot of space, these files are in a release.

> [!WARNING]
> Please note that the Unreal axes and the outputs generated with the models may vary and therefore the front axis must be configured when importing the FBX.




### Synthetic video generation

The C++ component [HSMTracker](Source/HyperSynMotion/AHSMTracker.h) has been created to generate videos from virtual cameras. An instance of this class has to be created within the level to be able to generate data.

**Use of HSMTracker**
The instance has to be parameterised with the correct paths and data of the images to be generated.

- **Pawns**: List of Pawns reference which are used in the enviroment.
- **CameraActors**: List of Cameras used to record the scene.
- **bRecordMode**: 
- - TRUE: To debug
- - FALSE: To generate videos from the cameras
  
- **scene_save_directory**: Root directory of the project.
- **scene_folder**: Folder where scenes definition JSONs are stored e.g. "MotionData".

- **json_file_names**: List of JSON file names (without extension) to be runned.
- **start_frames**: List of start rebuild frames for the corresponding sequence from the previous sequence list.
- **generate_rgb**: If checked, RGB images (JPG RGB 8bit) will be generated for each frame of rebuilt sequences.
- **format_rgb**: Format for RGB images (PNG ~3MB, JPG 95% ~800KB, JPG 80% ~120KB).
- **generate_depth**: If checked, Depth images (PNG Gray 16bit) will be generated for each frame of rebuilt sequences.
- **generate_object_mask**: If checked, Human Mask images (PNG RGB 8bit) will be generated for each frame of rebuilt sequences.

- **screenshots_save_directory**: Directory where the folder for storing generated images from rebuilt sequences will be created.
- **screenshots_folder**: Folder where generated images from rebuilt sequences will be stored. e.g. "Screenshots".
- **screenshot_width**: Width size for generated images.
- **screenshot_height**: Height size for generated images.
- **initial_delay**: Seconds to wait since execution starts until rebuild process does.
- **place_cameras_delay**: Seconds to wait since skeletons are placed until cameras can be placed (needed for avoiding failures with bone cameras positions, 0.1 is enough).
- **first_viewmode_of_frame_delay**: Seconds to wait since rebuild is done until first camera is set and viewmode is changed (0.1 is enough).
- **change_viewmode_delay**: Seconds to wait since last image is generated until next viewmode can be changed (0.1 is enough, 0.2 is also good for slower PCs).
- **take_screenshot_delay**: Seconds to wait since viewmode has changed until image is generated (0.1 is enough).


Inside the MotionData folder you will find the JSON with the information of each sequence. This is the format:

```

{
	"name": "Sequence name",
	"total_frames": Nº Frames,
	"animations": [
		{"name":"/Script/Engine.AnimSequence'/Game/Motion/Path_Of_Animation_Asset.'"}	
	],
	"cameras": [
		{
			"name": "CameraName",
			"stereo": 0,
			"fov": 90,
			"position":
				{
					"x": 622.6,
					"y": 36.76,
					"z": 172.92
				},
			"rotation":
				{
					"r": -4.16,
					"p": -38.427,
					"y": -80.77
					
				}
        }, ...
	],
	"skeletons": [
		{
			"name": "Name_of_Metahuman_Assset",
			"num_bones": 24,
			"position":
			{
				"x": 592.25,
				"y": -351.26,
				"z": -10
			},
			"rotation":
			{
				"r": 0,
				"p": 0,
				"y": 150
			}
		}
	]
}

```

### Concept graphs

The official implementation of [Concept Graphs](https://github.com/concept-graphs/concept-graphs) has been used with the images of our environment generated with Unreal  


## Dataset information

The dataset is composed of 250 videos of 4 seconds each. The videos are in RGB-D format and human segmentation. It can be downloaded from the [data release](../../releases/tag/Dataset).
The format of the name of the videos is the following:  ```sX_aName_Gender_MHId_Format_CameraN```

- **X**: Scene Id
- **aName**: Id the motion sequence.
- **Gender**: F (Female) or M (Male)
- **MHId**: Id of the Metahuman
- **Format**: RGBD, Depth or Segmentation
- **CameraN**: Camera Id


**Scene information**
| Scene Id | Scene Name     |
|----------|----------------|
| s0       | Meeting room   |
| s1       | Living room    |
| s2       | Living room    |
| s3       | Study room    |
| s4       | Kitchen    |
| s5       | Living room    |
| s6       | Leisure room    |
| s7       | Park    |

