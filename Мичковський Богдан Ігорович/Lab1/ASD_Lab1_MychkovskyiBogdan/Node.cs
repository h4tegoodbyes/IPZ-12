namespace ASD_Lab1_MychkovskyiBogdan
{
    public class Node
    {
        public Node NextInd;
        public Node Head;
        public int Count { get; set; }
        public int Data;

        public Node()
        {
            Head = null;
            NextInd = null;
            Count = 0;
        }

        public Node(int data)
        {
            Data = data;
            NextInd = null;
        }

        public void Add(int data)
        {
            Count++;
            Node New = new Node(data);

            if (Head == null)
            {
                Head = new Node(data);
            }

            else
            {

                New.NextInd = null;
            Node last = Head;

            while (last.NextInd != null)
                last = last.NextInd;
            last.NextInd = New;
            }
        }
    }
}