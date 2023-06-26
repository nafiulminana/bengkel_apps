using CalculatorServiceReference;
using Microsoft.AspNetCore.Mvc;

namespace BengkelMotorApp.Controllers
{
    public class CalculatorController : Controller
    {
        CalculatorSoapClient _clientSoap;

        public CalculatorController()
        {
            _clientSoap = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<int> Add(int a, int b)
        {
            return await _clientSoap.AddAsync(a, b);
        }

        [HttpGet]
        public async Task<int> Subtract(int a, int b)
        {
            return await _clientSoap.SubtractAsync(a, b);
        }

        [HttpGet]
        public async Task<int> Multiply(int a, int b)
        {
            return await _clientSoap.MultiplyAsync(a, b);
        }

        [HttpGet]
        public async Task<int> Divide(int a, int b)
        {
            return await _clientSoap.DivideAsync(a, b);
        }
    }
}
