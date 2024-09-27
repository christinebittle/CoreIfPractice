using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IfPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IfChallengeController : ControllerBase
    {



        /// <summary>
        /// de Morgan approaches a restaurant, with a sign:
        /// "Entry Allowed IF (1) Wearing Sandals AND (2) Warm Weather OR (3) you have a Dog. Denied Otherwise."
        /// "Warm weather" means 20 degrees C or above (inclusive).
        /// </summary>
        /// <param name="Sandals">If de Morgan is wearing Sandals</param>
        /// <param name="Temperature">Temperature, in C</param>
        /// <param name="Pup">If de Morgan brought his dog</param>
        /// <returns>true if de Morgan is allowed inside the restaurant. false otherwise.</returns>
        /// <example>
        /// GET api/IfChallenge/DeMorganFlip?Sandals=false&Weather=0&Pup=false -> false
        /// GET api/IfChallenge/DeMorganFlip?Sandals=false&Weather=0&Pup=true -> true
        /// GET api/IfChallenge/DeMorganFlip?Sandals=true&Weather=0&Pup=false -> false
        /// GET api/IfChallenge/DeMorganFlip?Sandals=true&Weather=19&Pup=false -> false
        /// GET api/IfChallenge/DeMorganFlip?Sandals=true&Weather=25&Pup=false -> true
        /// </example>
        [HttpGet(template:"DeMorganFlip")]
        public bool DeMorganFlip(bool Sandals, int Temperature, bool Pup)
        {
            //todo: implement DeMorganFlip
            return true;
        }

        /// <summary>
        /// de Morgan approaches a restaurant, with a sign:
        /// "Entry Denied IF (1) NOT Wearing Sandals OR (2) Cold Weather AND (3) you forgot your dog. Allowed Otherwise."
        /// "Cold weather" means below 20C (not inclusive).
        /// </summary>
        /// <param name="Sandals">If de Morgan is wearing Sandals</param>
        /// <param name="Temperature">Temperature, in C</param>
        /// <param name="Pup">If de Morgan brought his dog</param>
        /// <returns>true if de Morgan is DENIED from the restaurant. false otherwise.</returns>
        /// <example>
        /// GET api/IfChallenge/DeMorganFlip?Sandals=false&Weather=0&Pup=false -> true
        /// GET api/IfChallenge/DeMorganFlip?Sandals=false&Weather=0&Pup=true -> false
        /// GET api/IfChallenge/DeMorganFlip?Sandals=true&Weather=0&Pup=false -> true
        /// GET api/IfChallenge/DeMorganFlip?Sandals=true&Weather=19&Pup=false -> true
        /// GET api/IfChallenge/DeMorganFlip?Sandals=true&Weather=25&Pup=false -> false
        /// </example>
        [HttpGet(template:"DeMorganFlop")]
        public bool DeMorganFlop(bool Sandals, int Temperature, bool Pup)
        {
            //todo: implement DeMorganFlop
            return true;
        }


        /// <summary>
        /// We purchase groceries on a given Day (M)onday, (T)uesday, (W)ednesday, T(H)ursday, (F)riday, (S)aturday, S(U)nday.
        /// Fruits are on sale (M)ondays and (W)ednesdays and (F)ridays for 10% off
        /// Vegetables are on sale T(H)ursdays and (F)ridays for 20% off
        /// On weekends (S)aturday and S(u)nday, there is a sale where both are 50% off
        /// </summary>
        /// <param name="Day">The day of week. One of M, T, W, H, F, S, U</param>
        /// <param name="Fruits">The number of fruits to buy at $2.50 each</param>
        /// <param name="Vegetables">The number of vegetables to buy at $2.00 each</param>
        /// <returns>
        /// The total amount of discount
        /// </returns>
        /// <example>
        /// GET api/Shopping?Day=M&Fruits=1&Vegetables=0 -> 0.25
        /// GET api/Shopping?Day=M&Fruits=0&Vegetables=1 -> 0
        /// GET api/Shopping?Day=S&Fruits=1&Vegetables=1 -> 2.25
        /// GET api/Shopping?Day=H&Fruits=0&Vegetables=5 -> 2.0
        /// GET api/Shopping?Day=F&Fruits=3&Vegetables=7 -> 3.55
        /// </example>
        [HttpGet(template:"Shopping")]
        public decimal Shopping(char Day, int Fruits, int Vegetables)
        {
            //todo: implement shopping
            return 0;
        }


        /// <summary>
        /// A knight piece sits alone on square F4, and wants to move. A knight can move two ways:
        /// 1) two squares left OR right AND one square up OR down
        /// 2) one square left OR right AND two squares up OR down
        /// </summary>
        /// <param name="Row">The desired row. One of (a,b,c,d,e,f,g,h)</param>
        /// <param name="Col">The desired column. One of (1,2,3,4,5,6,7,8)</param>
        /// <returns>
        /// true if the knight can move to the square in one move, false otherwise.
        /// </returns>
        /// <example>
        /// GET api/LonelyKnight/H/3 -> true
        /// GET api/LonelyKnight/H/6 -> false
        /// GET api/LonelyKnight/F/4 -> false
        /// GET api/LonelyKnight/D/3 -> true
        /// GET api/LonelyKnight/A/1 -> false
        /// GET api/LonelyKnight/G/6 -> true
        /// </example>
        [HttpGet(template:"LonelyKnight/{Row}/{Col}")]
        public bool LonelyKnight(char Row, int Col)
        {
            // todo: implement LonelyKnight
            return true;
            
        }

        // extra challenge:
        // extend Lonely Knight to take 2 arguments, of the form
        // api/LonelyKnight/{StartPos}/{EndPos}
        // assume {StartPos} and {EndPos} are valid algebraic chess moves as a string i.e. one of ("A1",..,"H8")
        // determine if the Lonely Knight can move to that square in one move.

        

    }
}
