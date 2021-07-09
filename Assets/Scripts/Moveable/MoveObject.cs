using UnityEngine;

public class MoveObject : MonoBehaviour, IMovable
{
    [field: SerializeField] public float MaxSpeed { get; set; }
    [field: SerializeField] public float TimeToMaxAccelerate { get; set; }
    [field: SerializeField] public float DistanceToDecelerate { get; set; }
    [field: SerializeField] public float RotateSpeed { get; set; }


    private Vector3 positionToMove;
    private float _timeElapsed;
    private float _currentSpeed;
    private bool isMoving = false;

    public void Move()
    {
        
        
        CountTime();
        
        float currentDistanceToEndPoint = Vector3.Distance(transform.position, positionToMove);

        if (currentDistanceToEndPoint < DistanceToDecelerate)
        {
            _currentSpeed = Mathf.Lerp(0, MaxSpeed, currentDistanceToEndPoint / DistanceToDecelerate); 
            ResetTime();
        }
        else
            _currentSpeed = Mathf.Lerp(0, MaxSpeed,  _timeElapsed/TimeToMaxAccelerate);

        transform.position += transform.forward * _currentSpeed * Time.deltaTime;
    }

    public void Rotate()
    {
        Vector3 targetDirection = positionToMove - transform.position;
        targetDirection.y = 0.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDirection), Time.time * RotateSpeed);
    }

    private void CountTime()
    {
        _timeElapsed += Time.deltaTime;
    }

    private void ResetTime()
    {
        _timeElapsed = 0;
    }

    public void ChangePositionToMove(Vector3 position)
    {
        isMoving = true;
        positionToMove = position;
    }
    private void Update()
    {
        if (isMoving)
        {
            Move();
            Rotate();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        isMoving = false;
    }
}
