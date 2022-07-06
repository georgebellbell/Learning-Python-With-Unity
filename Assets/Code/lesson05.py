"""

Author: George Bell
Since: 06-07-2022
Organisation: Newcastle University

"""
import UnityEngine as ue

player = ue.GameObject.FindGameObjectWithTag("platform")


def create_cube(y):
	player.GetComponent("lesson05").CreateCube(y)


"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

i = 0
cube_target = 5

while i <= 5:
	create_cube(i)
	i = i + 1