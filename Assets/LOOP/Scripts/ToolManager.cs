using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public List<Tool> availableTools;


    public static ToolManager Instance;

    public Tool SelectedTool { get; private set; }
    public Tool HeldTool { get; private set; }


    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        
    }


    void Update()
    {
        // Choosing a tool (number keys)

        for(int i=0; i<availableTools.Count; i++)
        {
            if (Input.GetKeyDown("" + (i+1)))
            {
                ChooseTool(availableTools[i]);
            }
        }


        // Using a tool (mouse)

        if (SelectedTool != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ThrowTool();
            }
        }
    }

    private void ChooseTool(Tool tool)
    {
        SelectedTool = tool;

        if (HeldTool)
            Destroy(HeldTool);

        HeldTool = Instantiate(
            SelectedTool.gameObject, 
            ThrowManager.Instance.GetWorldMousePos(), 
            Quaternion.identity)
            .GetComponent<Tool>();
    }

    private void ThrowTool()
    {
        HeldTool.Use();
        HeldTool = null;

        ChooseTool(SelectedTool);
    }

}
