"""

Author: George Bell
Since: 06-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

level = ue.GameObject.FindGameObjectWithTag("levelmanager")


def create_cube(x_pos):
	"""
	Creates a cube in the unity scene at a specified location

	:param x_pos: int, X position of cube, should coincide with incrementer of loop
	"""
	level.GetComponent("lesson01And02").CreateCube(x_pos)


def create_sphere(x_pos):
	"""
	Creates a sphere in the unity scene at a specified location

	:param x_pos: int, X position of sphere, should coincide with incrementer of loop
	"""
	level.GetComponent("lesson01And02").CreateSphere(x_pos)


def create_cylinder(x_pos):
	"""
	Creates a cylinder in the unity scene at a specified location

	:param x_pos: int, X position of cylinder, should coincide with incrementer of loop
	"""
	level.GetComponent("lesson01And02").CreateCylinder(x_pos)


def create_objects(new_list):
	"""
	Loops through list of objects passed in, creating different shapes depending on string at current index

	:param new_list: str[], sliced list of the constant OBJECTS list
	"""
	for x in range(len(new_list)):
		if new_list[x] == "cube":
			create_cube(x)
		elif new_list[x] == "sphere":
			create_sphere(x)
		elif new_list[x] == "cylinder":
			create_cylinder(x)
		else:
			UnityEngine.Debug.Log("object name not recognised")


OBJECTS = ["cylinder", "cube", "sphere", "cube", "cylinder"]

"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

# Create all objects
create_objects(OBJECTS)

# Create last three objects
create_objects(OBJECTS[2:])

# Middle three objects
create_objects(OBJECTS[1:4])

# Penultimate object
create_objects(OBJECTS[3:4])

# Everything except the middle object
create_objects(OBJECTS[:2] + OBJECTS[3:])
