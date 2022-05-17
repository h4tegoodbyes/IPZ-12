

using ASD_Lab2;

Random rand = new Random();

Node.Tree binTree = new Node.Tree();
BinaryRedBlack RB = new BinaryRedBlack();
AVL check1 = new AVL();
AVL check2 = new AVL();

Console.WriteLine("ASD    Lab 2    Bogdan Mychkovskyi    IPZ-12-1\n\nBinary tree...");
binTree.Add(10);
binTree.Add(15);
binTree.Add(16);
binTree.Add(7);
binTree.Add(3);
binTree.Add(5);
binTree.Add(0);
binTree.Add(25);
binTree.Add(24);
binTree.Add(27);
binTree.Add(12);

binTree.MaxElement();
binTree.MinElement();
binTree.FindElement(16);
binTree.FindElement(9);

binTree.DisplayTree();
binTree.DeleteElement(15);
binTree.DisplayTree();

/*
BinaryAVL___template.AVL avl = new BinaryAVL___template.AVL();

avl.AddElement(10);
avl.AddElement(30);
avl.AddElement(25);
avl.AddElement(23);
avl.AddElement(27);

 ---------------------------------------------------------
for (int i = 0; i < 30; i++)
{
    avl.AddElement(rand.Next(0,1000));
}

avl.MaxElement();
avl.MinElement();
avl.FindElement(25);
avl.FindElement(45);
---------------------------------------------------------
*/
Console.WriteLine("\n\nAVL tree...");
check1.Add(50);
check1.Add(17);
check1.Add(12);
check1.Add(9);
check1.Add(14);
check1.Add(23);
check1.Add(19);
check1.Add(72);
check1.Add(76);
check1.Add(54);
check1.Add(67);
/*
check1.Delete(9);
check1.DisplayTree();
check1.Delete(12);
check1.DisplayTree();
check1.Delete(14);
check1.DisplayTree();
check1.Delete(17);
check1.DisplayTree();
check1.Delete(23);
check1.DisplayTree();
check1.Delete(19);
check1.DisplayTree();
*/

for (int i = 0; i < 60; i++)
{
    check2.Add(rand.Next(0,1000));
}
check2.Add(18);
check2.Add(28);
check2.MaxElement();
check2.MinElement();
check2.FindElement(18);
check2.FindElement(1001);
check2.DisplayTree();
check2.Delete(18);
check2.DisplayTree();


Console.WriteLine("\n\nSplay tree...");
SplayTree tree = new SplayTree();

tree.Add(9);
tree.Add(3);
tree.Add(7);
tree.Add(20);
tree.Add(13);
tree.Add(32);
tree.Add(1);
tree.Add(4);

tree.Max();
tree.Min();
tree.Find(4);
tree.Find(100);

tree.Delete(3);
tree.Delete(9);
tree.DisplayTree();
tree.Delete(20);
tree.Delete(5);
tree.DisplayTree();
tree.Delete(105);


Console.WriteLine("Done");

