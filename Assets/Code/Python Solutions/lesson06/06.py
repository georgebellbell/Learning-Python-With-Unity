"""

Author: George Bell
Since: 02-08-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

pairs = ue.GameObject.FindGameObjectsWithTag("key_value_pair")

value_name = ["", "", ""]

for i in range(len(pairs)):
	value_name[i] = pairs[i].GetComponent("KeyValuePair").GetValueAsString()


def check_dictionary(dictionary):
	"""
	Loops through inverted dictionary, setting the keys on the wall accordingly
	:param dictionary: dictionary of strings that should be an inversion of yellow_room_dict
	"""
	for j in range(len(pairs)):
		pairs[j].GetComponent("KeyValuePair").SetKey(dictionary.get(value_name[j]))

yellow_room_dict = {
	"shape": "circle",
	"number": "three",
	"letter": "a"
}

"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

inverted_dict = dict(map(reversed, yellow_room_dict.items()))

check_dictionary(inverted_dict)
