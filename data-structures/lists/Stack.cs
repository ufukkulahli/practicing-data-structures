namespace practicing_data_structures.data_structures.lists
{
  public sealed class Stack<T>
  {
    readonly ArrayList<T> items = new ArrayList<T>();
    public void Push(T item) => items.Add(item);
    public int Count { get => items.Count(); }
  }
}