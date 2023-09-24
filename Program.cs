// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;
using Manager;
using List;

class Program  {
  public static int inputFloor = -98;

  static void Main() {
    Thread inputThread = new Thread(GetInput);
    inputThread.Start();
    Thread elevator = new Thread(RunElevator);
    elevator.Start();
  }

  static void GetInput() {
    while(true) {
      inputFloor = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine($"Your input: {inputFloor}");
    }
  }

  static void RunElevator() {
    ListManager listmanager = new ListManager();

    Uplist uplist = new Uplist();
    Downlist downlist = new Downlist();

    int currentFloor = 0;
    string direction = "up";
    int prev_inputFloor = -98; // -98 is just a random number that isnt available in the elevator input numbers

    while(true) {
      if(inputFloor == prev_inputFloor) {
        // NO new input
      } else {
        if(listmanager.newInput(inputFloor, currentFloor)== true) {
          uplist.addElement(inputFloor);
        } else {
          downlist.addElement(inputFloor);
        }
      }
      prev_inputFloor = inputFloor; 

      if(uplist.list.Count == 0 && downlist.list.Count == 0) {
        Console.WriteLine("AWAIT");
        Thread.Sleep(1000);
        continue;
      }


      if(direction == "up") {
        if (currentFloor == uplist.list[0]) {
          uplist.removeElement(currentFloor);
          Console.WriteLine($"Reached {currentFloor}");
          if(uplist.list.Count == 0) {
            direction = "down";
          }
          continue;
        }
        Console.WriteLine($"Currently on {currentFloor} going to {currentFloor + 1}");
        currentFloor ++;
        Thread.Sleep(1000); //wait time between floors
      } else {
        if (currentFloor == downlist.list[0]) {
          downlist.removeElement(currentFloor);
          Console.WriteLine($"Reached {currentFloor}");
          if(downlist.list.Count == 0) {
            direction = "up";
          }
          continue;
        }
        Console.WriteLine($"Currently on {currentFloor} going to {currentFloor - 1}");
        currentFloor --; 
        Thread.Sleep(1000); // wait time between floors
      }
    }
  }
}
