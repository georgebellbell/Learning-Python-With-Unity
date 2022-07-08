"""

Author: George Bell
Since: 07-07-2022
Organisation: Newcastle University

"""
import UnityEngine as ue

player = ue.GameObject.FindGameObjectWithTag("Player")


def get_wall_type():
	"""
	Retrieves the energy type of the wall the player has just hit
	:return: EnergyType
	"""
	return player.GetComponent("lesson04").GetWallType()


def get_player_type():
	"""
	Retrieves the energy type of the player's shield at the time of hitting the wall
	:return: EnergyType
	"""
	return player.GetComponent("lesson04").GetPlayerType()


def player_dies():
	"""
	Should be invoked when energy type of wall does not match energy type of player's shield, killing them
	"""
	player.GetComponent("lesson04").KillPlayer()


"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

player_type = get_player_type()

wall_type = get_wall_type()

if player_type != wall_type:
	player_dies()
