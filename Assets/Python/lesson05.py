"""

Author: George Bell
Since: 07-07-2022
Organisation: Newcastle University

"""
import UnityEngine as ue

player = ue.GameObject.FindGameObjectWithTag("platform").GetComponent("lesson05")


def create_cube(y_pos):
	"""
	Creates cubes at different y positions

	:param y_pos: Y position of cube, should coincide with incrementer of loop
	"""
	player.CreateCube(y_pos)


"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""
