using UnityEngine;

public class VisualField : MonoBehaviour
{
    public Transform player;

    public Transform robotModel;

    private bool m_IsPlayerInRange;

    void Start()
    {

    }

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - robotModel.position;

            Ray ray = new Ray(robotModel.position + Vector3.up * 1.5f, direction);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.transform == player)
                    GetComponentInParent<HoverBotAgent>().targetInVisualField = true;
                else
                    GetComponentInParent<HoverBotAgent>().targetInVisualField = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
            m_IsPlayerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
            m_IsPlayerInRange = false;
    }
}
