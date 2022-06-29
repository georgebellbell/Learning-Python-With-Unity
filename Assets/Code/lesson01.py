from UnityEngine import GameObject, PrimitiveType, Rigidbody
import UnityEngine

# DO NOT EDIT
# Name: create_cube
# Parameter: x, integer, current cube being created
# Purpose: Instantiates a cube object, adding a rigidbody, changing position relative to other cubes and setting tags
def create_cube(x, z):
	new_object = GameObject.CreatePrimitive(PrimitiveType.Cube)
	new_object.AddComponent(Rigidbody)
	Vector = UnityEngine.Vector3(x * 2.0, x, z * 2);
	new_object.transform.position = Vector
	new_object.tag = "cube"

def create_sphere(x, z):
	new_object = GameObject.CreatePrimitive(PrimitiveType.Sphere)
	new_object.AddComponent(Rigidbody)
	Vector = UnityEngine.Vector3(x * 2.0, x, z *  2);
	new_object.transform.position = Vector
	new_object.tag = "sphere"


for i in range(5):
	for j in range(5):
		if i == 2 and j == 2:
			create_sphere(i,j)
		else:
			create_cube(i,j)
		
		