
namespace BlazorHybridApp.Handle.Service
{
    public enum OperationEnum
    {
        Add,

        Subtract,

        Multiply,

        Divide
    }
    public interface ICalculatorService
    {
        Task<double> Calculate(double number1, double number2, OperationEnum operation);
    }
    public class CalculatorService : ICalculatorService
    {
        public Task<double> Calculate(double number1, double number2, OperationEnum operation)
        {
            switch (operation)
            {
                case OperationEnum.Add:
                    return Task.FromResult(number1 + number2);
                case OperationEnum.Subtract:
                    return Task.FromResult(number1 - number2);
                case OperationEnum.Multiply:
                    return Task.FromResult(number1 * number2);
                case OperationEnum.Divide:
                    if (number2 == 0)
                    {
                        throw new DivideByZeroException("Division by zero is not allowed.");
                    }
                    return Task.FromResult(number1 / number2);
                default:
                    throw new ArgumentException("Invalid operation.");
            }
        }
    }
}
