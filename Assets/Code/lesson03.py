from UnityEngine import GameObject, PrimitiveType, Rigidbody
import UnityEngine as ue



player = ue.GameObject.FindGameObjectWithTag("Player")
finish = ue.GameObject.FindGameObjectWithTag("Finish")

def WinnableGame(winnable):
	player.GetComponent("lesson03").SetFinish(winnable)

if player:
	coin_count = player.GetComponent("lesson03").GetCoinCount()
	print(coin_count)
else:
	print("no player")

#####################################################################################

if coin_count == 8 or coin_count == 1:
	WinnableGame(True)
else:
	WinnableGame(False)




