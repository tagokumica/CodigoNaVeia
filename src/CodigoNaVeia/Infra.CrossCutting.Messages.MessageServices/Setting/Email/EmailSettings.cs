﻿namespace Infra.CrossCutting.Messages.MessageServices.Setting.Email
{
    public class EmailSettings
    {
        public string PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public string UsernameEmail { get; set; }
        public string UsernamePassword { get; set; }
        public string ToEmail { get; set; }
        public string CcEmail { get; set; }
    }
}