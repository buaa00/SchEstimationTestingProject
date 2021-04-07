using System;
using SchEstimationTestingProject.Core.Common.Exceptions;

namespace SchEstimationTestingProject.Core.Users.Exceptions
{
    public class UserAlreadyExistsException : SchEstimationTestingProjectException
    {
        public UserAlreadyExistsException()
        {
            
        }

        public UserAlreadyExistsException(string jmbg) : base($"User with JMBG: {jmbg} already exists!")
        {
            
        }
    }
}
