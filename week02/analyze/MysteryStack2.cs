public static class MysteryStack2 {
    private static bool IsFloat(string text) {
        return float.TryParse(text, out _);
    }

    public static float Run(string text) {
        var stack = new Stack<float>();
        foreach (var item in text.Split(' ')) {
            if (item == "+" || item == "-" || item == "*" || item == "/") {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop();
                var op1 = stack.Pop();
                float res;
                if (item == "+") {
                    res = op1 + op2;
                }
                else if (item == "-") {
                    res = op1 - op2;
                }
                else if (item == "*") {
                    res = op1 * op2;
                }
                else {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                stack.Push(res);
            }
            else if (IsFloat(item)) {
                stack.Push(float.Parse(item));
            }
            else if (item == "") {
            }
            else {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();
    }
}

//This looks like a classic stack-based algorithm with a purpose for evaluating postfix expressions like a postfix mathematical expression.
//text.Split('') splits the input into tokens like numbers or operations.
//Stack(float) is used to store operands.
//When an operator is encountered, it pops the last two numbers from the stack, applies the operation then pushes the result back to the stack.
//When a number is encountered: push it onto the stack.
//At the end, is the stack does not have exactly one number, the expression is invalid.

//Stack usefulness is LIFO order allowing to always use the most recent operands for operations, which is waht postfix notation requires.

//Input 1 - 5 push
//        - 3 push
//        - 7 push
//        + - operator → pop 7, 3 → 3+7=10
//        * - operator → pop 10, 5 → 5*10=50
// Output is 50.

//Input 2 - 6 push
//        - 2 push
//        - + operator → 6+2=8
//        - 5 push
//        - 3 push
//        - - operator → 5-3=2
//        - / operator → 8/2=4
//Output is 4.

//Invalid Case 1 - stack.Count < 2 when an operator is encountered, meaning there are not enough operands for the operation.
//Examples: "+", "5 +", "3 4 + +" → The second + has only one number → Invalid Case 1

//Invalid Case 2 - division by zero when the second operand is zero during a division operation.
//Example: "5 0 /" → division by zero → Invalid Case 2

//Invalid Case 3 - when a token is neither an operator nor a valid float number, meaning the input contains invalid characters.
//Example: "5 3 &" → & is not a valid operator or number → Invalid Case 3

//Invalid Case 4 - happens when the expression is valid postfix but extra operands remain, i.e., not all numbers were used.
//Example: "5 3" → both numbers are pushed but no operator is applied → stack has 2 numbers at the end → Invalid Case 4

//Operands are pushed in order
//Operators pop last two operands - correct postfix calculation
//Ensures LIFO order, which is essential fo postfix evaluation.