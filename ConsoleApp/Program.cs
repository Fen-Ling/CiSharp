﻿internal class Program
{
    private static void Main(string[] args)
    {
        MyList<int> myList= new MyList<int>(16);
        myList.Add(0);
        myList.Add(1);
        myList.Add(2);
        myList.Insert(0, -1);
        myList.Remove(2);
        myList.RemoveAt(2);

        // List<BaseEnemy> list = new List<BaseEnemy>();
        

        // TestClass testClass = new TestClass();
        // Enemy enemy = new Enemy();

        

        // testClass.AddHp(0);

        // list.Add(enemy);
        // list.Add(testClass);
        // list.ForEach(en => en.Update());
        
        // ITestInterface test = enemy;
        // test.Update();
    }
}