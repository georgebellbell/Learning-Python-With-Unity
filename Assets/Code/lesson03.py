"""

Author: George Bell
Since: 06-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

player = ue.GameObject.FindGameObjectWithTag("Player").GetComponent("lesson03")


def winnable_game(winnable):
	"""
	Used to set enable, or disable, the target gate for the level

	:param winnable: bool, True to enable the gate and False to disable the gate
	"""
	player.SetFinish(winnable)


coin_count = player.GetComponent("lesson03").GetCoinCount()

"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""
