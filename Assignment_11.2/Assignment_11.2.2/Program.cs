/*
1. Listen (and ask questions),
2. Generate Examples (that cover all pertinent cases and corner cases),
3. Brute Force (pseudo),
4. Optimize,
5. Walk Through,
6. Test,
7. Implement (code),
8. Test Again

Given the head of a singly linked list, reverse the list, and return the reversed list.

Linked lists... I wish I would have paid better attention to the syntax for these
If we're given the head and it's not circular then it has an end. 
I remember each node only points to the next node. 
So I guess just follow the list to the end? 
we have to move the pointers though. what does that look like?

The last node will not point to anything. can we then make that the head and point back to the last node?
that would reverse it but I have no idea what that logic looks like

maybe we can use the same logic we did when we reversed an array with a temp var? instead of holding an index if holds the pinter/ref?
then 3 card monte the vars around until we swap everything out

LinkedList<int> givenLinkedList
var referencePointer
var tempPointer
var reference

Looking at C# API I can see useful props of First and Last with lots of built in props like Add/Remove First/Last
that makes it too easy though, right? Ok, confirmed by Deepali it has to be from scratch. She's off the Christmas list now for sure.

We need to write our own classes to create the LinkedList Node Logic. We also need a class to create the nodes.

class ListNode
props for Value and Next
constructor requiring an input value to assign to the Value prop and set Next prop to null

class LinkedList

instantiate ListNode class as Head property
constructor assigning Head as null

func reverstList
    previous = null
    current = head
    next = null
    
    while (current)
        next = current.next
        current.next = previous
        previous = current
        current = next

*/
Console.WriteLine();
Console.WriteLine("Hello, World!");
Console.WriteLine();

var list = new CustomLinkedList();
list.Head = new ListNode(1);
list.Head.Next = new ListNode(2);
list.Head.Next.Next = new ListNode(3);

Console.WriteLine("Before reversal:");
PrintList(list.Head);
Console.WriteLine();

list.Head = ReverseList(list.Head);

Console.WriteLine("After reversal:");
PrintList(list.Head);
Console.WriteLine();


static ListNode ReverseList(ListNode head)
{
    ListNode previous = null;
    ListNode current = head;
    ListNode next = null;
    
    while (current != null)
    {
        // Store the next node
        next = current.Next;
        
        // Reverse the link
        current.Next = previous;
        
        // Move pointers forward
        previous = current;
        current = next;
    }
    
    // Previous is now the new head
    return previous;
}
static void PrintList(ListNode head)
{
    ListNode current = head;
    while (current != null)
    {
        Console.Write(current.Value + " -> "); // looks cool in console
        current = current.Next;
    }
    Console.WriteLine("null");
}

public class ListNode
{
    public int Value;
    public ListNode Next;
    
    public ListNode(int value)
    {
        Value = value;
        Next = null;
    }
}

// Basic LinkedList class
public class CustomLinkedList
{
    public ListNode Head;
    
    public CustomLinkedList()
    {
        Head = null;
    }
}