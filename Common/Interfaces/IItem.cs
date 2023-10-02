namespace Common.Interfaces;

public interface IItem
{
    public int? Id { get; }
    void AssignId(int? id);
}
