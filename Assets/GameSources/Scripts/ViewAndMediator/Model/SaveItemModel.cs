public class SaveItemModel : EnhancedScrollerCellData
{
    public string name { get; private set; }

    public SaveItemModel(string name)
    {
        this.name = name;
    }

    public override float GetCellViewSize()
    {
        return 50;
    }
}