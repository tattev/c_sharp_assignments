
public class CustomStringBuilderLinkedList
{
    private class Node
    {
        public char Data { get; set; }
        public Node Next { get; set; }

        public Node(char data)
        {
            Data = data;
            Next = null;
        }
    }
    private Node? head;
    private Node? tail;
    private int length;


    //Length method that returns the current length of the string being built.
    public int Length
    {
        get { return length; }
    }

    private CustomStringBuilderLinkedList Append(char c)
    {
        Node newNode = new Node(c);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }

        length++;
        return this;
    }
    //Append method, which appends the given string to the end of the current string.
    public CustomStringBuilderLinkedList Append(string str)
    {
        if (str == null)
            return null;

        foreach (char c in str)
        {
            Append(c);
        }
        return this;
    }

    //InsertAt method, which inserts the given string at the specified index in the current string.
    private CustomStringBuilderLinkedList InsertAt(char c, int index)
    {
        Node newNode = new Node(c);
        if (index == 0)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }

        length++;
        return this;
    }

    public CustomStringBuilderLinkedList InsertAt(string str, int index)
    {
        if (str == null || index < 0 || index > length)
            return null;

        foreach (char c in str)
        {
            InsertAt(c, index++);
        }
        return this;
    }


    //RemoveDuplicates method, which removes duplicate characters from the current string, leaving only the first occurrences.
    public CustomStringBuilderLinkedList RemoveDuplicates()
    {
        Node current = head;
        while (current != null)
        {
            Node node = current;
            while (node.Next != null)
            {
                if (node.Next.Data == current.Data)
                {
                    node.Next = node.Next.Next;
                    length--;
                }
                else
                {  
                    node = node.Next;
                }
            }
            current = current.Next;
         }
        return this;
    }

    //RemoveWhitespaces method, which removes all whitespace characters from the current string.
    public CustomStringBuilderLinkedList RemoveWhitespaces()
    {
        Node current = head;
        while (current != null)
        {
            if (char.IsWhiteSpace(current.Data))
            {
                head = current.Next;
                current = head;
                length--;
            }
            else if (current.Next != null && char.IsWhiteSpace(current.Next.Data))
            {
                current.Next = current.Next.Next;
                length--;
            }
            else
            {
                current = current.Next;
            }      
        }
        return this;
    }

    //GetString method, which returns the string representation of the current string.
    public string GetString()
    {
        char[] result = new char[length];
        Node current = head;
        int index = 0;
        while (current != null)
        {
            result[index++] = current.Data;
            current = current.Next;
        }
        return new string(result);
    }

    //IsBlank method, which checks whether the current string is null, empty, or consists of only whitespace characters.
    public bool IsBlank()
    {
        return length == 0;
    }

    //OnBlank method, which returns the string representation of the current string or the given string if the current value is blank.
    public string OnBlank(string str)
    {
        return IsBlank() ? str : GetString();
    }

    public class Program
    {
        static void Main()
        {
            CustomStringBuilderLinkedList customStringBuilder = new CustomStringBuilderLinkedList();
            customStringBuilder.Append("aaaa ");
            customStringBuilder.Append("bbbb").Append("yyyy");

            Console.WriteLine("Length: " + customStringBuilder.Length);
            Console.WriteLine("Result: " + customStringBuilder.GetString());

            customStringBuilder.InsertAt(" cccc", 5);
            Console.WriteLine("Result after InsertAt: " + customStringBuilder.GetString());

            customStringBuilder.RemoveDuplicates();
            Console.WriteLine("Result after RemoveDuplicates: " + customStringBuilder.GetString());

            customStringBuilder.RemoveWhitespaces();
            Console.WriteLine("Result after RemoveWhitespaces: " + customStringBuilder.GetString());

            Console.WriteLine("IsBlank: " + customStringBuilder.IsBlank());

            string result = customStringBuilder.OnBlank("Default Value");
            Console.WriteLine("OnBlank: " + result);
        }
    }

}




