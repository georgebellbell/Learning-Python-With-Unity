"""

Author: George Bell
Since: 07-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

obstacle = ue.GameObject.FindGameObjectWithTag("obstacle")


def open_gate():
	"""
	Called when the conditions of equations are met
	"""
	obstacle.GetComponent("Gate_Number").CheckGate()


numbers = obstacle.GetComponent("Gate_Number").GetNumbers()

num1 = numbers[0]
num2 = numbers[1]
num3 = numbers[2]

num4 = numbers[3]
num5 = numbers[4]
num6 = numbers[5]

"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

equationA = num1 < num2 < num3

equationB = num4 * num5 == num6

if equationA and equationB:
	open_gate()
