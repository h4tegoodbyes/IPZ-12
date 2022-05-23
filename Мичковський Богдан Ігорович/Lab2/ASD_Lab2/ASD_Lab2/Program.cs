

using ASD_Lab2;

Random rand = new Random();

Node.Tree binTree = new Node.Tree();
BinaryRedBlack RedBlack = new BinaryRedBlack();

AVL AVL1 = new AVL();
AVL AVL2 = new AVL();

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
AVL1.Add(50);
AVL1.Add(17);
AVL1.Add(12);
AVL1.Add(9);
AVL1.Add(14);
AVL1.Add(23);
AVL1.Add(19);
AVL1.Add(72);
AVL1.Add(76);
AVL1.Add(54);
AVL1.Add(67);

for (int i = 0; i < 60; i++)
{
    AVL2.Add(rand.Next(0,1000));
}
AVL2.Add(18);
AVL2.Add(28);
AVL2.MaxElement();
AVL2.MinElement();
AVL2.FindElement(18);
AVL2.FindElement(1001);
AVL2.DisplayTree();
AVL2.Delete(18);
AVL2.DisplayTree();

Console.WriteLine("\n\nRed-black tree...");

/*
RB.Add(10);
RB.Add(20);
RB.Add(30);
RB.Add(14);
RB.Add(12);
RB.Add(13);
RB.Add(11);
RB.Add(23);
*/
RedBlack.Add(10);
RedBlack.Add(50);
RedBlack.Add(60);
RedBlack.Add(70);
RedBlack.Add(54);
RedBlack.Add(44);
RedBlack.Add(42);
RedBlack.Add(38);
RedBlack.MaxElement();
RedBlack.MinElement();
RedBlack.SearchNode(10);
RedBlack.SearchNode(200);
RedBlack.DisplayTree();
RedBlack.DeleteElement(44);
RedBlack.DisplayTree();


Console.WriteLine("\n\nSplay tree...");
SplayTree Splaytree = new SplayTree();

Splaytree.Add(9);
Splaytree.Add(3);
Splaytree.Add(7);
Splaytree.Add(20);
Splaytree.Add(13);
Splaytree.Add(4);
Splaytree.Add(5);
Splaytree.Add(0);
Splaytree.Add(1);
Splaytree.Add(99);
Splaytree.Add(8);

Splaytree.Max();
Splaytree.Min();
Splaytree.Find(4);
Splaytree.Find(100);

Splaytree.DeleteElement(3);
Splaytree.DeleteElement(9);
Splaytree.DisplayTree();
Splaytree.DeleteElement(20);
Splaytree.DeleteElement(8);
Splaytree.DisplayTree();
Splaytree.DeleteElement(105);

Console.WriteLine("Finish");

