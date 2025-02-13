﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class DjangoAdminLog
    {
        public long Id { get; set; }
        public byte[] ActionTime { get; set; }
        public string ObjectId { get; set; }
        public string ObjectRepr { get; set; }
        public string ChangeMessage { get; set; }
        public long? ContentTypeId { get; set; }
        public long UserId { get; set; }
        public long ActionFlag { get; set; }

        public virtual DjangoContentType ContentType { get; set; }
        public virtual AuthUser User { get; set; }
    }
}
