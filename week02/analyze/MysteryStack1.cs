public static class MysteryStack1 {
    public static string Run(string text) {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}

//The var stack looks like it is iterating over each character in the input text. 
//It then pushes each character onto a stack.
//Stack is using the LIFO method.

//Var result pops each character off the stack and appends it to result.
//Because the stack is LIFO, the last character pushed becommes the first one popped.

//This code reverses the input string using a stack.

//Input 1 - racecar: This word reversed is still "racecar", which is also the output.

//Input 2 - stressed: This word reversed is desserts. The output is "desserts".

//Input 3 - a nut for a jar of tuna: This phrase reversed is "anut fo raj a rof tun a", which is also the output.

//This stack is useful using the LIFO order as it is perfect for reversing sentences.
//Instead of using a loop and building a reverse string manually, we can push all elements, then pop.
