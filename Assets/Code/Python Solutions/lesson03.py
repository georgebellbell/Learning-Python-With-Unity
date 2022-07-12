"""

Author: George Bell
Since: 06-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

player = ue.GameObject.FindGameObjectWithTag("Player")


def winnable_game(winnable):
	"""
	Used to set enable, or disable, the target gate for the level
	:param winnable: bool, True to enable the gate and False to disable the gate
	"""
	player.GetComponent("lesson03").SetFinish(winnable)


coin_count = player.GetComponent("lesson03").GetCoinCount()

"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

# Gate opens if all coins have been collected
if coin_count == 8:
	winnable_game(True)
else:
	winnable_game(False)

# Gate opens if no coins have been collected
if coin_count == 0:
	winnable_game(True)
else:
	winnable_game(False)

# Gate opens if more than three coins have been collected
if coin_count > 3:
	winnable_game(True)
else:
	winnable_game(False)

# Gate opens if less than or equal to five coins have been collected
if coin_count <= 5:
	winnable_game(True)
else:
	winnable_game(False)

# Gate opens if more than four coins and less than seven coins have been collected
if 4 < coin_count < 7:
	winnable_game(True)
else:
	winnable_game(False)

# Gate opens if 1 or 4 coins have been collected
if coin_count == 1 or coin_count == 6:
	winnable_game(True)
else:
	winnable_game(False)




