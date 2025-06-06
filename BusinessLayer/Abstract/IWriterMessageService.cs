﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterMessageService:IGenericService<WriterMessage>
    {
        List<WriterMessage> GetListSendedMessage(string p);
        List<WriterMessage> GetListReceivedMessage(string p);
    }
}
