using System;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Models;

namespace PancakeProwler.BookCreator
{
    internal interface IMailSender
    {
        void SendCreationEMail(BookCreationRequest request);
    }
}
