namespace BinaryTree;

public class BinaryTree
{
    public Node top;

    public BinaryTree()
    {
        top = null;
    }

    public BinaryTree(int initial)
    {
        top = new Node(initial);
    }

    public void Add(int value)
    {
        if (top==null)
        {
            Node NewNode = new Node(value);
            top = NewNode;
            return;
        }

        Node currentNode = top;
        bool added = false;
        do
        {
            if (value<currentNode.value)
            {
                if (currentNode.left == null)
                {
                    Node NewNode = new Node(value);
                    currentNode.left = NewNode;
                    added = true;
                }
                else
                {
                    currentNode = currentNode.left;
                }
            }else
            {
                //goRight
                if (currentNode.right == null)
                {
                    Node NewNode = new Node(value);
                    currentNode.right = NewNode;
                    added = true;
                }
                else
                {
                    currentNode = currentNode.right;
                }
            }
            
            
            
        } while (!added);
    }

    public void AddRecursively(int value, Node? N = null)
    {
        if (N==null)
        {
            N = new Node(value);
            return;;
        }

        if (value<N.value)
        {
            
            AddRecursively(value, N.left);
            return;
        }
        else
        {
            
            AddRecursively(value, N.right);
            return;
        }
    }

    public bool Find(int value)
    {
        Node tempNode = top;

        while (tempNode.value!=value)
        {
            if (value<tempNode.value)
            {
                if (tempNode.left !=null)
                {
                    tempNode = tempNode.left;
                }
                else
                {

                    return false;
                }
                
            }
            else
            {
                if (tempNode.right !=null)
                {
                    tempNode = tempNode.right;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
    public Node FindNode(int value)
    {
        Node tempNode = top;

        while (tempNode.value!=value)
        {
            if (value<tempNode.value)
            {
                if (tempNode.left !=null)
                {
                    tempNode = tempNode.left;
                }
                else
                {

                    throw new Exception("Element doesn't exist in Tree");
                }
                
            }
            else
            {
                if (tempNode.right !=null)
                {
                    tempNode = tempNode.right;
                }
                else
                {
                    throw new Exception("Element doesn't exist in Tree");
                }
            }
        }

        return tempNode;
    }

    // private Node GetFather(int value)
    // {
    //     Node tempNode = top;
    //     while ((tempNode.left != null || tempNode.right!=null)&&(tempNode.left.value != node.value && tempNode.right.value!= node.value ))
    //     {
    //         if (tempNode.value >node.value)
    //         {
    //             tempNode = tempNode.left;
    //         }
    //         else
    //         {
    //             tempNode = tempNode.right;
    //         }
    //     } 
    //     return tempNode;
    // }
    public void Delete(int value)
    {
        if (Find(value))
        {
            Node node = FindNode(value);
            if (node.left!=null && node.right!=null)
            {
                Node NewNode = FindMin(node.right);
                //int temp = NewNode.value;
                Node tempNode = top;
                while ((tempNode.left != null || tempNode.right!=null)&&(tempNode.left.value != value && tempNode.right.value!= value ))
                {
                    if (tempNode.value >value)
                    {
                        tempNode = tempNode.left;
                    }
                    else
                    {
                        tempNode = tempNode.right;
                    }
                } 
                if (tempNode.left.value == value)
                {
                    tempNode.left = NewNode;
                }
                else
                {
                    tempNode.right = NewNode;
                }
                Delete(NewNode.value);
                              
            }else if (node.left != null || node.right != null)
            {
                Node tempNode = top;
                do
                {
                    if (tempNode.value <value)
                    {
                        tempNode = tempNode.left;
                    }
                    else
                    {
                        tempNode = tempNode.right;
                    }
                } while (tempNode.left.value != value|| tempNode.right.value!= value);

                if (tempNode.left.value == value)
                {
                    tempNode.left = tempNode.left.right;
                }
                else
                {
                    tempNode.right = tempNode.left.right;
                }
            } else
            {
                Node tempNode = top;
                while ((tempNode.left != null || tempNode.right!=null)&&(tempNode.left.value != value && tempNode.right.value!= value ))
                {
                    if (tempNode.value >value)
                    {
                        tempNode = tempNode.left;
                    }
                    else
                    {
                        tempNode = tempNode.right;
                    }
                } 

                if (tempNode.left.value == value)
                {
                    tempNode.left = null;
                }
                else
                {
                    tempNode.right = null;
                }
            }
        }
        else
        {
            throw new Exception("Element doesn't exist in Tree");
        }

    }

    public static Node FindMax(Node top)
    {
        Node tempNode = top;
        while (tempNode.right!=null)
        {
            tempNode = tempNode.right;
        }

        return tempNode;
    }
    public static Node FindMin(Node top)
    {
        Node tempNode = top;
        while (tempNode.left!=null)
        {
            tempNode = tempNode.left;
        }

        return tempNode;
    }
}

public class Node
{
    public int value { get; set; }
    public Node left { get; set; }
    public Node right { get; set; }
    

    public Node(int initial)
    {
        value = initial;
        left = null;
        right = null;
    }
}