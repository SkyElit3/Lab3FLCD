namespace Lab2FLCD
{
    public class MyLinkedElement
    {
        public string Content;
        public MyLinkedElement Next;
        public int Position;

        public MyLinkedElement()
        {
            Next = null;
            Position = 0;
        }
    }
}