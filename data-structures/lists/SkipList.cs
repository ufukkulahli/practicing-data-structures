using System;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class SkipList<T> where T: IComparable<T>
  {
    public SkipListNode<T> Head {get; private set;} = new SkipListNode<T>(default(T), 1);
    public int Height {get => Head.Height;}
    public int Count { get; private set;} = 0;
    private Random random = new Random();
    private double probability = 0.5;

    public void Add(T value)
    {
      var nodesToBeUpdated = NodesToBeUpdated(value);
      ThrowIfTryToInsertDuplicate(value, nodesToBeUpdated);
      var heightOfNewNode = GenerateHeightOfNewNode();
      var newNode = new SkipListNode<T>(value, heightOfNewNode);
      HandleHeadHeightAndSetNewNode(heightOfNewNode, newNode);
      AddTheNewNode(newNode, nodesToBeUpdated);
      this.Count++;
    }

    public SkipListNode<T>[] NodesToBeUpdated(T value)
    {
      var results = new SkipListNode<T>[this.Height];
      var currentNode = this.Head;

      for(var i=(this.Height-1);  i>=0;  i--)
      {
        while(currentNode[i]!=null && value.CompareTo(currentNode[i].Value) > 0)
        {
          currentNode = currentNode[i];
        }

        results[i] = currentNode;
      }


      return results;
    }

    public void ThrowIfTryToInsertDuplicate(T valueToBeAdded, SkipListNode<T>[] nodes)
    {
      var firstNode = nodes[0];
      var valuesAreSame = firstNode[0] != null && valueToBeAdded.CompareTo(firstNode[0].Value) == 0;

      if (valuesAreSame)
      {
        throw new ArgumentException();
      }
    }

    public int GenerateHeightOfNewNode()
    {
      var generatedHeight = 1;

      while(this.random.NextDouble() < this.probability  &&  generatedHeight < this.Head.Height+1)
      {
        generatedHeight++;
      }
      
      return generatedHeight;
    }

    public void HandleHeadHeightAndSetNewNode(int height, SkipListNode<T> newNode)
    {
      if(height > this.Head.Height)
      {
        this.Head.IncreaseHeight();
        this.Head[this.Head.Height-1] = newNode;
      }
    }

    public void AddTheNewNode(SkipListNode<T> newNode, SkipListNode<T>[] nodesToBeUpdated)
    {
      for(var i=0; i<newNode.Height; i++)
      {
        if(i < nodesToBeUpdated.Length)
        {
          newNode[i] = nodesToBeUpdated[i][i];
          nodesToBeUpdated[i][i] = newNode;
        }
      }
    }

    public bool Remove(T value)
    {
      if(this.Count==0)
      {
        return false;
      }

      var nodesToBeUpdated = this.NodesToBeUpdated(value);
      var nodeToBeDeleted = nodesToBeUpdated[0][0];

      if(nodeToBeDeleted!=null && value.CompareTo(nodeToBeDeleted.Value)==0)
      {
        this.Remove(nodesToBeUpdated, nodeToBeDeleted);
        nodeToBeDeleted.Reset();
        if(this.Head[this.Head.Height-1]==null)
        {
          this.Head.DecreaseHeight();
        }
        this.Count--;
        return true;
      }

      return false;
    }

    public void Remove(SkipListNode<T>[] nodesToBeUpdated, SkipListNode<T> nodeToBeDeleted)
    {
      for(var i=0; i<this.Head.Height; i++)
      {
        if(nodesToBeUpdated[i][i] != nodeToBeDeleted)
        {
          break;
        }

        nodesToBeUpdated[i][i] = nodeToBeDeleted[i];
      }
    }

    public bool Contains(T value)
    {
      var currentNode = this.Head;

      for(var i=this.Height-1; i>=0; i--)
      {
        while(currentNode[i]!=null)
        {
          var compareResult = value.CompareTo(currentNode[i].Value);

          if(compareResult == 0)
          {
            return true;
          }
          if(compareResult < 0)
          {
            break;
          }
          if(compareResult > 0)
          {
            currentNode = currentNode[i];
          }
        }
      }

      return false;
    }

    public void Reset()
    {
      var currentNode = this.Head;
      var lastNode    = this.Head;

      while(currentNode!=null)
      {
        currentNode = currentNode.Forwards[0];
        lastNode.Reset();
        lastNode = currentNode;
      }

      this.Head = new SkipListNode<T>(default(T), 1);
      this.Count = 0;
    }

  }
}
