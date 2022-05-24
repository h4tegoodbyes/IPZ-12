using System;

namespace AvlTree
{
    public class AvlTree<T> where T : IComparable<T>
    {
        public AvlTreeNote<T> Root;       

        private bool _isBalance;            


        public AvlTreeNote<T> Add(T key) => Root = Add(key, Root);
        
        private AvlTreeNote<T> Add(T key, AvlTreeNote<T> node)
        {
            if (node == null)
            {
                node = new AvlTreeNote<T>(key, null, null);
            }
            else
            {

                if (key.CompareTo(node.Key) == 0) return null;

                if (key.CompareTo(node.Key) < 0)
                {

                    node.LChild = Add(key, node.LChild);

                    if (node.LChild == null) return node;
                    
                    switch (node.Height)
                    {
                        case 1:
                            return LeftBalance(node);
                        case 0:
                            node.Height = _isBalance ? 0 : 1;
                            break;
                        case -1:
                            node.Height = 0;
                            break;
                    }
                }
                else
                {

                    node.RChild = Add(key, node.RChild);

                    if (node.RChild == null) return node;
                    
                    switch (node.Height)
                    {
                        case 1:
                            node.Height = 0;
                            break;
                        case 0:
                            node.Height = _isBalance ? 0 : -1;
                            break;
                        case -1:
                            return RightBalance(node); 
                    }
                }
            }
            
            _isBalance = false;

            return node;
        }
        
        private AvlTreeNote<T> LeftBalance(AvlTreeNote<T> node)
        {
            if (_isBalance) return node;
            
            var leftNode = node.LChild;

            switch (leftNode.Height)
            {
                case 1:

                    node.Height = leftNode.Height = 0;

                    node = R_Rotate(node);

                    break;

                case -1:

                    node.Height = leftNode.Height = 0;

                    node.LChild = L_Rotate(leftNode);

                    node = R_Rotate(node);

                    break;
            }

            return node;
        }

        private AvlTreeNote<T> RightBalance(AvlTreeNote<T> node)
        {
            if (_isBalance) return node;
            
            var rightNode = node.RChild;

            switch (rightNode.Height)
            {
                case -1:
                    
                    node.Height = rightNode.Height = 0;
                
                    node = L_Rotate(node);
                    
                    break;
                
                case 1:

                    node.Height = rightNode.Height = 0;

                    node.RChild = R_Rotate(rightNode);
                    
                    node = L_Rotate(node);
                    
                    break;
            }

            return node;
        }
        
        private AvlTreeNote<T> R_Rotate(AvlTreeNote<T> node)
        {
            var temp = node.LChild;
            
            node.LChild = temp.RChild;

            temp.RChild = node;
            
            _isBalance = true;
            
            return temp;
        }
        
        private AvlTreeNote<T> L_Rotate(AvlTreeNote<T> node)
        {
            var temp = node.RChild;
            
            node.RChild = temp.LChild;
            
            temp.LChild = node;
            
            _isBalance = true;

            return temp;
        }
        
        public AvlTreeNote<T> Find(T key) => Find(key, Root);
        
        public AvlTreeNote<T> Find(T key,AvlTreeNote<T> node)
        {
            if (node == null) return null;
            
            if (key.CompareTo(node.Key) < 0)
            {
                node = Find(key,node.LChild);
            }
            else if(key.CompareTo(node.Key)>0)
            {
                node = Find(key, node.RChild);
            }
            
            return node;
        }


        private AvlTreeNote<T> Move(AvlTreeNote<T> node, AvlTreeNote<T> findNode)
        {
            AvlTreeNote<T> moveNode;

            if (findNode != null)
            {
                if (findNode.RChild != null)
                {
                    moveNode = findNode.RChild;

                    findNode.RChild = null;
                }
                else
                {
                    findNode.LChild = null;

                    moveNode = findNode;
                }
                
                if (node.LChild != moveNode) moveNode.LChild = node.LChild;

                if (node.RChild != moveNode) moveNode.RChild = node.RChild;
            }
            else
            {
                moveNode = null;
            }

            node.LChild = null;

            node.RChild = null;

            node.Key = default(T);

            node.Height = 0;

            return moveNode;
        }


        public void Remove(T key) => Root = Remove(key, Root);

        private AvlTreeNote<T> Remove(T key, AvlTreeNote<T> node)
        {
            if (node == null) return null;
            
            if (key.CompareTo(node.Key) < 0)
            {
                if (node.LChild == null) return node;
                
                node.LChild = Remove(key, node.LChild);
                    
                switch (node.Height)
                {
                    case 1:
                        node.Height = 0;
                        break;
                    case 0:
                        node.Height = -1;
                        break;
                    case -1:

                        node.Height = 0;
                        return node.LChild == null ? RightBalance(node) : LeftBalance(node);
                }
            }
            else if (key.CompareTo(node.Key) > 0)
            {
                if (node.RChild == null) return node;
                
                node.RChild = Remove(key, node.RChild);

                switch (node.Height)
                {
                    case 1:

                        node.Height = 0;
                        return node.RChild == null ? LeftBalance(node) : RightBalance(node);
                        break;
                    case 0:
                        node.Height = 1;
                        break;
                    case -1:
                        node.Height = 0;
                        break;
                }
            }
            else if (key.CompareTo(node.Key) == 0)
            {
                var findNode = Remove(key,node.LChild);

                node = Move(node, findNode);
            }
            
            _isBalance = false;

            return node;
        }
    }
}