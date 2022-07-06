"""

Author: George Bell
Since: 06-07-2022
Organisation: Newcastle University

"""

from UnityEngine import GameObject, PrimitiveType, Rigidbody
import UnityEngine


def create_cube(x_pos, z_pos):
	"""
	Creates a cube in the unity scene at a specified location

	:param x_pos: int, X position of cube, should coincide with incrementer of loop
	:param z_pos: int, Z position of cube, should coincide with incrementer of loop. Set to 0 if Z does not change
	"""
	new_object = GameObject.CreatePrimitive(PrimitiveType.Cube)
	new_object.AddComponent(Rigidbody)
	vector = UnityEngine.Vector3(x_pos * 2.0, x_pos, z_pos * 2);
	new_object.transform.position = vector
	new_object.tag = "cube"


def create_sphere(x_pos, z_pos):
	"""
		Creates a sphere in the unity scene at a specified location

		:param x_pos: int, X position of sphere, should coincide with incrementer of loop
		:param z_pos: int, Z position of sphere, should coincide with incrementer of loop. Set to 0 if Z does not change
		"""
	new_object = GameObject.CreatePrimitive(PrimitiveType.Sphere)
	new_object.AddComponent(Rigidbody)
	vector = UnityEngine.Vector3(x_pos * 2.0, x_pos, z_pos * 2);
	new_object.transform.position = vector
	new_object.tag = "sphere"


"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

for i in range(5):
	create_cube(i, 0)
