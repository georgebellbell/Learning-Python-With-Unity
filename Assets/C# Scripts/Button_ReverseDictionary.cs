using UnityEngine;

public class Button_ReverseDictionary : Button
{
    [SerializeField] KeyValuePair[] target;
    [SerializeField] KeyValuePair[] answers;

    [SerializeField] GameObject lightButton;

    /// <summary>
    /// Override ActivateButton to check all answers against the target 
    /// </summary>
    public override void ActivateButton()
    {
        base.ActivateButton();

        bool correctValues = true;
        for (int i = 0; i < target.Length; i++)
        {
            if (target[i].GetKeyValueType() == answers[i].GetKeyValueType()
                && target[i].GetCurrentKey() == answers[i].GetCurrentKey())
            {
                CorrectMatch(answers[i]);
            }
            else
            {
                IncorrectMatch(answers[i]);
                correctValues = false;
            }
        }

        if (correctValues)
            RoomCompleted();
    }

    /// <summary>
    /// Sets correct value to green
    /// </summary>
    /// <param name="answer"></param>
    void CorrectMatch(KeyValuePair answer)
    {
        answer.SetColour(Color.green);
    }

    /// <summary>
    /// Sets incorrect value to false
    /// </summary>
    /// <param name="answer"></param>
    void IncorrectMatch(KeyValuePair answer)
    {
        answer.SetColour(Color.red);
    }

    /// <summary>
    /// If all values match correctly, the finish light will appear successfully
    /// </summary>
    private void RoomCompleted()
    {
        lightButton.SetActive(true);
    }

}
