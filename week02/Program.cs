using System;
public class person
    {
        private string _title;
        private string _firstname;
        private string _lastname;

        public string GetInformalSignature()
        {
            return "thanks," + _firstname;
        }
    }

