"""

Author: George Bell
Since: 06-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

level = ue.GameObject.FindGameObjectWithTag("levelmanager").GetComponent("lesson01And02")


def create_cube(x_pos, z_pos):
	"""
	Creates a cube in the unity scene at a specified location

	:param x_pos: int, X position of cube, should coincide with incrementer of loop
	:param z_pos: int, Z position of cube, should coincide with incrementer of loop. Set to 0 if Z does not change
	"""
	level.CreateCube(x_pos, z_pos)


def create_sphere(x_pos, z_pos):
	"""
	Creates a sphere in the unity scene at a specified location

	:param x_pos: int, X position of sphere, should coincide with incrementer of loop
	:param z_pos: int, Z position of sphere, should coincide with incrementer of loop. Set to 0 if Z does not change
	"""
	level.CreateSphere(x_pos, z_pos)


"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

