using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Willprecht_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "DMV Personnel,Law Enforcement")]
        public OkObjectResult Post([FromBody] List<KeyValuePair<string, string>> value)
        {
            Dictionary<string, string> mainDict = new Dictionary<string, string>();
            Dictionary<string, string> secondDict = new Dictionary<string, string>();
            List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();
            foreach (var element in value)
            {
                if(mainDict.ContainsKey(element.Key))
                {
                    if(secondDict.ContainsKey(element.Key))
                    {
                        foreach(var second in secondDict)
                        {
                            if(second.Key == element.Key)
                            {
                                int newNum = int.Parse(second.Value) + 1;
                                secondDict[second.Key] = newNum.ToString();
                            }
                        }
                    } else
                    {
                        secondDict.Add(element.Key, "2");
                    }
                } else
                {
                    mainDict.Add(element.Key, element.Value);
                }
            }

            results.Add(mainDict);
            results.Add(secondDict);

            return Ok(results);

        }
    }
}
