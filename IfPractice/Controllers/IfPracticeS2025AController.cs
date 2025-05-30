using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace IfPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IfPracticeS2025AController : ControllerBase
    {

        /// <summary>
        /// The output expression is the number of good apples we have remaining
        /// </summary>
        /// <returns>
        /// This method will produce the numerical output of two numbers used in an expression. 
        /// </returns>
        /// <example>
        /// GET api/IfPracticeS2025A/Expression -> 7
        /// </example>
        [HttpGet]
        [Route(template:"Expression")]
        public int Expression()
        {
            // expression: a sequence of operators and operands that can be reduced to a single value
            int BadApples = 3+1;
            int Apples = 10 - (BadApples);
            return Apples;
        }

        /// <summary>
        /// This endpoint receives the temperature and decides if the door should be open or closed
        /// </summary>
        /// <returns>
        /// true if the door is open, false if the door is closed
        /// </returns>
        /// <param name="temp">the input temp in C</param>
        /// <example>
        /// GET api/IfPracticeS2025A/Door?temp=15 -> true
        /// </example>
        /// /// <example>
        /// GET api/IfPracticeS2025A/Door?temp=5 -> false
        /// </example>
        [HttpGet]
        [Route(template:"Door")]
        public bool Door(int temp)
        {
            // bool: is either true or false, must be one of them
            // expression: can be reduced to a single value
            // logical expression: that single value is true or false
            // aka. A question that can be answered with yes or no
            bool IsDoorOpen = temp > 10;
            return IsDoorOpen;
        }

        /// <summary>
        /// Determine if it is time to plant crops based on soil tilled and equipment ready
        /// </summary>
        /// <returns>
        /// Receives the conditions of our farm, decides if we are ready to plant or not
        /// </returns>
        /// <example>
        /// GET api/IfPracticeS2025A/Planting?IsSoilTilled=false&IsEquipmentReady=false -> false
        /// </example>
        /// <example>
        /// GET api/IfPracticeS2025A/Planting?IsSoilTilled=false&IsEquipmentReady=true -> false
        /// </example>
        /// <example>
        /// GET api/IfPracticeS2025A/Planting?IsSoilTilled=true&IsEquipmentReady=false -> false
        /// </example>
        /// <example>
        /// GET api/IfPracticeS2025A/Planting?IsSoilTilled=true&IsEquipmentReady=true -> true
        /// </example>
        [HttpGet]
        [Route(template:"Planting")]
        public bool Planting(bool IsSoilTilled, bool IsEquipmentReady)
        {
            bool ReadyToPlant = IsSoilTilled && IsEquipmentReady;

            return ReadyToPlant;
        }


        /// <summary>
        /// If we can have dinner ready for today
        /// </summary>
        /// <param name="HaveEggs">We have eggs in the farm</param>
        /// <param name="HaveVeggies">We have veggies</param>
        /// <returns>If we have eggs or we have veggies, we can eat dinner</returns>
        /// <example>
        /// GET api/IfPractice2025A/Dinner/true/false -> true
        /// </example>
        /// <example>
        /// GET api/IfPractice2025A/Dinner/false/true -> true
        /// </example>
        /// <example>
        /// GET api/IfPractice2025A/Dinner/true/true -> true
        /// </example>
        /// <example>
        /// GET api/IfPractice2025A/Dinner/false/false -> false
        /// </example>
        [HttpGet]
        [Route(template: "Dinner/{HaveEggs}/{HaveVeggies}")]
        public bool Dinner(bool HaveEggs, bool HaveVeggies)
        {
            bool DinnerReady = HaveEggs || HaveVeggies;

            return DinnerReady;
        }


        /// <summary>
        /// receives an input bool and flips the boolean value
        /// </summary>
        /// <param name="input">a boolean input</param>
        /// <returns>
        /// the negation of the boolean
        /// </returns>
        /// <example>
        /// GET api/S2025A/Negation?input=true -> false
        /// </example>
        /// <example>
        /// GET api/S2025A/Negation?input=false -> true
        /// </example>
        [HttpGet]
        [Route(template: "Negation")]
        public bool Negation(bool input)
        {
            // logical negation operator ! takes 1 operand
            return !input;
        }


        /// <summary>
        /// Outputs a different message depending on the farm season
        /// </summary>
        /// <param name="Cows">The number of cows we gained this year</param>
        /// <param name="Eggs">The total eggs we have this year</param>
        /// <param name="CropYield">The percentage of crop yield this year</param>
        /// <returns>
        /// The farm season is good if the crop yield is above 80%, or we have both > 2000 eggs and > 5 cows
        /// 
        /// The farm season is okay if the crop yield is above 70 or we have 1000 eggs and > 0 cows
        /// 
        /// The farm season is bad otherwise
        /// </returns>
        /// <example>
        /// POST api/IfPracticeS2025A/FarmSeason
        /// HEADERS: Content-Type: application/x-www-form-urlencoded
        /// DATA: Eggs=2200&Cows=3&CropYield=70
        /// -> "The farm season is good"
        /// </example>
        /// <example>
        /// POST api/IfPracticeS2025A/FarmSeason
        /// HEADERS: Content-Type: application/x-www-form-urlencoded
        /// DATA: Eggs=1900&Cows=0&CropYield=90
        /// -> "The farm season is good"
        /// </example>
        /// <example>
        /// POST api/IfPracticeS2025A/FarmSeason
        /// HEADERS: Content-Type: application/x-www-form-urlencoded
        /// DATA: Eggs=1800&Cows=-1&CropYield=65
        /// -> "The farm season is bad"
        /// </example>
        /// /// <example>
        /// POST api/IfPracticeS2025A/FarmSeason
        /// HEADERS: Content-Type: application/x-www-form-urlencoded
        /// DATA: Eggs=2001&Cows=5&CropYield=65.4
        /// -> "The farm season is good"
        /// </example>
        [HttpPost]
        [Route(template: "FarmSeason")]
        public string FarmSeason([FromForm]int Eggs, [FromForm] int Cows, [FromForm] decimal CropYield)
        {
            //string message = $"Eggs {Eggs} Cows {Cows} CropYield {CropYield}";
            
            string message = "";

            // If eggs > 2k and cows >= 5 or cropyield above 80
            if (((Eggs > 2000) && (Cows >= 5)) || CropYield > 80M)
            {
                message = "Season is good";
            } // if eggs greater than 1k and cow >0 or cropyield above 70
            else if (((Eggs > 1000) && (Cows > 0)) || CropYield > 70M)
            {
                message = "Season is okay";
            }
            else // poor season otherwise
            {
                message = "Season is bad";
            }
        
            return message;

            
        }

    }
}
