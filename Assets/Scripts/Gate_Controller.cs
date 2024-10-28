using UnityEngine;
using TMPro;

public class Gate_Controller : MonoBehaviour
{
    [SerializeField] private TMP_Text gateNumberText;
    [SerializeField] private enum GateType{NegativeGate,PositiveGate}

    [SerializeField] private GateType gateType;
    [SerializeField] private int gateNumber;

    void Start()
    {
        RandomGateNumber();
    }

    public int GetGateNuber()
    {
        return gateNumber;
    }
    private void RandomGateNumber()
    {
        switch(gateType) { 
            case GateType.NegativeGate:
                gateNumber = Random.Range(-1,-10);
                gateNumberText.text = gateNumber.ToString();
                break;

            case GateType.PositiveGate:
                gateNumber = Random.Range(1,10);
                gateNumberText.text = gateNumber.ToString();
                break;
        }
    }
}
