using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    public GameObject MenuPanel;
    [SerializeField]
    public GameObject IngredientPanel;

    void Start()
    {
        // TODO： set panel1 and panel2 to disactive
        if (MenuPanel != null) MenuPanel.SetActive(true);
        if (IngredientPanel != null) IngredientPanel.SetActive(false);
    }
}