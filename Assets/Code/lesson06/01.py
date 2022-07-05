from UnityEngine import GameObject, PrimitiveType, Rigidbody
import UnityEngine as ue

button = ue.GameObject.FindGameObjectWithTag("button_platform")

platforms = button.GetComponent("Button_Platforms").GetPlatforms()

i = 0

for i in range(4):
	platforms[i].ActivatePlatform()