using System.Collections;

namespace BinaryTree.DataStructures.SplayTree;

public class SplayTree<T> : IEnumerable<T> where T : IComparable<T>, IComparable
    {
        private Node _root;
        
        public int Count { get; private set; }
        
        class Node
        {
            public Node Left, Right;
            public T Key;

            public Node(T pKey)
            {
                Key = pKey;
                Left = null;
                Right = null;
            }

            public Node(Node pNode)
            {
                Key = pNode.Key;
                Left = pNode.Left;
                Right = pNode.Right;
            }

            public static bool operator true(Node pN)
            {
                return pN != null;
            }

            public static bool operator false(Node pN)
            {
                return pN == null;
            }

            public static bool operator !(Node pN)
            {
                return pN == null;
            }
        }


        public SplayTree()
        {
            _root = null;
            Count = 0;
        }

        public SplayTree(T pRoot)
        {
            _root = new Node(pRoot);
            Count = 1;
        }

        public SplayTree(T[] pItems)
        {
            _root = new Node(pItems[0]);
            for (int i = 1; i < pItems.Length; i++)
            {
                Add(ref _root, pItems[i]);
            }
        }
       
        public bool Remove(T pKey)
        {
            Node n;
            Node parent;
            FindWithParent(_root, pKey, out n, out parent);
            if (!n) return false;

            if (!n.Right && !n.Left)
            {
                Node next = SubtreeMax(n.Right);
                n.Key = next.Key;
                
                FindWithParent(n.Right, next.Key, out n, out parent);
                
                parent.Right = null;
            }
            else 
            {
                if (parent.Right != null && parent.Right.Key.CompareTo(pKey) == 0)
                {
                    parent.Right = !n.Right ? n.Right : n.Left;
                }
                else
                {
                    parent.Left = !n.Right ? n.Right : n.Left;
                }
            }

            return true;
        }

       
        public bool Contains(T pKey)
        {
            Node currentNode = _root;
            Node previousNode = null; 
            if (!_root) return false;
            if (pKey.CompareTo(currentNode.Key) == 0) return true;

            Node leftTree = null;
            Node rightTree = null;
            
            while (currentNode)
            {
                
                if (pKey.CompareTo(currentNode.Key) < 0)
                {
                    if (!rightTree)
                    {
                        rightTree = new Node(currentNode);
                        rightTree.Left = null;
                    }
                    
                    previousNode = currentNode;
                    currentNode = currentNode.Left;
                    
                    if (currentNode)
                    {
                        if (pKey.CompareTo(currentNode.Key) > 0)
                        {
                            if (!leftTree)
                            {
                                leftTree = new Node(currentNode);
                                leftTree.Right = null;
                            }
                            else
                            {
                                Add(ref leftTree, currentNode.Key);
                            }
                        }
                        else 
                        {
                            Add(ref rightTree, currentNode.Key);
                        }
                    }
                }
                else if (pKey.CompareTo(currentNode.Key) > 0) 
                {

                    if (!leftTree)
                    {
                        leftTree = new Node(currentNode);
                        leftTree.Right = null;
                    }
                    
                    previousNode = currentNode;
                    currentNode = currentNode.Right;
                    
                    if (currentNode)
                    {
                        if (pKey.CompareTo(currentNode.Key) > 0)
                        {
                            Add(ref leftTree, currentNode.Key);
                        }
                        else
                        {
                            if (!rightTree)
                            {
                                rightTree = new Node(currentNode);
                                rightTree.Left = null;
                            }
                            else
                            {
                                Add(ref rightTree, currentNode.Key);
                            }
                        }
                    }
                }
                else 
                {

                    if (currentNode.Left)
                    {
                        Attach(ref leftTree, ref currentNode.Left);
                    }

                    if (currentNode.Right)
                    {
                        Attach(ref rightTree, ref currentNode.Right);
                    }

                    Node n;
                    Find(pKey.CompareTo(previousNode.Key) < 0 ? leftTree : rightTree, previousNode.Key, out n);
                    if (!n || !n.Left) break;
                    
                    if (n.Left.Key.CompareTo(pKey) == 0)
                    {
                        n.Left = null;
                    }
                    else
                    {
                        n.Right = null;
                    }

                    break;
                }

            }
            
            if (currentNode)
            {
                _root = currentNode;
                _root.Left = leftTree;
                _root.Right = rightTree;

                return true;
            }
            else 
            {
                leftTree = null;
                rightTree = null;
                return false;
            }

        }
        
        public void Add(T pKey)
        {
            Node currentNode = _root;
            Node leftTree = null;
            Node rightTree = null;
            
            while (currentNode)
            {
                if (pKey.CompareTo(currentNode.Key) < 0)
                {
                    if (!rightTree)
                    {
                        rightTree = new Node(currentNode);
                        rightTree.Left = null;
                    }
                    
                    currentNode = currentNode.Left;
                    
                    if (currentNode)
                    {
                        if (pKey.CompareTo(currentNode.Key) > 0)
                        {
                            if (!leftTree)
                            {
                                leftTree = new Node(currentNode);
                                leftTree.Right = null;
                            }
                            else
                            {
                                Add(ref leftTree, currentNode.Key);
                            }
                        }
                        else
                        {
                            Add(ref rightTree, currentNode.Key);
                        }
                    }
                }
                else
                {
                    if (!leftTree)
                    {
                        leftTree = new Node(currentNode);
                        leftTree.Right = null;
                    }
                    
                    currentNode = currentNode.Right;
                    
                    if (currentNode)
                    {
                        if (pKey.CompareTo(currentNode.Key) > 0)
                        {
                            Add(ref leftTree, currentNode.Key);
                        }
                        else
                        {
                            if (!rightTree)
                            {
                                rightTree = new Node(currentNode);
                                rightTree.Left = null;
                            }
                            else
                            {
                                Add(ref rightTree, currentNode.Key);
                            }
                        }
                    }
                }
            }
            
            _root = new Node(pKey);
            _root.Left = leftTree;
            _root.Right = rightTree;

            Count++;
        }

        public T Minimum()
        {
            return SubtreeMin(_root).Key;
        }
        
        public T Maximum()
        {
            return SubtreeMax(_root).Key;
        }


        private void Add(ref Node pNode, T pKey)
        {
            if (!pNode)
            {
                pNode = new Node(pKey);
            }
            else if (pKey.CompareTo(pNode.Key) < 0)
            {
                Add(ref pNode.Left, pKey);
            }
            else
            {
                Add(ref pNode.Right, pKey);
            }
        }
        
        private void Attach(ref Node pNode, ref Node pAttachNode)
        {
            if (!pNode)
            {
                pNode = pAttachNode;
            }
            else if (pAttachNode.Key.CompareTo(pNode.Key) < 0)
            {
                Attach(ref pNode.Left, ref pAttachNode);
            }
            else
            {
                Attach(ref pNode.Right, ref pAttachNode);
            }
        }

        private void Find(T pKey, out Node pNode)
        {
            Find(_root, pKey, out pNode);
        }

        private void Find(Node pSubtree, T pKey, out Node pNode)
        {
            Node currentNode = pSubtree;
            while (currentNode)
            {
                if (pKey.CompareTo(currentNode.Key) < 0)
                {
                    currentNode = currentNode.Left;
                }
                else if (pKey.CompareTo(currentNode.Key) > 0)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    pNode = currentNode;
                    return;
                }
            }

            pNode = null;
        }

        private void FindWithParent(Node pRoot, T pKey, out Node pNode, out Node pParent)
        {
            Node currentNode = pRoot;
            Node previousNode = null;
            while (currentNode)
            {
                if (pKey.CompareTo(currentNode.Key) < 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Left;
                }
                else if (pKey.CompareTo(currentNode.Key) > 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Right;
                }
                else
                {
                    pParent = previousNode;
                    pNode = currentNode;
                    return;
                }
            }

            pNode = null;
            pParent = null;
        }

        private Node SubtreeMin(Node pNode)
        {
            Node retval = pNode;
            while (pNode.Left)
            {
                retval = pNode.Left;
            }

            return retval;
        }

        private Node SubtreeMax(Node pNode)
        {
            Node retval = pNode;
            while (pNode.Right)
            {
                retval = pNode.Right;
            }

            return retval;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return new SplayTreeEnumerator(_root);
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }
        
        private class SplayTreeEnumerator : IEnumerator<T>
        {
            private List<Node> _path;
            private Node _root;
            private Node _current;
            private Node _next;

            public T Current
            {
                get { return _current.Key; }
            }

            private object Current1
            {
                get { return Current; }
            }
            object IEnumerator.Current
            {
                get { return Current1; }
            }

            public SplayTreeEnumerator(Node pRoot)
            {
                _path = new List<Node>();
                _root = pRoot;
                _current = pRoot;

                _path.Add(_current);
                var t = _current.Left;
                while (t)
                {
                    _path.Add(t);
                    t = t.Left;
                }
                _next = _path[_path.Count - 1];
            }

            public bool MoveNext()
            {
                _current = _next;
                _path.RemoveAt(_path.Count - 1);

                if (_path.Count > 0)
                {
                    _next = _path[_path.Count - 1];
                }
                else if (_next.Right)
                {
                    _path.Add(_next.Right);

                    var t = _next.Right.Left;
                    while (t)
                    {
                        _path.Add(t);
                        t = t.Left;
                    }

                    _next = _path[_path.Count - 1];
                }
                else
                {
                    return false;
                }

                return true;
            }

            public void Reset()
            {
                _path = new List<Node>();
                _current = _root;

                _path.Add(_current);
                var t = _current.Left;
                while (t)
                {
                    _path.Add(t);
                    t = t.Left;
                }
                _next = _path[_path.Count - 1];
            }

            public void Dispose()
            {
                _path = null;
            }
        }
    }