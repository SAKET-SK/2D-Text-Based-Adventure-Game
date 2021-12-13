using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if(ReadItem(controller,controller.player.currentLocation.items, noun))
        {
            return;
        }
        if(ReadItem(controller,controller.player.inventory, noun))
        {
            return;
        }
        controller.currentText.text = "The plaque reads as: The Adventurer Saket has known to been passed from here!!!";
    }

    private bool ReadItem(GameController controller, List<Item> items, string noun)
    {
        foreach(Item item in items)
        {
            if(item.itemName == noun)
            {
                if(controller.player.CanReadItem(controller,item))
                {
                    if(item.InteractWith(controller, "read"))
                    {
                        return true;
                    }
                }
                controller.currentText.text = "You have nothing on " + noun + "to read";
                return true;
            }
        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
