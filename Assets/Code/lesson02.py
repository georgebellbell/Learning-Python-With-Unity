from UnityEngine import GameObject, PrimitiveType, Rigidbody
import UnityEngine

# DO NOT EDIT
# Name: create_objects
# Parameter: newObs, list of strings, list of objects to be created
# Purpose: Moves through supplied list, creating basic primitives based on current list item
def create_objects(newObs):
	for x in range(len(newObs) ):
		if newObs[x] == "cube":
			new_object = GameObject.CreatePrimitive(PrimitiveType.Cube)
			Vector = UnityEngine.Vector3(x * 2.0, 1);
			new_object.transform.position = Vector
			new_object.tag = "cube"	
		elif newObs[x] == "sphere":
			new_object = GameObject.CreatePrimitive(PrimitiveType.Sphere)
			Vector = UnityEngine.Vector3(x * 2.0, 1);
			new_object.transform.position = Vector
			new_object.tag = "sphere"	
		elif newObs[x] == "cylinder":
			new_object = GameObject.CreatePrimitive(PrimitiveType.Cylinder)
			Vector = UnityEngine.Vector3(x * 2.0, 1);
			new_object.transform.position = Vector
			new_object.tag = "cylinder"
		elif newObs[x] == "capsule":
			new_object = GameObject.CreatePrimitive(PrimitiveType.Capsule)
			Vector = UnityEngine.Vector3(x * 2.0, 1);
			new_object.transform.position = Vector
			new_object.tag = "capsule"
		else:
			UnityEngine.Debug.Log("object name not recognised")


objects = ["cylinder", "cylinder", "cylinder", "cylinder"]
create_objects(objects)