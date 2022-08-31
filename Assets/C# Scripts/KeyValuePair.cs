using UnityEngine;

public class KeyValuePair : MonoBehaviour
{
    [SerializeField] KeyValuePairType type = KeyValuePairType.none;

    [SerializeField] GameObject defaultKey;
    [SerializeField] GameObject defaultValue;

    [SerializeField] GameObject[] keyTypes;
    [SerializeField] GameObject[] valueTypes;

    [SerializeField] string currentKey = "";

    /// <summary>
    /// Set KeyValuePair type to shape, showing circle object
    /// </summary>
    public void SetToShape()
    {
        DeactivateAllValues();
        type = KeyValuePairType.shape;
        valueTypes[0].SetActive(true);
    }

    /// <summary>
    /// Set KeyValuePair type to number, showing number 3 object
    /// </summary>
    public void SetToNumber()
    {
        DeactivateAllValues();
        type = KeyValuePairType.number;
        valueTypes[1].SetActive(true);
    }

    /// <summary>
    /// Set KeyValuePair type to letter, showing letter a object
    /// </summary>
    public void SetToLetter()
    {
        DeactivateAllValues();
        type = KeyValuePairType.letter;
        valueTypes[2].SetActive(true);
    }

    /// <summary>
    /// Called by python object to set key value needed to complete room
    /// </summary>
    /// <param name="key">string passed in from python for one of the three KeyPairTypes</param>
    public void SetKey(string key)
    {
        currentKey = key;

        DeactivateAllKeys();

        switch (key)
        {
            case "shape":
                keyTypes[0].SetActive(true);
                break;
            case "number":
                keyTypes[1].SetActive(true);
                break;
            case "letter":
                keyTypes[2].SetActive(true);
                break;
            default:
                defaultKey.SetActive(true);
                break;
        }
    }

    /// <summary>
    /// Get current type for this KeyValuePair
    /// </summary>
    /// <returns></returns>
    public KeyValuePairType GetKeyValueType()
    {
        return type;
    }

    /// <summary>
    /// Called by python to retrieve current KeyValue pair value 
    /// </summary>
    /// <returns>value as a string</returns>
    public string GetValueAsString()
    {
        string value;

        switch (type)
        {
            case KeyValuePairType.shape:
                value = "circle";
                break;
            case KeyValuePairType.number:
                value = "three";
                break;
            case KeyValuePairType.letter:
                value = "a";
                break;
            default:
                value = "none";
                break;
        }

        return value;
    }
   
    /// <summary>
    /// Retrieves current key value
    /// </summary>
    /// <returns></returns>
    public string GetCurrentKey()
    {
        return currentKey;
    }

    /// <summary>
    /// Sets all possible key objects to false
    /// </summary>
    void DeactivateAllKeys()
    {
        defaultKey.SetActive(false);

        foreach (GameObject key in keyTypes)
        {
            key.SetActive(false);
        }
    }

    /// <summary>
    /// Sets all possible value objects to false
    /// </summary>
    void DeactivateAllValues()
    {
        defaultValue.SetActive(false);

        foreach (GameObject value in valueTypes)
        {
            value.SetActive(false);
        }
    }

    /// <summary>
    /// Sets colour of value objects on wall to represent completion or not
    /// </summary>
    /// <param name="color">Colour to set values on wall</param>
    public void SetColour(Color color)
    {
        defaultValue.GetComponent<Renderer>().material.color = color;

        for (int i = 0; i < keyTypes.Length; i++)
        {
            valueTypes[i].GetComponent<Renderer>().material.color = color;
        }
    }
}
