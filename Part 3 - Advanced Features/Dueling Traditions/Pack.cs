using InventoryItems;

namespace Pack;

public class Pack
{
    public int MaxItems { get; } = 10;
    public float MaxWeight { get; } = 20;
    public float MaxVolume { get; } = 30;

    private InventoryItem[] ItemList;

    public int CurrentItems { get; private set; } = 0;
    public float CurrentWeight { get; private set; } = 0;
    public float CurrentVolume { get; private set; } = 0;

    public Pack()
    {
        ItemList = new InventoryItem[MaxItems];
    }

    public bool Add(InventoryItem item)
    {
        //fail to add scenarios
        if (CurrentItems >= MaxItems) return false;
        if (CurrentVolume + item.ItemWeight > MaxWeight) return false;
        if (CurrentWeight + item.ItemVolume > MaxVolume) return false;

        ItemList[CurrentItems] = item;
        CurrentItems++;
        CurrentWeight += item.ItemWeight;
        CurrentVolume += item.ItemVolume;
        return true;
    }

    public override string ToString()
    {
        string packContents = "Currently, the pack contains ";

        if (CurrentItems == 0)
        {
            packContents += "nothing at the moment.";
        }
        else
        {
            foreach (InventoryItem inventoryItem in ItemList)
            {
                packContents += $"{inventoryItem} ";
            }
        }

        return packContents;
    }
}