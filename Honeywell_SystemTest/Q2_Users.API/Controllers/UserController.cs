using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Users.Model;
using Users.Repository;

namespace Users.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userList = await userRepository.GetUsers();
            return Ok(userList);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                await userRepository.InsertUser(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{path}")]
        public async Task<IActionResult> GetBulkUserList(string path)
        {
            List<User> userList = new List<User>();
            var fileName = @"E:\Altruista\Attended\Excel_API\Data\Users.Xslx";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using(var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        userList.Add(new User
                        {
                            FirstName = reader.GetValue(0).ToString(),
                            LastName = reader.GetValue(1).ToString(),
                            Email = reader.GetValue(2).ToString(),
                            UserName = reader.GetValue(3).ToString(),
                            Address = reader.GetValue(4).ToString(),
                            Age = int.Parse(reader.GetValue(5).ToString())
                        });
                    }
                }
            }
            await userRepository.InsertUserList(userList);
            return Ok(userList);
        }
    }
}
