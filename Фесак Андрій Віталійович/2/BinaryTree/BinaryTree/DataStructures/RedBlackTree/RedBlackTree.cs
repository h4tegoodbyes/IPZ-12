namespace BinaryTree.DataStructures.RedBlackTree;

public class RedBlackTree
    {
        public TreeNode root;
        public static  TreeNode NIL;
        int MaxLevel;
        TreeNode current;

        TreeNode Tree_Maximum(TreeNode x)
        {
            while (x.right != NIL)
            {
                x = x.right;
            }
            return x;
        }
 
    TreeNode Tree_Minimum(TreeNode x)
        {
            while (x.left != NIL)
            {
                x = x.left;
            }
            return x;
        }
      
      public  RedBlackTree() 
        {
            root = null;
            NIL = new TreeNode(0, TreeColor.black,0);
            MaxLevel = 0;
            current = null;
        }

        public TreeNode Find(int number)
        {
            Search_Node(root, number);
            return current;
        }

        void Search_Node(TreeNode temp, int number)
        {
            if (temp != NIL)
            {
                if (temp.data == number)
                    current= temp;
                else
                {
                    if (number < temp.data)
                    
                        Search_Node(temp.left, number);
                    
                    else
                    
                        Search_Node(temp.right, number);
                       
                    
                }
            }
            else current= null;
        }

        
       public void Delete(int number)
        {
            Search_Node(root, number);
            if (current!=null)
                Delete(current);
        }
        

        
        void Transplant(TreeNode u, TreeNode v)
        {
            if (u.parent == NIL)
                root = v;
            else
            {
                if (u == u.parent.left)
                    u.parent.left = v;
                else u.parent.right = v;
            }
            v.parent = u.parent;
            int ColOfLvl = 1;
            if (v!=NIL)
            ColOfLvl = v.level - u.level;
            v.level=u.level;
           
                DecAllNodes(v.left);
                DecAllNodes(v.right);
            
        }
        
              void Delete(TreeNode z)
              {
                  bool m=false;
                  TreeNode y = z;
                  TreeNode x = NIL;
                  TreeColor y_original_color = y.color;
                  if (z.left == NIL)
                  {
                      x = z.right;
                      Transplant(z, z.right);
                  }
                  else
                  {
                      if (z.right == NIL)
                      {
                          x = z.left;
                          Transplant(z, z.left);
                      }
                      else
                      {
                          y = Tree_Minimum(z.right);
                          y_original_color = y.color;
                          x = y.right;
                          if (y.parent == z) x.parent = y;
                          else
                          {
                              Transplant(y, y.right);
                              Transplant(z, y);
                              y.right.level += 1;
                              y.right = z.right;
                              y.right.parent = y;
                              m = true;
                          }
                          if(m==false)
                          Transplant(z, y);
                          y.left = z.left;
                          y.left.parent = y;
                          y.color = z.color;
                      }
                      if (y_original_color == TreeColor.black)
                    deleteFixup(x);
                  }
              }
              
        void deleteFixup(TreeNode x)
        {
            while (x != root && x.color == TreeColor.black)
            {
                if (x == x.parent.left)
                {
                    TreeNode w = x.parent.right;
                    if (w.color == TreeColor.red)
                    {
                        w.color = TreeColor.black;
                        x.parent.color = TreeColor.red;
                        Left_Rotate(x.parent);
                        w = x.parent.right;
                    }
                    if (w.left.color == TreeColor.black && w.right.color == TreeColor.black)
                    {
                        w.color = TreeColor.red;
                        x = x.parent;
                    }
                    else
                    {
                        if (w.right.color == TreeColor.black)
                        {
                            w.left.color = TreeColor.black;
                            w.color = TreeColor.red;
                            Right_Rotate(w);
                            w = x.parent.right;
                        }
                        w.color = x.parent.color;
                        x.parent.color = TreeColor.black;
                        w.right.color = TreeColor.black;
                        Left_Rotate(x.parent);
                        x = root;
                    }
                }
                else
                {
                    TreeNode w = x.parent.left;
                    if (w.color == TreeColor.red)
                    {
                        w.color = TreeColor.black;
                        x.parent.color = TreeColor.red;
                        Right_Rotate(x.parent);
                        w = x.parent.left;
                    }
                    if (w.right.color == TreeColor.black && w.left.color == TreeColor.black)
                    {
                        w.color = TreeColor.red;
                        x = x.parent;
                    }
                    else
                    {
                        if (w.left.color == TreeColor.black)
                        {
                            w.right.color = TreeColor.black;
                            w.color = TreeColor.red;
                            Left_Rotate(w);
                            w = x.parent.left;
                        }
                        w.color = x.parent.color;
                        x.parent.color = TreeColor.black;
                        w.left.color = TreeColor.black;
                        Right_Rotate(x.parent);
                        x = root;
                    }
                }
            }
            x.color = TreeColor.black;
        }

        void IncAllNodes(TreeNode p)
        {
            if (p != NIL)
            {
                IncAllNodes(p.left);
                p.level += 1;
                IncAllNodes(p.right);
            }
        }
        void DecAllNodes(TreeNode p)
        {
            if (p != NIL)
            {
                DecAllNodes(p.left);
                p.level -= 1;
                DecAllNodes(p.right);
            }
        }
        void Left_Rotate(TreeNode x)
        {
            TreeNode y = x.right;
            x.right = y.left;
            if (y.left != NIL)
                y.left.parent = x;
            y.parent = x.parent;
            if (x.parent == NIL)
                root = y;
            else
            {
                if (x == x.parent.left)
                    x.parent.left = y;
                else x.parent.right = y;
            }
            y.left = x;
            x.parent = y;

            x.level += 1;
            y.level -= 1;
            DecAllNodes(y.right);
            IncAllNodes(x.left);

        }
        
        void Right_Rotate(TreeNode y)
        {
            TreeNode x = y.left;
            y.left = x.right;
            if (x.right != NIL)
                x.right.parent = y;
            x.parent = y.parent;
            if (y.parent == NIL)
                root = x;
            else
            {
                if (y == y.parent.right)
                    y.parent.right = x;
                else y.parent.left = x;
            }
            x.right = y;
            y.parent = x;

            x.level -= 1;
            y.level += 1;
            DecAllNodes(x.left);
            IncAllNodes(y.right);
        }
       
        void Insert_FixUp(TreeNode z)
        {
            TreeNode y = NIL;
            while (z.parent.color == TreeColor.red)
            {
                if (z.parent == z.parent.parent.left)
                {
                    y = z.parent.parent.right;
                    if (y.color == TreeColor.red)
                    {
                        z.parent.color = TreeColor.black;
                        y.color = TreeColor.black;
                        z.parent.parent.color = TreeColor.red;
                        z = z.parent.parent;
                    }
                    else
                    {
                        if (z == z.parent.right)
                        {
                            z = z.parent;
                            Left_Rotate(z);
                        }
                        z.parent.color = TreeColor.black;
                        z.parent.parent.color = TreeColor.red;
                        Right_Rotate(z.parent.parent);
                    }
                }
                else
                {
                    y = z.parent.parent.left;
                    if (y.color == TreeColor.red)
                    {
                        z.parent.color = TreeColor.black;
                        y.color = TreeColor.black;
                        z.parent.parent.color = TreeColor.red;
                        z = z.parent.parent;
                    }
                    else
                    {
                        if (z == z.parent.left)
                        {
                            z = z.parent;
                            Right_Rotate(z);
                        }
                        z.parent.color = TreeColor.black;
                        z.parent.parent.color = TreeColor.red;
                        Left_Rotate(z.parent.parent);
                       

                    }
                }
            }
            root.color = TreeColor.black;
        }

        private void checkMaxLevel(int newLevel)
        {
            MaxLevel = (newLevel > MaxLevel) ? newLevel : MaxLevel;
        }

        public void insert( int data) {
	        if (root == null) {
		        root = NIL;
		        root.parent = NIL;
		        root.left = NIL;
		        root.right = NIL;
		        root.color = TreeColor.black;
	        }
            TreeNode z = new TreeNode(data, TreeColor.red,0);
            TreeNode y = NIL;
            TreeNode x = root;
	        while (x!=NIL) {
		        y = x;
                if (z.data < x.data)
                    x = x.left;
                else
                {
                    if (z.data > x.data)
                        x = x.right;
                    else return;
                }
	        }
        z.parent = y;
	        if (y == NIL)
		        root = z;
	        else {
		        if (z.data<y.data)

                    y.left = z;
		        else y.right = z;
	        }
	        z.left = NIL;
	        z.right = NIL;
	        z.color = TreeColor.red;
            if(z.parent!=NIL)
                z.level = z.parent.level+1;
            checkMaxLevel(z.level);
            Insert_FixUp(z);
        }
        
    }