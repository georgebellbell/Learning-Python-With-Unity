"""

Author: George Bell
Since: 07-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

button = ue.GameObject.FindGameObjectWithTag("button_platform")

platforms = button.GetComponent("Button_Platforms").GetPlatforms()

"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

i = 0

for i in range(4):
	platforms[i].ActivatePlatform()

