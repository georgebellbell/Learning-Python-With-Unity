"""

Author: George Bell
Since: 12-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

button = ue.GameObject.FindGameObjectWithTag("button_platform")

# retrieves all the platforms
platforms = button.GetComponent("Button_Platforms").GetPlatforms()


def activate_platform(current_platform):
    """
    Activates current platform, making it rise up out of the ground

    :param current_platform: the current platform object that you want to activate
    """
    current_platform.ActivatePlatform()


"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""
