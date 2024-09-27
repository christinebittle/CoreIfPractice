using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace IfPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IfStatementSectionB : ControllerBase
    {


        [HttpGet(template:"BoolPractice")]
        public bool BoolPractice()
        {
            //Bool Expression 1>0 true
            //Bool Expression 0<500 true
            //Bool Expression 0==0 true
            //Bool Expression 0==1 false
            return 1 <0;
        }

        /// <summary>
        /// Two students (Sam) and (Alex) and we will receive the height of both students in cm. Output which student is taller
        /// </summary>
        /// <param name="AlexHeight">Alex height in cm</param>
        /// <param name="SamHeight">Sam height in cm</param>
        /// <returns>Returns who is taller</returns>
        /// <example>
        /// POST: api/IfStatementSectionB/Height
        /// Header: Content-Type: application/x-www-formurlencoded
        /// POST DATA: SamHeight=175&AlexHeight=170
        /// -> Sam is taller
        /// POST: api/IfStatementSectionB/Height
        /// Header: Content-Type: application/x-www-formurlencoded
        /// POST DATA: SamHeight=158&AlexHeight=177 
        /// -> Alex is taller
        /// POST: api/IfStatementSectionB/Height
        /// Header: Content-Type: application/x-www-formurlencoded
        /// POST DATA: SamHeight=165&AlexHeight=165 
        /// -> They have the same height
        /// </example>
        [HttpPost(template:"Height")]
        [Consumes("application/x-www-form-urlencoded")]
        public string Height([FromForm]int SamHeight, [FromForm]int AlexHeight)
        {
            // if statement always goes first before else if - else
            // else if statements always go before else statements
            // else statements always are last
            // You can only have one if statement in a if - else if - else chain
            // You can only have one else statement in an if - else if - else chain

            //This checks if Sam is taller than Alex
            if (AlexHeight > SamHeight)
            {
                return "Alex is taller than Sam ";

            } else if (SamHeight > AlexHeight)
            {
                return "Sam is taller than Alex";

            } else
            {
                return "They are the same height";
            }
        }

        /// <summary>
        /// Determine the season based off the temperature. 
        /// Winter if the temp is less than or equal 5c
        /// Fall if the temp is 6 to 15c (inclusive)
        /// Spring if the temp is 16 to 20c (inclusive)
        /// Summer if the temp is above 20c (exclusive)
        /// </summary>
        /// <param name="Temperature">input in C</param>
        /// <returns>The estimated season given the temp</returns>
        /// <example>
        /// GET api/GetSeason/16 -> "Fall"
        /// GET api/GetSeason/20 -> "Spring"
        /// GET api/GetSeason/21 -> "Summer"
        /// GET api/GetSeason/1 -> "Winter"
        /// </example>
        [HttpGet(template:"GetSeason/{Temperature}")]
        public string GetSeason(int Temperature)
        {
            if (Temperature <= 5)
            {
                return "Winter";

            } else if (Temperature >= 6 && Temperature<=15)
            {
                //AND is a logical operator that evaluates to true when both sides evaluate to true
                return "Fall";
            }
            else if (Temperature >= 16 && Temperature <=20)
            {
                return "Spring";
            }
            else
            {

                return "Summer";
            }

        }


        /// <summary>
        /// Gary is happy If he has a toy or has food
        /// </summary>
        /// <returns>
        /// :) if Gary is happy, :( if Gary is sad
        /// </returns>
        /// <example>
        /// GET api/GaryHappy?HasToy=false&HasFood=false -> :(
        /// GET api/GaryHappy?HasToy=true&HasFood=false -> :)
        /// GET api/GaryHappy?HasToy=false&HasFood=true -> :)
        /// GET api/GaryHappy?HasToy=true&HasFood=true -> :)
        /// </example>
        [HttpGet(template:"GaryHappy")]
        public string GaryHappy(bool HasToy, bool HasFood)
        {
            // The OR logical operator evaluates to true if ONE side evaluates to true
            bool IsGaryHappy = HasToy || HasFood;
            
            if (IsGaryHappy)
            {
                return ":)";
            }
            else
            {
                return ":(";
            }
        }

        /// <summary>
        /// Passes the test if
        /// Hit less than 4 pylons OR parallel parked
        /// AND
        /// >= 80 on the written test
        /// </summary>
        /// <param name="PylonsHit">Number of pylons hit</param>
        /// <param name="Parallel">Can parallel park</param>
        /// <param name="WrittenTest">The written test value from 0 to 100</param>
        /// <returns>if the student passed the driving test</returns>
        /// <example>
        /// GET api/DrivingTest?PylonsHit=10&ParallelFail=true&WrittenTest=50 -> false
        /// GET api/DrivingTest?PylonsHit=1&ParallelFail=false&WrittenTest=95 -> true
        /// GET api/DrivingTest?PylonsHit=7&ParallelFail=false&WrittenTest=80 -> true
        /// GET api/DrivingTest?PylonsHit=7&ParallelFail=false&WrittenTest=79 -> false
        /// </example>
        [HttpGet(template:"DrivingTest")]
        public bool DrivingTest(int PylonsHit, bool ParallelFail, int WrittenTest)
        {
            //analagous to console.log() for the server
            Debug.WriteLine("Pylons Hit "+PylonsHit.ToString());
            Debug.WriteLine("Parallel " + ParallelFail.ToString());
            Debug.WriteLine("Written Test " + WrittenTest.ToString());

            bool PylonPass = PylonsHit < 4;
            bool ParallelPass = !ParallelFail;
            bool WrittenPass = WrittenTest >= 80;

            if (PylonPass || (ParallelPass && WrittenPass))
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
