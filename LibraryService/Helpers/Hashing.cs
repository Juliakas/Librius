using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Helpers
{
    class Hashing
    {
        public String GenerateHash(String password)
        {
            password = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());

            return password;
        }

        public bool Verify(String password, String hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

    }
}
