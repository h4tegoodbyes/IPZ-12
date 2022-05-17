
public class SplayTree
{
	public class Node
	{
		public int Data;
		public Node Left;
		public Node Right;
		public Node Parent;

		public Node(int data)
		{
			Data = data;
			Left = null;
			Right = null;
			Parent = null;
		}

		public Node()
		{
		}
	}
	public Node Root;
	public SplayTree()
	{
		Root = null;
	}
	public void Find(int data)
	{
		Node temp = Root;
		while (temp.Data != data)
		{
			if (data < temp.Data)
			{
				if (temp.Left != null)
				{
					temp = temp.Left;
				}
				else break;
			}
			else
			{
				if (temp.Right != null)
				{
					temp = temp.Right;
				}
				else break;
			}
		}
		if (temp.Data == data) Console.WriteLine($"Element {temp.Data} found");
		else Console.WriteLine($"Element {data} not found");
	}
	void zig(Node node)
	{
		Node parent = node.Parent;
		parent.Left = node.Right;
		if (node.Right != null)
		{
			node.Right.Parent = parent;
		}
		node.Right = parent;
		node.Parent = parent.Parent;
		parent.Parent = node;
	}
	void zag(Node node)
	{
		Node parent = node.Parent;
		parent.Right = node.Left;
		if (parent.Right != null)
		{
			parent.Right.Parent = parent;
		}
		node.Left = parent;
		node.Parent = parent.Parent;
		parent.Parent = node;
	}
	void zigZig(Node node)
	{
		Node parent = node.Parent;
		Node grandParent = node.Parent.Parent;
		parent.Left = node.Right;
		if (node.Right != null)
		{
			node.Right.Parent = parent;
		}
		node.Right = parent;
		parent.Parent = node;
		grandParent.Left = parent.Right;
		if (parent.Right != null)
		{
			parent.Right.Parent = grandParent;
		}
		parent.Right = grandParent;
		node.Parent = grandParent.Parent;
		if (grandParent.Parent != null)
		{
			if (grandParent.Parent.Left != null && grandParent.Parent.Left == grandParent)
			{
				grandParent.Parent.Left = node;
			}
			else
			{
				grandParent.Parent.Right = node;
			}
		}
		grandParent.Parent = parent;
	}
	void zagZag(Node node)
	{
		Node parent = node.Parent;
		Node grandParent = node.Parent.Parent;
		parent.Right = node.Left;
		if (node.Left != null)
		{
			node.Left.Parent = parent;
		}
		node.Left = parent;
		node.Parent = grandParent.Parent;
		if (grandParent.Parent != null)
		{
			if (grandParent.Parent.Left != null && grandParent.Parent.Left == grandParent)
			{
				grandParent.Parent.Left = node;
			}
			else
			{
				grandParent.Parent.Right = node;
			}
		}
		parent.Parent = node;
		grandParent.Right = parent.Left;
		if (parent.Left != null)
		{
			parent.Left.Parent = grandParent;
		}
		parent.Left = grandParent;
		grandParent.Parent = parent;
	}
	void zagZig(Node node)
	{
		Node parent = node.Parent;
		Node grandParent = node.Parent.Parent;
		parent.Left = node.Right;
		if (node.Right != null)
		{
			node.Right.Parent = parent;
		}
		grandParent.Right = node;
		node.Parent = grandParent;
		node.Right = parent;
		parent.Parent = node;
	}
	void zigZag(Node node)
	{
		Node parent = node.Parent;
		Node grandParent = node.Parent.Parent;
		parent.Right = node.Left;
		if (node.Left != null)
		{
			node.Left.Parent = parent;
		}
		grandParent.Left = node;
		node.Parent = grandParent;
		node.Left = parent;
		parent.Parent = node;
	}
	
	void applyRotation(Node node)
	{
		if (node.Parent != null)
		{
			if (node.Parent.Left == node && node.Parent.Parent == null)
			{
				zig(node);
			}
			else if (node.Parent.Right != null && node.Parent.Right == node && node.Parent.Parent == null)
			{
				zag(node);
			}
			else if (node.Parent.Left != null && node.Parent.Left == node && node.Parent.Parent.Left != null && node.Parent.Parent.Left == node.Parent)
			{
				zigZig(node);
			}
			else if (node.Parent.Right != null && node.Parent.Right == node && node.Parent.Parent.Right != null && node.Parent.Parent.Right == node.Parent)
			{
				zagZag(node);
			}
			else if (node.Parent.Right != null && node.Parent.Right == node && node.Parent.Parent != null && node.Parent.Parent.Left != null && node.Parent.Parent.Left == node.Parent)
			{
				zigZag(node);
			}
			else if (node.Parent.Left != null && node.Parent.Left == node && node.Parent.Parent != null && node.Parent.Parent.Right != null && node.Parent.Parent.Right == node.Parent)
			{
				zagZig(node);
			}
			else
			{
				return;
			}
			applyRotation(node);
		}
	}
	public void Add(int data)
	{
		Node node = new Node(data);
		Node temp = new Node();
		if (Root == null)
		{
			Root = node;
		}
		else
		{
			temp = Root;
			while (temp != null)
			{
				if (data > temp.Data)
				{
					if (temp.Right == null)
					{
						temp.Right = node;
						node.Parent = temp;
						temp = null;
					}
					else
					{
						temp = temp.Right;
					}
				}
				else
				{
					if (temp.Left == null)
					{
						temp.Left = node;
						node.Parent = temp;
						temp = null;
					}
					else
					{
						temp = temp.Left;
					}
				}
			}
			applyRotation(node);
		} 
		Root = node;
	}
	public void Delete(int data)
	{
		if (Root != null)
		{
			Node node = Root;
			Node rightNode = new Node();
			Node leftNode = new Node();
			
			while (node != null && node.Data != data)
			{
				if (data > node.Data)
				{
					node = node.Right;
				}
				else
				{
					node = node.Left;
				}
			}
			
			
			if (node != null)
			{
				applyRotation(node);
				Root = node;
				if (node.Left == null)
				{
					Root = node.Right;
				}
				else if (node.Right == null)
				{
					Root = node.Left;
				}
				else
				{
					if (node.Left != null)
					{
						node.Left.Parent = null;
					}
					if (node.Right != null)
					{
						node.Right.Parent = null;
					}
					rightNode = node.Right;
					leftNode = node.Left;
					Root = null;
					
					node.Right = null;
					node.Left = null;
					node = leftNode;
					
					while (node.Right != null)
					{
						node = node.Right;
					}
					
					applyRotation(node);
					node.Right = rightNode;
					rightNode.Parent = node;
					Root = node;
				}
			}
			else
			{
				Console.WriteLine($"\nElement {data} not exist");
			}
			if (Root != null)
			{
				Root.Parent = null;
			}
		}
	}
	public void Max()
	{
		Node current = Root;
		while (current.Right != null) { current = current.Right; }
		Console.WriteLine($"Max element is {current.Data}");
	}
	public void Min()
	{
		Node current = Root;
		while (current.Left != null) { current = current.Left; }
		Console.WriteLine($"Min element is {current.Data}");
	}
	public void DisplayTree()
	{
		if (Root == null)
		{
			Console.WriteLine("Tree is empty");
			return;
		}

		InOrder(Root);
		Console.WriteLine();
	}

	void InOrder(Node current)
	{
		if (current != null)
		{
			InOrder(current.Left);
			Console.Write("({0}) ", current.Data);
			InOrder(current.Right);
		}
	}
}