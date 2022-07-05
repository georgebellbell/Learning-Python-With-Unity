from UnityEngine import GameObject, PrimitiveType, Rigidbody
import UnityEngine as ue

button_red = ue.GameObject.FindGameObjectWithTag("button_slicing_red")

def activate_pillars(sliced_pillars):
	pillars_bool = [False, False, False, False, False, False, False, False, False]
	for i in range(len(PILLARS)):
		for j in range(len(sliced_pillars)):
			if sliced_pillars[j] == PILLARS[i]:
				pillars_bool[i] = True
				break
	button_red.GetComponent("Button_Slicing").SetPythonPillars(pillars_bool)
	


PILLARS = ["Pillar1", "Pillar2", "Pillar3", "Pillar4", "Pillar5", "Pillar6", "Pillar7", "Pillar8", "Pillar9"]

activate_pillars(PILLARS[3:5] + PILLARS[7:])