using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.Repo;
using JooleGroupProject.Data;

namespace JooleGroupProject.Service
{
    public class UserService
    {
        UserRepository userRepository;

        public UserService()
        {
            this.userRepository = new UserRepository();
        }
    }
}
