using UnityEngine;
using UnityEngine.UI;

public class PerformWork : MonoBehaviour {
    public Text TextFieldToUpdate;

    public void DoWork_Click()
    {
        TextFieldToUpdate.text = "This text will never be seen as the UI won't update on time...";

        Dispatcher.Instance.Enqueue(
            () => LongOperation("3000ms")
        );
    }

    private void LongOperation(string delayText)
    {
        System.Threading.Thread.Sleep(3000); // main thread blocker
        TextFieldToUpdate.text = delayText + " blocking work complete. " + System.DateTime.Now.ToString();
    }

    public void DoMultipleWorkItems_Click()
    {
        Dispatcher.Instance.Enqueue(
            () => LongOperation("3000ms")
        );

        Dispatcher.Instance.Enqueue(
            () => LongOperation("6000ms")
        );

        Dispatcher.Instance.Enqueue(
            () => LongOperation("9000ms")
        );
    }

    public void Perform1000Tasks()
    {
        for (int i = 0; i < 1000000; i++)
        {
            Dispatcher.Instance.Enqueue(
                () => { }
            );
        }
    }
}
