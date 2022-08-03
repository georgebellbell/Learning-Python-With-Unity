"""

Author: George Bell
Since: 06-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

level = ue.GameObject.FindGameObjectWithTag("levelmanager").GetComponent("lesson01And02")


def create_cube(x_pos):
	"""
	Creates a cube in the unity scene at a specified location

	:param x_pos: int, X position of cube, should coincide with incrementer of loop
	"""
	level.CreateCube(x_pos)


def create_sphere(x_pos):
	"""
	Creates a sphere in the unity scene at a specified location

	:param x_pos: int, X position of sphere, should coincide with incrementer of loop
	"""
	level.CreateSphere(x_pos)


def create_cylinder(x_pos):
	"""
	Creates a cylinder in the unity scene at a specified location

	:param x_pos: int, X position of cylinder, should coincide with incrementer of loop
	"""
	level.CreateCylinder(x_pos)


def create_objects(new_list):
	"""
	Loops through list of objects passed in, creating different shapes depending on string at current index

	:param new_list: str[], sliced list of the constant OBJECTS list
	"""
	for i in range(len(OBJECTS)):
		for j in range(len(new_list)):
			if new_list[j] == OBJECTS[i]:
				if new_list[j].__contains__("cube"):
					create_cube(i)
				elif new_list[j] == "sphere":
					create_sphere(i)
				elif new_list[j].__contains__("cylinder"):
					create_cylinder(i)
				else:
					print("No object in this position?")


OBJECTS = ["cylinder1", "cube1", "sphere", "cube2", "cylinder2"]

"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

# Create all objects
create_objects(OBJECTS)