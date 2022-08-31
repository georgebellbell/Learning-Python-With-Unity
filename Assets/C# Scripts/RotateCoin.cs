using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    public AnimationCurve myCurve;

    /// <summary>
    /// Rotate coin and make it bob up and down
    /// </summary>
    void Update()
    {
        transform.RotateAround(transform.position, transform.right, rotateSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
