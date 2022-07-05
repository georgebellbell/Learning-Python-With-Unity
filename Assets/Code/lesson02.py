from UnityEngine import GameObject, PrimitiveType, Rigidbody
import UnityEngine as ue

level = ue.GameObject.FindGameObjectWithTag("levelmanager")

def create_cube(x):
	level.GetComponent("lesson01And02").CreateCube(x)

def create_sphere(x):
	level.GetComponent("lesson01And02").CreateSphere(x)

def create_cylinder(x):
	level.GetComponent("lesson01And02").CreateCylinder(x)

# DO NOT EDIT
# Name: create_objects
# Parameter: newObs, list of strings, list of objects to be created
# Purpose: Moves through supplied list, creating basic primitives based on current list item
def create_objects(newObs):
	for x in range(len(newObs)):
		if newObs[x] == "cube":
			create_cube(x)
		elif newObs[x] == "sphere":
			create_sphere(x)
		elif newObs[x] == "cylinder":
			create_cylinder(x)
		else:
			UnityEngine.Debug.Log("object name not recognised")


OBJECTS = ["cylinder", "cube", "sphere", "cube", "cylinder"]
create_objects(OBJECTS)