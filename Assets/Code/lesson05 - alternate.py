from UnityEngine import GameObject, PrimitiveType, Rigidbody
import UnityEngine as ue

player = ue.GameObject.FindGameObjectWithTag("platform")

def create_cube(y):
	player.GetComponent("lesson05").CreateCube(y)

#####################################################################################

i = 0
cube_target = 5

for j in range(cube_target):
	create_cube(j)
