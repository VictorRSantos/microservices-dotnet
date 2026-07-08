using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber, string operation)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertDecimal(firstNumber) + ConvertDecimal(secondNumber);
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid input.");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sub = ConvertDecimal(firstNumber) - ConvertDecimal(secondNumber);
            return Ok(sub.ToString());
        }

        return BadRequest("Input Invalid.");
    }

    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplication(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var mult = ConvertDecimal(firstNumber) * ConvertDecimal(secondNumber);
            return Ok(mult.ToString());
        }

        return BadRequest("Input Invalid.");
    }

    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult Division(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var div = ConvertDecimal(firstNumber) / ConvertDecimal(secondNumber);
            return Ok(div.ToString());
        }

        return BadRequest("Input Invalid.");
    }

    [HttpGet("median/{firstNumber}/{secondNumber}")]
    public IActionResult Median(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var median = (ConvertDecimal(firstNumber) + ConvertDecimal(secondNumber)) / 2;
            return Ok(median.ToString());
        }

        return BadRequest("Input Invalid.");
    }

    [HttpGet("square-root/{firstNumber}")]
    public IActionResult SquareRoot(string firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            var sqrt = Math.Sqrt(Convert.ToDouble(firstNumber));
            return Ok(sqrt.ToString());
        }
        return BadRequest("Input Invalid.");
    }

    #region Metodos 
    private decimal ConvertDecimal(string strNumber)
    {
        decimal decimalValue;
        if (decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }

        return decimalValue;
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumeric = double.TryParse(
        strNumber,
        System.Globalization.NumberStyles.Any,
        System.Globalization.NumberFormatInfo.InvariantInfo,
        out number);

        return isNumeric;
    }

    #endregion
}
