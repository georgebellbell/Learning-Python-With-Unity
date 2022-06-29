from UnityEngine import GameObject, PrimitiveType, Rigidbody
import UnityEngine as ue

player = ue.GameObject.FindGameObjectWithTag("Player")

def get_wall_type():
	return player.GetComponent("lesson04").GetWallType()

def get_player_type():
	return player.GetComponent("lesson04").GetPlayerType()

def player_dies():
	return player.GetComponent("lesson04").KillPlayer()

#####################################################################################

player_type = get_player_type()

wall_type = get_wall_type()

if player_type != wall_type:
	player_dies()