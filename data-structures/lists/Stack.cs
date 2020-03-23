using System;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class Stack<T>
  {
    readonly ArrayList<T> items = new ArrayList<T>();
    public void Push(T item) => items.Add(item);
    public bool IsEmpty { get => items.IsEmpty(); }
    public int Count { get => items.Count(); }
    public T Top { get => items.Last(); }
    public T Pop()
    {
      if(StackIsEmpty())
      {
        throw new Exception("Stack is empty!");
      }
      var top = Top;
      items.RemoveAt(Last());
      return top;
    }
    bool StackIsEmpty() => Count <= 0;
    int Last()          => Count - 1;
  }
}
