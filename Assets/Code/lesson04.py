"""

Author: George Bell
Since: 06-07-2022
Organisation: Newcastle University

"""
import UnityEngine as ue

player = ue.GameObject.FindGameObjectWithTag("Player")


def get_wall_type():
	return player.GetComponent("lesson04").GetWallType()


def get_player_type():
	return player.GetComponent("lesson04").GetPlayerType()


def player_dies():
	return player.GetComponent("lesson04").KillPlayer()


"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

player_type = get_player_type()

wall_type = get_wall_type()

if player_type != wall_type:
	player_dies()