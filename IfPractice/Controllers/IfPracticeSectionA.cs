using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace IfPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IfPracticeSectionA : ControllerBase
    {

        /// <summary>
        /// Outputs whether the light is on or off
        /// </summary>
        /// <returns>true if the light is on, off if the light is off</returns>
        /// <example>
        /// GET: api/IfPracticeSectionA/Light -> true
        /// </example>
        [HttpGet(template:"Light")]
        public bool Light()
        {
            //NOT logical operator (!) returns the opposite of the value attached to it
            bool IsLightOff = false;
            return !IsLightOff;
        }

        /// <summary>
        /// Returns the output of an expression
        /// </summary>
        /// <returns>a boolean</returns>
        /// <example>
        /// GET api/IfPracticeSectionA/ExpressionExample -> true
        /// </example>
        [HttpGet(template:"ExpressionExample")]
        public bool ExpressionExample()
        {
            
            return 100!=99;
        }


        /// <summary>
        /// Outputs who has more squash fellows plushies
        /// </summary>
        /// <param name="AlexSquashFellows">The number of squash fellows plushies that Alex has</param>
        /// <param name = "SamSquashFellows" > The number of squash fellows plushies that Sam has</param>
        /// <returns>
        /// A sentence describing who has more plushies
        /// </returns>
        /// <example>
        /// POST api/IfPracticeSectionA/Comparison
        /// Content-Type: application/x-www-form-urlencoded
        /// POST DATA: SamSquashFellows=10&AlexSquashFellows=9 
        /// -> "Sam is the bigger fan"
        /// POST api/IfPracticeSectionA/Comparison
        /// Content-Type: application/x-www-form-urlencoded
        /// POST DATA: SamSquashFellows=5&AlexSquashFellows=20 
        /// -> "Alex is the bigger fan"
        /// 
        /// POST api/IfPracticeSectionA/Comparison
        /// Content-Type: application/x-www-form-urlencoded
        /// POST DATA: SamSquashFellows=20&AlexSquashFellows=20 
        /// -> "They are equal fans"
        /// </example>
        [HttpPost(template:"Comparison")]
        [Consumes("application/x-www-form-urlencoded")]
        public string Comparison([FromForm]int SamSquashFellows, [FromForm]int AlexSquashFellows)
        {
            //if must start an (if - else if - else chain)
            //else if must be before else in (if - else if - else chain)
            //else can only be at the end of (if - else if - else chain)

            //a variable to determine if Sam has more SquashFellows than Alex
            bool SamFavorite = SamSquashFellows > AlexSquashFellows;
            //a variable to determine if Alex has more than Sam
            bool AlexFavorite = AlexSquashFellows > SamSquashFellows;

            if (SamFavorite)
            {
                return "Sam is the bigger fan";

            } else if (AlexFavorite)
            {
                return "Alex is the bigger fan";

            }else
            {
                return "They are equal fans";
            }
        }

        /// <summary>
        /// The level based on the input score the score is between 0 and 100.
        /// A is 85 - 100 (inclusive)
        /// B is 70 - 84 (inclusive)
        /// C 55 - 69 (inclusive)
        /// D less than 54 (inclusive)
        /// </summary>
        /// <returns></returns>
        /// <example>
        /// GET API: MathTest/90 -> A
        /// GET API: MathTest/75 -> B
        /// GET API: MathTest/0 -> D
        /// GET API: MathTest/120 -> "Invalid Input"
        /// </example>
        [HttpGet(template:"MathTest/{Score}")]
        public string MathTest(int Score)
        {
            //OR logical operator || returns true if one is true

            //If the score is greater than 100 or less than 0, it is invalid
            if (Score > 100 || Score < 0)
            {

                return "Invalid Input";
            }
            

            //AND logical operator && returns true if both are true
            //Score less than 100 AND score greater than 85
            if (Score >= 85 && Score<=100)
            {
                return "A";
            }
            else if (Score >= 70 && Score <= 84)
            {
                return "B";

            }else if (Score >= 55 && Score <= 69)
            {
                return "C";
            }
            else
            {
                return "D";
            }
            

        }

        /// <summary>
        /// Receives the 1k run, vertical jump (cm), broadd jump (m), determines if the participant makes the tryouts for the track team
        /// They make the team IF
        /// less than 240sec for the run
        /// OR
        /// vertical >= 50cm AND broad jump >= 2m
        /// </summary>
        /// <returns></returns>
        /// <example>
        /// GET : api/IfPracticeSectionA/Tryouts?OneKilometerRun=200&VerticalJump=60&BroadJump=2.1 -> true
        /// GET : api/IfPracticeSectionA/Tryouts?OneKilometerRun=199&VerticalJump=20&BroadJump=0.5 -> true
        /// GET : api/IfPracticeSectionA/Tryouts?OneKilometerRun=300&VerticalJump=55&BroadJump=2.0 -> true
        /// GET : api/IfPracticeSectionA/Tryouts?OneKilometerRun=288&VerticalJump=55&BroadJump=1.9 -> false
        /// </example>
        [HttpGet(template:"Tryouts")]
        public bool Tryouts(int OneKilometerRun, int VerticalJump, decimal BroadJump)
        {
            //like console.log in JS, but for the server
            Debug.WriteLine("One K: " + OneKilometerRun);
            Debug.WriteLine("V Jump:" + VerticalJump);
            Debug.WriteLine("B Jump: " + BroadJump);

            bool GoodRunner = OneKilometerRun < 240;
            bool GoodVerticalJump = VerticalJump >= 50;
            bool GoodHorizontalJump = BroadJump >= 2;

            if( (GoodRunner || GoodVerticalJump) && GoodHorizontalJump )
            {
                return true;
            }
            else
            {
                return false;
            }

           

        }


    }
}
