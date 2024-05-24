using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public RequestRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        return new RequestRegisterExpenseJson 
        {

        };
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var tituloIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        var dateCompare = DateTime.Compare(request.Data, DateTime.UtcNow);
        var isValidPaymentType = Enum.IsDefined(typeof(PaymentsType), request.PaymentsType);


        if (tituloIsEmpty)
        {
            throw new ArgumentException("The title is required");
        }

        if(request.Amount <= 0)
        {
            throw new ArgumentException("The amount must be greater than zero");
        }

        if(dateCompare > 0)
        {
            throw new ArgumentException("The date can't be in the future");
        }

        if(isValidPaymentType == false)
        {
            throw new ArgumentException("The payment type is not valid");
        }

    }
}
