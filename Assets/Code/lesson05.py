from UnityEngine import GameObject, PrimitiveType, Rigidbody
import UnityEngine as ue

player = ue.GameObject.FindGameObjectWithTag("platform")

def create_cube(y):
	player.GetComponent("lesson05").CreateCube(y)

#####################################################################################

i = 0
cube_target = 5

while i <= 5:
	create_cube(i)
	i = i + 1