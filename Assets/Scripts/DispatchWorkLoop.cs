/// <summary>
/// This class/script runs on the main thread and invokes queued actions.
/// This script must be added only once to any game object that lives for the life of the application.
/// </summary>
public class DispatchWorkLoop : UnityEngine.MonoBehaviour
{
    /// <summary>
    /// Controls single-item or all items execution within the frame loop
    /// </summary>
    public bool SingleItemMode = true;

    private static DispatchWorkLoop _instance;

    public static DispatchWorkLoop Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            _instance.SingleItemMode = true;
        }
    }

    // Update is called once per frame from the Unity engine
    void Update () {

        if (DispatchWorkLoop.Instance.SingleItemMode)
        {
            // Can InvokeOne to not hold the Frame loop when many operations are queued
            Dispatcher.Instance.InvokeOne();
        }
        else
        {
            // Runs all actions in a single Frame loop 
            Dispatcher.Instance.InvokeAllPending();
        }
    }
}
