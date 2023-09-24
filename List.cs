namespace List {
  using System;
  using System.Collections.Generic;

 abstract class List {
    public List<int> list = new List<int>();
    
    public void removeElement(int element) {
      list.Remove(element);
    }
  }

  class Uplist : List {
    public void addElement(int element) {
      list.Add(element);
      list.Sort();
    }
  }

  class Downlist: List {
    public void addElement(int element) {
      list.Add(element);
      list.Sort();
      list.Reverse();
    }
  }
}
