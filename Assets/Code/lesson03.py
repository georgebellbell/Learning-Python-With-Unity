"""

Author: George Bell
Since: 06-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

player = ue.GameObject.FindGameObjectWithTag("Player")


def winnable_game(winnable):
	player.GetComponent("lesson03").SetFinish(winnable)


coin_count = player.GetComponent("lesson03").GetCoinCount()

"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

if coin_count == 8 or coin_count == 1:
	winnable_game(True)
else:
	winnable_game(False)




