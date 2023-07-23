# 🌟Scriptable Object Field Copier 🌟

"Scriptable Ojbect Field Copier" is a time-saving tool for Unity, allowing swift and precise copying of ScriptableObject data. It supports selective field copying, batch pasting, and even works with private fields marked with [SerializeField]. With Undo History integration and a user-friendly interface, it's an essential asset for efficient Unity project management.
![Main Image](https://lh3.googleusercontent.com/drive-viewer/AITFw-y7jyWBhlCK2WSifD0zP_8XRC1lxmin6jtlUDTIlHLOHoNmfJoXp44XVMbhfbXDQUMj1aUtn3e98VFZY6TGoIJYUYsoGg=w1920-h937)
[![Video Name](https://i.ibb.co/mFGRDVn/video.png)](https://youtu.be/D5oiuVO0FjU)
## Features
- ➡Field Filtering - You can quickly select the fields you want to change by filtering and ensure only they are modified
- 🔒Private Field Support - Even if the fields are private, they're supported if the [SerializeField] attribute has been used.
- 🕓 Save Time - Paste to multiple objects simultaneously, skipping the hassle of handling each one individually.
- ↩️ Undo Ready - All operations can be easily undone from the Unity's Undo History. Safety and convenience at your fingertips!
- 👌 User-Friendly - Our tool comes with a well-structured Editor Window, making it easy to select and modify fields. Search functionality and eligibility check are in place to ensure a smooth workflow.

![Image 2](https://lh3.googleusercontent.com/drive-viewer/AITFw-w8ByKf-SeU1c7ILlGp58bJJOjfm9jpGa-pMCAbbwdlp2mQ6QToFUo7_lumyB1KzLDm-z8n7DCRjnUboU_pco5hYLDryw=w1920-h937)
![Image 3](https://lh3.googleusercontent.com/drive-viewer/AITFw-xj3_vVYycxpm2dX6fQqVWUhbzYkJKH7V6X_mSStjMY4BjjRZlwxE2pH-zBJaokRqz3dYkqUX8JZVq4sMHDbYFLcZi-kg=w1920-h937)
![Image 4](https://lh3.googleusercontent.com/drive-viewer/AITFw-xvH8S2eeN0DAkV4FYCuF8D2qEkdR-bjOv2MyuQuDnLVlILbQQyJqDt0MaZvmcpKfo20QV7m7_6cL7su91WqP6l7SO9Cw=w1920-h937)
![Image 5](https://lh3.googleusercontent.com/drive-viewer/AITFw-wDmHhTHDxKe6ZMGvJAUz_cUWqluMve7Kwac1F8CW0J_3YFzs8j6K0ImlO2rGiZTQyl8VGVh0iJWoW84yIgOdmSRrU3EA=w1920-h937)

## How to Use?
Right-click on the ScriptableObject whose data you want to copy and select "Copy ScriptableObject."
Then, select the ScriptableObjects where you want to paste the data. Right-click again and choose "Paste ScriptableObject."
In the window that appears, make the necessary filters and click on the "Paste" button to proceed.
Also, you can access the editor window through the Unity menu by navigating to Tools -> ScriptableObject Field Copier.

🚀 Elevate your Unity project with Scriptable Object Field Copier and accelerate your game development process! 🎮


Tested variable types;

```
int
bool
float
string
CustomClass
UnityEngine.Object
Sprite
Mesh
Texture2D
UnityEngine.Object[]
List<int>
List<CustomClass>
AnimationCurve
Gradient
AssetReference
privateString (private field)
ReadOnlyClass (read-only field)
NestedClass (nested class)
CustomClassWithoutDefaultConstructor
