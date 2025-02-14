/*
 *  This is a container for a list of items. It could be used by a player, a store, a container etc.
 */

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    List<Item> items = new List<Item>();

    public void Init(int max_items)
    {
        for (int i = 0; i < max_items; i++)
            items.Add(new Item());
    }

    public int CountItems() { return items.Count; }

    public Item GetItemAt(int index) { return (index >= 0 && index < CountItems()) ? items[index] : null; }

    public (int, int) PutItemAt(Item.Type type, int number, int index)
    {
        if (index < 0 || index >= CountItems()) return (-1, 0); // out of range

        if (items[index].IsValid())
        {
            if (items[index].type != type)
                return (0, 0); // mismatch, we can't put it in
        }
        else
            items[index].Set(type);

        return (1, items[index].Plus(number)); // we did it, return the remainder
    }

    //public void AddItem(Item.Type type, int number)
    //{
    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        if (items[i].type == type)
    //        {
    //            number = items[i].Plus(number);
    //        }
    //    }

    //    while (number > 0)
    //    {
    //        items.Add(new Item(type));
    //        number = items[items.Count - 1].Plus(number);
    //    }
    //}

}
