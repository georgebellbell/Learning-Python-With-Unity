using System.Collections.Generic;
using UnityEngine;

public class YellowRoomController : MonoBehaviour
{
    [SerializeField] KeyValuePair[] keyValueAnswers;
    [SerializeField] List<KeyValuePairType> keyValueOptions;
    
    /// <summary>
    /// Randomise answers at the start and then represent this on the wall
    /// </summary>
    void Start()
    {
        RandomiseOptions();
        for (int i = 0; i < keyValueAnswers.Length; i++)
        {
            switch (keyValueOptions[i])
            {
                case KeyValuePairType.shape:
                    keyValueAnswers[i].SetToShape();
                    keyValueAnswers[i].SetKey("shape");
                    break;
                case KeyValuePairType.number:
                    keyValueAnswers[i].SetToNumber();
                    keyValueAnswers[i].SetKey("number");
                    break;
                case KeyValuePairType.letter:
                    keyValueAnswers[i].SetToLetter();
                    keyValueAnswers[i].SetKey("letter");
                    break;
            }
        }
    }

    /// <summary>
    /// Shuffle key value types 
    /// </summary>
    void RandomiseOptions()
    {
        for (int i = 0; i < keyValueOptions.Count; i++)
        {
            KeyValuePairType temp = keyValueOptions[i];
            int randomIndex = Random.Range(i, keyValueOptions.Count);
            keyValueOptions[i] = keyValueOptions[randomIndex];
            keyValueOptions[randomIndex] = temp;
        }
    }
}
