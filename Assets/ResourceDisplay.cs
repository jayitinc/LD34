using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceDisplay : MonoBehaviour
{
    public EntityInfo playerEntityInfo;
    public Text rockText;
    public Text waterText;
    public Text oxygenText;
    public Text ironText;

    private void Update()
    {
        rockText.text = "Rock: " + playerEntityInfo.resources.rock;
        waterText.text = "Water: " + playerEntityInfo.resources.water;
        oxygenText.text = "Oxygen: " + playerEntityInfo.resources.oxygen;
        ironText.text = "Iron: " + playerEntityInfo.resources.iron;
    }
}