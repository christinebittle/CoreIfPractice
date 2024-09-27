using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IfPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IfPracticeController : ControllerBase
    {

        /// <summary>
        /// Determines if 3 angles can make a triangle.
        /// </summary>
        /// <param name="angle1">The first angle of the triangle.</param>
        /// <param name="angle2">The second angle of the triangle.</param>
        /// <param name="angle3">The third angle of the triangle.</param>
        /// <returns>TRUE if the angles can make a triangle. FALSE otherwise.</returns>
        /// <example>
        ///     GET : /api/IfPractice/ValidTriangle/60/60/60 -> TRUE
        /// </example>
        /// <example>
        ///     GET : /api/IfPractice/ValidTriangle/100/50/50 -> FALSE
        /// </example>
        [HttpGet(template:"ValidTriangle/{angle1}/{angle2}/{angle3}")]
        public bool ValidTriangle(decimal angle1, decimal angle2, decimal angle3)
        {
            bool isValidTriangle;
            if (angle1 <= 0 || angle2 <= 0 || angle3 <= 0)
            {
                isValidTriangle = false;
                return isValidTriangle;
            }
            decimal sum = angle1 + angle2 + angle3;

            if (sum == 180) isValidTriangle = true;
            else isValidTriangle = false;

            return isValidTriangle;
        }



        /// <summary>
        /// Determines if a number is divisible by another number
        /// </summary>
        /// <param name="dividend">The number to divide</param>
        /// <param name="divisor">The number to divide by</param>
        /// <returns>Returns TRUE if the dividend is divisible by the divisor, FALSE if not.</returns>
        /// <example>
        ///     GET : /api/IfPractice/Divisible/10/2        ->       TRUE
        /// </example>
        /// <example>
        ///     GET : /api/IfPractice/Divisible/15/5        ->       TRUE
        /// </example>
        /// <example>
        ///     GET : /api/IfPractice/Divisible/23/3        ->       FALSE
        /// </example>
        [HttpGet(template:"Divisor/{dividend}/{divisor}")]
        public bool Divisible(int dividend, int divisor)
        {
            int remainder = dividend % divisor;
            if (remainder == 0) return true;
            else return false;
        }

        /// <summary>
        /// Determines the length of the hypotenuse of a right-angled triangle.
        /// </summary>
        /// <param name="sideA">The length of side A</param>
        /// <param name="sideB">The length of side B</param>
        /// <returns>The length of the hypotenuse. 0 if not a valid triangle</returns>
        /// <example>
        ///     eg. GET api/example/pythagorean/9/12	-> 15
        /// </example>
        /// <example>
        ///     GET api/example/pythagorean/9/10	-> 13.453
        /// </example>
        [HttpGet(template:"Pythagorean/{sideA}/{sideB}")]
        public double Pythagorean(double sideA, double sideB)
        {
            //We must have positive numbers for our actual triangle sides
            if (sideA > 0 && sideB > 0)
            {
                double hypotenuse = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
                return hypotenuse;
            }
            else
            {
                //Not a valid triangle
                return 0;
            }
        }

        /// <summary>
        /// This is a function which calculates the power of two integers
        /// </summary>
        /// <param name="numberBase">Base Number</param>
        /// <param name="numberExponent">Exponent Number</param>
        // <returns>numberBase ^ numberExponent</returns>
        /// <example>
        ///     GET : api/IfPractice/Power/2/3     ->      8
        /// </example>
        /// <example>
        //      GET : api/IfPractice/Power/2/4     ->      16
        //  </example>
        [HttpGet(template:"Power/{numberBase}/{numberExponent}")]
        public double Power(double numberBase, double numberExponent)
        {
            double power = Math.Pow(numberBase, numberExponent);
            return power;
        }

        /// <summary>
        /// Calculates the number of coins. Returns TRUE if we have enough to buy a toy for $10.50CAD. Returns FALSE otherwise.
        /// </summary>
        /// <param name="Nickels">The number of Nickels</param>
        /// <param name="Dimes">The number of Dimes</param>
        /// <param name="Quarters">The number of Quarters</param>
        /// <param name="Loonies">The number of Loonies</param>
        /// <param name="Toonies">The number of Toonies</param>
        /// <returns>If the total amount of money is enough to purchase a toy worth $10.50CAD</returns>
        /// <example>
        ///     GET api/IfPractice/CoinComputer/0/0/0/15/0		-> TRUE
        /// </example>
        /// <example>
        ///     GET api/IfPractice/CoinComputer/20/0/0/1/1		-> FALSE
        /// </example>
        /// <example>
        ///     GET api/IfPractice/CoinComputer/100/20/2/4/0	-> TRUE
        /// </example>
        [HttpGet(template:"CoinComputer/{Nickels}/{Dimes}/{Quarters}/{Loonies}/{Toonies}")]
        public bool CoinComputer(int Nickels, int Dimes, int Quarters, int Loonies, int Toonies)
        {
            //Declare value of Toy as well as value of coins
            decimal ToyCost = 10.50M;
            decimal NickelValue = 0.05M;
            decimal DimeValue = 0.10M;
            decimal QuarterValue = 0.25M;
            decimal LoonieValue = 1.00M;
            decimal ToonieValue = 2.00M;

            //value is the sum of (#coins * coinsvalue)
            decimal TotalAmount = Nickels * NickelValue
                + Dimes * DimeValue
                + Quarters * QuarterValue
                + Loonies * LoonieValue
                + Toonies * ToonieValue;

            //Compare amount with the Toy Cost
            if (TotalAmount >= ToyCost) return true;
            else return false;
        }

        /// <summary>
        /// Determines the quadrant of an (x,y) coordinate. Returns 0 if the point is not on any quadrant.
        /// </summary>
        /// <param name="x">The x value of the coordinate</param>
        /// <param name="y">The y value of the coordinate</param>
        /// <returns>The quadrant the coordinate belongs to. 0 if on no quadrant.</returns>
        /// <example>
        ///     GET api/IfPractice/PointQuadrant/1/1	-> 	1
        /// </example>
        /// <example>
        ///     GET api/IfPractice/PointQuadrant/-1/-1	->	3
        /// </example>
        /// <example>
        ///     GET api/IfPractice/PointQuadrant/1/-1	->	4
        /// </example>
        /// <example>
        ///     GET api/IfPractice/PointQuadrant/0/10	->	0
        /// </example>
        /// <remarks>
        /// Learn more about quadrants: For the exercise that deals with points and quadrants, see https://www.purplemath.com/modules/plane3.htm
        /// </remarks>
        [HttpGet(template:"PointQuadrant/{x}/{y}")]
        public int PointQuadrant(int x, int y)
        {
            //Value which we will return indicating the quadrant #
            int quadrant;

            //top right quadrant
            if (x > 0 && y > 0) quadrant = 1;
            //top left quadrant
            else if (x < 0 && y > 0) quadrant = 2;
            //bottom left quadrant
            else if (x < 0 && y < 0) quadrant = 3;
            //bottom right quadrant
            else if (x > 0 && y < 0) quadrant = 4;
            //point lies on either x-axis (x=0,y), y-axis (x,y=0), or both (x=0,y=0)
            else quadrant = 0;

            return quadrant;
        }

    }
}
