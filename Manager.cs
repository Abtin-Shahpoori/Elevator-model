namespace Manager{
  using System;
  using System.Collections.Generic;

  class ListManager {
    public bool newInput(int inputFloor, int currentFloor) {
      // returns 1 if the input should be added to the uplist, 
      // returns 0 if the input should be added to the donwlist
      if(inputFloor > currentFloor) {
        //add to uplist
        return true;
      } else {
        //add to downlist
        return false;
      }
      
    }
  }
}
