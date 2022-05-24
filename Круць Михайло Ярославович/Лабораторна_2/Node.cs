using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{
    public class Node
    {

        public int num { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public string color { get; set; }
        public Node parentNode { get; set; }  
        public int height { get; set; }
        public Node(int data) 
        {
            num = data;
            height = 1;
            this.parentNode =  null;        
        }
        public Node() 
        {
            num = 0;
            this.parentNode = null;
        }
        
    }
}
