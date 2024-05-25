using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Exception.ExceptionBase;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;

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
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
