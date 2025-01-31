using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IfPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IfPracticeW2025AController : ControllerBase
    {

        /// <summary>
        /// This determines if the light is on or off
        /// </summary>
        /// <returns>a boolean value</returns>
        // GET : api/IfPracticeW2025A/BoolPractice -> true
        [HttpGet(template: "BoolPractice")]
        public bool BoolPractice()
        {
            bool isLightOn = true;
            return isLightOn;
        }

        /// <summary>
        /// Receives a temperature and recommends what to wear
        /// </summary>
        /// <param name="temperature">The input temp</param>
        /// <returns>
        /// A string representing your clothing recommendation
        /// </returns>
        /// <example>
        /// GET api/IfPracticeW2025A/WhatToWear?temperature=20 -> "Wear a Tshirt!"
        /// GET api/IfPracticeW2025A/WhatToWear?temperature=0 -> "Winter Clothes Needed!"
        /// GET api/IfPracticeW2025A/WhatToWear?temperature=15 -> ?
        /// 
        /// </example>
        [HttpGet(template: "WhatToWear")]
        public string WhatToWear(int temperature)
        {
            // is the temperature greater than 0?
            // can be answered with yes (true) or no (false)

            // how could we tell if we want to wear a tshirt?
            string Message = "";

            // look at the temperature and change our recommendation
            // if it is freezing
            if (temperature <= 0)
            {
                Message = "Winter clothes needed!";
            }
            else if (temperature >= 20)
            {
                Message = "Wear a Tshirt!";
            }
            else
            {
                Message = "Wear a light jacket";
            }
           

            return Message;
        }

        /// <summary>
        /// Takes number one and adds it to number 2
        /// </summary>
        /// <param name="number1">the first number to add</param>
        /// <param name="number2">the second number to add</param>
        /// <returns>a sum of the two numbers plus 100</returns>
        /// <example>
        /// GET api/IfPracticeW2025A/Addition?number1=10&number2=20 -> 130
        /// </example>
        [HttpGet(template:"Addition")]
        public int Addition(int number1, int number2)
        {
            int Sum = (number1 + number2) + 100;
            return Sum;
        }

        /// <summary>
        /// Tells us if the light is off.
        /// </summary>
        /// <returns>a boolean indicating if the light is off.</returns>
        /// <param name="isLightOn">The status of the light</param>
        /// <example>
        /// GET: api/IfPracticeW2025A/Flip/true -> false
        /// GET: api/IfPracticeW2025A/Flip/false -> true
        /// </example>
        [HttpGet(template: "Flip/{isLightOn}")]
        public bool Flip(bool isLightOn)
        {
            // ! indicates the opposite of isLightOn
            
            return !isLightOn;
        }


        /// <summary>
        /// We will receive two pieces of information:
        /// Is the Theatre open?
        /// Is the park open?
        /// </summary>
        /// <param name="isParkOpen">If the park is open</param>
        /// <param name="isTheatreOpen">If the theatre is open</param>
        /// <returns>
        /// A sentence indicating if we have something to do based on the theatre or park availability
        /// </returns>
        /// <example>
        /// GET api/IfPracticeW2025A/WhatTodo?isTheatreOpen=true&isParkOpen=false -> "You have something to do"
        /// GET api/IfPracticeW2025A/WhatTodo?isTheatreOpen=false&isParkOpen=true -> "You have something to do"
        /// GET api/IfPracticeW2025A/WhatTodo?isTheatreOpen=true&isParkOpen=true -> "You have something to do"
        /// GET api/IfPracticeW2025A/WhatTodo?isTheatreOpen=false&isParkOpen=false -> "You don't have something to do"
        /// </example>
        [HttpGet(template:"WhatToDo")]
        public string WhatToDo(bool isTheatreOpen, bool isParkOpen)
        {
            string Message = "";
            if (isTheatreOpen || isParkOpen)
            {
                Message = "You have something to do";
            }
            else
            {
                Message = "You don't have something to do";
            }
            return Message; 
        }


        /// <summary>
        /// Determines if the party can happen based on the availability of Sam and Alex
        /// </summary>
        /// <param name="isAlexAvailable">Is Alex Available for a party</param>
        /// <param name="isSamAvailable">Is Sam Available for a party</param>
        /// <returns>A string indicating if the party can happen</returns>
        /// <example>
        /// GET api/IfPracticeW2025A/CanParty?isAlexAvailable=true&isSamAvailable=true -> "We can party!"
        /// GET api/IfPracticeW2025A/CanParty?isAlexAvailable=true&isSamAvailable=false -> "No party :("
        /// GET api/IfPracticeW2025A/CanParty?isAlexAvailable=false&isSamAvailable=true -> "No party :("
        /// /// GET api/IfPracticeW2025A/CanParty?isAlexAvailable=false&isSamAvailable=false -> "No party :("
        /// </example>
        [HttpGet(template:"CanParty")]
        public string CanParty(bool isAlexAvailable, bool isSamAvailable)
        {

            if (isSamAvailable && isAlexAvailable)
            {
                return "Can Party!";
            }
            else
            {
                return "no party :(";
            }
        }

        /// <summary>
        /// We are going to receive three pieces of information
        /// 1) how many cones we hit
        /// 2) checked the mirrors
        /// 3) can parallel park
        /// </summary>
        /// <returns>If the person passes the driving test.
        /// If the person (hits less than 5 cones or parallel parks)
        /// and (checks the mirrors) 
        /// then they pass, else, they must try again
        /// If they pass, and hit more than 20 cones, they must practice more.
        /// </returns>
        /// <param name="CheckMirrors">If the mirrors were checked</param>
        /// <param name="ConesHit">How many cones were hit</param>
        /// <param name="ParallelPark">If the parallel park was successful</param>
        /// <example>
        /// POST: api/IfPracticeW2025A/DrivingTest
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: ConesHit=20&ParallelPark=true&CheckMirrors=true -> "You passed, but more practice needed!"
        /// </example>
        /// <example>
        /// POST: api/IfPracticeW2025A/DrivingTest
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: ConesHit=10&ParallelPark=true&CheckMirrors=false -> "Try again!"
        /// </example>
        /// /// <example>
        /// POST: api/IfPracticeW2025A/DrivingTest
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: ConesHit=5&ParallelPark=false&CheckMirrors=true -> "Try again!"
        /// </example>
        [HttpPost(template:"DrivingTest")]
        [Consumes("application/x-www-form-urlencoded")]
        public string DrivingTest([FromForm]int ConesHit, [FromForm] bool ParallelPark, [FromForm] bool CheckMirrors)
        {
            string Message = "";

            // How do I know if I hit less than 5 cones OR parallel parked AND checks mirrors?

            bool isPassed = CheckMirrors && (ConesHit < 5 || ParallelPark);

            if (isPassed && ConesHit > 20)
            {
                return "You Passed, but more practice is needed!";

            } else if (isPassed) {

                return "You Passed!";
            } else
            {
                return "Try again!";
            }

        }




    }
}
