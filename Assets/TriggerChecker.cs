using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    private EatingBugsController _eatingController;
    private void Awake()
    {
        _eatingController = FindObjectOfType<EatingBugsController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bug"))
        {
            _eatingController.EatBug(other.gameObject);
        }
    }
}
