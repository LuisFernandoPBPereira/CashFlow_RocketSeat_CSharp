using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Reponses;
using CashFlow.Communication.Requests;
using CashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
		try
		{
            var useCase = new RegisterExpenseUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
		catch (ErrorOnValidationException exception)
		{
            var errorResponse = new ResponseErrorJson(exception.Errors);

            return BadRequest(errorResponse);
		}
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "unknown error");
        }
    }
}
