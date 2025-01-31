using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IfPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IfPracticeW2025BController : ControllerBase
    {

        /// <summary>
        /// If the light is on or off
        /// </summary>
        /// <returns>true or false depending on whether the light is on or off</returns>
        /// <example>GET api/IfPracticeW2025B/LightSwitch -> true</example>
        [HttpGet(template:"LightSwitch")]
        public bool LightSwitch()
        {
            return true;
        }

        /// <summary>
        /// Returns the result of a math expression
        /// </summary>
        /// <returns>the result of the expression</returns>
        /// <example>
        /// GET: api/IfPracticeW2025B/Expression -> 4
        /// </example>
        [HttpGet(template: "Expression")]
        public int Expression()
        {
            return (10 - 8)*2;
        }

        /// <summary>
        /// recommends how to move the box given the box weight.
        /// </summary>
        /// <returns>gives a recommendation on how to move the box in different circumstances of the weight</returns>
        /// <param name="BoxWeight">The input weight in kg</param>
        /// <example>
        /// GET api/IfPracticeW2025B/HowToLift/40 -> "Use a forklift"
        /// GET api/IfPracticeW2025B/HowToLift/15 -> "Two people should lift this box"
        /// GET api/IfPracticeW2025B/HowToLift/9 -> "One person can lift this box"
        /// </example>
        [HttpGet(template: "HowToLift/{BoxWeight}")]
        public string HowToLift(int BoxWeight)
        {
            // the box is heavy if it is over 10kg
           
            string Message = "";

            if (BoxWeight >= 25)
            {
                Message = "Use a forklift";
            }
            else if (BoxWeight > 10) // the weight of the box is less than 25 and more than 10
            {
                Message = "Two people can lift this box";
            }
            else
            {
                Message = "One person can lift this box";
            }

            return Message;
        }

        /// <summary>
        /// We have a pet family if we have both a dog and a cat
        /// </summary>
        /// <param name="haveDog">Does the user have a dog</param>
        /// <param name="haveCat">Does the user have a cat</param>
        /// <returns>true if the user has both a dog and a cat, false otherwise</returns>
        /// <example>
        /// GET: api/IfPracticeW2025B/PetFamily?hasDog=true&hasCat=true -> true
        /// GET: api/IfPracticeW2025B/PetFamily?hasDog=false&hasCat=true -> false
        /// GET: api/IfPracticeW2025B/PetFamily?hasDog=true&hasCat=false -> false
        /// GET: api/IfPracticeW2025B/PetFamily?hasDog=true&hasCat=false -> false
        /// </example>
        [HttpGet(template:"PetFamily")]
        public bool PetFamily(bool hasDog, bool hasCat)
        {
            bool hasPetFamily = hasDog && hasCat; // LOGICAL AND
            return hasPetFamily;
        }

        /// <summary>
        /// Outputs a message indicating if we can play with our pets or not
        /// </summary>
        /// <param name="GaryAwake">True if Gary (cat) is awake</param>
        /// <param name="JuneauAwake">True if Juneau (dog) is awake</param>
        /// <returns>
        /// A message indicating if we can play with one of our pets
        /// </returns>
        /// <example>
        /// GET : api/IfPracticeW2025B/CanPlay?GaryAwake=true&JuneauAwake=true -> "We can play! :)"
        ///  GET : api/IfPracticeW2025B/CanPlay?GaryAwake=false&JuneauAwake=true -> "We can play! :)"
        ///  GET : api/IfPracticeW2025B/CanPlay?GaryAwake=false&JuneauAwake=false -> "We can't play :("
        ///   GET : api/IfPracticeW2025B/CanPlay?GaryAwake=true&JuneauAwake=false -> "We can play :)"
        /// </example>
        [HttpGet(template:"CanPlay")]
        public string CanPlay(bool GaryAwake, bool JuneauAwake)
        {
            bool JuneauAsleep = !JuneauAwake;
            bool GaryAsleep = !GaryAwake;

            //the demorgan flip and demorgan flop challenge questions are good for this!
            if (!(JuneauAsleep && GaryAsleep))
            {
                return "Can Play :)";
            }
            else //JuneauAsleep && GaryAsleep)
            {
                return "Can't Play :(";
            }
        }


        /// <summary>
        /// Represents the results of the track tryouts given the high jump, the km run and long jump
        /// </summary>
        /// <param name="HighJump">The highjump in m</param>
        /// <param name="KmRun">The time to run a km in seconds</param>
        /// <param name="LongJump">The longjump in m</param>
        /// <returns>
        /// Makes the team if the 
        /// km run is <300 seconds 
        /// and (The high jump is over 1.1m or the longjump is over 1.9m). 
        /// "Try again" otherwise
        /// if we make the team and the run is over 280, we will say "more practice needed"
        /// </returns>
        /// <example>
        /// POST: api/IfPracticeW2025B/TrackTryout
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: HighJump=1.2&KmRun=290&LongJump=1.85
        /// -> "You made the team, more practice needed"
        /// </example>
        /// <example>
        /// POST: api/IfPracticeW2025B/TrackTryout
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: HighJump=1.3&KmRun=350&LongJump=2
        /// -> "Try again!"
        /// </example>
        /// <example>
        /// POST: api/IfPracticeW2025B/TrackTryout
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: HighJump=1.2&KmRun=275&LongJump=1.85
        /// -> "You made the team!"
        /// </example>
        [HttpPost(template:"TrackTryout")]
        public string TrackTryout([FromForm]decimal HighJump, [FromForm] int KmRun, [FromForm] decimal LongJump)
        {
            string Message = "";

            bool runQualified = KmRun <= 300;
            bool jumpQualified = (LongJump > 1.9M || HighJump > 1.1M);

            bool isQualified = runQualified && jumpQualified;

            if (isQualified && KmRun > 280)
            {
                Message = "You made the team, more practice needed";
            }
            else if (isQualified) {

                Message = "You made the team!";
            }
            else
            {
                Message = "Try again";
            }
            return Message;
           
        }


    }
}
