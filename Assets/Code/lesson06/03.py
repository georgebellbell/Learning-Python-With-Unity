"""

Author: George Bell
Since: 07-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

obstacle = ue.GameObject.FindGameObjectWithTag("obstacle").GetComponent("Gate_Number")


def open_gate():
	"""
	Called when the conditions of equations are met
	"""
	obstacle.CheckGate()


numbers = obstacle.GetNumbers()

numA_1 = numbers[0]
numA_2 = numbers[1]
numA_3 = numbers[2]

numB_1 = numbers[3]
numB_2 = numbers[4]
numB_3 = numbers[5]

"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

