using System;

namespace SchEstimationTestingProject.Core.Banks.Entities
{
    public class Bank
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public Bank(string name)
        {
            Name = name;
        }
    }
}
