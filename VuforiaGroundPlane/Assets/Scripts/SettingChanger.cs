using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using TMPro;

public class SettingChanger : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public Dropdown dd;
    public int selectVP;
    IViewerParametersList vpl;
    ICustomViewerParameters myCustomVP;

    // Start is called before the first frame update
    void Start()
    {        
        tmpText.text += "\n" + Screen.orientation;

        vpl = Vuforia.EyewearDevice.Instance.GetViewerList();

        //myCustomVP = Vuforia.EyewearDevice.Instance.CreateCustomViewerParameters(0.1f, "MyCustomVP", "Ruben Wood");
        //Vuforia.EyewearDevice.Instance.SelectViewer(myCustomVP);

        tmpText.text += "\nCurrent selected profile " + Vuforia.EyewearDevice.Instance.GetSelectedViewer().GetName();

        logVP();
        populateDD();
    }

    void logVP() /// logs name of vps in vpl to text box
    {
        for (int i = 0; i < vpl.Size(); i++)
        {
            tmpText.text += "\n" + vpl.Get(i).GetName();
        }
    }

    void populateDD() /// populates the dropdown list with viewer parameters
    {
        List<string> vpNames = new List<string>();
        for (int i = 0; i < vpl.Size(); i++)
        {
            vpNames.Add(vpl.Get(i).GetName());
        }

        dd.AddOptions(vpNames);
    }

    public void selectProfile(int i) /// selects from vpl based off of option selected in dd
    {
        Vuforia.EyewearDevice.Instance.SelectViewer(vpl.Get(i)); ///This doesn't seem to be selecting

        tmpText.text += "\nCurrent selected profile " + Vuforia.EyewearDevice.Instance.GetSelectedViewer().GetName(); ///This is not selecting for some reason

        tmpText.text += "\nCurrent selected profile2 " + vpl.Get(i).GetName(); ///This works
    }
}
