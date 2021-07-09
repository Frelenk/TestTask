using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] private ScoreInformation scoreInformation;
    [SerializeField] private MoveObject movePlayerObject;

    private SetNearestSphere setNearestSphere;
    private SphereSpawnHandler sphereSpawnHandler;
    private UIController uiController;
    
    public delegate void SphereColected();
    public event SphereColected OnSphereColection;
    public delegate void SphereCreated();
    public event SphereColected OnSphereCreation;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        uiController = GetComponent<UIController>();
    }

    private void Start()
    {
        ScoreNullify();

        setNearestSphere = GetComponent<SetNearestSphere>();
        sphereSpawnHandler = GetComponent<SphereSpawnHandler>();
        
        OnSphereColection += SetNewPositionToMove;
        OnSphereCreation += SetNewPositionToMove;
    }

    public void SphereSpawn()
    {
        OnSphereCreation?.Invoke();
    }

    public void SphereCollection()
    {
        OnSphereColection?.Invoke();
    }
    private void SetNewPositionToMove()
    {
        if (sphereSpawnHandler.IsAnySphereActive())
        {
            Vector3 nearestPosition = setNearestSphere.SetNearestPoint
                (sphereSpawnHandler.GetActiveSperesTransform(), movePlayerObject.transform.position);
        
            movePlayerObject.ChangePositionToMove(nearestPosition);
        }
    }
    private void ScoreNullify()
    {
        if (!scoreInformation.IsSaving)
        {
            scoreInformation.Score = 0;
        }
    }
    public void UpdateScore()
    {
        scoreInformation.Score++;
        uiController.UpdateInfo(scoreInformation);
    }
}
