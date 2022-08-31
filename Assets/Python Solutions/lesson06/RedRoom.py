"""

Author: George Bell
Since: 27-07-2022
Organisation: Newcastle University

"""

import UnityEngine as ue

button = ue.GameObject.FindGameObjectWithTag("button_platform_colour").GetComponent("Button_Coloured_Platforms")

platform_colours = ["red", "orange", "yellow", "green", "blue", "indigo", "violet"]
platform_heights = [1, 2, 3, 4, 5, 6, 7]


def get_platform_colours():
    """
    Retrieves the order of the pillars as their colours
    """
    temp_list = button.GetPlatformColours()
    for i in range(len(temp_list)):
        platform_colours[i] = temp_list[i]


def get_platform_heights():
    """
    Retrieves the order of the pillars as their heights
    """
    temp_list = button.GetPlatformHeights()
    for i in range(len(temp_list)):
        platform_heights[i] = temp_list[i]


def change_platforms(platforms):
    """
    Changes positions of pillars to match order of sorted platform colours
    :param platforms: array of strings representing the different pillars
    """
    button.PythonPlatformPositioning(platforms)


get_platform_colours()
get_platform_heights()

"""
Use the functions above and your python knowledge to accomplish the Unity Scene's challenges, as described on Canvas
"""

sortedList = [val for (_, val) in sorted(zip(platform_heights, platform_colours), key=lambda x: \
    x[0])]

change_platforms(sortedList)
