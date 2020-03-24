using System;
using System.Collections;
using System.Collections.Generic;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class Stack<T> : IEnumerable<T>
  {
    readonly ArrayList<T> items = new ArrayList<T>();

    public void Push(T item) => items.Add(item);
    public bool IsEmpty { get => items.IsEmpty(); }
    public int Count { get => items.Count(); }
    public T Top { get => items.Last(); }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public IEnumerator<T> GetEnumerator()
    {
      for (var i = Last(); i >= 0; --i)
      {
        yield return items[i];
      }
    }

    public T Pop()
    {
      if (StackIsEmpty())
      {
        throw new Exception("Stack is empty!");
      }
      var top = Top;
      items.RemoveAt(Last());
      return top;
    }
    bool StackIsEmpty() => Count <= 0;
    int Last() => Count - 1;
  }
}
