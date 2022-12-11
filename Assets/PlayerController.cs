using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Speed;

    [SerializeField]
    //private InputActionReference move, attack, reflect;
    private Rigidbody rigidbody;

    [SerializeField]
    private Vector3 inputVector;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //inputVector = move.action.ReadValue<Vector3>();
        //var transformVector = new Vector3(inputVector.x * Speed, inputVector.y, inputVector.z);
        //rigidbody.AddForce(transformVector);
    }

    //private void OnMove(InputValue inputValue)
    //{
    //    inputVector = inputValue.Get<Vector3>();
    //}
}
