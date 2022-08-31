"""

Author: George Bell
Since: 29-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

button = ue.GameObject.FindGameObjectWithTag("button_linked").GetComponent("Button_Linked_Platforms")


def set_platforms(dictionary):
    """
    Checks dictionary creating by setting platforms to transforms. If correct, platforms will allow progression
    :param dictionary: dictionary created to link list of platform objects and desired transforms
    """
    for platform, position in dictionary.items():
        button.AddPlatform(platform, position)


platform_objects = button.GetPlatformObjects()
platform_positions = button.GetPlatformTransforms()

"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""
