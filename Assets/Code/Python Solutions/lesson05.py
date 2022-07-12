"""

Author: George Bell
Since: 07-07-2022
Organisation: Newcastle University

"""
import UnityEngine as ue

player = ue.GameObject.FindGameObjectWithTag("platform")


def create_cube(y_pos):
	"""
	Creates cubes at different y positions

	:param y_pos: Y position of cube, should coincide with incrementer of loop
	"""
	player.GetComponent("lesson05").CreateCube(y_pos)


"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

# while loop solution
i = 0
cube_target = 6

while i < cube_target:
	create_cube(i)
	i = i + 1

# for loop solution
i = 0
cube_target = 6

for j in range(cube_target):
	create_cube(j)
