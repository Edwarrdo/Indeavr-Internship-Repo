using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem12
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var algorithm = new ShuntinYardAlgorithm();
            
            var calculation = new CalCulateRNP();

            string expression = algorithm.Transform(input);

            Console.WriteLine(calculation.CalculateNotation(expression));

        }
    }
    public class ShuntinYardAlgorithm
    {
        private List<string> listOfInputTokens;
        private Stack<string> pendingTokens;
        private List<string> outputTokens;

        public string Transform(string expression)
        {
            Initialize(expression);

            ProcesTokens();

            AppendAllPendingTokes();

            return ProduceResult();
        }

        private string ProduceResult()
        {
            string result = "";

            foreach (string current in outputTokens)
            {
                if (result.Length > 0)
                {
                    result += " ";
                }
                result += current;
            }

            return result;
        }

        private void AppendAllPendingTokes()
        {
            while (ThereArePendingTokens())
            {
                AppendPendingToken();
            }
        }

        private void AppendPendingToken()
        {
            if (ThereArePendingTokens())
            {
                AppendToken(pendingTokens.Pop());
            }
        }

        private bool ThereArePendingTokens()
        {
            return pendingTokens.Count > 0;
        }

        private void ProcesTokens()
        {
            foreach (string current in listOfInputTokens)
            {
                if (IsLiteral(current))
                {
                    HandleLiteral(current);
                }
                else if (IsOpenParentheses(current))
                {
                    HandleOpenParentheses();
                }
                else if (IsClosedParentheses(current))
                {
                    HandleClosedParentheses();
                }
                else if (IsParameterSeparator(current))
                {
                    HandleParameterSeparator();
                }
                else
                {
                    HandleOperator(current);
                }
            }
        }

        private void HandleParameterSeparator()
        {
            BalanceToOpenParentheses();
        }

        private bool IsParameterSeparator(string current)
        {
            return current.Equals(",");
        }

        private void HandleClosedParentheses()
        {
            BalanceToOpenParentheses();
            DropOpenParentheses();

            ConditionallyAddFunctionNameToOutput();
        }

        private void ConditionallyAddFunctionNameToOutput()
        {
            if (PendingTokenIsFunctionName())
            {
                AppendToken(BildFunctionName());
            }
        }

        private string BildFunctionName()
        {
            return pendingTokens.Pop() + "()";
        }

        private bool PendingTokenIsFunctionName()
        {
            return ThereArePendingTokens() && IsFunctionName(pendingTokens.Peek());
        }

        private void DropOpenParentheses()
        {
            pendingTokens.Pop();
        }

        private void BalanceToOpenParentheses()
        {
            while (LastPendingTokenIsNotOpenParentheses())
            {
                AppendPendingToken();
            }
        }
        private bool LastPendingTokenIsNotOpenParentheses()
        {
            if (ThereArePendingTokens())
            {
                return !pendingTokens.Peek().Equals("(");
            }
            else
            {
                return false;
            }
        }

        private bool IsClosedParentheses(string current)
        {
            return current.Equals(")");
        }

        private void HandleOpenParentheses()
        {
            if (LastOperatorIsFunctionName())
            {
                MoveLastOutputTokenToPendingTokens();
            }
            AddToPendingTokens("(");
        }

        private void AddToPendingTokens(string token)
        {
            pendingTokens.Push(token);
        }

        private void MoveLastOutputTokenToPendingTokens()
        {
            AddLastOutputTokenToPending();
            DropLastOutputToken();
        }

        private void AddLastOutputTokenToPending()
        {
            AddToPendingTokens(LastOutputToken());
        }

        private string LastOutputToken()
        {
            return outputTokens[CalculateLastIndexOfOutputTokens()];
        }

        private void DropLastOutputToken()
        {
            outputTokens.RemoveAt(CalculateLastIndexOfOutputTokens());
        }

        private int CalculateLastIndexOfOutputTokens()
        {
            int lastIndex = outputTokens.Count - 1;
            return lastIndex;
        }

        private bool LastOperatorIsFunctionName()
        {
            return ThereAreOutputTokens() && IsFunctionName(LastOutputToken());
        }

        private bool ThereAreOutputTokens()
        {
            return outputTokens.Count > 0;
        }

        private bool IsFunctionName(string tokens)
        {
            return Regex.IsMatch(tokens, "[a-z]") && !Regex.IsMatch(tokens, @"\W");
        }

        private bool IsOpenParentheses(string current)
        {
            return current.Equals("(");
        }

        private void HandleOperator(string current)
        {
            while (PendingTokenExecutedBeforeCurrent(current))
            {
                AppendPendingToken();
            }
            AddToPendingTokens(current);
        }

        private bool PendingTokenExecutedBeforeCurrent(string current)
        {
            if (ThereArePendingTokens() && !pendingTokens.Peek().Equals("="))
            {
                int pendingPrecedence = CalculatePrecedence(pendingTokens.Peek());
                int currentPrecedence = CalculatePrecedence(current);

                return pendingPrecedence >= currentPrecedence;
            }
            else
            {
                if (ThereArePendingTokens() && pendingTokens.Peek().Equals("="))
                {
                    int pendingPrecedence = CalculatePrecedence(pendingTokens.Peek());
                    int currentPrecedence = CalculatePrecedence(current);

                    return pendingPrecedence > currentPrecedence;

                }
            }

            return false;
        }

        private int CalculatePrecedence(string current)
        {
            int precedence = 80;
            switch (current)
            {
                case "ln":
                case "pow":
                    return 110;
                case "*":
                case "/":
                    return 100;
                case "+":
                case "-":
                    return 90;
                case "=":
                    return precedence - 1;
                case "(":
                case ")":
                    return 10;
                default:
                    return 1;
            }
        }

        private void Initialize(string expression)
        {
            pendingTokens = new Stack<string>();
            listOfInputTokens = new List<string>();
            listOfInputTokens.AddRange((expression ?? "").Split());
            outputTokens = new List<string>();
        }

        private void HandleLiteral(string current)
        {
            AppendToken(current);
        }

        private void AppendToken(string token)
        {
            outputTokens.Add(token);
        }

        private bool IsLiteral(string token)
        {
            return Regex.IsMatch(token, @"(\w+|\d+)");
        }
    }

    public class CalCulateRNP
    {
        private Stack<double> numbers;

        public double CalculateNotation(string expression)
        {
            double result = 0;

            string[] tokens = expression.Split(' ');
            numbers = new Stack<double>();
            double currentNumber;
            double[] numbersForCalculation = new double[2];

            for (int i = 0; i < tokens.Length; i++)
            {
                if (IsNumber(tokens[i]))
                {
                    currentNumber = double.Parse(tokens[i]);
                    numbers.Push(currentNumber);
                }
                else
                {
                    int neededOperators = GetNumberOfOperators(tokens[i]);

                    for (int j = 0; j < neededOperators; j++)
                    {
                        numbersForCalculation[j] = numbers.Pop();
                    }

                    numbers.Push(CurrentCalculation(numbersForCalculation, tokens[i]));
                }
            }
            result = numbers.Pop();

            return result;
        }

        private double CurrentCalculation(double[] numbersForCalculation, string token)
        {
            switch (token)
            {
                case "+":
                    return numbersForCalculation[0] + numbersForCalculation[1];
                case "-":
                    return numbersForCalculation[1] - numbersForCalculation[0];
                case "/":
                    return numbersForCalculation[1] / numbersForCalculation[0];
                case "*":
                    return numbersForCalculation[0] * numbersForCalculation[1];
                case "ln()":
                    return Math.Log(numbersForCalculation[0], Math.E);
                case "sqrt()":
                    return Math.Sqrt(numbersForCalculation[0]);
                case "pow()":
                    if (numbersForCalculation[0] > 0)
                    {
                        return Math.Pow(numbersForCalculation[1], numbersForCalculation[0]);
                    }
                    else
                    {
                        return 1 / Math.Pow(numbersForCalculation[1], Math.Abs(numbersForCalculation[0]));
                    }
                default:
                    return 0;
            }
        }
        private int GetNumberOfOperators(string current)
        {
            switch (current)
            {
                case "+":
                case "-":
                case "/":
                case "*":
                case "pow()":
                    return 2;

                default: return 1;
            }
        }

        private bool IsNumber(string token)
        {
            return Regex.IsMatch(token, @"\d");
        }
    }
}
