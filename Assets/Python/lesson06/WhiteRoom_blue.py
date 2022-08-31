"""

Author: George Bell
Since: 07-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

button_blue = ue.GameObject.FindGameObjectWithTag("button_slicing_blue").GetComponent("Button_Slicing")


def activate_pillars(sliced_pillars):
	"""
	Sets certain pillars in list to blue colour

	:param sliced_pillars: str[], sliced list of PILLARS, containing pillars to be activated
	"""
	pillars_bool = [False, False, False, False, False, False, False, False, False]
	for i in range(len(PILLARS)):
		for j in range(len(sliced_pillars)):
			if sliced_pillars[j] == PILLARS[i]:
				pillars_bool[i] = True
				break

	button_blue.SetPythonPillars(pillars_bool)


PILLARS = ["Pillar1", "Pillar2", "Pillar3", "Pillar4", "Pillar5", "Pillar6", "Pillar7", "Pillar8", "Pillar9"]

"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""
