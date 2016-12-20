using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;
using Logic;

namespace Intuition
{
    public class DatabaseManager
    {
        private static Technician _currentTech;

        public static void Initialize() {
            ParseClient.Initialize("Tw2r8qF0O99UyAVINDMqD0Yimj3QMqHSZg5fwQqt", "2eOGxh69e0BKGaS4PhtJz63BLCGQKVLe1w9cebBJ");
        }

        public static async void Test() {
            var testObject = new ParseObject("TestObject");
            testObject["foo"] = "bar";
            await testObject.SaveAsync();
        }

        public static Technician GetLoggedInTech() {
            return _currentTech;
        }


        public static bool Login(string username, string password) {
            ParseUser pUser = ParseUser.LogInAsync(username, password).Result;

            return true;
        }
    }
}
