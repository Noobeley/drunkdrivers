using UnityEngine;
using UnityEngine.UI;

public class ChecklistScript : MonoBehaviour
{
    
    public Toggle checkbox;

    
    public Image checkmarkImage;

    void Start()
    {
        
        checkbox.onValueChanged.AddListener(OnToggleChanged);

        
        UpdateCheckmark(checkbox.isOn);
    }

    
    private void OnToggleChanged(bool isChecked)
    {
        UpdateCheckmark(isChecked);
    }

    
    private void UpdateCheckmark(bool isChecked)
    {
        if (checkmarkImage != null)
        {
            checkmarkImage.enabled = isChecked;
        }
    }

    void OnDestroy()
    {
        
        checkbox.onValueChanged.RemoveListener(OnToggleChanged);
    }
}
