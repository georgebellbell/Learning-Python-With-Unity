

from UnityEngine import GameObject, PrimitiveType, Rigidbody
import UnityEngine as ue

obstacle = ue.GameObject.FindGameObjectWithTag("obstacle")

def open_gate():
	obstacle.GetComponent("Gate_Number").CheckGate()

numbers = obstacle.GetComponent("Gate_Number").GetNumbers()

num1 = numbers[0]
num2 = numbers[1]
num3 = numbers[2]

num4 = numbers[3]
num5 = numbers[4]
num6 = numbers[5]

#####################################################

equationA =  num1 < num2 and num2 < num3

equationB = num4 * num5 == num6

if equationA and equationB:
	open_gate()