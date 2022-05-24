// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using AvlTree;
using BinaryTree.DataStructures.RedBlackTree;
using BinaryTree.DataStructures.SplayTree;
using BinaryTree = BinaryTree_v2.BinaryTree;

Stopwatch stopwatch = new Stopwatch();
Console.WriteLine("Binary Tree");
var tree0 = new BinaryTree_v2.BinaryTree();
stopwatch.Start();
for (int i = 0; i < 1000; i++)
{
    tree0.Add(i);
}
stopwatch.Stop();
Console.WriteLine($"Time of insertion in BinaryTree tree: {stopwatch.Elapsed}");
stopwatch.Reset();
stopwatch.Start();
var node0 = tree0.Find(999);
stopwatch.Stop();
Console.WriteLine($"Time of search in Binary tree: {stopwatch.Elapsed}. Data is {node0.Value}");
stopwatch.Reset();
stopwatch.Start();
tree0.Delete(19);
stopwatch.Stop();
Console.WriteLine($"Time of delete in Binary tree: {stopwatch.Elapsed}.");
stopwatch.Reset();
Console.WriteLine("____________________________________________________________________________________________________\nRB Tree");




var tree = new RedBlackTree();
stopwatch.Start();
for (int i = 0; i < 1000; i++)
{
    tree.insert(i);
}
stopwatch.Stop();
Console.WriteLine($"Time of insertion in RB tree: {stopwatch.Elapsed}");
stopwatch.Reset();
stopwatch.Start();
var node = tree.Find(999);
stopwatch.Stop();
Console.WriteLine($"Time of search in RB tree: {stopwatch.Elapsed}. Data is {node.data}");
stopwatch.Reset();
stopwatch.Start();
tree.Delete(19);
stopwatch.Stop();
Console.WriteLine($"Time of delete in RB tree: {stopwatch.Elapsed}.");
stopwatch.Reset();
Console.WriteLine("____________________________________________________________________________________________________\nAVL Tree");

var tree1 = new AvlTree<int>();
stopwatch.Start();
for (int i = 0; i < 1000; i++)
{
    tree1.Add(i);
}
stopwatch.Stop();

Console.WriteLine($"Time of insertion in AVL tree: {stopwatch.Elapsed}");
stopwatch.Reset();
stopwatch.Start();
var node1 = tree1.Find(999);
stopwatch.Stop();
Console.WriteLine($"Time of search in AVL tree: {stopwatch.Elapsed}. Data is {node1.Key}");
stopwatch.Reset();
stopwatch.Start();
tree1.Remove(19);
stopwatch.Stop();
Console.WriteLine($"Time of delete in AVL tree: {stopwatch.Elapsed}.");
stopwatch.Reset();
Console.WriteLine("____________________________________________________________________________________________________\nSplay Tree");


var tree2 = new SplayTree<int>();
stopwatch.Start();
for (int i = 0; i < 1000; i++)
{
    tree2.Add(i);
}
stopwatch.Stop();
Console.WriteLine($"Time of insertion in Splay tree: {stopwatch.Elapsed}");
stopwatch.Reset();
stopwatch.Start();
var node2 = tree2.Contains(999);
stopwatch.Stop();
Console.WriteLine($"Time of search in Splay tree: {stopwatch.Elapsed}");
stopwatch.Reset();
// stopwatch.Start();
// tree2.Remove(19);
// stopwatch.Stop();
// Console.WriteLine($"Time of delete in Splay tree: {stopwatch.Elapsed}.");