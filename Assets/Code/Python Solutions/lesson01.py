"""

Author: George Bell
Since: 06-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

level = ue.GameObject.FindGameObjectWithTag("levelmanager")


def create_cube(x_pos, z_pos):
	"""
	Creates a cube in the unity scene at a specified location

	:param x_pos: int, X position of cube, should coincide with incrementer of loop
	:param z_pos: int, Z position of cube, should coincide with incrementer of loop. Set to 0 if Z does not change
	"""
	level.GetComponent("lesson01And02").CreateCube(x_pos, z_pos)


def create_sphere(x_pos, z_pos):
	"""
	Creates a sphere in the unity scene at a specified location

	:param x_pos: int, X position of sphere, should coincide with incrementer of loop
	:param z_pos: int, Z position of sphere, should coincide with incrementer of loop. Set to 0 if Z does not change
	"""
	level.GetComponent("lesson01And02").CreateSphere(x_pos, z_pos)


"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

# Task 1: 5 Cubes
for x in range(5):
	create_cube(x, 0)

# Task 2: 2 Cubes, 1 Sphere, 2 Cubes
for x in range(5):
	if x == 2:
		create_sphere(x, 0)
	else:
		create_cube(x, 0)

# Task 3: Grid of Cubes with Sphere in the middle
for x in range(5):
	for z in range(5):
		if x == 2 and z == 2:
			create_sphere(x, z)
		else:
			create_cube(x, z)
