namespace Lab2FLCD
{
    public class MyLinkedElement
    {
        public string content;
        public MyLinkedElement next;
        public int position;

        public MyLinkedElement()
        {
            next = null;
            position = 0;
        }
    }
}