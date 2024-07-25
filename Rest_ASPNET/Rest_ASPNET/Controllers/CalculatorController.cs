using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace Rest_ASPNET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> Logger;
        public CalculatorController(ILogger<CalculatorController> logger)
        {
            Logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                double ans = ConvertToDouble(firstNumber) + ConvertToDouble(secondNumber);
                return Ok(ans);
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                double ans = ConvertToDouble(firstNumber) - ConvertToDouble(secondNumber);
                return Ok(ans);
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)) 
            {
                double ans = ConvertToDouble(firstNumber) * ConvertToDouble(secondNumber);
                return Ok(ans);
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)) 
            {
                double divisor = ConvertToDouble(secondNumber);
                if(divisor == 0)
                {
                    return BadRequest("Division by zero is not allowed");
                }
                double ans = ConvertToDouble(firstNumber) / divisor;
                return Ok(ans);
            }
            return BadRequest("Invalid Input");
        }

        public bool IsNumeric(string strNumber)
        {
            double num;
            return double.TryParse(strNumber, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out num);
            
        }

        public double ConvertToDouble(string strNumber)
        {
            if (double.TryParse(strNumber, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out double num))
            {
                return num;
            }
            return 0;
        }
    }
}
